namespace SysproTech.App.Requestses.Product
{
    public class GetProductListModel
    {
        public bool IsDeleted { get; set; } = true;
        public string? Search { get; set; } = null;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public string? SortBy { get; set; } = null;
        public bool IsAscending { get; set; } = true;
    }
}
