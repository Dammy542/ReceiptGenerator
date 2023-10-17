using ReceiptGenerator.Core.Models;

namespace ReceiptGenerator.Core.DTOs.Receipt;

/// <summary>
/// used to collect the list of items in the cart
/// </summary>
public class CreateReceiptRequest
{
    /// <summary>
    /// Holds the list of items in the cart
    /// </summary>
    public List<CartItemRequest> CartItems { get; set; } = new List<CartItemRequest>();
}