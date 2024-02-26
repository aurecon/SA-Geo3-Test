using Aurecon.Geometry.Converters.Speckle;
using Speckle.Automate.Sdk;

namespace Aurecon.SpeckleAutomate.MyFunction;

public class SpeckleRuntime : IRuntime
{
    protected readonly AutomationContext _context;
    protected readonly SpeckleApi _api;
    protected readonly SpeckleSerializer _serializer;

    protected readonly string _projectId;
    protected readonly string _branchName;

    public FunctionInputs Inputs { get; }

    public SpeckleRuntime(AutomationContext context, FunctionInputs inputs)
    {
        _context = context;
        Inputs = inputs;

        _projectId = context.AutomationRunData.ProjectId;
        _branchName = context.AutomationRunData.BranchName;

        string serverUrl = context.AutomationRunData.SpeckleServerUrl;
        string token = context.SpeckleClient.Account.token;

        _api = new(token, serverUrl);
        _serializer = new(token, serverUrl);
    }

    public Task<SpeckleDocument> ReadModel()
    {
        return _serializer.ReadBranch(_projectId, _branchName, default);
    }

    public Task<SpeckleDocument> ReadModel(string modelName)
    {
        return _serializer.ReadBranch(_projectId, modelName, default);
    }

    public Task WriteModel(string modelName, SpeckleDocument document)
    {
        return _serializer.WriteCommit(_projectId, modelName, document, "Automated Commit From Speckle Automate", default);
    }

    public void SetFailed(string message) => _context.MarkRunFailed(message);
    public void SetSuccess(string message) => _context.MarkRunSuccess(message);
}