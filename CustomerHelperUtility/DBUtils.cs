using System.Data.SqlClient;


namespace CustomerHelperUtility
{
    public static class DBUtils
    {
        public static SqlConnection GetSQLExpressDBConnection()
        {
            string datasource = ""; // @"tran-vmware\SQLEXPRESS";
            string database = ""; //"simplehr";
            string username = ""; //"username";
            string password = ""; // "1234";

            return DBsqlServerUtils.GetDBConnection(datasource, database, username, password);
        }

        public static SqlConnection GetSQLServerDBConnection()
        {
            string datasource = "";
            string database = "";
            string username = "";
            string password = "";

            return DBsqlServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }
}
