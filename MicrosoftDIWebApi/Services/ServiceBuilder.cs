namespace MicrosoftDIWebApi.Services
{
  public class ServiceBuilder
  {
    private readonly IConfiguration configuration;

    public ServiceBuilder(IConfiguration configuration)
    {
      this.configuration = configuration;
    }
    public IService GetServiceFromConfig()
    {
      IService service = null;

      switch (this.configuration["IService:ServiceType"])
      {
        case "ScopedService":
          service =  new ScopedService();
          break;
        case "TransientService":
          service=  new TransientService();
          break;
        default:
          break;
      }

      return service;
    }
  }
}
