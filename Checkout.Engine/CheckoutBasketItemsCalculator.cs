using Checkout.Data.Entities;

namespace Checkout.Engine;

public class CheckoutBasketItemsCalculator : ICheckoutBasketItemsCalculator
{
    public decimal CalculateTotalPrice(IEnumerable<LineItem> lineItems,
        IEnumerable<LineItemSpecialPrice>? lineItemSpecialPrices)
    {
        //Group line items by name and quantity property indicates how many times the line item exists
        //this will be grouped by unique SKUs in real world application
        var groupedLineItems = lineItems.GroupBy(x => x.Name).Select(x =>
            new { Name = x.Key, Quantity = x.Count(), Price = x.FirstOrDefault()?.Price });

        var totalPrice = 0m;
        foreach (var lineItem in groupedLineItems)
        {
            var lineItemPrice = lineItem.Price ?? 0;
            var lineItemSpecialPrice = lineItemSpecialPrices?.FirstOrDefault(x => x.Name == lineItem.Name);
            if (lineItemSpecialPrice != null)
            {
                if (lineItem.Quantity >= lineItemSpecialPrice.Quantity)
                {
                    var lineItemSpecialPriceQuantity = lineItem.Quantity / lineItemSpecialPrice.Quantity;
                    var lineItemSpecialPriceRemainder = lineItem.Quantity % lineItemSpecialPrice.Quantity;
                    var lineItemSpecialPriceTotalPrice = lineItemSpecialPriceQuantity * lineItemSpecialPrice.Price;
                    var lineItemSpecialPriceRemainderTotalPrice = lineItemSpecialPriceRemainder * lineItem.Price;
                    var lineItemSpecialPriceTotalPricePlusRemainderTotalPrice = lineItemSpecialPriceTotalPrice +
                        lineItemSpecialPriceRemainderTotalPrice;
                    lineItemPrice = lineItemSpecialPriceTotalPricePlusRemainderTotalPrice ?? 0;
                }
            }
            totalPrice += lineItemPrice;
        }
        return totalPrice;
    }
}