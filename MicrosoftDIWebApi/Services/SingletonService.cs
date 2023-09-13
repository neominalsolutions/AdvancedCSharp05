namespace MicrosoftDIWebApi.Services
{
  public class SingletonService : IService
  {
    public Guid Id { get; set; }

    public SingletonService()
    {
      Id = Guid.NewGuid();
    }
  }
}
