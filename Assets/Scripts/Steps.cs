using System;
using System.Collections.Generic;
using System.Linq;

public class Steps : ISteper, IStepChangeNotifable
{
    public event Action<Step> Changed;
    
    private List<Step> _steps;
    private int _index;

    public Steps(IEnumerable<string> steps)
    {
        _steps = steps.Select(nameStep => new Step(nameStep)).ToList();
    }
    
    public List<Step> Next()
    {
        SetIndex(_index + 1);
        return _steps;
    }

    public List<Step> Change(string step)
    {
        Step nextStep = new Step(step);
        SetIndex(_steps.IndexOf(nextStep));
        return _steps;
    }

    private void SetIndex(int index)
    {
        _index = index;
        Changed?.Invoke(_steps[_index]);
    } 
}