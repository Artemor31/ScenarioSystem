using UnityEngine;

public class DataMenuScenario : MonoBehaviour
{
    public DataScenario DataScenario { get; }
    public static DataMenuScenario Data => new DataMenuScenario();
}