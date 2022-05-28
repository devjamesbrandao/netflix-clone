using BackEnd.Data.Configurations;
using BackEnd.Data.Repositories;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DatabaseConfig>(builder.Configuration.GetSection(nameof(DatabaseConfig)));

builder.Services.AddSingleton<IDatabaseConfig>(sp => sp.GetRequiredService<IOptions<DatabaseConfig>>().Value);

builder.Services.AddSingleton<IMidiaRepository, MidiaRepository>();

builder.Services.AddCors(
    o => o.AddPolicy(
        "CorsPolicy", builder => 
        {
            builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
        }
    )
);

builder.Services.AddSingleton<ISliderRepository, SlidersRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.MapControllers();

app.MapGet("/sliders", async (ISliderRepository repository) => 
{
    return Results.Ok(await repository.Buscar());
});

app.MapGet("/midias", async (IMidiaRepository repository) => 
{
    return Results.Ok(await repository.Buscar());
});

app.MapGet("/midias/{id}", async (IMidiaRepository repository, string id) => 
{
    return Results.Ok(await repository.Buscar(id));
});

app.Run();
