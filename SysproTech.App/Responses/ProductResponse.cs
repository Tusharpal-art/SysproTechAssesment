namespace SysproTech.App.Responses
{
    public record ProductResponse(Guid Id, string Name, string Description, int Quantity, Decimal Price, DateTime CreatedDate, bool IsDeleted, Guid CreatedById);
}
