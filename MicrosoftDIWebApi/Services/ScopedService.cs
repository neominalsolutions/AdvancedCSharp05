namespace MicrosoftDIWebApi.Services
{
  public class ScopedService : IService
  {
    public Guid Id { get; set; }

    public ScopedService()
    {
      Id = Guid.NewGuid();
    }
  }
}
