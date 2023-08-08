using NUnit.Framework;

namespace Checkout.Tests;

public class ShoppingBasketShould : BaseTest
{
    [Test]
    public void StoreLineItems()
    {
        basket.AddItem(item1);
        basket.AddItem(item2);
        basket.AddItem(item3);
        basket.AddItem(item4);
        Assert.That(basket._lineItems.Count, Is.EqualTo(4));
    }
    
    [Test]
    public void NotAllowRemovalOfNonExistentLineItems()
    {
        Assert.That(()=> basket.RemoveItem(item1),Throws.TypeOf<ArgumentException>());
    }
    
    [Test]
    public void BeAbleToRemoveLineItems()
    {
        basket.AddItem(item1);
        basket.AddItem(item2);
        //remove item
        basket.RemoveItem(item1);
        basket.RemoveItem(item2);
        Assert.That(basket._lineItems.Count, Is.EqualTo(0));
    }
    
    [Test]
    public void BeAbleToGetBasketWithoutLineItems()
    {
        var lineItems = basket.GetLineItems();
        Assert.That(lineItems.Count(), Is.EqualTo(0), "Basket should be empty because no items have been added");
    }
    [Test]
    public void BeAbleToGetBasketWithLineItems()
    {
        basket.AddItem(item1);
        basket.AddItem(item2);
        var lineItems = basket.GetLineItems();
        Assert.That(lineItems.Count(), Is.EqualTo(2));
    }
    
    

}