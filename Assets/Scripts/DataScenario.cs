using System.Collections.Generic;
using UnityEngine;

public class DataScenario : ScriptableObject
{
    public int Number => _number;
    public List<string> Steps => _steps;
    public DataTrain Train => _train;
    
    [SerializeField] private int _number;
    [SerializeField] private List<string> _steps;
    [SerializeField] private DataTrain _train;
}