using System.Collections.Generic;

public interface ISteper : IStepChangeNotifable
{
    Step Next();
    Step Change(string step);
}