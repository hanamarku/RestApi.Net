
using ClassLibraryModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using restApiProject.Data.BaseRepository;
using restApiProject.Data.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace restApiProject.Data.Repositories
{
    public class AuthRepository : EntityBaseRepository<User>, IAuthRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AuthRepository(AppDbContext context, IConfiguration configuration, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _context = context;
            _configuration = configuration;
            this.webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(username.ToLower()));

            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found";
            }

            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong Password !";
            }
            else
            {
                response.Data = CreateToken(user);
            }
            return response;
        }


        public async Task<ServiceResponse<int>> Register(User employee, string password)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();


            if (await UserExists(employee.Username))
            {
                response.Success = false;
                response.Message = "User already exist !";
                return response;
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            employee.PasswordHash = passwordHash;
            employee.PasswordSalt = passwordSalt;
            _context.Users.Add(employee);
            await _context.SaveChangesAsync();

            response.Data = employee.Id;
            return response;
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(5),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<ServiceResponse<string>> UpdateUserAsync(int userId, RegisterVM data)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                var employee = await _context.Users.FirstOrDefaultAsync(c => c.Id == userId);
                if (employee != null)
                {
                    string uniqueFileName = UploadedFile(data.ProfileImage);
                    employee.Name = data.Name;
                    employee.Lastname = data.LastName;
                    employee.Username = data.Username;
                    employee.EmailAddress = data.EmailAddress;
                    employee.Username = data.Username;
                    employee.ImageUrl = uniqueFileName;
                    CreatePasswordHash(data.Password, out byte[] passwordHash, out byte[] passwordSalt);
                    employee.PasswordHash = passwordHash;
                    employee.PasswordSalt = passwordSalt;

                    await _context.SaveChangesAsync();
                }



                response.Success = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;

        }

        [HttpDelete("RemoveUser")]

        public async Task<ServiceResponse<string>> DeleteUser(int id)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                var employee = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
                if (employee != null)
                {
                    _context.Users.Remove(employee);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public User GetUser(LoginVM loginVM)
        {
            User user = _context.Users.FirstOrDefault(u => u.Username.Equals
            (loginVM.Username, StringComparison.OrdinalIgnoreCase)
            && VerifyPasswordHash(loginVM.Password, u.PasswordHash, u.PasswordSalt));

            return user;
        }


        public string UploadedFile([FromForm] IFormFile ProfileImage)
        {
            string uniqueFileName = null;

            if (ProfileImage != null)
            {
                //var appDataPath = Server.MapPath("~/App_Data/");
                webHostEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "images");
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

    }
}