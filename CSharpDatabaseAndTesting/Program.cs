using System;
using System.Data;
using System.Data.SqlClient;

namespace CSharpDatabaseAndTesting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Data Source=VINODHPC\\SQLEXPRESS;Initial Catalog=csharp;User ID=sa;Password=sqlserver";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string statement = "insert into people values(1,'Roger','Chennai')";
            Console.WriteLine(cnn.State);

            SqlCommand cmd = new SqlCommand(statement,cnn);
            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("New row inserted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }
    }
}
