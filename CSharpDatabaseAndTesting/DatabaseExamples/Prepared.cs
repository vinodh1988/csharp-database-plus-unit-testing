using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Numerics;
using System.Text;

namespace CSharpDatabaseAndTesting.DatabaseExamples
{
    internal class Prepared
    {
        static void Main(string[] n) {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Data Source=VINODHPC\\SQLEXPRESS;Initial Catalog=csharp;User ID=sa;Password=sqlserver";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string statement = "insert into people values(@Sno,@Name,@City)";
            SqlCommand command = new SqlCommand(statement, cnn);
            SqlParameter param1=command.Parameters.Add("@Sno", SqlDbType.Int);
            SqlParameter param2 = command.Parameters.Add("@Name", SqlDbType.VarChar,25);
            SqlParameter param3 = command.Parameters.Add("@City", SqlDbType.VarChar,25);

            while (true){
                try
                {
                    Console.WriteLine("Enter sno:");
                    int Sno = Int32.Parse(Console.ReadLine());
                    if (Sno == -1)
                        break;
                    Console.WriteLine("Enter Name:");
                    string Name = Console.ReadLine();
                    Console.WriteLine("Enter City:");
                    string City = Console.ReadLine();
                    param1.Value = Sno;
                    param2.Value = Name;
                    param3.Value = City;
                    command.Prepare();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
