using Checkout.Data.Entities;
using Checkout.Engine;
using NUnit.Framework;

namespace Checkout.Tests;

public class ShoppingBasketShould
{
    //be able to add line items
    [Test]
    public void StoreLineItems()
    {
        var basket = new ShoppingBasket();
        //add 3 items
        LineItem item1 = new LineItem
        {
            Id = 1,
            Name = "A",
            Price = 50
        };
        LineItem item2 = new LineItem
        {
            Id = 2,
            Name = "B",
            Price = 30
        };
        LineItem item3 = new LineItem
        {
            Id = 3,
            Name = "C",
            Price = 20
        };
        LineItem item4 = new LineItem
        {
            Id = 4,
            Name = "D",
            Price = 15
        };
        basket.AddItem(item1);
        basket.AddItem(item2);
        basket.AddItem(item3);
        basket.AddItem(item4);
        Assert.That(basket._lineItems.Count, Is.EqualTo(4));
    }

}