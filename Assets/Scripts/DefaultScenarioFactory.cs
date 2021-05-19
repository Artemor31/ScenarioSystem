
public class DefaultScenarioFactory : ScenarioFactory
{
    public override Scenario GetScenario(DataScenario data)
    {
        return new ScenarioDefault(data);
    }
}