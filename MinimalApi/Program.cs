using Microsoft.EntityFrameworkCore;
using MinimalApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("AppConnectionString");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//using(var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//    // db.Database.EnsureCreated();
//    db.Database.Migrate();    
//}

// U¿ycie metody statycznej
// ApplyMigrations<ApplicationDbContext>(app);

// U¿ycie metody rozszerzaj¹cej
app.ApplyMigrations<ApplicationDbContext>();
    
app.MapGet("/", () => "Hello World!");

app.Run();


static void ApplyMigrations<TDbContext>(WebApplication app)
   where TDbContext : DbContext
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<TDbContext>();
    db.Database.Migrate();
}