
namespace ReceiptGenerator.Core.DTOs.Receipt;

/// <summary>
/// Holds the Receipt details
/// </summary>
public class CreateReceiptResponse
{
    public Models.Receipt Receipt { get; set; } = new Models.Receipt();
}