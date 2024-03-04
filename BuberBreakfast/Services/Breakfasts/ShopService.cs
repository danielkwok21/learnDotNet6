using BuberBreakfast.Data;
using BuberBreakfast.Models;
using BuberShop.Services.Shops;

namespace BuberBreakfast.Services.ShopService
{
    public class ShopService : IShopService
    {
        private readonly DataContext _context;

        public ShopService(DataContext context)
        {
            _context = context;
        }

        public ICollection<Shop> ListShops()
        {
            return _context.Shops.ToList();
        }
    }
}