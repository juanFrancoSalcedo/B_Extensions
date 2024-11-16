using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;
using static UnityEngine.GraphicsBuffer;

public class AnimationUIController : BaseDoAnimationController
{
    private RectTransform rectTransform;
    private Image image;

    private new void OnEnable()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        base.OnEnable();
    }

    protected new void OnDisable()
    {
        base.OnDisable();
        rectTransform.DOKill();
        image.DOKill();
    }


    public override void ActiveAnimation(string origen = "")
    {
        if (currentAnimation == 0)
            OnStartedCallBack?.Invoke();

        Sequence sequence = DOTween.Sequence();
        var currentAux = listAux[currentAnimation];
        var delay = currentAux.delay;
        var timeAnim = currentAux.timeAnimation;
        RectTransform atractor = null;
        if (currentAux.atractor != null)
            atractor = (RectTransform)currentAux.atractor.transform;
        else
            atractor = (RectTransform)transform;

        var targetPos = (currentAux.atractor != null) ? (Vector3)atractor.localPosition : currentAux.targetPosition;
        if (currentAux.displayPosition)
            sequence.Insert(0, rectTransform.DOLocalMove(targetPos, timeAnim).
                SetEase(currentAux.animationCurve).SetDelay(delay).
                SetLoops(currentAux.loops).SetUpdate(!useTimeScale));
        if (currentAux.displayScale)
            sequence.Insert(0, rectTransform.DOScale(currentAux.targetScale, timeAnim).
                SetEase(currentAux.animationCurve).SetDelay(delay).
                SetLoops(currentAux.loops).SetUpdate(!useTimeScale));
        if (currentAux.displayTexture)
            sequence.Insert(0, image.DOFade(1, timeAnim).
                SetEase(currentAux.animationCurve).
                SetDelay(currentAux.delay).SetLoops(currentAux.loops).
                OnComplete(delegate { image.sprite = currentAux.spriteShift; }).SetUpdate(!useTimeScale));
        if (currentAux.displayRotation)
            sequence.Insert(0, rectTransform.DORotate(currentAux.targetRotation, timeAnim, RotateMode.FastBeyond360).
                SetEase(currentAux.animationCurve).
                SetDelay(currentAux.delay).
                SetLoops(currentAux.loops)
                .SetUpdate(!useTimeScale));
        if (currentAux.displayColor)
            sequence.Insert(0, image.DOColor(currentAux.colorTarget, timeAnim).
                SetEase(currentAux.animationCurve).
                SetDelay(currentAux.delay).
                SetLoops(currentAux.loops)
                .SetUpdate(!useTimeScale));
        if (currentAux.displaySizeDelta)
            sequence.Insert(0, rectTransform.DOSizeDelta(currentAux.targetSizeDelta, timeAnim).
                SetEase(currentAux.animationCurve).
                SetDelay(currentAux.delay).
                SetLoops(currentAux.loops)
                .SetUpdate(!useTimeScale));

        if (currentAux.displayPixelMultiplier)
            sequence.Insert(0, DOTween.To(() => image.pixelsPerUnitMultiplier, juu => image.pixelsPerUnitMultiplier = juu, currentAux.pixelMultiplier,
                currentAux.timeAnimation).SetEase(currentAux.animationCurve).SetDelay(currentAux.delay).
                SetLoops(currentAux.loops).OnComplete(() => { StopCoroutine(UpdatePixelPerUnit()); }).SetUpdate(!useTimeScale).
                OnPlay(() => StartCoroutine(UpdatePixelPerUnit())));

        if (currentAux.displayFade)
        {
            if (currentAux.applyOnCanvasGroup)
            {
                var canvasGroup = GetComponent<CanvasGroup>();
                sequence.Insert(0, DOTween.To(() => canvasGroup.alpha, juu => canvasGroup.alpha = juu, currentAux.fadeTarget, timeAnim).
                    SetEase(currentAux.animationCurve).
                    SetDelay(currentAux.delay).
                    SetLoops(currentAux.loops).SetUpdate(!useTimeScale));

            }
            else
            {
                sequence.Insert(0, image.DOFade(currentAux.fadeTarget, currentAux.timeAnimation).
                    SetEase(currentAux.animationCurve).SetDelay(delay).
                    SetLoops(currentAux.loops).SetUpdate(!useTimeScale));
            }
        }

        sequence.OnComplete(CallBacks);
    }

    private IEnumerator UpdatePixelPerUnit()
    {
        while (gameObject.activeInHierarchy)
        {
            image.SetAllDirty();
            yield return new WaitForEndOfFrame();
        }
    }

}

