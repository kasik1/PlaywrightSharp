using System.Data.SqlClient;


namespace CustomerHelperUtility
{
    public static class DBsqlServerUtils
    {
        public static SqlConnection GetDBConnection(string datasource, string database, string username, string password)
        {
            // Based on the type of DB we are using in the project, we can pass the corresponding Data Sources here to connect to DB
            // Ex for Data Source:- Data Source=TRAN-VMWARE\SQLEXPRESS;Initial Catalog=simplehr;Persist Security Info=True;User ID=username;Password=pwd
            //
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
    }
}
