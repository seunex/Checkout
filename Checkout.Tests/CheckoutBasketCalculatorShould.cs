using Checkout.Data.Entities;
using Checkout.Engine;
using NUnit.Framework;

namespace Checkout.Tests;

public class CheckoutBasketCalculatorShould : BaseTest
{
    [Test]
    public void BeAbleToGetLineItemsTotalPrice()
    {
        basket.AddItem(item2);
        basket.AddItem(item1);
        basket.AddItem(item2);
        var lineItems = basket.GetLineItems();
        var calculator = new CheckoutBasketItemsCalculator();
        /*var totalPrice = calculator.CalculateTotalPrice(lineItems);
        Assert.That(totalPrice, Is.EqualTo(115));*/
    }
}

