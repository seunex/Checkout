using Checkout.Data.Entities;

namespace Checkout.Engine;

public class CheckoutBasketItemsCalculator : ICheckoutBasketItemsCalculator
{
    public decimal CalculateTotalPrice(IEnumerable<LineItem> lineItems,
        IEnumerable<LineItemSpecialPrice>? lineItemSpecialPrices = null)
    {
        //Group line items by name and quantity property indicates how many times the line item exists
        //this will be grouped by unique SKUs in real world application
        var groupedLineItems = lineItems.GroupBy(x => x.Name).Select(x =>
            new { Name = x.Key, Quantity = x.Count(), Price = x.FirstOrDefault().Price });

        var totalPrice = 0m;
        foreach (var lineItem in groupedLineItems)
        {
            var lineItemPrice = lineItem.Price;
            var lineItemSpecialPrice = lineItemSpecialPrices?.FirstOrDefault(x => x.Name == lineItem.Name);
            if (lineItemSpecialPrice != null)
            {
                if (lineItem.Quantity >= lineItemSpecialPrice.Quantity)
                {
                    //this item qualifies for special price
                    var lineItemSpecialPriceQuantity = lineItem.Quantity / lineItemSpecialPrice.Quantity;
                    var lineItemSpecialPriceRemainder = lineItem.Quantity % lineItemSpecialPrice.Quantity;
                    //calculate total price for special price and remainder
                    var lineItemSpecialPriceTotalPrice = lineItemSpecialPriceQuantity * lineItemSpecialPrice.Price;
                    var lineItemSpecialPriceRemainderTotalPrice = lineItemSpecialPriceRemainder * lineItem.Price;
                    var lineItemSpecialPriceTotalPricePlusRemainderTotalPrice = lineItemSpecialPriceTotalPrice +
                        lineItemSpecialPriceRemainderTotalPrice;
                    lineItemPrice = lineItemSpecialPriceTotalPricePlusRemainderTotalPrice;
                }
            }
            else
            {
                //this item does not qualify for special price
                //final price is quantity * price
                lineItemPrice = lineItem.Quantity * lineItem.Price;
            }
            totalPrice += lineItemPrice;
        }
        return totalPrice;
    }
}