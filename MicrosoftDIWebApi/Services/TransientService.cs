namespace MicrosoftDIWebApi.Services
{
  public class TransientService : IService
  {
    public Guid Id { get; set; }

    public TransientService()
    {
      Id = Guid.NewGuid();
    }
  }
}
