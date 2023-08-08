using Checkout.Data.Entities;
using Checkout.Engine;
using NUnit.Framework;

namespace Checkout.Tests;

public class BaseTest
{
    protected ShoppingBasket basket;
    protected LineItem item1;
    protected LineItem item2;
    protected LineItem item3;
    protected LineItem item4; 
    
    [SetUp]
    public void Setup()
    {
        basket = new ShoppingBasket();
        item1 = new LineItem
        {
            Id = 1,
            Name = "A",
            Price = 50
        };
        item2 = new LineItem
        {
            Id = 2,
            Name = "B",
            Price = 30
        };
        item3 = new LineItem
        {
            Id = 3,
            Name = "C",
            Price = 20
        };
        item4 = new LineItem
        {
            Id = 4,
            Name = "D",
            Price = 15
        };
    }
}