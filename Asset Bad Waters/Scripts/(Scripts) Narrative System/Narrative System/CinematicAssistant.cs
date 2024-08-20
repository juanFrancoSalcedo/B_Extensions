using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEditor;

public abstract partial class CinematicAssistant : MonoBehaviour
{
    [field:SerializeField] public CinematicController Control { get; set; }
    [SerializeField] protected float delayAction = 0.6f;
    [SerializeField] protected float delayCut = 0.6f;
    public UnityEvent OnCompletedMission;

    public abstract void Action();
    public abstract void Cut();

    private void Start()
    {
        if (Control == null)
            Control = GetComponentInParent<CinematicController>();
    }

    public void StartSecuence() => Invoke(nameof(Action),delayAction);
    public void FinishSecuence() => Finish();
    private void Finish() 
    {
        OnCompletedMission?.Invoke();
        Control.NextSequence();
    }

    public void BackController()
    {
        bool disableAfter = false;
        if (!Control.gameObject.activeInHierarchy)
        {
            Control.gameObject.SetActive(true);
            disableAfter = true;
        }

#if UNITY_EDITOR
        Selection.activeObject = Control.gameObject;
#endif
        if (disableAfter) Control.gameObject.SetActive(false);
    }

    public void FindControl()
    {
        Control = transform.parent.GetComponent<CinematicController>();
        Control = GetComponentInParent<CinematicController>();
    }
}
