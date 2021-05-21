using System;
using UnityEngine;

public class TrainSetup : MonoBehaviour
{
    [SerializeField] private DataScenario _data;

    private void OnEnable()
    {
        new ScenarioServiceInstaller(_data).TextSystemInit<TextSystem>(null);
    }
}


