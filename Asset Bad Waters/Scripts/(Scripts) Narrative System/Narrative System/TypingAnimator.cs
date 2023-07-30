using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class TypingAnimator : MonoBehaviour
{
    public TextMeshProUGUI TextCompo => GetComponent<TextMeshProUGUI>();
    [Tooltip("Less is faster")] [Min(0)]
    [SerializeField] private float speedText= 0.4f;
    public event System.Action OnComplitedText;
    Coroutine textAnimation = null;
    private string bufferText = "";
    public bool IsCompleted() => textAnimation == null;
    public void StartAnimation()
    {
        StopAnimation();
        if (gameObject.activeInHierarchy)
            textAnimation = StartCoroutine(ShowPartial());
    }

    public void StartAnimation(string f)
    {
        StopAnimation();
        if (gameObject.activeInHierarchy)
            textAnimation = StartCoroutine(ShowPartial(f));
    }

    public void StopAnimation() 
    {
        if (textAnimation != null)
            StopCoroutine(textAnimation);
        textAnimation = null;
    }

    private IEnumerator ShowPartial(string fullText = "")
    {
        if (string.IsNullOrEmpty(fullText))
            fullText = TextCompo.text;
        bufferText = fullText;
        string currentString;
        for (int i = 0; i < fullText.Length; i++)
        {
            currentString = fullText.Substring(0, i);
            if (currentString.Equals(" "))
                continue;
            TextCompo.text = currentString;
            yield return new WaitForSeconds(speedText);
        }
        Complete();
    }

    private void Complete()
    {
        ShowFullText();
        textAnimation = null;
        OnComplitedText?.Invoke();
    }

    public void ShowFullText() => TextCompo.text = bufferText;
}
