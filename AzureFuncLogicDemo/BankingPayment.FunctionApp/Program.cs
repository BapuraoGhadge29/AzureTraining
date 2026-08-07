using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BankingPayment.FunctionApp.Services;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddHttpClient();
        services.AddScoped<ILogicAppService,LogicAppService>();
    })
    .Build();

host.Run();