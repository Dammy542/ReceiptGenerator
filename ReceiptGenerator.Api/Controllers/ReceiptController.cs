using Microsoft.AspNetCore.Mvc;
using ReceiptGenerator.Api.Attribute;
using ReceiptGenerator.Core.DTOs.Receipt;
using ReceiptGenerator.Core.Interfaces;

namespace ReceiptGenerator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
[ServiceFilter(typeof(ValidationFilterAttribute))]
public class ReceiptController : ControllerBase
{
    private readonly IReceiptInterface _receiptService;

    public ReceiptController(IReceiptInterface receiptService)
    {
        _receiptService = receiptService;
    }

    [HttpPost("generate")]
    public async Task<object> CreateReceipt([FromBody] CreateReceiptRequest request)
    {
        var result = await _receiptService.CreateReceiptAsync(request);

        return result.Code == 200 ? (object)Ok(result) : BadRequest(result);
    }
}