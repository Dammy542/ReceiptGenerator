
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReceiptGenerator.Core.Models;

/// <summary>
/// The Receipt to return after the tax and amount calculation
/// </summary>
public class Receipt
{
    public Dictionary<string, decimal> Items { get; } = new Dictionary<string, decimal>();
    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:n2}")]
    public decimal TotalSalesTax { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:n2}")]
    public decimal TotalPrice { get; private set; }

    public void AddItem(string name, decimal price)
    {
        if (Items.ContainsKey(name))
            Items[name] += price;
        else
            Items[name] = price;

        TotalPrice += price;
    }

    public void AddSalesTax(decimal salesTax)
    {
        TotalSalesTax += salesTax;
    }
}