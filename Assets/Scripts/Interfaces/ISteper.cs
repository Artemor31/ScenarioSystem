using System.Collections.Generic;

public interface ISteper : IStepChangeNotifable
{ 
    Step First { get; }
    Step Next();
    Step Change(string step);
    void Change(Step step);
}