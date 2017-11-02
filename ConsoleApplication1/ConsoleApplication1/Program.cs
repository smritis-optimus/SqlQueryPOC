using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute();
        }

        static void Execute()
        {
            var connectionString = "Server=SMRITI-PC;Database=TBL1;Trusted_Connection=true;MultipleActiveResultSets=true";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "select * from Table1";
                using (var command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var subQuery = reader[1].ToString();
                            subQuery = subQuery + " where date > '2017-11-02' and id in (2,3)";
                            using (var subCommand = new SqlCommand(subQuery, connection))
                            {
                                using (SqlDataReader subReader = subCommand.ExecuteReader())
                                {
                                    while(subReader.Read())
                                    {
                                        for(int i=0; i< subReader.FieldCount; i++)
                                        {
                                            Console.Write(subReader[i] + " ,");
                                        }
                                        Console.WriteLine("\n");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
