using BuberBreakfast.Models;

namespace BuberShop.Services.Shops;

public interface IShopService
{
    ICollection<Shop> ListShops();
}