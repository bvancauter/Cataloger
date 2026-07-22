using FastEndpoints;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();

builder.Services.AddSwaggerDocument();

var app = builder.Build();

app.UseFastEndpoints();

app.UseOpenApi();

app.UseSwaggerUi();

app.Run();
