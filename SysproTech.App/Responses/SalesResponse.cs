namespace SysproTech.App.Responses
{
    public class SalesResponse
    {
        public int Id { get; set; }
        public Guid? OrderbyId { get; set; }
        public Decimal? TotalPrice { get; set; } = 0;
        public decimal UnitPrice { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public Guid? ProductId { get; set; }
        public virtual ProductResponse? Product { get; set; }
        public int ProductCount { get; set; } = 0;
    }
}
