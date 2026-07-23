using Cataloger.Api.Data;
using Microsoft.EntityFrameworkCore;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    var connectionString =
        $"Host={Environment.GetEnvironmentVariable("POSTGRES_HOST")};" +
        $"Port={Environment.GetEnvironmentVariable("POSTGRES_PORT")};" +
        $"Database={Environment.GetEnvironmentVariable("POSTGRES_DB")};" +
        $"Username={Environment.GetEnvironmentVariable("POSTGRES_USER")};" +
        $"Password={Environment.GetEnvironmentVariable("POSTGRES_PASSWORD")}";

    options.UseNpgsql(connectionString);
});

// builder.Services.AddFastEndpoints();

// builder.Services.AddSwaggerDocument();

var app = builder.Build();

// app.UseFastEndpoints();

// app.UseOpenApi();

// app.UseSwaggerUi();

app.Run();
