using Checkout.Data.Entities;

namespace Checkout.Engine;

public class CheckoutBasketItemsCalculator : ICheckoutBasketItemsCalculator
{
    public decimal CalculateTotalPrice(IEnumerable<LineItem>? lineItems)
    {
        //throw an exception if line items is less than 1
        if (lineItems == null)
        {
            throw new ArgumentNullException(nameof(lineItems));
        }
        return 0;
    }
}