using LicencaMongoDB.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using webapiMongoDB.Mapper;
using webapiMongoDB.Model;
using webapiMongoDB.Repository;
using webapiMongoDB.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));


builder.Services.AddScoped<ILicencaService, LicencaService>();
builder.Services.AddScoped<ILicencaRepository, LicencaRepository>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<LicencaProfile>();
});

builder.Services.AddControllers();
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
