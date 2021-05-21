using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ScenarioFactoryDefault : IScenarioFactory
{
    public ISteper GetSteps(IEnumerable<string> steps)
    {
        if (steps == null || !steps.Any()) throw new ArgumentException();
        return new Steps(steps);
    }
    
    public IScenario GetScenario(ISteper steps)
    {
        if (steps == null) throw new ArgumentException();
        return new ScenarioDefault(steps);
    }
}