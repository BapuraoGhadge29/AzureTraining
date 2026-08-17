using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LoanApiController : ControllerBase
{
    private readonly IConfiguration _config;

    public LoanApiController(IConfiguration config)
    {
        _config = config;
    }

    [HttpGet]
    [HttpGet]
public IActionResult Get()
{
    var products = new List<object>
    {
        new { Id = 1, Name = "Laptop", Price = 50000 },
        new { Id = 2, Name = "Mobile", Price = 25000 },
        new { Id = 3, Name = "Tablet", Price = 30000 }
    };

    return Ok(products);
}
}