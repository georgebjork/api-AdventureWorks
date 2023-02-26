using api_AdventureWorks;
using api_AdventureWorks.routes;

const string CorsPolicyName = "_myCorsPolicy";

var builder = WebApplication.CreateBuilder(args);

// This handles our CORS policy
builder.Services.AddCors(options => options.AddPolicy(name: CorsPolicyName, builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddEndpointsApiExplorer();

// Add Swagger to API
builder.Services.AddSwaggerGen();

// Add error handling
builder.Services.AddProblemDetails();

var app = builder.Build();

// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/handle-errrors?view=aspnetcore-7.0#problem-details
app.UseStatusCodePages(async statusCodeContext 
    =>  await Results.Problem(statusCode: statusCodeContext.HttpContext.Response.StatusCode)
                 .ExecuteAsync(statusCodeContext.HttpContext));

app.UseExceptionHandler();
app.UseStatusCodePages();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Here is our api routes
app.CustomerRoutes();

// This will enable cors 
app.UseCors();

// Default route
app.MapGet("/api", () => "Welcome to the Adventure Works API");

// Exception route 
app.Map("/exception", () => { throw new InvalidOperationException("Sample Exception"); });

// This will be where our api starts on launch
app.Map("/", () => Results.Redirect("/swagger"));

// Run the app
app.Run();
