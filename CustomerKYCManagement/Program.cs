using CustomerKYCManagement.Data;
using CustomerKYCManagement.repositories;
using CustomerKYCManagement.services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<BankingDbContext>(options =>
{    
    string connectstring= builder.Configuration.GetConnectionString("cn")!;
    options.UseAzureSql(connectstring);
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
builder.Services.AddScoped<ICustomerService,CustomerService>();
builder.Services.AddScoped<IAccountRepository,AccountRepository>();
builder.Services.AddScoped<IAccountService,AccountService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.UseHttpsRedirection();
app.Run();


