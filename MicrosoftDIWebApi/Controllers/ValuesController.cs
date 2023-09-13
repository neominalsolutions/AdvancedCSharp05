using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MicrosoftDIWebApi.Services;
using System.Runtime.CompilerServices;

namespace MicrosoftDIWebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
    // Logger service
    private readonly IService service;

    public ValuesController(IService service)
    {
      this.service = service;
    }

    [HttpGet]
    public IActionResult GetResult()
    {
      try
      {

        var response = new { nameOf = this.service.GetType().Name };
        return Ok(response);
      }
      catch (Exception ex)
      {

        throw;
      }



     
    }
  }
}
