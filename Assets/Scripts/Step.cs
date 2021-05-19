using System;
using System.Collections.Generic;
using System.Linq;

public struct Step
{
    private IEnumerable<int> _subSteps;
 
    public Step(string step)
    {
        _subSteps = step.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
    }
    
    public bool IsEqual(string step)
    {
        var steps = step.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
        return _subSteps.SequenceEqual(steps);
    }

    public override string ToString()
    {
        return string.Join(".", _subSteps.ToArray());
    }
}