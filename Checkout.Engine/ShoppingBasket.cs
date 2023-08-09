using Checkout.Data.Entities;

namespace Checkout.Engine;

public class ShoppingBasket
{
    public List<LineItem> _lineItems = new ();
    /**
     * This will be Add to Cart or Add to Basket button in a real world scenario
     * Add item to basket
     * @param item
     * @return void
     */
    public void AddItem(LineItem item)
    {
        _lineItems.Add(item);
    }
    
    /**
     * This will be Remove from Cart or Remove from basket button in a real world scenario
     * Remove item from basket
     * @param item
     * @throws ArgumentException
     */
    public void RemoveItem(LineItem item)
    {
        if (!_lineItems.Contains(item)){
            throw new ArgumentException("Item does not exist in basket");
        }
        _lineItems.Remove(item);
    }
    
    /**
     * This will be the Checkout Page in the real world scenario where user will see the list of selected items in their basket
     * Get all line items in basket
     * @return List<LineItem>
     */
    public IEnumerable<LineItem> GetLineItems()
    {
        return _lineItems;
    }
}