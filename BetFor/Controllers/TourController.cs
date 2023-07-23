using BetFor.Context;
using BetFor.Services;
using BetFor.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TourController : ControllerBase
{
    private readonly ITourService service;
    public TourController(ITourService service)
    {
        this.service = service;
    }

    [HttpGet]
    [Route("GetTourInfo")]
    public IActionResult GetTourInfo()
    {
        var result = service.GetTourInfo();

        if (result != null)
        {
            return Ok(result);
        }

        return BadRequest();
    }

    [HttpPost]
    [Route("TryBetForCurrentTour")]
    public IActionResult TryBetForCurrentTour(TourRequest request)
    {
        var result = service.TryBetForCurrentTour(request);

        if (result.HasWinner)
        {
            return Ok(result.Message);
        }

        return BadRequest(result.Message);
    }
}