using Microsoft.Extensions.DependencyInjection;
using ReceiptGenerator.Core.Interfaces;
using ReceiptGenerator.Core.Services;

namespace ReceiptGenerator.Core.Helpers;

public static class DepedencyRegistration
{
    /// <summary>
    /// Add the services dependencies 
    /// </summary>
    /// <param name="services"></param>
    public static void AddCoreServices(this IServiceCollection services)
    {
        //Core services
        services.AddScoped<IReceiptInterface, ReceiptService>();
        services.AddScoped<ITaxInterface, TaxService>();
        services.AddScoped<IItemInterface, ItemService>();
    }
}