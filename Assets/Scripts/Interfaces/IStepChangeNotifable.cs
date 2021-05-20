using System;

public interface IStepChangeNotifable
{
    event Action<Step> Changed;
}