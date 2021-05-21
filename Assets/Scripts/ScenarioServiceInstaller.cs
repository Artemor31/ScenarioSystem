using System;
using UnityEngine;

public class ScenarioServiceInstaller
{
    private readonly ScenarioService _scenarioService;  
    
    public ScenarioServiceInstaller(DataScenario data)
    {
        if (data == null) throw new ArgumentException();
        _scenarioService = new ScenarioService(data);
    }

    public ScenarioServiceInstaller TextSystemInit<T>(IMessageScenario messageScenario) where T : ITextSystem
    {
        if (messageScenario == null) throw new ArgumentException();
        
        var textSystem = new TextSystem(_scenarioService.Steps);
        var messageBridge = new MessageScenarioBridge(messageScenario, textSystem);
        return this;
    }
}

