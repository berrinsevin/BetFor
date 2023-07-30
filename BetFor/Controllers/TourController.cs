using BetFor.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

[EnableCors("MyPolicy")]
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
    public async Task<IActionResult> GetTourInfo()
    {
        var result = await service.GetCurrentTourAsync();

        if (result != null)
        {
            return Ok(result);
        }

        return BadRequest();
    }

    // [HttpPost]
    // [Route("TryBetForCurrentTour")]
    // public IActionResult TryBetForCurrentTour(TourRequest request)
    // {
    //     var result = service.TryBetForCurrentTour(request);

    //     if (result.HasWinner)
    //     {
    //         return Ok(result.Message);
    //     }

    //     return BadRequest(result.Message);
    // }
}