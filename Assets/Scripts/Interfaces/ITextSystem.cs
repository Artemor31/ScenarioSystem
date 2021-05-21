using System;

public interface ITextSystem
{
    event Action<string> Changed;
}