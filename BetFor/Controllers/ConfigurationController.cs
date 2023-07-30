using BetFor.Helpers;
using BetFor.Services;
using BetFor.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

[EnableCors("MyPolicy")]
[ApiController]
[Route("api/[controller]")]
public class ConfigurationController : ControllerBase
{
    private readonly IConfigurationService configurationService;

    public ConfigurationController(IConfigurationService configurationService)
    {
        this.configurationService = configurationService;
    }

    [HttpPost]
    [Route("GetConfigurationValue")]
    public async Task<IActionResult> GetConfigurationValue(GetConfigurationValueRequest request)
    {
        Guard.NotNull<GetConfigurationValueRequest>(request);
        return Ok(await configurationService.GetConfigurationValueAsync(request));
    }

    [HttpPost]
    [Route("CreateConfiguration")]
    public async Task<IActionResult> CreateConfiguration(CreateConfigurationRequest request)
    {
        Guard.NotNull<CreateConfigurationRequest>(request);
        return await configurationService.TryCreateConfigurationAsync(request) ? Ok() : BadRequest();
    }

    [HttpPost]
    [Route("UpdateConfiguration")]
    public async Task<IActionResult> UpdateConfiguration(UpdateConfigurationRequest request)
    {
        Guard.NotNull<UpdateConfigurationRequest>(request);
        return await configurationService.TryUpdateConfigurationAsync(request) ? Ok() : BadRequest();
    }

    [HttpPost]
    [Route("DeleteConfiguration")]
    public async Task<IActionResult> DeleteConfiguration(DeleteConfigurationRequest request)
    {
        Guard.NotNull<DeleteConfigurationRequest>(request);
        return await configurationService.TryDeleteConfigurationAsync(request) ? Ok() : BadRequest();
    }
}