using Aurecon.Geometry.Converters.Speckle;
using Aurecon.SpeckleAutomate.MyFunction;

namespace tests;

public class BaseTests
{
    private FakeRuntime _runtime;

    public BaseTests()
    {
        _runtime = new FakeRuntime(new FunctionInputs()
        {
            TargetModelName = "Hello",
        }, new SpeckleDocument("World"));
    }

    [Fact]
    public async Task Test1()
    {
        await AutomateFunction.Run(_runtime);
        _runtime.SuccessMessage.Should().NotBeNull();
    }
}