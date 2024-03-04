namespace BuberBreakfast.Contracts.Shop
{
    public record ShopResponse(
        int Id,
        string Name,
        string Addres,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );
}