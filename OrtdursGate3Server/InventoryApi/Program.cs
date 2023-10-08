using Microsoft.EntityFrameworkCore;
using OrtdursGateDataAccess;
using OrtdursGateDataAccess.Repositories;
using OrtdursGateDataAccessInterface;
using OrtdursGateDomain;
using OrtdursGateLogic;
using OrtdursGateLogicInterface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<DataInitializer.DataInitializer, DataInitializer.DataInitializer>();


builder.Services.AddDbContext<OrtdursContext>(options => options.UseInMemoryDatabase(databaseName: "OrtdursGate3MemoryDb"));
var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
