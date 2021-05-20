using UnityEngine;
using SimpleLocalization;

public class TextSystem
{
    public TextSystem(IStepChangeNotifable notifable)
    {
        notifable.Changed += Change;
    }
    
    private void Change(Step step)
    {
        //SimpleLocalization.GetText("");
    }
}
