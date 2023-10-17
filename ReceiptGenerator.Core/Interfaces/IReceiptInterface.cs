using ReceiptGenerator.Core.DTOs.Receipt;
using ReceiptGenerator.Core.Helpers;

namespace ReceiptGenerator.Core.Interfaces;

public interface IReceiptInterface
{
    /// <summary>
    /// Creates the receipt using the Cart items
    /// </summary>
    /// <param name="request">The Cart items</param>
    /// <returns>An Api response containing the receipt</returns>
    public Task<ApiResponse> CreateReceiptAsync(CreateReceiptRequest request);
}