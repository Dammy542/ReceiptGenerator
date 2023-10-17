
namespace ReceiptGenerator.Core.Interfaces;

public interface IItemInterface
{
    /// <summary>
    /// Check if the item is imported
    /// </summary>
    /// <param name="name">Name of the item</param>
    /// <returns>True or false</returns>
    public bool IsImported(string name);

    /// <summary>
    /// Check if the item is exempted
    /// </summary>
    /// <param name="name">Name of the item</param>
    /// <returns>True or false</returns>
    public bool IsExempt(string name);
}