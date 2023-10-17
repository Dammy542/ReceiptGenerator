using Microsoft.Extensions.Configuration;
using Moq;
using ReceiptGenerator.Core.Services;

namespace ReceiptGenerator.Test;

public class ItemServiceTests
{
    private readonly Mock<IConfiguration> _configuration;

    public ItemServiceTests()
    {
        _configuration = new Mock<IConfiguration>();
    }

    [Theory]
    [InlineData("Imported box of chocolates")]
    [InlineData("Imported bottle of perfume")]
    public void Item_IsImported(string name)
    {
        // Arrange
        _configuration.Setup(c => c["ExemptedItems"]).Returns("book,books,chocolate,chocolates,food,foods,pill,pills");

        var itemService = new ItemService(_configuration.Object);

        // Act
        var result = itemService.IsImported(name); 

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData("Book")]
    [InlineData("Chocolate bar")]
    public void Item_IsNotImported(string name)
    {
        // Arrange
        _configuration.Setup(c => c["ExemptedItems"]).Returns("book,books,chocolate,chocolates,food,foods,pill,pills");

        var itemService = new ItemService(_configuration.Object);

        // Act
        var result = itemService.IsImported(name);

        // Assert
        Assert.False(result);
    }


    [Theory]
    [InlineData("Book")]
    [InlineData("Chocolate bar")]
    public void Item_IsExempted(string name)
    {
        // Arrange
        _configuration.Setup(c => c["ExemptedItems"]).Returns("book,books,chocolate,chocolates,food,foods,pill,pills");

        var itemService = new ItemService(_configuration.Object);

        // Act
        var result = itemService.IsExempt(name);

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData("Music CD")]
    [InlineData("Bottle of perfume")]
    public void Item_IsNotExempted(string name)
    {
        // Arrange
        _configuration.Setup(c => c["ExemptedItems"]).Returns("book,books,chocolate,chocolates,food,foods,pill,pills");

        var itemService = new ItemService(_configuration.Object);

        // Act
        var result = itemService.IsExempt(name);

        // Assert
        Assert.False(result);
    }
}