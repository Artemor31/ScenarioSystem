using System;

public class TextSystem : ITextSystem
{
    private const string ScenarioKey = "scenario_6";
    
    public event Action<string> Changed;

    public TextSystem(IStepChangeNotifable notifable)
    {
        if (notifable == null) throw new ArgumentException();
        notifable.Changed += Change;
    }
    
    private void Change(Step step)
    {
        Changed?.Invoke(LocalizedControl.GetText(ScenarioKey + step));
    }
}