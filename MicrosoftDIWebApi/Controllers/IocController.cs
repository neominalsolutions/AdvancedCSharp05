using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MicrosoftDIWebApi.Services;

namespace MicrosoftDIWebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class IocController : ControllerBase
  {
    // IOC ilgili servis instancelarını uygulama genelinde Dependency Injection ile kullanmak için, otomatik olarak alır.
    // Tabi bu servis tanımlarını Program dosyasında ServiceCollection içerisine eklemeliyiz.

    private readonly ScopedService s1;
    private readonly ScopedService s2;
    private readonly TransientService t1;
    private readonly TransientService t2;
    private readonly SingletonService sp1;
    private readonly SingletonService sp2;


    public IocController(ScopedService s1, ScopedService s2, TransientService t1, TransientService t2, SingletonService sp1, SingletonService sp2)
    {
      this.s1 = s1;
      this.s2 = s2;
      this.t1 = t1;
      this.t2 = t2;
      this.sp1 = sp1;
      this.sp2 = sp2;
    }

    [HttpGet]
    public IActionResult GetResult()
    {
      var response = new { scoped1 = s1.Id, scoped2 = s2.Id, transient1 = t1.Id, transient2 = t2.Id, singleton1 = sp1.Id, singleton2 = sp2.Id };

      return Ok(response);
    }
  }
}
