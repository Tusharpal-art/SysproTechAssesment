namespace SysproTech.App.Requestses.Product
{
    public class AddProductModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int? MinimumQuantity { get; set; } = 0;
        public string? Category { get; set; } = String.Empty;
    }
}
