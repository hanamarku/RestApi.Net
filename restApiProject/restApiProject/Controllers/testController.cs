using ClassLibraryModels;
using Microsoft.AspNetCore.Mvc;

namespace restApiProject.Controllers
{
    public class testController : Controller
    {
        private static List<Project> project = new List<Project>{
            new Project(),
            new Project
            {
                Id = 1,
                Name = "hana"
            }
            };

        [HttpGet("Gettest")]

        public ActionResult<List<Project>> Gettest()
        {
            return Ok(project);
        }

        [HttpGet("{id}")]
        public ActionResult<List<Project>> GetSingle(int id)
        {
            return Ok(project.FirstOrDefault(c => c.Id == id));
        }
    }
}
