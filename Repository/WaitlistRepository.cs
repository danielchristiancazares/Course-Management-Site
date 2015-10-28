namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class WaitlistRepository : BaseRepository, IWaitlistRepository
    {
        private const string InsertWaitlistProcedure = "spInsertWaitlist";
        private const string UpdateWaitlistProcedure = "spUpdateWaitlist";
        private const string DeleteWaitlistProcedure = "spDeleteWaitlist";
        private const string GetWaitlistProcedure = "spGetStudentList";

        public void InsertWaitlist(Waitlist waitlist, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertWaitlistProcedure, conn)
                                  {
                                      SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                                  };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 25));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));
                
                adapter.SelectCommand.Parameters["@student_id"].Value = waitlist.StudentId;
                adapter.SelectCommand.Parameters["@schedule_id"].Value = waitlist.ScheduleId;

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

        public void UpdateWaitlist(Waitlist waitlist, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateWaitlistProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 25));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@student_id"].Value = waitlist.StudentId;
                adapter.SelectCommand.Parameters["@schedule_id"].Value = waitlist.ScheduleId;

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

        public void DeleteWaitlist(Waitlist waitlist, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(DeleteWaitlistProcedure, conn)
                                  {
                                      SelectCommand =
                                          {
                                              CommandType =
                                                  CommandType
                                                  .StoredProcedure
                                          }
                                  };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 25));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@student_id"].Value = waitlist.StudentId;
                adapter.SelectCommand.Parameters["@schedule_id"].Value = waitlist.ScheduleId;

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

        public List<Waitlist> GetWaitlist(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var waitList = new List<Waitlist>();

            try
            {
                var adapter = new SqlDataAdapter(GetWaitlistProcedure, conn)
                                  {
                                      SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                                  };

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var waitlist = new Waitlist
                                      {
                                          StudentId = dataSet.Tables[0].Rows[i]["student_id"].ToString(),
                                          ScheduleId = dataSet.Tables[0].Rows[i]["schdule_id"].ToString(),
                                          Waitlist_Id = dataSet.Tables[0].Rows[i]["Waitlist_id"].ToString()
                                      };
                    waitList.Add(waitlist);
                }
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return waitList;
        }
    }
}
