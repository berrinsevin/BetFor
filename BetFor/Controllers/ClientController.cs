using BetFor.Helpers;
using BetFor.Services;
using BetFor.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

[EnableCors("MyPolicy")]
[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService clientService;

    public ClientController(IClientService clientService)
    {
        this.clientService = clientService;
    }

    [HttpPost]
    [Route("GetClient")]
    public async Task<IActionResult> GetClient(GetClientRequest request)
    {
        Guard.NotNull<GetClientRequest>(request);
        return Ok(await clientService.GetClientAsync(request));
    }

    [HttpPost]
    [Route("CreateClient")]
    public async Task<IActionResult> CreateClient(CreateClientRequest request)
    {
        Guard.NotNull<CreateClientRequest>(request);
        return await clientService.TryCreateClientAsync(request) ? Ok() : BadRequest();
    }

    [HttpPost]
    [Route("UpdateClient")]
    public async Task<IActionResult> UpdateClient(UpdateClientRequest request)
    {
        Guard.NotNull<UpdateClientRequest>(request);
        return await clientService.TryUpdateClientAsync(request) ? Ok() : BadRequest();
    }

    [HttpPost]
    [Route("DeleteClient")]
    public async Task<IActionResult> DeleteClient(DeleteClientRequest request)
    {
        Guard.NotNull<DeleteClientRequest>(request);
        return await clientService.TryDeleteClientAsync(request) ? Ok() : BadRequest();
    }

    [HttpPost]
    [Route("CreateBet")]
    public async Task<IActionResult> CreateBet(CreateBetRequest request)
    {
        Guard.NotNull<CreateBetRequest>(request);
        var response = await clientService.CreateBetAsync(request);

        if (response.IsCreated == true)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }

    [HttpPost]
    [Route("GetBetResultList")]
    public async Task<IActionResult> GetBetResultList(GetBetResultRequest request)
    {
        Guard.NotNull<GetBetResultRequest>(request);
        return Ok(await clientService.GetBetResultListAsync(request));
    }
}