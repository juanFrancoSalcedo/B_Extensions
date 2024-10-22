using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSkipDialogue : MonoBehaviour
{
    [SerializeField] private CinematicController cinematicController = null;

    Button button => GetComponent<Button>();
    private void Start() => button.onClick.AddListener(Skip);

    private void Skip()
    {
        if (!cinematicController.dialogue.IsCompleted())
        {
            cinematicController.dialogue.ShowFullText();
            cinematicController.dialogue.StopAnimation();
        }
        else
            cinematicController.NextSequence();

    }
}
