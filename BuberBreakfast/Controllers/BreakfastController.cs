using BuberBreakfast.Contracts.Breakfast;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;

[ApiController]
[Route("breakfasts")] // specify parent path for this controller
public class BreakfastController : ControllerBase
{
    [HttpPost("")]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {
         Console.WriteLine(request);
        return Ok(request);
    }
    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
        return Ok(id);        
    }
    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(UpsertBreakfastRequest request)
    {
        return Ok(request);        
    }
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        return Ok(id);        
    }
}