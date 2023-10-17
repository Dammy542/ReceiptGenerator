using Microsoft.Extensions.Configuration;
using ReceiptGenerator.Core.Interfaces;

namespace ReceiptGenerator.Core.Services;

public class ItemService : IItemInterface
{
    private readonly IConfiguration _configuration;

    public ItemService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public bool IsImported(string name) => name.ToLower().Contains("imported", StringComparison.OrdinalIgnoreCase);

    public bool IsExempt(string name)
    {
        bool exempted = false;
        var exemptedItems = _configuration["ExemptedItems"].Split(',').ToList();
        exemptedItems.ForEach(x =>
        {
            if (name.ToLower().Contains(x, StringComparison.OrdinalIgnoreCase))
                exempted = true;
        });
        return exempted;
    }
}