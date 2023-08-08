using Checkout.Data.Entities;

namespace Checkout.Engine;

public class ShoppingBasket
{
    public List<LineItem> _lineItems = new ();
    public void AddItem(LineItem item)
    {
        _lineItems.Add(item);
    }
    
    //Remove item from basket
    public void RemoveItem(LineItem item)
    {
        if (!_lineItems.Contains(item)){
            throw new ArgumentException("Item does not exist in basket");
        }
        _lineItems.Remove(item);
    }
    
    //get basket line item list
    public IEnumerable<LineItem> GetLineItems()
    {
        //return line items
        return _lineItems;
    }
}