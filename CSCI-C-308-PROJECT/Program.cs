using CSCI_308_TEAM5.API.Actions;
using CSCI_308_TEAM5.API.Repository;
using CSCI_308_TEAM5.API.Security;
using CSCI_308_TEAM5.API.Services;
using System.Text.Json.Serialization;
using FluentValidation;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using CSCI_308_TEAM5.API.ControllerFilters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication()
    .AddTeam5Jwt();

builder.Services.AddAuthorization();
builder.Services.AddSecurities();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddActions();
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

var targetAssembly = Path.Combine(AppContext.BaseDirectory, "CSCI-C-308-TEAM5.API.dll");
var assemblyName = Assembly.Load(AssemblyName.GetAssemblyName(targetAssembly));
builder.Services.AddValidatorsFromAssembly(assemblyName);

builder.Services.Configure<MvcOptions>(options => options.Filters.Add<FluentValidatorFilter>());
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
await app.RunAsync();
