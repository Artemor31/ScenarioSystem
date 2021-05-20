public class ScenarioService
{
    public ScenarioService(DataScenario data)
    {
        var scenario = new ScenarioFactoryDefault().GetScenario(data);
        scenario.Start();
    }
}