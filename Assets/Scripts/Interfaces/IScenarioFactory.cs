using System.Collections.Generic;

public interface IScenarioFactory
{
    IScenario GetScenario(ISteper steps);
    ISteper GetSteps(IEnumerable<string> steps);
}