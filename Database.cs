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
        
        return builder.ConnectionString;
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