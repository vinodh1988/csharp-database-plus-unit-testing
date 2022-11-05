using System;
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
            Console.WriteLine(cnn.ToString());
        }
    }
}
