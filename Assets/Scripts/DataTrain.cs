using UnityEngine;

public class DataTrain : ScriptableObject
{
    public float Position => _position;
    public string Name => _name;
    public string SplineName => _splineName;
    
    [SerializeField] private string _name;
    [SerializeField] private string _splineName;
    [SerializeField] private float _position;
}