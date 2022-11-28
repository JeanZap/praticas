using BubberBreakFast.Contracts.BreakFast;
using BubberBreakFast.Models;
using Microsoft.AspNetCore.Mvc;

namespace BubberBreakFast.Controllers;

[ApiController]
[Route("[controller]")]
public class BreakFastsController : ControllerBase
{
    private readonly IBreakfastsService _breakfastService;

    public BreakFastsController(IBreakfastsService breakfastService)
    {
        _breakfastService = breakfastService;
    }

    [HttpPost]
    public IActionResult CreateBreakFast(CreateBreakFastRequest request)
    {
        var breakfast = new Breakfast(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet);

        _breakfastService.CreateBreakFast(breakfast);

        var response = new BreakFastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet);



        return CreatedAtAction(nameof(GetBreakFast), new { id = breakfast.Id }, response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakFast(Guid id)
    {
        var breakfast = _breakfastService.GetBreakfast(id);

        var response = new BreakFastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet);

        return Ok(breakfast);
    }


    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakFast(Guid id, UpsertBreakFastRequest request)
    {
        var breakfast = new Breakfast(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet);

        _breakfastService.UpsertBreakfast(breakfast);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakFast(Guid id)
    {
        _breakfastService.DeleteBreakfast(id);

        return NoContent();
    }
}