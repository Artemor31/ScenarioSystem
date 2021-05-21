public class ScenarioService
{
    public ISteper Steps { get; private set; }
    
    private readonly DataScenario _data;

    public ScenarioService(DataScenario data)
    {
        _data = data;
        var scenario = ResolveFactory<ScenarioFactoryDefault>();
        scenario.Start();
    }

    private IScenario ResolveFactory<T>() where T : IScenarioFactory, new()
    {
        var factory = new T();
        Steps = factory.GetSteps(_data.Steps);
        var scenario = factory.GetScenario(Steps);
        
        return scenario;
    }
}