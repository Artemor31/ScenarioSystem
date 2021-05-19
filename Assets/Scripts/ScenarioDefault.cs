public class ScenarioDefault : Scenario
{
    private const int FirstStep = 1;
    private readonly Steps _steps;
    
    public ScenarioDefault(DataScenario data)
    {
        _steps = new Steps(data.Steps);
    }

    public override void Start()
    {
        _steps.Change(FirstStep.ToString());
    }
}