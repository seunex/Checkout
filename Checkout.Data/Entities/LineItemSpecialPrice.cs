namespace Checkout.Data.Entities;

public class LineItemSpecialPrice
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    //In Real world application, ExpiresOn will allow us to know if the special price is still valid or not
    public DateTime? ExpiresOn { get; set; }
}