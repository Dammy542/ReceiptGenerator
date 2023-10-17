using ReceiptGenerator.Core.Models;

namespace ReceiptGenerator.Core.Interfaces;

public interface ITaxInterface
{
    /// <summary>
    /// calulate the Tax of the Cart Item
    /// </summary>
    /// <param name="item">The Cart item</param>
    /// <returns>The Tax</returns>
    public decimal CalculateTax(CartItem item);
}