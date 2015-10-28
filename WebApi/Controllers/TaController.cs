namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using Repository;
    using Service;

    public class TaController : ApiController
    {
        [HttpGet]
        public List<TA> GetTAList()
        {
            var errors = new List<string>();
            var repository = new TARepository();
            var service = new TaService(repository);
            return service.GetTAList(ref errors);
        }

        [HttpPost]
        public string InsertTa(TA ta)
        {
            var errors = new List<string>();
            var repository = new TARepository();
            var service = new TaService(repository);

            service.InsertTA(null, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }
            
            return "error";
        }

        [HttpPost]
        public string UpdateStudent(TA ta)
        {
            var errors = new List<string>();
            var repository = new TARepository();
            var service = new TaService(repository);

            service.UpdateTA(ta, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string DeleteTA(TA ta)
        {
            var errors = new List<string>();
            var repository = new TARepository();
            var service = new TaService(repository);

            service.DeleteTA(ta, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }
    }
}