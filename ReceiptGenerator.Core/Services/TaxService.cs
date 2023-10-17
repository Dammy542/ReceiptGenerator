using Microsoft.Extensions.Logging;
using ReceiptGenerator.Core.Helpers;
using ReceiptGenerator.Core.Interfaces;
using ReceiptGenerator.Core.Models;
using System.Net;

namespace ReceiptGenerator.Core.Services;
public class TaxService : ITaxInterface
{
    private readonly IItemInterface _itemService;
    private readonly ILogger<TaxService> _logger;

    public TaxService(IItemInterface itemService, ILogger<TaxService> logger)
    {
        _itemService = itemService;
        _logger = logger;
    }

    public decimal CalculateTax(CartItem item)
    {
        try
        {
            if (item is null)
                return 0.0m;

            decimal taxRate = 0.10m;
            if (_itemService.IsExempt(item.Name))
                taxRate = 0.0m;

            decimal importDuty = _itemService.IsImported(item.Name) ? 0.05m : 0.0m;
            decimal salesTax = Math.Ceiling(item.Price * taxRate * 20) / 20;
            return Math.Round((salesTax + (item.Price * importDuty)) * item.Quantity, 2);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error in CalculateTax message = " + ex.Message + " \nStack trace = " + ex.StackTrace);
            return 0.0m;
        }
    }
}