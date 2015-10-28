namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class InstructorRepository : BaseRepository, IInstructorRepository
    {
        private const string InsertInstructorProcedure = "insertInstructor";
        private const string DeleteInstructorProcedure = "deleteInstructor";
        private const string GetInstructorInfoProcedure = "getInstructorInfo";

        public void InsertInstructor(Instructor instructor, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertInstructorProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@instructor_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@title", SqlDbType.VarChar, 50));
                
                adapter.SelectCommand.Parameters["@instructor_id"].Value = instructor.InstructorId;
                adapter.SelectCommand.Parameters["@first_name"].Value = instructor.FirstName;
                adapter.SelectCommand.Parameters["@last_name"].Value = instructor.LastName;
                adapter.SelectCommand.Parameters["@title"].Value = instructor.Title;

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

        public void DeleteInstructor(String id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(DeleteInstructorProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@instructor_id", SqlDbType.VarChar, 20));

                adapter.SelectCommand.Parameters["@instructor_id"].Value = id;

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

        public Instructor GetInstructorInfo(string id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            Instructor instructor = null;
            try
            {
                var adapter = new SqlDataAdapter(GetInstructorInfoProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@instructor_id", SqlDbType.VarChar, 20));

                adapter.SelectCommand.Parameters["@instructor_id"].Value = id;
                
                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                instructor = new Instructor
                {
                    InstructorId = dataSet.Tables[0].Rows[0]["instructor_id"].ToString(),
                    FirstName = dataSet.Tables[0].Rows[0]["first_name"].ToString(),
                    LastName = dataSet.Tables[0].Rows[0]["last_name"].ToString(),
                    Title = dataSet.Tables[0].Rows[0]["title"].ToString()
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

            return instructor;
        }
    }
}
