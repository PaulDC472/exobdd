using ApplicationLayer;
using DomainLayer;
using Entities;
using InfrastructureLayer;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddSingleton<IWeatherForecastApplicationService, WeatherForecastApplicationService>();

builder.Services.AddSingleton<IWeatherForecastDomainService, WeatherForecastDomainService>();

builder.Services.AddSingleton<IWeatherForecastRepository, WeatherForecastRepository>();


builder.Services.AddScoped<IUserApplicationService, UserApplicationService>();

builder.Services.AddScoped<IUserDomainService, UserDomainService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();




builder.Services.AddScoped<DbContext, AppDbContext>();


builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



// OpenTelemetry
var serviceName = "MonAppliWeb";
var serviceVersion = "1.0.0";

builder.Services.AddOpenTelemetryTracing((builder) => builder
                .AddAspNetCoreInstrumentation()
                .AddJaegerExporter()
                .AddSqlClientInstrumentation()
                .AddSource(serviceName)
                .SetResourceBuilder(ResourceBuilder.CreateDefault()
                .AddService(serviceName: serviceName, serviceVersion: serviceVersion))
       );



builder.Services.AddHealthChecks();



// builder.Services.AddMetrics();

// builder.Services.AddMetricsTrackingMiddleware();



var app = builder.Build();



app.MapHealthChecks("/healthz");



// app.UseMetricsAllEndpoints();





using (var scope = app.Services.CreateScope())
{

    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();


    // context.Database.EnsureDeleted();

    // context.Database.EnsureCreated();


    context.Database.Migrate();


    if (context.Books.Count() == 0)
    {

        var book1 = new Book { Title = "Robin", PageCount = 100 };
        var book2 = new Book { Title = "Peter Pan", PageCount = 200 };
        var book3 = new Book { Title = "Tarzan", PageCount = 300 };
        var book4 = new Book { Title = "Tarzan", PageCount = 300 };

        book1.SimilaryBook = book2;

        var book5 = new GraphicBook { Title = "Batman", MainColor = "black" };


        var user1 = new User { Name = "Pierre" };
        var user2 = new User { Name = "Paul" };
        User user3 = new User { Name = "Patrick" };
        User user4 = new() { Name = "Jean" };

        user1.ReadBooks.Add(book1);
        user1.ReadBooks.Add(book2);

        user2.ReadBooks.Add(book5);

        var lib1 = new Library { LibName = "Enfants" };
        var lib2 = new Library { LibName = "Policier" };
        var lib3 = new Library { LibName = "Comics" };


        lib1.LibBooks.Add(book1);
        lib1.LibBooks.Add(book2);
        lib1.LibBooks.Add(book3);
        lib1.LibBooks.Add(book4);

        lib3.LibBooks.Add(book5);


        using var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);


        context.Books.Add(book1);
        context.Books.Add(book2);
        context.Books.Add(book3);
        context.Books.Add(book4);

        context.Books.Add(book5);

        context.SaveChanges();


        context.Libraries.Add(lib1);
        context.Libraries.Add(lib2);
        context.Libraries.Add(lib3);

        context.SaveChanges();


        context.Set<User>().Add(user1);
        context.Users.Add(user2);
        context.Users.Add(user3);

        context.Users.Add(user4);

        context.SaveChanges();


        transaction.Commit();

    }



}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();



