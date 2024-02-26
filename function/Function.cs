using System.ComponentModel.DataAnnotations;
using Speckle.Automate.Sdk;

namespace Aurecon.SpeckleAutomate.MyFunction;

public struct FunctionInputs
{
    [Required]
    public string TargetModelName;
}

public static class AutomateFunction
{
    public static async Task Run(IRuntime runtime)
    {
        runtime.SetSuccess("Cooking with gas...");
    }
}