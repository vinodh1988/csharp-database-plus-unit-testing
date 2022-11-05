using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace CSharpDatabaseAndTesting.DatabaseExamples
{
    internal class Transactions
    {
        static void Main(string[] n) {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Data Source=VINODHPC\\SQLEXPRESS;Initial Catalog=csharp;User ID=sa;Password=sqlserver";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlTransaction t;
            try
            {
                t = cnn.BeginTransaction();
                string statement = "insert into people values(@Sno,@Name,@City)";
                
                SqlCommand command = new SqlCommand(statement, cnn);
                
                SqlParameter param1 = command.Parameters.Add("@Sno", SqlDbType.Int);
                SqlParameter param2 = command.Parameters.Add("@Name", SqlDbType.VarChar, 25);
                SqlParameter param3 = command.Parameters.Add("@City", SqlDbType.VarChar, 25);
                string update = "update people set name=@NewName where sno=@QSno";
                SqlCommand command2 = new SqlCommand(update, cnn);
                SqlParameter uparam1 = command2.Parameters.Add("@QSno", SqlDbType.Int);
                SqlParameter uparam2 = command2.Parameters.Add("@NewName", SqlDbType.VarChar, 25);
                command.Transaction = t;
                command2.Transaction = t;
              
                Console.WriteLine("Enter sno for insertion:");
                int Sno = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Enter Name for insertion:");
                string Name = Console.ReadLine();
                Console.WriteLine("Enter City insertion:");
                string City = Console.ReadLine();
                param1.Value = Sno;
                param2.Value = Name;
                param3.Value = City;
                Console.WriteLine("Enter sno for updation:");
                int USno = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Enter Name for updation:");
                string UName = Console.ReadLine();
                uparam1.Value = USno;
                uparam2.Value = UName;
                command2.Prepare();
                
                command.Prepare();
                command2.ExecuteNonQuery();
                Console.Write("Row updated - Transaction yet to commit");
                command.ExecuteNonQuery();
                Console.WriteLine("Row inserted - Transaction about to commit");
                t.Commit();
                Console.WriteLine("Transaction Success");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace + " " + e.Message);
                Console.WriteLine("Exception occured during transaction");
            }
           
        }
    }
}
