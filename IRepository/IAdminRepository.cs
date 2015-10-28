namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IAdminRepository
    {
        void InsertAdmin(Admin admin, ref List<string> errors);

        void DeleteAdmin(string id, ref List<string> errors);

        void UpdateAdmin(Admin admin, ref List<string> errors);

        Admin GetAdmin(int id, ref List<string> errors);
    }
}
