﻿using ClassLibraryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using System.Security.Claims;

namespace restApiProject.Data.BaseRepository
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EntityBaseRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public int GetUserId()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            return Int32.Parse(result);
        }
        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();
        }


        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);


        public async Task<ServiceResponse<string>> AddAsync(T entity)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;

        }

        public async Task<ServiceResponse<string>> UpdateAsync(int id, T entity)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                EntityEntry entityEntry = _context.Entry<T>(entity);
                entityEntry.State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<string>> DeleteAsync(int id)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
                EntityEntry entityEntry = _context.Entry<T>(entity);
                entityEntry.State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;

        }
    }
}
