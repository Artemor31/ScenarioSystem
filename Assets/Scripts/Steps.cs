using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Steps : ISteper
{
    public event Action<Step> Changed;
    
    private List<Step> _steps;
    private int _index;

    public Steps(IEnumerable<string> steps)
    {
        if (steps == null || !steps.Any())
            throw new ArgumentException();
        
        _steps = steps.Select(nameStep => new Step(nameStep)).ToList();
    }
    
    public Step Next()
    {
        SetIndex(_index + 1);
        return _steps[_index + 1];
    }

    public Step Change(string step)
    {
        if (IsValidatedStepRegex(step) == false)
            throw new ArgumentException();
        
        Step nextStep = new Step(step);
        SetIndex(_steps.IndexOf(nextStep));
        return _steps[_steps.IndexOf(nextStep)];
    }

    private void SetIndex(int index)
    {
        if (index < 0 || index >= _steps.Count)
            throw new ArgumentException();
        
        _index = index;
        Changed?.Invoke(_steps[_index]);
    }

    public static bool IsValidatedStep(string message)
    {
        return message.All(sym => char.IsDigit(sym) || sym == '.');
    }

    public static bool IsValidatedStepRegex(string message)
    {
        if (string.IsNullOrEmpty(message) == true) 
            return false;
        
        Regex regex = new Regex(@"(^\.)|([^\d|.])");
        var foundChars = regex.IsMatch(message);
        return foundChars == false;
    }
    
    
}