using Aurecon.Geometry.Converters.Speckle;
using Aurecon.SpeckleAutomate.MyFunction;

namespace tests;

public class FakeRuntime : IRuntime
{
    public FunctionInputs Inputs { get; }

    protected Dictionary<string, SpeckleDocument> _otherModels;
    protected SpeckleDocument _model;

    public string? SuccessMessage;
    public string? FailedMessage;

    public FakeRuntime(FunctionInputs inputs, SpeckleDocument model, Dictionary<string, SpeckleDocument> otherModels)
    {
        Inputs = inputs;
        _model = model;
        _otherModels = otherModels;

        SuccessMessage = null;
        FailedMessage = null;
    }

    public FakeRuntime(FunctionInputs inputs, SpeckleDocument model) : this(inputs, model, new Dictionary<string, SpeckleDocument>()) { }

    public Task<SpeckleDocument> ReadModel()
    {
        return Task.FromResult(_model);
    }

    public Task<SpeckleDocument> ReadModel(string modelName)
    {
        if (_otherModels.TryGetValue(modelName, out SpeckleDocument? doc))
            return Task.FromResult(doc);

        return Task.FromResult(new SpeckleDocument());
    }

    public Task WriteModel(string modelName, SpeckleDocument document)
    {
        _otherModels[modelName] = document;
        return Task.CompletedTask;
    }

    public SpeckleDocument GetModel(string name)
    {
        return _otherModels[name];
    }

    public void SetFailed(string message)
    {
        FailedMessage = message;
        SuccessMessage = null;
    }

    public void SetSuccess(string message)
    {
        SuccessMessage = message;
        FailedMessage = null;
    }
}