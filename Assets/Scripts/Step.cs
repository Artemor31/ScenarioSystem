using System;
using System.Linq;
using System.Collections.Generic;

public struct Step
{
    private readonly IEnumerable<int> SubSteps;
 
    public Step(string step) : this()
    {
        if (Steps.IsValidatedStepRegex(step) == false)
            throw new ArgumentException();
        
        SubSteps = GetSteps(step);
    }
    
    public bool IsEqual(string step)
    {
        var steps = GetSteps(step);
        return SubSteps.SequenceEqual(steps);
    }

    public override string ToString()
    {
        return string.Join(StepsHelper.Separator, SubSteps.ToArray());
    }

    private IEnumerable<int> GetSteps(string step)
    {
        return step.Split(new[] { StepsHelper.Separator }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
    }
}