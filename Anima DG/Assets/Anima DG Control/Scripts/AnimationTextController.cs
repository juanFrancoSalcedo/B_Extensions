using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class AnimationTextController : BaseDoAnimationController
{
    public override void ActiveAnimation(string fromDebug = "")
    {

    }
    private RectTransform _rectTransform;
    private TMP_Text _text;

    private new void OnEnable()
    {
        _rectTransform = GetComponent<RectTransform>();
        _text = GetComponent<TMP_Text>();
        base.OnEnable();
    }

    protected new void OnDisable()
    {
        base.OnDisable();
        _rectTransform.DOKill();
        _text.DOKill();
    }
}
