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
    [Route("GetCurrentTour")]
    public IActionResult GetTour()
    {
        return Ok(service.GetTour());
    }

    [HttpGet]
    [Route("TryGetTourByDate")]
    public IActionResult TryGetTourByDate(DateTime date)
    {
        var result = service.TryGetTourByDate(date);
        return result != null ? Ok(result) : BadRequest("Tour not found");
    }

    [HttpPost]
    [Route("TryBetForCurrentTour")]
    public IActionResult TryBetForCurrentTour(TourRequest request)
    {
        string message;
        var result = service.TryBetForCurrentTour(request, out message);

        return result == true ? Ok(message) : BadRequest(message);
    }

    [HttpDelete]
    [Route("TryDeleteTour")]
    //berrins void mu olmalı yoksa if eklenip deleted başaşrılı gibi bir şey mi dönmeli?
    public IActionResult TryDeleteTour(long id)
    {
        service.TryDeleteTour(id);
        return Ok();
    }
}