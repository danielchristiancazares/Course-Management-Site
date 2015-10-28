namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class TARepository : BaseRepository, ITARepository
    {
        private const string InsertTAProcedure = "spInsertSchedule_TA";
        private const string UpdateTAProcedure = "spUpdateSchedule_TA";
        private const string DeleteTAProcedure = "spGetSchedule_TA";
        private const string GetTAProcedure = "spGetSchedule_TA";

        public void InsertTA(TA ta, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertTAProcedure, conn)
                                  {
                                      SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                                  };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@ta_id", SqlDbType.VarChar, 25));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@ta_id"].Value = ta.TA_Id;
                adapter.SelectCommand.Parameters["@schedule_id"].Value = ta.Schedule_Id;
          
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

        public void UpdateTA(TA ta, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateTAProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@ta_id", SqlDbType.VarChar, 25));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@ta_id"].Value = ta.TA_Id;
                adapter.SelectCommand.Parameters["@schedule_id"].Value = ta.Schedule_Id;

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

        public void DeleteTA(TA ta, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(DeleteTAProcedure, conn)
                                  {
                                      SelectCommand =
                                          {
                                              CommandType =
                                                  CommandType
                                                  .StoredProcedure
                                          }
                                  };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@ta_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@ta_id"].Value = ta.TA_Id_int;
                adapter.SelectCommand.Parameters["@schedule_id"].Value = ta.Schedule_Id;

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

        public List<TA> GetTAList(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var ta_List = new List<TA>();

            try
            {
                var adapter = new SqlDataAdapter(GetTAProcedure, conn)
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
                    var talist = new TA
                                      {
                                          Schedule_Id = dataSet.Tables[0].Rows[i]["schdule_id"].ToString(),
                                          TA_Id = dataSet.Tables[0].Rows[i]["TA_id"].ToString()
                                      };
                    ta_List.Add(talist);
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

            return ta_List;
        }
    }
}
