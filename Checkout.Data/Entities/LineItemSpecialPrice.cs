namespace Checkout.Data.Entities;

public class LineItemSpecialPrice
{
    public int Id { get; set; }
    public int Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DateTime ExpiresOn { get; set; }
}