using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataMenuScenario : MonoBehaviour
{
    public DataScenario DataScenario { get; }
    public static DataMenuScenario Data => new DataMenuScenario();
}

public class ScenariosSystem
{
    public ScenariosSystem(DataScenario data)
    {
        var scenario = new ScenarioDefault(data);
        scenario.Start();
    }
}

public class ScenarioDefault : Scenario
{
    private const int FirstStep = 1;
    private Steps _steps;
    
    public ScenarioDefault(DataScenario data)
    {
        _steps = new Steps(data.Steps);
    }

    public override void Start()
    {
        _steps.Change(FirstStep.ToString());
    }
}

public interface ISteper
{
    void Next();
    void Change(string step);
}

public interface IStepChangeNotifable
{
    event Action<Step> Changed;
}


public class Steps : ISteper, IStepChangeNotifable
{
    public event Action<Step> Changed;
        
    private int _index;
    private readonly List<Step> _steps;

    public Steps(IEnumerable<string> steps)
    {
        _steps = steps.Select(nameStep => new Step(nameStep)).ToList();
    }
    
    public void Next()
    {
        SetIndex(_index + 1);
    }

    public void Change(string step)
    {
        Step nextStep = new Step(step);
        SetIndex(_steps.IndexOf(nextStep));
    }

    private void SetIndex(int index)
    {
        _index = index;
        Changed?.Invoke(_steps[_index]);
    } 
}

public struct Step
{
    private IEnumerable<int> _subSteps;
 
    public Step(string step)
    {
        _subSteps = step.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(subStep => int.Parse(subStep));
    }
    
    public bool IsEqual(string step)
    {
        var steps = step.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(subStep => int.Parse(subStep));
        return _subSteps.SequenceEqual(steps);
    }

    public override string ToString()
    {
        return string.Join(".", _subSteps.ToArray());
    }
}

public abstract class Scenario
{
    public abstract void Start();
}

public class DataScenario : ScriptableObject
{
    public int Number => _number;
    public List<string> Steps => _steps;
    public DataTrain Train => _train;
    
    [SerializeField] private int _number;
    [SerializeField] private List<string> _steps;
    [SerializeField] private DataTrain _train;
}

[System.Serializable]
public class DataTrain
{
    public string Name => _name;
    public float Position => _position;
    public string PathName => _pathName;
    
    [SerializeField] private string _name;
    [SerializeField] private float _position;
    [SerializeField] private string _pathName;
}
