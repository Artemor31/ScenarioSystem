using UnityEngine;

public class DataTrain : ScriptableObject
{
    public float Position => _position;
    public string Name => _name;
    public string PathName => _pathName;
    
    [SerializeField] private string _name;
    [SerializeField] private string _pathName;
    [SerializeField] private float _position;
}