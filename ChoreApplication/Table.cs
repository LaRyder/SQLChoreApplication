//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ChoreApplication
//{
//    public class Table
//    {

//        public int ChoreId { get; set; }
//        public String ChoreName { get; set; }
//        public String ChoreAssignment { get; set; }

//        public void CreateDatabase()
//        {

//        }

//        public DataTable CreateChoreTable()
//        {
//            DataTable dt = new DataTable();
//            dt.Columns.Add("ChoreId",typeof(Int32));
//            dt.Columns.Add("ChoreName",typeof(string));
//            dt.Columns.Add("ChoreAssigment",typeof(string));
//            return dt;

//            //Create table
//            DataTable myTable = CreateChoreTable();
//            myTable.Rows.Add(1, ChoreName = "Dishes", ChoreAssignment = "Zoey");
//            myTable.Rows.Add(2, ChoreName = "Dust", ChoreAssignment = "Jaxon");
//            myTable.Rows.Add(3, ChoreName = "Vacuum", ChoreAssignment = "Joe");

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

//        public string AddChore()
//        {
//            DataTable myTable = new DataTable();
//            myTable.Rows.Add(4, ChoreName = "Dishes", ChoreAssignment = "Zoey");
//        }

//        public string UpdateChore()
//        {
//            throw new NotImplementedException();
//        }

//        public string DeleteChore()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
