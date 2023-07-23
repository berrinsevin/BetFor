using BetFor.Dtos;
using BetFor.Services;
using BetFor.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService service;
    public ClientController(IClientService service)
    {
        this.service = service;
    }

    [HttpPost]
    [Route("CreateClient")]
    //berrins if ile başarılı/başarısız sonuç döndürülsün mü
    public void CreateClient(Client client)
    {
        service.TryCreateClient(client);
    }

    [HttpPost]
    [Route("UpdateClient")]
    //berrins if ile başarılı/başarısız sonuç döndürülsün mü
    public void UpdateClient(UpdateClientDto client)
    {
        service.TryUpdateClient(client);
    }

    [HttpGet]
    [Route("TryGetClientById")]
    public IActionResult TryGetClientById(long id)
    {
        var client = service.TryGetClientById(id);
        return client != null ? Ok(client) : BadRequest("Client not found");
    }

    [HttpDelete]
    [Route("TryDeleteClient")]
    public void TryDeleteClient(long id)
    {
        service.TryDeleteClient(id);
    }
}