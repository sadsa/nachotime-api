using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nachotime_data;
using nachotime_data.Repository;
using nachotime_services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ICardRepository, CardRepository>();

builder.Services.AddDbContext<NachotimeDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("NachotimeDbContext")));

var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new AutoMapperProfile()); });
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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
