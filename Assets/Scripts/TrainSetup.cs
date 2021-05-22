using System;
using UnityEngine;

public class TrainSetup : MonoBehaviour
{
    [SerializeField] private DataScenario _data;

    private void OnEnable()
    {
        var installer = new ScenarioServiceInstaller(_data);
        var steps = installer.Service.Steps;
        var textSystem = new TextSystem(steps);
        
        installer.TextSystemInit(textSystem, null);
    }
}


