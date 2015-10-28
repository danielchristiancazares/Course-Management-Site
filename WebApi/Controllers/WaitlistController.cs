namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using Repository;
    using Service;

    public class WaitlistController : ApiController
    {
        [HttpGet]
        public List<Waitlist> GetWaitList()
        {
            var errors = new List<string>();
            var repository = new WaitlistRepository();
            var service = new WaitlistService(repository);
            return service.GetWaitlist(ref errors);
        }

        [HttpPost]
        public string InsertWaitlist(Waitlist waitlist)
        {
            var errors = new List<string>();
            var repository = new WaitlistRepository();
            var service = new WaitlistService(repository);

            service.InsertWaitlist(null, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }
            
            return "error";
        }

        [HttpPost]
        public string UpdateStudent(Waitlist waitlist)
        {
            var errors = new List<string>();
            var repository = new WaitlistRepository();
            var service = new WaitlistService(repository);

            service.UpdateWaitlist(waitlist, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string DeleteTA(Waitlist waitlist)
        {
            var errors = new List<string>();
            var repository = new WaitlistRepository();
            var service = new WaitlistService(repository);

            service.DeleteWaitlist(waitlist, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }
    }
}