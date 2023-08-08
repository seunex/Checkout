using Checkout.Data.Entities;

namespace Checkout.Engine;

public class ShoppingBasket
{
    private readonly ICheckoutBasketItemsCalculator _checkoutBasketItemsCalculator;
    private List<LineItem> _lineItems = new ();
    public ShoppingBasket(ICheckoutBasketItemsCalculator checkoutBasketItemsCalculator)
    {
        _checkoutBasketItemsCalculator = checkoutBasketItemsCalculator;
    }
    //Add item to basket
    public void AddItem(LineItem item)
    {
        _lineItems.Add(item);
    }
    
    //Remove item from basket
    public void RemoveItem(LineItem item)
    {
        _lineItems.Remove(item);
    }
    
    //get basket line item list
    private IEnumerable<LineItem> GetLineItems()
    {
        //return line items
        return _lineItems;
    }
    
    //get total price
    public decimal GetTotalPrice()
    {
       return  _checkoutBasketItemsCalculator.CalculateTotalPrice(GetLineItems());
    }
}