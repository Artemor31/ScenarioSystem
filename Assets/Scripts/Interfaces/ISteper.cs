using System.Collections.Generic;

public interface ISteper
{
    List<Step> Next();
    List<Step> Change(string step);
}