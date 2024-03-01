using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;

[ApiController]
[Route("breakfasts")] // specify parent path for this controller
public class BreakfastController : ControllerBase
{
    [HttpPost("")]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {

        // map request body into internal model
        var breakfast = new Breakfast(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );

        // map internal model into response body
        var response = new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet
        );

        return CreatedAtAction(
            // populates the "Location" header for 201 response code
            // https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Location
            actionName: nameof(GetBreakfast),       // derive path from GetBreakfast action
            routeValues: new { id = breakfast.Id }, // "id" is a parameter required by GetBreakfast

            // actual response body
            value: response
        );
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