using Microsoft.Extensions.Logging;
using ReceiptGenerator.Core.DTOs.Receipt;
using ReceiptGenerator.Core.Helpers;
using ReceiptGenerator.Core.Interfaces;
using ReceiptGenerator.Core.Models;
using System.Net;

namespace ReceiptGenerator.Core.Services;

public class ReceiptService : IReceiptInterface
{
    private readonly ILogger<ReceiptService> _logger;
    private readonly ITaxInterface _taxService;

    public ReceiptService(ILogger<ReceiptService> logger, ITaxInterface taxService)
    {
        _logger = logger;
        _taxService = taxService;
    }

    public async Task<ApiResponse> CreateReceiptAsync(CreateReceiptRequest request)
    {
        try
        {
            if (request.CartItems.Count <= 0)
                return new ApiResponse((int)HttpStatusCode.BadRequest, "One item at least is needed.", null);

            List<CartItem> cartItems = new List<CartItem>();

            //add the request to the cart items
            foreach (var item in request.CartItems)
            {
                cartItems.Add(new CartItem
                {
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity
                });
            }

            var response = new CreateReceiptResponse();

            //calculate the tax for each item and add to the Receipt list
            foreach (var item in cartItems)
            {
                decimal salesTax = _taxService.CalculateTax(item);
                salesTax = Math.Round(salesTax, 2, MidpointRounding.AwayFromZero);
                decimal totalPrice = item.TotalPrice() + salesTax;
                response.Receipt.AddItem(item.Name, totalPrice);
                response.Receipt.AddSalesTax(salesTax);
            }

            return new ApiResponse((int)HttpStatusCode.OK, "Successful", response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error in CreateReceiptAsync message = " + ex.Message + " \nStack trace = " + ex.StackTrace);
            return new ApiResponse((int)HttpStatusCode.InternalServerError, "An error occured, please try again.", null);
        }
    }


}