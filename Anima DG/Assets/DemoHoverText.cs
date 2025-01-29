using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class DemoHoverText : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    [SerializeField] TMP_Text textComponent;

    DOTweenTMPAnimator animatorText;

    private void Start()
    {
        animatorText = new DOTweenTMPAnimator(textComponent);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }
}
