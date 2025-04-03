using UGB.Infrastructure.Interfaces;
namespace UGB.MSTest;

[TestClass]
public sealed class Test1
{
    private static WebApplicationFactory<Program> _factory = null;
    private readonly IEmailServiceInterface emailServiceInterface;
    public Test1(TestContext _)
    {
        _factory = new CustomWebAplicationFactory();
        emailServiceInterface = _factory.Services.GetRequiredService<IEmailServiceInterface>();
    }

    [TestMethod]
    public void TestMethod1()
    {

    }
}
