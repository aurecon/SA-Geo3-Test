using Aurecon.SpeckleAutomate.MyFunction;
using Objects;
using Speckle.Automate.Sdk;

return await AutomationRunner
    .Main<FunctionInputs>(args, (context, inputs) =>
    {
        _ = typeof(ObjectsKit).Assembly; // INFO: Force objects kit to initialize

        IRuntime speckleRuntime = new SpeckleRuntime(context, inputs);

        return AutomateFunction.Run(speckleRuntime);
    })
    .ConfigureAwait(false);