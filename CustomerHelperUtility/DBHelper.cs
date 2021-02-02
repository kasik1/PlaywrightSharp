using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CustomerHelperUtility
{
    public class DBHelper
    {
        private SqlConnection connection;

        public DBHelper()
        {
            connection = DBUtils.GetSQLServerDBConnection();
        }

        /// <summary>
        /// This method is used only for Read Data from DB.
        /// </summary>
        public DataTable ReadData(string sqlQuery)
        {
            SqlDataReader dataReader = null;

            try
            {
                // Open the connection
                connection.Open();
                // 1. Instantiate a new command with a sqlQuery and connection Object
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                // 2. Call Execute reader to get query results
                dataReader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Raised is: " + ex.StackTrace);
                connection.Close();
                throw new ConduentUIAutomationException(ex.ToString());
            }

            DataTable dt = new DataTable();
            dt.Load(dataReader);
            return dt;
        }

        /// <summary>
        /// This method is used only for Close the DB Connection.
        /// </summary>
        public void closeDBConnection()
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
            else
            {
                //Why is this else empty there should be something here to check if it is null
            }
        }

        /// <summary>
        /// This method is used only for Inserting data into the DB.
        /// </summary>
        public void Insert(string insertSqlQuery)
        {
            try
            {
                // Open the connection
                connection.Open();

                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(insertSqlQuery, connection);

                // 2. Call ExecuteNonQuery to send command
                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }

        /// <summary>
        /// This method is used only for Updating data in the DB.
        /// </summary>
        public void UpdateData(string updateSqlQuery)
        {
            try
            {
                // Open the connection
                connection.Open();

                // 1. Instantiate a new command with command text only
                SqlCommand cmd = new SqlCommand(updateSqlQuery)
                {
                    // 2. Set the Connection property
                    Connection = connection
                };

                // 3. Call ExecuteNonQuery to send command
                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }

        /// <summary>
        /// This method is used only for Deleting data from the DB.
        /// </summary>
        public void DeleteData(string deleteString)
        {
            try
            {
                // Open the connection
                connection.Open();

                // 1. Instantiate a new command
                SqlCommand cmd = new SqlCommand
                {

                    // 2. Set the CommandText property
                    CommandText = deleteString,

                    // 3. Set the Connection property
                    Connection = connection
                };

                // 4. Call ExecuteNonQuery to send command
                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }

        /// <summary>
        /// This method is used to get the number of records
        /// </summary>
        /// <returns>number of records</returns>
        public int GetNumberOfRecords(string query)
        {
            int count = -1;
            try
            {
                // Open the connection
                connection.Open();

                // 1. Instantiate a new command
                SqlCommand cmd = new SqlCommand(query, connection);

                // 2. Call ExecuteScalar to send command
                count = (int)cmd.ExecuteScalar();
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
            return count;
        }
    }
}
