using UnityEngine;

public class DialogueCineAssistant : CinematicAssistant
{
    [TextArea(2,3)]
    public string textToShow;
    private void OnEnable() => Control.dialogue.OnComplitedText += Cut;

    private void OnDisable() => Control.dialogue.OnComplitedText -= Cut;

    public override void Action() => Control.dialogue.StartAnimation(textToShow);
    public override void Cut() => Invoke(nameof(FinishSecuence), delayCut);
}