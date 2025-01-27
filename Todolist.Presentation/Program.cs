using Microsoft.EntityFrameworkCore;
using Todolist.Application.Repositories.EF;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("Default"),
        new MySqlServerVersion(new Version(8, 0, 40))
    ));

var app = builder.Build();

app.MapControllers();

app.Run();