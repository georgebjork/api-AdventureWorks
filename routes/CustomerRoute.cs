
namespace api_AdventureWorks.routes;

public static class CustomerRoutesConfig 
{   
    // CORS Policy 
    const string CorsPolicyName = "_myCorsPolicy";

    // All customer routes
    public static void CustomerRoutes(this IEndpointRouteBuilder app) 
    {
        const string routePrefix = "/api";

        app.MapGet($"{routePrefix}/customer", () => Results.Ok(CustomerHelper.GetCustomers()))
            .RequireCors(CorsPolicyName).WithDescription("This will return all customers in the database");

        app.MapGet($"{routePrefix}/customer/{{id}}", (int id) => Results.Ok(CustomerHelper.GetCustomer(id)))
            .RequireCors(CorsPolicyName).WithDescription("This will return all customers in the database");
    }
};