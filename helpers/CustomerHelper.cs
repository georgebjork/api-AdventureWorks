
using System.Diagnostics;
using api_AdventureWorks.models;

namespace api_AdventureWorks;

public static class CustomerHelper
{

    private static Stopwatch? stopwatch;

    private static void StartTimer()
    {
        stopwatch = Stopwatch.StartNew();
    }

    private static void StopTimer()
    {
        stopwatch!.Stop();

        // Get the execution time in milliseconds
        long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

        // Print the execution time
        Console.WriteLine("The function took {0} milliseconds to execute.", elapsedMilliseconds);
    }

    public static List<Customer> GetCustomers()
    {
        List<Customer> customers = new List<Customer>();

        using (var reader = Database.RunQuery("SELECT * FROM SalesLT.Customer")) 
        {
            while(reader.Read()) 
            {
                customers.Add(new Customer(reader));
            }
        }
        return customers;
    }

    public static Customer GetCustomer(int id)
    {
        List<Customer> customers = new List<Customer>();

        using (var reader = Database.RunQuery($"SELECT * FROM SalesLT.Customer WHERE CustomerID = {id}")) 
        {
            while(reader.Read()) 
            {
                customers.Add(new Customer(reader));
            }
        }
        return customers[0];
    }
};