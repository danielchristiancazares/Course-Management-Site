namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class AdminRepository : BaseRepository, IAdminRepository
    {
        private const string InsertAdminProcedure = "insertAdmin";
        private const string DeleteAdminProcedure = "deleteAdmin";
        private const string GetAdminProcedure = "getAdmin";
        private const string UpdateAdminProcedure = "updateAdmin";

        public void InsertAdmin(Admin admin, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertAdminProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@admin_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar, 50));

                adapter.SelectCommand.Parameters["@admin_id"].Value = admin.Id;
                adapter.SelectCommand.Parameters["@email"].Value = admin.Email;
                adapter.SelectCommand.Parameters["@password"].Value = admin.Password;
                adapter.SelectCommand.Parameters["@first_name"].Value = admin.FirstName;
                adapter.SelectCommand.Parameters["@last_name"].Value = admin.LastName;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }

        public void DeleteAdmin(String id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(DeleteAdminProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@admin_id", SqlDbType.VarChar, 20));

                adapter.SelectCommand.Parameters["@admin_id"].Value = id;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }

        public Admin GetAdmin(int id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            Admin admin = null;
            try
            {
                var adapter = new SqlDataAdapter(GetAdminProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@admin_id", SqlDbType.VarChar, 20));

                adapter.SelectCommand.Parameters["@admin_id"].Value = id;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                admin = new Admin
                {
                    Id = Convert.ToInt32(dataSet.Tables[0].Rows[0]["admin_id"].ToString()),
                    FirstName = dataSet.Tables[0].Rows[0]["first_name"].ToString(),
                    LastName = dataSet.Tables[0].Rows[0]["last_name"].ToString(),
                    Email = dataSet.Tables[0].Rows[0]["email"].ToString(),
                    Password = dataSet.Tables[0].Rows[0]["password"].ToString()
                };
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return admin;
        }

        public void UpdateAdmin(Admin admin, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateAdminProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@admin_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 64));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 64));

                adapter.SelectCommand.Parameters["@admin_id"].Value = admin.Id;
                adapter.SelectCommand.Parameters["@first_name"].Value = admin.FirstName;
                adapter.SelectCommand.Parameters["@last_name"].Value = admin.LastName;
                adapter.SelectCommand.Parameters["@email"].Value = admin.Email;
                adapter.SelectCommand.Parameters["@password"].Value = admin.Password;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }
    }
}
