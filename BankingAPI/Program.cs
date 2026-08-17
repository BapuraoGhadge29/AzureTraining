
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
var builder = WebApplication.CreateBuilder(args);
var keyVaultUrl="https://bgzen-banking-kv.vault.azure.net/";
var secretClient = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
var secret = await secretClient.GetSecretAsync("SqlConnectionString");
string connectionString = secret.Value.Value;
builder.Configuration["ConnectionStrings:DefaultConnection"] = connectionString;
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
