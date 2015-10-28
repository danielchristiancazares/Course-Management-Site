namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using Repository;
    using Service;

    public class AdminController : ApiController
    {
        [HttpGet]
        public Admin GetAdminInfo(int adminId)
        {
            //// 136 TODO: get the admin info 
            //// for now, returning the hard-coded value
            var errors = new List<string>();
            var repository = new AdminRepository();
            var service = new AdminService(repository);
            return service.GetAdmin(adminId, ref errors);
            
        }

        [HttpPost]
        public string UpdateStudent(Admin admin)
        {
            var errors = new List<string>();
            var repository = new AdminRepository();
            var service = new AdminService(repository);
            service.UpdateAdmin(admin, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string InsertAdmin(Admin admin)
        {
            var errors = new List<string>();
            var repository = new AdminRepository();
            var service = new AdminService(repository);
            service.InsertAdmin(admin, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string DeleteStudent(string id)
        {
            var errors = new List<string>();
            var repository = new AdminRepository();
            var service = new AdminService(repository);
            service.DeleteAdmin(id, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }
    }
}