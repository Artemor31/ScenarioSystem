using System;

public class ScenarioDefault : IScenario
{
    private readonly ISteper _steps;
    
    public ScenarioDefault(ISteper steps)
    {
        _steps = steps ?? throw new ArgumentException();
    }

    public void Start(Step firstStep)
    {
        _steps.Change(firstStep);
    }
}