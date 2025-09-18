using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


[ApiController]
[Route("[controller]")]
public class FeatureController : ControllerBase
{
    private readonly IOptionsMonitor<FeatureFlags> _flags;

    public FeatureController(IOptionsMonitor<FeatureFlags> flags)
    {
        _flags = flags;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { UseNewCheckout = _flags.CurrentValue.UseNewCheckout });
    }
}