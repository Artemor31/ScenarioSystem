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

    public override bool Equals(object obj)
    {
        if (obj == null) return false;

        if (obj is string str)
            return SubSteps.SequenceEqual(GetSteps(str));

        return obj.ToString() == ToString();
    }

    public override string ToString()
    {
        return string.Join(StepsHelper.Separator, SubSteps.ToArray());
    }

    private IEnumerable<int> GetSteps(string step)
    {
        return step.Split(new[] { StepsHelper.Separator }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(value => int.TryParse(value, out var temp) ? temp : throw new ArgumentOutOfRangeException());
        
    }
}