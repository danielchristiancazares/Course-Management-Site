namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using Repository;
    using Service;

    public class InstructorController : ApiController
    {
        [HttpGet]
        public Instructor GetInstructorInfo(string id)
        {
            var errors = new List<string>();
            var repository = new InstructorRepository();
            var service = new InstructorService(repository);
            return service.GetInstructorInfo(id, ref errors);
        }

        [HttpPost]
        public string InsertInstructor(Instructor instructor)
        {
            var errors = new List<string>();
            var repository = new InstructorRepository();
            var service = new InstructorService(repository);
            service.InsertInstructor(instructor, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string DeleteInstructor(string id)
        {
            var errors = new List<string>();
            var repository = new InstructorRepository();
            var service = new InstructorService(repository);
            service.DeleteInstructor(id, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }
    }
}