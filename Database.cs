using System.Data;
using Microsoft.Data.SqlClient;

namespace api_AdventureWorks;

public static class Database {

    /// <summary>
    /// This function will create a Connection String for our database.
    /// </summary>
    ///     
    /// <returns>String</returns>
    private static string ConnectionStringBuilder() 
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        builder.DataSource = "localhost\\SQLEXPRESS"; 
        builder.UserID = "";            
        builder.Password = "";     
        builder.InitialCatalog = "AdventureWorksLT2019";
        
        return "Data Source=localhost\\SQLEXPRESS;Initial Catalog=AdventureWorksLT2019;Integrated Security=True;Persist Security Info=False;User ID=;Password=******;Pooling=False;Min Pool Size=0;Max Pool Size=100;Multiple Active Result Sets=False;Replication=False;Connect Timeout=15;Encrypt=True;Trust Server Certificate=True;Load Balance Timeout=0;Packet Size=8000;Type System Version=Latest;Application Name=sqlops-connection-string;Application Intent=ReadWrite;Multi Subnet Failover=False;Connect Retry Count=1;Connect Retry Interval=10;Column Encryption Setting=Disabled";
    }

    /// <summary>
    /// This function will run a query on the database
    /// </summary>
    ///     
    /// <returns>SqlDataReader object</returns>
    
    public static SqlDataReader RunQuery(string query) 
    {
        // Create a connection
        var connection = new SqlConnection(ConnectionStringBuilder());

        // Open the connection
        connection.Open();

        // Create a new sql command
        var command = new SqlCommand(query, connection);

        // Return the command reader
        return command.ExecuteReader();
    }

    /// <summary>
    /// This function will run a stored procedure on the database
    /// </summary>
    ///     
    /// <returns>SqlDataReader object</returns>

    public static SqlDataReader RunProcedure(string procedure, SqlParameter[] parameters) 
    {
        // Create a connection
        var connection = new SqlConnection(ConnectionStringBuilder());

        // Open the connection
        connection.Open();

        // Create a new sql command
        var command = new SqlCommand(procedure, connection);
        
        // Change command to stored procedure
        command.CommandType = CommandType.StoredProcedure;

        // Add procedure paramaters
        command.Parameters.AddRange(parameters);

        // Return the command reader
        return command.ExecuteReader();
    }
};