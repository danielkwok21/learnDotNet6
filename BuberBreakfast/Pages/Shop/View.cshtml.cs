using Microsoft.AspNetCore.Mvc.RazorPages;
using BuberBreakfast.Models;

namespace BuberBreakfast.Pages.Shops;

public class ShopPageModel : PageModel
{
    private readonly Data.DataContext _context;

    public ShopPageModel(Data.DataContext context)
    {
        _context = context;
    }

    public IList<Shop> Shops { get; set; } = default!;

    public void Onget()
    {
        Shops = _context.Shops.ToList();
    }
}