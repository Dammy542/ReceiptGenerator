﻿
namespace ReceiptGenerator.Core.Helpers;

/// <summary>
/// Used the return the standard Api resoponse to the client
/// </summary>
public class ApiResponse
{
    public int Code { get; set; }
    public string Status { get; set; }
    public string Message { get; set; }
    public object? Data { get; set; }


    public ApiResponse(int statusCode, string message, object? payload)
    {
        this.Code = statusCode;
        this.Message = message;
        this.Data = payload;
        this.Status = Code == 200 ? "success" : "failed";
    }
}
