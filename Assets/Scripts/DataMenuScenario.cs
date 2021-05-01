using System.Collections;
using System.Collections.Generic;
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
    public ScenarioDefault(DataScenario data)
    {
    }

    public override void Start()
    {
    }
}


public abstract class Scenario
{
    public abstract void Start();
}

public class DataScenario : ScriptableObject
{
    public int Number => _number;
    public int CountOfSteps => _countOfSteps;
    public List<string> Steps => _steps;
    public DataTrain Train => _train;
    
    [SerializeField] private int _number;
    [SerializeField] private int _countOfSteps;
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
