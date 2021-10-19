using System;
using System.Text;
using System.Data.SqlTypes;
using System.Data.SqlClient;


namespace ChoreApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Build connection string
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "DESKTOP-7D7TJF6\\SQLSERVER2019";
                builder.UserID = "sa";
                builder.Password = "@Lexandra1988!";
                builder.InitialCatalog = "master";

                //Connect to SQL
                Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("Created database schema.");

                    //Create database
                    Console.Write("Dropping and creating database 'ChoreChart'...");
                    string sql = "DROP DATABASE IF EXISTS [ChoreChart]; CREATE DATABASE [ChoreChart]";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Done.");
                    }

                    // Create a Table and insert data
                    Console.Write("Creating table with data, press any key to continue...");
                    Console.ReadKey(true);
                    StringBuilder sb = new StringBuilder();
                    sb.Append("USE ChoreChart; ");
                    sb.Append("CREATE TABLE Chores ( ");
                    sb.Append(" ChoreId INT IDENTITY(1,1) NOT NULL PRIMARY KEY, ");
                    sb.Append(" ChoreName NVARCHAR(MAX), ");
                    sb.Append(" ChoreAssignment NVARCHAR(MAX) ");
                    sb.Append("); ");
                    sb.Append("INSERT INTO Chores (ChoreName, ChoreAssignment) VALUES ");
                    sb.Append("(N'Dishes - ', N'Zoey'), ");
                    sb.Append("(N'Dust - ', N'Jaxon'), ");
                    sb.Append("(N'Vacuum - ', N'Joe'); ");
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Done.");
                    }

                    // INSERT new chore
                    Console.Write("Inserting a new row into table, press any key to continue...");
                    Console.ReadKey(true);
                    sb.Clear();
                    sb.Append("INSERT Chores (ChoreName, ChoreAssignment) ");
                    sb.Append("VALUES (@ChoreName, @ChoreAssignment);");
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ChoreName", "Laundry - ");
                        command.Parameters.AddWithValue("@ChoreAssignment", "Lauren");
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " row(s) inserted");
                    }

                    // UPDATE Chore
                    String choreToUpdate = "Dishes";
                    Console.Write("Updating 'ChoreName' for chore '" + choreToUpdate + "', press any key to continue...");
                    Console.ReadKey(true);
                    sb.Clear();
                    sb.Append("UPDATE Chores SET ChoreName = N'Mop' WHERE ChoreName = @ChoreName");
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ChoreName", choreToUpdate);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " row(s) updated");
                    }

                    // DELETE Chore
                    String choreToDelete = "Dust - ";
                    Console.Write("Deleting chore '" + choreToDelete + "', press any key to continue...");
                    Console.ReadKey(true);
                    sb.Clear();
                    sb.Append("DELETE FROM Chores WHERE ChoreName = @ChoreName;");
                    sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ChoreName", choreToDelete);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " row(s) deleted");
                    }

                    // READ 
                    Console.WriteLine("Reading data from table, press any key to continue...");
                    Console.ReadKey(true);
                    sql = "SELECT ChoreId, ChoreName, ChoreAssignment FROM Chores;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1} {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("All done. Press any key to finish...");
            Console.ReadKey(true);
        }
    }
}