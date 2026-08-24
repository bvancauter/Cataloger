using Cataloger.Api.Data;
using Cataloger.Api.Middlewares;
using FastEndpoints;
using FastEndpoints.Swagger;
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

builder.Services.AddFastEndpoints();

builder.Services.SwaggerDocument();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();


app.UseFastEndpoints();

app.UseSwaggerGen();

app.Run();
