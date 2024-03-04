using BuberShop.Services.Shops;
using Microsoft.AspNetCore.Mvc;

namespace BuberShop.Controllers;

[ApiController]
[Route("shop")] // specify parent path for this controller
public class ShopController : ControllerBase
{

    private readonly IShopService _shopService;

    public ShopController(IShopService shopService)
    {
        _shopService = shopService;
    }

    [HttpGet()]
    public IActionResult ListShops()
    {
        var shops = _shopService.ListShops();
        return Ok(shops);
    }
}