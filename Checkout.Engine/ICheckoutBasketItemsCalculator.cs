using Checkout.Data.Entities;

namespace Checkout.Engine;

public interface ICheckoutBasketItemsCalculator
{
    public decimal CalculateTotalPrice(IEnumerable<LineItem> lineItems, IEnumerable<LineItemSpecialPrice>? lineItemSpecialPrices);
}