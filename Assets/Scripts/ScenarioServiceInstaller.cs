using System;
using UnityEngine;

public class ScenarioServiceInstaller
{
    public ScenarioService Service => _service;  
    private readonly ScenarioService _service;  
    
    public ScenarioServiceInstaller(DataScenario data)
    {
        if (data == null) throw new ArgumentException();
        _service = new ScenarioService(data);
    }

    public ScenarioServiceInstaller TextSystemInit(ITextSystem textSystem, IMessageScenario messageScenario)
    {
        if (messageScenario == null) throw new ArgumentException();
        var messageBridge = new MessageScenarioBridge(messageScenario, textSystem);
        
        return this;
    }
}

