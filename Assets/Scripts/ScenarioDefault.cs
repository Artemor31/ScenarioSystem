using System;

public class ScenarioDefault : IScenario
{
    private const int FirstStep = 1;
    private readonly ISteper _steps;
    
    public ScenarioDefault(ISteper steps)
    {
        _steps = steps ?? throw new ArgumentException();
    }

    public void Start()
    {
        _steps.Change(FirstStep.ToString());
    }
}