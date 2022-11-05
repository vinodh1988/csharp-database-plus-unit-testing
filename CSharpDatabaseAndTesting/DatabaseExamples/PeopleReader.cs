using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CSharpDatabaseAndTesting.DatabaseExamples
{
    internal class PeopleReader
    {
        static void Main(string[] n) {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Data Source=VINODHPC\\SQLEXPRESS;Initial Catalog=csharp;User ID=sa;Password=sqlserver";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            string statement = "select * from people";
            
            try
            {
                SqlCommand command=new SqlCommand(statement, cnn);
               SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine(reader.FieldCount);
                for (int x = 0; x < reader.FieldCount; x++)
                { 
                   Console.WriteLine("{0}------------------{1}",reader.GetName(x),reader.GetFieldType(x));
                }
                Console.WriteLine("    Sno             Name                     City");
                Console.WriteLine("---------------------------------------------------------------------------- ");
                while (reader.Read()) {
                    Console.WriteLine("{0,10}{1,25}{2,25}", reader.GetInt32(0),
                        reader.GetString(1), reader.GetString(2));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
