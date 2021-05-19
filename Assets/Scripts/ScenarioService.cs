public class ScenarioService
{
    public ScenarioService(DataScenario data)
    {
        var scenario = new DefaultScenarioFactory().GetScenario(data);
        scenario.Start();
    }
}