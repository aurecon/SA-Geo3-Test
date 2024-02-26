using Aurecon.Geometry.Converters.Speckle;

namespace Aurecon.SpeckleAutomate.MyFunction;

public interface IRuntime
{
    FunctionInputs Inputs { get; }

    Task<SpeckleDocument> ReadModel();
    Task<SpeckleDocument> ReadModel(string modelName);

    Task WriteModel(string modelName, SpeckleDocument document);

    void SetFailed(string message);
    void SetSuccess(string message);
}