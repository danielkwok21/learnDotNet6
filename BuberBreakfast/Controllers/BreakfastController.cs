using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfasts;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;

[ApiController]
[Route("breakfasts")] // specify parent path for this controller
public class BreakfastController : ControllerBase
{

    private readonly IBreakfastService _breakfastService;

    public BreakfastController(IBreakfastService breakfastService)
    {
        _breakfastService = breakfastService;
    }

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

        // save to db
        _breakfastService.CreateBreakfast(breakfast);

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

        var breakfast = _breakfastService.GetBreakfast(id);

        if (breakfast == null)
        {
            return NotFound();
        }
        else
        {
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
            return Ok(response);
        };
    }
    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, Breakfast breakfast)
    {
        var isCreated = _breakfastService.UpsertBreakfast(id, breakfast);
        if (isCreated)
        {
            return CreatedAtAction(
                actionName: nameof(GetBreakfast),
                routeValues: new { id },
                value: null
            );
        }

        return NoContent();
    }
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        _breakfastService.DeleteBreakfast(id);

        return NoContent();
    }

    [HttpGet()]
        public IActionResult ListBreakfast()
    {
        var breakfasts = _breakfastService.ListBreakfast();
        return Ok(breakfasts);
    }
}