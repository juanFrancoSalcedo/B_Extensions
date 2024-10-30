using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;
using static UnityEngine.GraphicsBuffer;

public class AnimationUIController : DoAnimationController
{
    private RectTransform rectTransform;
    private Image image;
    private Sprite spriteOriginal;

    private new void OnEnable()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        originPosition = rectTransform.anchoredPosition;
        originScale = rectTransform.localScale;
        if (image) spriteOriginal = image.sprite;
        base.OnEnable();
    }

    protected new void OnDisable()
    {
        base.OnDisable();
        rectTransform.DOKill();
        image.DOKill();
    }

    protected override void RestorePosition()
    {
        rectTransform.anchoredPosition = originPosition;
    }

    public override void ActiveAnimation()
    {
        if (currentAnimation == 0)
        {
            OnStartedCallBack?.Invoke();
        }

        Sequence sequence = DOTween.Sequence();
        var currentAux = listAux[currentAnimation];
        var delay = currentAux.delay;
        var timeAnim = currentAux.timeAnimation;
        RectTransform atractor = null;
        if (currentAux.atractor != null)
            atractor = (RectTransform)currentAux.atractor.transform;
        else
            atractor = (RectTransform)transform;

        var targetPos = (currentAux.atractor != null) ? (Vector3)atractor.anchoredPosition : currentAux.targetPosition;

        if (currentAux.useSequence)
        {
            if (currentAux.displayPosition)
                sequence.Append(rectTransform.DOLocalMove(targetPos, timeAnim).
                    SetEase(currentAux.animationCurve).
                    SetDelay(currentAux.delay).
                    SetLoops(currentAux.loops).
                    OnComplete(CallBacks).SetUpdate(!useTimeScale));
            if (currentAux.displayScale)
                sequence.Append(rectTransform.DOScale(currentAux.targetScale, timeAnim).
                    SetEase(currentAux.animationCurve).
                    SetDelay(currentAux.delay).
                    SetLoops(currentAux.loops).
                    OnComplete(CallBacks).SetUpdate(!useTimeScale));
            if (currentAux.displayTexture)
                sequence.Append(image.DOFade(1, timeAnim).
                    SetEase(currentAux.animationCurve).
                    SetDelay(currentAux.delay).
                    SetLoops(currentAux.loops).
                    OnComplete(delegate { CallBacks(); image.sprite = currentAux.spriteShift; }).SetUpdate(!useTimeScale));
            if (currentAux.displayRotation)
                sequence.Append(rectTransform.DORotate(currentAux.targetRotation, timeAnim, RotateMode.LocalAxisAdd).
                    SetEase(currentAux.animationCurve).
                    SetDelay(currentAux.delay).
                    SetLoops(currentAux.loops).
                    OnComplete(CallBacks).SetUpdate(!useTimeScale));
            if (currentAux.displayColor)
                sequence.Append(image.DOColor(currentAux.colorTarget, timeAnim).
                    SetEase(currentAux.animationCurve).
                    SetDelay(currentAux.delay).
                    SetLoops(currentAux.loops).
                    OnComplete(CallBacks).SetUpdate(!useTimeScale));
            if (currentAux.displaySizeDelta)
                sequence.Append(rectTransform.DOSizeDelta(currentAux.targetSizeDelta, timeAnim).
                    SetDelay(currentAux.delay).
                    SetLoops(currentAux.loops).
                    OnComplete(CallBacks).SetUpdate(!useTimeScale));

            if (currentAux.displayPixelMultiplier)
                sequence.Append(DOTween.To(() => this.image.pixelsPerUnitMultiplier, juu => this.image.pixelsPerUnitMultiplier = juu, currentAux.pixelMultiplier,
                    currentAux.timeAnimation).SetEase(currentAux.animationCurve).SetDelay(currentAux.delay).
                    SetLoops(currentAux.loops).OnComplete(() => { CallBacks(); StopCoroutine(UpdatePixelPerUnit()); }).SetUpdate(!useTimeScale).
                    OnPlay(() => StartCoroutine(UpdatePixelPerUnit())));

            if (currentAux.displayFade)
            {
                if (currentAux.applyOnCanvasGroup)
                {
                    var canvasGroup = GetComponent<CanvasGroup>();
                    sequence.Append(DOTween.To(() => canvasGroup.alpha, juu => canvasGroup.alpha = juu, currentAux.fadeTarget, timeAnim).
                    SetEase(currentAux.animationCurve).
                    SetDelay(currentAux.delay).
                    SetLoops(currentAux.loops).OnComplete(CallBacks).SetUpdate(!useTimeScale));

                }
                else
                {
                    sequence.Append(image.DOFade(currentAux.fadeTarget, currentAux.timeAnimation).
                        SetEase(currentAux.animationCurve).SetDelay(currentAux.delay).
                        SetLoops(currentAux.loops).SetUpdate(!useTimeScale));
                }
            }
        }
        else
        {
            if (currentAux.displayPosition)
                sequence.Insert(delay, rectTransform.DOLocalMove(targetPos, timeAnim).
                    SetEase(currentAux.animationCurve).
                    SetLoops(currentAux.loops).
                    OnComplete(CallBacks).
                    SetUpdate(!useTimeScale));

            if (currentAux.displayScale)
                sequence.Insert(delay, rectTransform.DOScale(currentAux.targetScale, timeAnim).
                    SetEase(currentAux.animationCurve).
                    SetLoops(currentAux.loops).
                    OnComplete(CallBacks).SetUpdate(!useTimeScale));
            if (currentAux.displayTexture)
                sequence.Insert(delay, image.DOFade(1, timeAnim).
                    SetEase(currentAux.animationCurve).
                    SetDelay(currentAux.delay).
                    SetLoops(currentAux.loops).
                    OnComplete(delegate { CallBacks(); image.sprite = currentAux.spriteShift; }).SetUpdate(!useTimeScale));
            if (currentAux.displayRotation)
                sequence.Insert(delay, rectTransform.DORotate(currentAux.targetRotation, timeAnim, RotateMode.LocalAxisAdd).
                    SetEase(currentAux.animationCurve).
                    SetDelay(currentAux.delay).
                    SetLoops(currentAux.loops).
                    OnComplete(CallBacks).SetUpdate(!useTimeScale));
            if (currentAux.displayColor)
                sequence.Insert(delay, image.DOColor(currentAux.colorTarget, timeAnim).
                    SetEase(currentAux.animationCurve).
                    SetDelay(currentAux.delay).
                    SetLoops(currentAux.loops).
                    OnComplete(CallBacks).SetUpdate(!useTimeScale));
            if (currentAux.displaySizeDelta)
                sequence.Insert(delay, rectTransform.DOSizeDelta(currentAux.targetSizeDelta, timeAnim).
                    SetEase(currentAux.animationCurve).
                    SetDelay(currentAux.delay).
                    SetLoops(currentAux.loops).
                    OnComplete(CallBacks).SetUpdate(!useTimeScale));

            if (currentAux.displayPixelMultiplier)
                sequence.Insert(delay, DOTween.To(() => image.pixelsPerUnitMultiplier, juu => image.pixelsPerUnitMultiplier = juu, currentAux.pixelMultiplier,
                    currentAux.timeAnimation).SetEase(currentAux.animationCurve).SetDelay(currentAux.delay).
                    SetLoops(currentAux.loops).OnComplete(() => { CallBacks(); StopCoroutine(UpdatePixelPerUnit()); }).SetUpdate(!useTimeScale).
                    OnPlay(() => StartCoroutine(UpdatePixelPerUnit())));

            if (currentAux.displayFade)
            {
                if (currentAux.applyOnCanvasGroup)
                {
                    var canvasGroup = GetComponent<CanvasGroup>();
                    sequence.Insert(delay, DOTween.To(() => canvasGroup.alpha, juu => canvasGroup.alpha = juu, currentAux.fadeTarget, timeAnim).
                        SetEase(currentAux.animationCurve).
                        SetDelay(currentAux.delay).
                        SetLoops(currentAux.loops).OnComplete(CallBacks).SetUpdate(!useTimeScale));

                }
                else
                {
                    sequence.Insert(delay, image.DOFade(currentAux.fadeTarget, currentAux.timeAnimation).
                        SetEase(currentAux.animationCurve).SetDelay(currentAux.delay).
                        SetLoops(currentAux.loops).SetUpdate(!useTimeScale));
                }
            }
        }
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

