//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Data.SqlTypes;
//using System.Data.SqlClient;
//using System.Data.Entity;
//using Microsoft.SqlServer.Server;
//using System.Data;

//namespace ChoreApplication
//{
//    public class DataAccess
//    {
//        public DataAccess(string connectionString)
//        {
//            ConnectionString = connectionString;
//        }

//        public int ChoreId { get; set; }
//        public string ChoreName { get; set; }
//        public string ChoreAssignment { get; set; }
//        public string ConnectionString { get; }
//    }

//    public class myDataCollection : List<DataAccess>, IEnumerable<SqlDataRecord>
//    {
//        private string connectionString;

//        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
//        {
//            SqlDataRecord ret = new SqlDataRecord(
//                new SqlMetaData("ChoreId", SqlDbType.Int),
//                new SqlMetaData("ChoreName", SqlDbType.NVarChar, byte.MaxValue),
//                new SqlMetaData("ChoreAssignment", SqlDbType.VarChar, byte.MaxValue)
//                ); 

//            foreach (myData data in this)
//            {
//                ret.SetInt32(0, data.ChoreId);
//                ret.SetString(1, data.ChoreName);
//                ret.SetString(1, data.ChoreName);
//                yield return ret;
//            }


//            myDataCollection myTable = new myDataCollection();
//            myTable.Add(new myData { ChoreId = 4, ChoreName = "Dishes", ChoreAssignment = "Zoey"});
//            myTable.Add(new myData { ChoreId = 5, ChoreName = "Dust", ChoreAssignment = "Jaxon" });
//            myTable.Add(new myData { ChoreId = 6, ChoreName = "Vacuum", ChoreAssignment = "Joe"});

//            SqlConnection connection = new SqlConnection();
//            connection.Open();
//            SqlCommand cmd = new SqlCommand("InsertValue", connection);
//            cmd.CommandType = CommandType.StoredProcedure;

//            //Pass table Valued parameter to Store Procedure
//            SqlParameter sqlParam = cmd.Parameters.AddWithValue("@TempTable", myTable);
//            sqlParam.SqlDbType = SqlDbType.Structured;
//            cmd.ExecuteNonQuery();
//            connection.Close();
//            Console.Write("Data Save Successfully.");
//        }
//        public List<string> GetChores()
//        {
//            {
//                var chores = new List<string>();

//                using (SqlConnection connection = new SqlConnection(connectionString))
//                {
//                    connection.Open();
//                    var sql = "SELECT ChoreName, ChoreAssignment FROM Chores;";

//                    using (SqlCommand command = new SqlCommand(sql, connection))
//                    {

//                        using (SqlDataReader reader = command.ExecuteReader())
//                        {
//                            while (reader.Read())
//                            {
//                                chores.Add($"{reader.GetInt32(0)} {reader.GetString(1)}");
//                            }
//                        }
//                    }

//                    connection.Close();
//                }

//                return chores;
//            }
//        }
//    }
//}

