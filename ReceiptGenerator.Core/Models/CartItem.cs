
namespace ReceiptGenerator.Core.Models;

/// <summary>
/// Represents an item in the Cart
/// </summary>
public class CartItem
{
    public int Quantity { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    

    public decimal TotalPrice()
    {
        return Price * Quantity;
    }
}