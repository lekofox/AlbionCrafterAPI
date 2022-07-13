using System.Text.Json.Serialization;
using AlbionCrafter.Interfaces;
using AlbionCrafter.Repository;
using AlbionCrafter.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions( options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); 
});
builder.Services.AddScoped<IProfitCalculator, ProfitCalculator>();
builder.Services.AddScoped<IWeaponTreat, WeaponTreat>();
builder.Services.AddScoped<IXmlRepository, XmlRepository>();
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
