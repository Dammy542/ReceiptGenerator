using ReceiptGenerator.Core.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReceiptGenerator.Core.Models;

/// <summary>
/// Holds each item in the cart passed in the request
/// </summary>
public class CartItemRequest
{
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than or equal to 1")]
    public int Quantity { get; set; }
    [Required(ErrorMessage = "Please enter the name of the item")]
    [StringLength(100)]
    public string Name { get; set; }
    [DecimalGreaterThanZero(ErrorMessage = "Amount must be greater than 0")]
    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:n2}")]
    public decimal Price { get; set; }
}