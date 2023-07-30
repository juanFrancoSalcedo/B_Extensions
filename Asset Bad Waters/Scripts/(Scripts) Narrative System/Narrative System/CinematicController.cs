using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CinematicController : MonoBehaviour
{
    [field: SerializeField] public bool StartOnEnable { get; set; } = true;
    public TypingAnimator dialogue;
    public List<CinematicAssistant> missionAnimations = new List<CinematicAssistant>();
    [SerializeField] private UnityEvent OnCompleted;
    //TODO solve this
    public int misionIndex = 0;
    public int IDLastButtonAssistants { get; set; } = 0;

    private void Start()
    {
        if (StartOnEnable)
            StartSecuence();
    }
    public void StartSecuence() => missionAnimations[misionIndex].StartSecuence();

    public void NextSequence()
    {
        print("arrive");
        if (misionIndex>= missionAnimations.Count || misionIndex+1 >= missionAnimations.Count)
        {
            OnCompleted?.Invoke();
            return;
        }
        misionIndex++;
        missionAnimations[misionIndex].StartSecuence();
    }
    public void InstanciateDialogueAssitant<T>()
    {
        GameObject gameAssis = new GameObject();
        gameAssis.transform.SetParent(transform);
        gameAssis.AddComponent(typeof(T));

        CinematicAssistant assitant = gameAssis.GetComponent<CinematicAssistant>();
        missionAnimations.Add(assitant);
        assitant.Control = this;
        gameAssis.name = "dialogue " + missionAnimations.IndexOf(assitant);
    }

    public void DeleteAllMissions()
    {
        missionAnimations.Clear();
        for (int i=0; i< transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

}

public enum SideCharacter
{
    None,
    Left,
    Right
}

public enum LanguageCharacter
{
    Tarbla,
    Deosumicio,
    Narrador
}

