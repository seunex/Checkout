using Checkout.Data.Entities;
using Checkout.Engine;
using NUnit.Framework;

namespace Checkout.Tests;

public class BaseTest
{
    protected ShoppingBasket basket { get; set; }
    protected LineItem item1 { get; set; }
    protected LineItem item2 { get; set; }
    protected LineItem item3 { get; set; }
    protected LineItem item4 { get; set; }
    
    [SetUp]
    public void Setup()
    {
        basket = new ShoppingBasket();
        //this is the line item test data
        //it will be list of rows from a database Table<LineItems> in a real world scenario and listed for in the 
        //frontend for the user to select/pick from
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