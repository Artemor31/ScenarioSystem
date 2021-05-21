using System;

public class MessageScenarioBridge
{
    private readonly IMessageScenario _messageScenario;
    private readonly ITextSystem _textSystem;
    
    public MessageScenarioBridge(IMessageScenario messageScenario, ITextSystem textSystem)
    {
        _messageScenario = messageScenario;
        _textSystem = textSystem;
        _textSystem.Changed += UpdateText;
    }

    private void UpdateText(string text)
    {
        if (text == null) throw new ArgumentException();
        _messageScenario.SetText(text);
    }
}