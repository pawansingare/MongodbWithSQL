using Microsoft.EntityFrameworkCore;
using MongoDbWithSQL;
using MongoDbWithSQL.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<BookStoreDatabaseSettings>(
    builder.Configuration.GetSection("BookStoreDatabase"));

builder.Services.AddControllers();
//builder.Services.AddDbContext<AppDbContext, AppDbContext>(options =>
//                    options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDb"),
//                                         b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

builder.Services.AddDbContext<AppDbContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDb")));
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

app.UseAuthorization();

app.MapControllers();

app.Run();
