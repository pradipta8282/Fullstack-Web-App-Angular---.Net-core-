using pradiptapaul.api.DATA;
using Microsoft.EntityFrameworkCore;
using pradiptapaul.api.Repository.Interface;
using pradiptapaul.api.Repository.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PradiptaConnectionString"));
});

builder.Services.AddScoped<IcategoryRepository , CategoryRepository>();////It registers the ICategoryRepository interface with the CategoryRepository class.When a class requests ICategoryRepository, the DI system provides an instance of //CategoryRepository.Lifetime Scope: AddScoped<TInterface, TImplementation>() registers it as a scoped service.
//insted of manually create an instance we inject it into the controller.//When the app runs: A user makes an API request ? The controller requires ICategoryRepository.ASP.NET Core DI resolves the dependency ? It finds CategoryRepository and creates an instance.
//Same instance is used throughout the request ? Ensures efficiency and database context safety.At the end of the request, the instance is disposed ? Prevents memory leaks.


/*Understanding Each Component
1. builder.Services
builder refers to the WebApplicationBuilder instance.

Services is a property of WebApplicationBuilder that provides access to the dependency injection container.

This allows us to register services (like DbContext, logging, authentication, etc.) for dependency injection.

2. .AddDbContext<ApplicationDBContext>(options => { ... })
AddDbContext<TContext> is an extension method used to register the Entity Framework Core database context.

ApplicationDBContext is the custom DbContext class that interacts with the database.

The lambda expression options => { ... } allows us to configure the database provider inside.

3. options.UseSqlServer(...)
UseSqlServer() is a method that specifies SQL Server as the database provider.

options is an object of DbContextOptionsBuilder that allows configuring the DbContext.

This method tells Entity Framework Core to use Microsoft SQL Server as the database engine.

4. builder.Configuration.GetConnectionString("PradiptaConnectionString")
builder.Configuration:

Accesses the application configuration settings from appsettings.json or environment variables.

.GetConnectionString("PradiptaConnectionString"):

Fetches the connection string named "PradiptaConnectionString" from appsettings.json.

This connection string contains the server name, database name, authentication details, etc.*/


//Any communication with the database has to be done through the repository.so will inject the ICategory interface in controller

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(cors =>
{
    cors.AllowAnyHeader();
    cors.AllowAnyOrigin();
    cors.AllowAnyMethod();

});

app.UseAuthorization();

app.MapControllers();

app.Run();
