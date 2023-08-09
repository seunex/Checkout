using Checkout.Data.Entities;
using Checkout.Engine;
using NUnit.Framework;

namespace Checkout.Tests;

public class CheckoutBasketCalculatorShould : BaseTest
{
    
    [Test]
    public void ApplySpecialPriceToBasketTotalPrice()
    {
        basket.AddItem(item2);
        basket.AddItem(item1);
        basket.AddItem(item2);
        basket.AddItem(item2);
        var lineItems = basket.GetLineItems();
        var specialPrices = new List<LineItemSpecialPrice>
        {
            new () { Id = 1, Quantity = 3, Name = "A", Price = 130},
            new () { Id = 2, Quantity = 2, Name = "B", Price = 45}
        };
        var calculator = new CheckoutBasketItemsCalculator();
        var totalPrice = calculator.CalculateTotalPrice(lineItems, specialPrices);
        Assert.That(totalPrice, Is.EqualTo(125));
    }

    [Test]
    public void ApplySpecialPriceToBasketWhenMoreThanOneLineItemQualifiesForSpecialPrice()
    {
        basket.AddItem(item2);
        basket.AddItem(item1);
        basket.AddItem(item1);
        basket.AddItem(item1);
        basket.AddItem(item2);
        
        var lineItems = basket.GetLineItems();
        var specialPrices = new List<LineItemSpecialPrice>
        {
            new () { Id = 1, Quantity = 3, Name = "A", Price = 130},
            new () { Id = 2, Quantity = 2, Name = "B", Price = 45}
        };
        var calculator = new CheckoutBasketItemsCalculator();
        var totalPrice = calculator.CalculateTotalPrice(lineItems, specialPrices);
        Assert.That(totalPrice, Is.EqualTo(175));
    }
    
    [Test]
    public void CalculateTotalPriceForBasketWhenLineItemsDoNotQualifyForSpecialPrice()
    {
        basket.AddItem(item1);
        basket.AddItem(item2);
        basket.AddItem(item4);
        var lineItems = basket.GetLineItems();
        var specialPrices = new List<LineItemSpecialPrice>
        {
            new () { Id = 1, Quantity = 3, Name = "A", Price = 130},
            new () { Id = 2, Quantity = 2, Name = "B", Price = 45}
        };
        var calculator = new CheckoutBasketItemsCalculator();
        var totalPrice = calculator.CalculateTotalPrice(lineItems, specialPrices);
        Assert.That(totalPrice, Is.EqualTo(95));
    }
    
    [Test]
    public void CalculateTotalPriceForBasketWhenLineItemsIsEmpty()
    {
        var lineItems = basket.GetLineItems();
        var specialPrices = new List<LineItemSpecialPrice>
        {
            new () { Id = 1, Quantity = 3, Name = "A", Price = 130},
            new () { Id = 2, Quantity = 2, Name = "B", Price = 45}
        };
        var calculator = new CheckoutBasketItemsCalculator();
        var totalPrice = calculator.CalculateTotalPrice(lineItems, specialPrices);
        Assert.That(totalPrice, Is.EqualTo(0));
    }
}

