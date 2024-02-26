using System.ComponentModel.DataAnnotations;
using Aurecon.CoDe.Geometry;
using Aurecon.Geometry.Converters.Speckle;

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
        List<Point3d> points = new() {
            new(0, 0, 0),
            new(1, 5, 0),
            new(2, 0, 0),
            new(3, 1, 1),
            new(4, 1, 5),
        };

        Polyline polyline = new(points);
        SpeckleDocument document = new("Geo3 Test")
        {
            polyline.AsSpeckleGeometry()
        };

        await runtime.WriteModel(runtime.Inputs.TargetModelName, document);
        runtime.SetSuccess("Cooking with gas...");
    }
}