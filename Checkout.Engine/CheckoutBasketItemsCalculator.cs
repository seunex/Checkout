using Checkout.Data.Entities;

namespace Checkout.Engine;

public class CheckoutBasketItemsCalculator : ICheckoutBasketItemsCalculator
{
    public decimal CalculateTotalPrice(IEnumerable<LineItem> lineItems)
    {
        throw new NotImplementedException();
    }
}