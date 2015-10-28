namespace Service
{
    using System;
    using System.Collections.Generic;
    using IRepository;
    using POCO;

    public class AdminService
    {
        private readonly IAdminRepository repository;

        public AdminService(IAdminRepository repository)
        {
            this.repository = repository;
        }

        public void InsertAdmin(Admin admin, ref List<string> errors)
        {
            if (admin == null)
            {
                errors.Add("Instructor cannot be null");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(admin.FirstName))
            {
                errors.Add("Admin requires a first name.");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(admin.LastName))
            {
                errors.Add("Admin requires a last name.");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(admin.Email))
            {
                errors.Add("Admin requires an email.");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(admin.Password))
            {
                errors.Add("Admin requires a password.");
                throw new ArgumentException();
            }

            this.repository.InsertAdmin(admin, ref errors);
        }

        public void UpdateAdmin(Admin admin, ref List<string> errors)
        {
            if (admin == null)
            {
                errors.Add("Instructor cannot be null");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(admin.FirstName))
            {
                errors.Add("Admin requires a first name.");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(admin.LastName))
            {
                errors.Add("Admin requires a last name.");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(admin.Email))
            {
                errors.Add("Admin requires an email.");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(admin.Password))
            {
                errors.Add("Admin requires a password.");
                throw new ArgumentException();
            }

            this.repository.UpdateAdmin(admin, ref errors);
        }

        public void DeleteAdmin(String id, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(id))
            {
                errors.Add("Invalid admin id.");
                throw new ArgumentException();
            }

            this.repository.DeleteAdmin(id, ref errors);
        }

        public Admin GetAdmin(int id, ref List<string> errors)
        {
            return this.repository.GetAdmin(id, ref errors);
        }
    }
}
