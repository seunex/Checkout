using Checkout.Data.Entities;
using Checkout.Engine;
using NUnit.Framework;

namespace Checkout.Tests;

public class CheckoutBasketCalculatorShould
{
    [Test]
    public void NotAllowNullLineItems()
    {
        var calculator = new CheckoutBasketItemsCalculator();
        Assert.That(()=> calculator.CalculateTotalPrice(null),Throws.TypeOf<ArgumentNullException>());
    }
}

