using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using NUnit.Framework;
using System.Data;

namespace SQLConnection
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestConnection()
        {
            string connectionString=@"Server=IVYGUO1002\SQLEXPRESS;Database=Test;Trusted_Connection=SSPI";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Do work here; connection closed on following line.  
                Console.WriteLine("State: {0}", connection.State);
                Console.WriteLine("ConnectionString: {0}",
                    connection.ConnectionString);
            }

        }
        [Test]
        public void TestNonQuery()
        {
            string connectionString =@"Server = IVYGUO1002\SQLEXPRESS; Database = Test; Trusted_Connection = SSPI";
            string queryString = "Insert Into Persons Values(5,'test','test','BrownsBay','Auckland')";
            using (SqlConnection connection = new SqlConnection(
                           connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                int result=command.ExecuteNonQuery();
                Console.WriteLine("ExecuteResult: {0}",
                            result);

            }
        }

        [Test]
        public void TestQuery()
        {
            string connectionString =@"Server = IVYGUO1002\SQLEXPRESS; Database = Test; Trusted_Connection = SSPI";
            string queryString = "Select * from Persons";
            using (SqlConnection connection = new SqlConnection(
                           connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                IDataRecord record = (IDataRecord)reader;
                while (reader.Read())
                {
                    Console.WriteLine(string.Format("{0},{1}\n"
                    ,record[0], record[1]));
                }
                // Call Close when done reading.
                reader.Close();
            }
        }
        [Test]
        public void TestDataSet()
        {

        }

    }
}
