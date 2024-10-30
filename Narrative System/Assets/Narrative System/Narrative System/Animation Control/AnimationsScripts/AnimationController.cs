using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class AnimationController : DoAnimationController
{
    private SpriteRenderer _spriteRender;

    private new void OnEnable()
    {
        base.OnEnable();

        if (GetComponent<SpriteRenderer>())
        {
            _spriteRender = GetComponent<SpriteRenderer>();
        }

        originPosition = transform.position;
        originScale = transform.localScale;
    }

    protected new void OnDisable()
    {
        base.OnDisable();
        _spriteRender.DOKill();
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
        

        if (currentAux.useSequence)
        {
            if (currentAux.displayPosition)
            {
                if (currentAux.atractor != null)
                {
                    sequence.Append(transform.DOMove(currentAux.atractor.position, timeAnim).
                        SetEase(currentAux.animationCurve).
                        SetDelay(currentAux.delay).
                        SetLoops(currentAux.loops).
                        OnComplete(CallBacks).SetUpdate(!useTimeScale));
                }
                else
                {
                    sequence.Append(transform.DOLocalMove(currentAux.targetPosition, timeAnim).
                        SetEase(currentAux.animationCurve).
                        SetDelay(currentAux.delay).
                        SetLoops(currentAux.loops).
                        OnComplete(CallBacks).SetUpdate(!useTimeScale));
                }
            }
        
            if (currentAux.displayScale)
                sequence.Append(transform.DOScale(currentAux.targetScale, timeAnim).
                    SetEase(currentAux.animationCurve).
                    SetDelay(currentAux.delay).
                    SetLoops(currentAux.loops).
                    OnComplete(CallBacks).SetUpdate(!useTimeScale));
            if (currentAux.displayRotation)
                sequence.Append(transform.DORotate(currentAux.targetRotation, timeAnim, RotateMode.LocalAxisAdd).
                    SetEase(currentAux.animationCurve).
                    SetDelay(currentAux.delay).
                    SetLoops(currentAux.loops).
                    OnComplete(CallBacks).SetUpdate(!useTimeScale));
            //if (currentAux.displayColor)
            //    sequence.Append(image.DOColor(currentAux.colorTarget, timeAnim).
            //        SetEase(currentAux.animationCurve).
            //        SetDelay(currentAux.delay).
            //        SetLoops(currentAux.loops).
            //        OnComplete(CallBacks).SetUpdate(!useTimeScale));
            //if (currentAux.displaySizeDelta)
            //    sequence.Append(rectTransform.DOSizeDelta(currentAux.targetSizeDelta, timeAnim).
            //        SetDelay(currentAux.delay).
            //        SetLoops(currentAux.loops).
            //        OnComplete(CallBacks).SetUpdate(!useTimeScale));

            //if (currentAux.displayPixelMultiplier)
            //    sequence.Append(DOTween.To(() => this.image.pixelsPerUnitMultiplier, juu => this.image.pixelsPerUnitMultiplier = juu, currentAux.pixelMultiplier,
            //        currentAux.timeAnimation).SetEase(currentAux.animationCurve).SetDelay(currentAux.delay).
            //        SetLoops(currentAux.loops).OnComplete(() => { CallBacks(); StopCoroutine(UpdatePixelPerUnit()); }).SetUpdate(!useTimeScale).
            //        OnPlay(() => StartCoroutine(UpdatePixelPerUnit())));

            //if (currentAux.displayFade)
            //{
            //    if (currentAux.applyOnCanvasGroup)
            //    {
            //        var canvasGroup = GetComponent<CanvasGroup>();
            //        sequence.Append(DOTween.To(() => canvasGroup.alpha, juu => canvasGroup.alpha = juu, currentAux.fadeTarget, timeAnim).
            //        SetEase(currentAux.animationCurve).
            //        SetDelay(currentAux.delay).
            //        SetLoops(currentAux.loops).OnComplete(CallBacks).SetUpdate(!useTimeScale));

            //    }
            //    else
            //    {
            //        sequence.Append(image.DOFade(currentAux.fadeTarget, currentAux.timeAnimation).
            //            SetEase(currentAux.animationCurve).SetDelay(currentAux.delay).
            //            SetLoops(currentAux.loops).SetUpdate(!useTimeScale));
            //    }
            //}
        }
        else
        {
            if (currentAux.displayPosition)
            {
                if (currentAux.atractor != null)
                {
                    sequence.Insert(delay, transform.DOMove(currentAux.atractor.position, timeAnim).
                        SetEase(currentAux.animationCurve).
                        SetDelay(currentAux.delay).
                        SetLoops(currentAux.loops).
                        OnComplete(CallBacks).SetUpdate(!useTimeScale));
                }
                else
                {
                    sequence.Insert(delay, transform.DOLocalMove(currentAux.targetPosition, timeAnim).
                        SetEase(currentAux.animationCurve).
                        SetLoops(currentAux.loops).
                        OnComplete(CallBacks).
                        SetUpdate(!useTimeScale));
                }
            }

            if (currentAux.displayScale)
                sequence.Insert(delay, transform.DOScale(currentAux.targetScale, timeAnim).
                    SetEase(currentAux.animationCurve).
                    SetLoops(currentAux.loops).
                    OnComplete(CallBacks).SetUpdate(!useTimeScale));
            if (currentAux.displayRotation)
                sequence.Insert(delay, transform.DORotate(currentAux.targetRotation, timeAnim, RotateMode.LocalAxisAdd).
                    SetEase(currentAux.animationCurve).
                    SetDelay(currentAux.delay).
                    SetLoops(currentAux.loops).
                    OnComplete(CallBacks).SetUpdate(!useTimeScale));
            //if (currentAux.displayColor)
            //    sequence.Insert(delay, image.DOColor(currentAux.colorTarget, timeAnim).
            //        SetEase(currentAux.animationCurve).
            //        SetDelay(currentAux.delay).
            //        SetLoops(currentAux.loops).
            //        OnComplete(CallBacks).SetUpdate(!useTimeScale));
            //if (currentAux.displaySizeDelta)
            //    sequence.Insert(delay, rectTransform.DOSizeDelta(currentAux.targetSizeDelta, timeAnim).
            //        SetEase(currentAux.animationCurve).
            //        SetDelay(currentAux.delay).
            //        SetLoops(currentAux.loops).
            //        OnComplete(CallBacks).SetUpdate(!useTimeScale));

            //if (currentAux.displayPixelMultiplier)
            //    sequence.Insert(delay, DOTween.To(() => image.pixelsPerUnitMultiplier, juu => image.pixelsPerUnitMultiplier = juu, currentAux.pixelMultiplier,
            //        currentAux.timeAnimation).SetEase(currentAux.animationCurve).SetDelay(currentAux.delay).
            //        SetLoops(currentAux.loops).OnComplete(() => { CallBacks(); StopCoroutine(UpdatePixelPerUnit()); }).SetUpdate(!useTimeScale).
            //        OnPlay(() => StartCoroutine(UpdatePixelPerUnit())));

            //if (currentAux.displayFade)
            //{
            //    if (currentAux.applyOnCanvasGroup)
            //    {
            //        var canvasGroup = GetComponent<CanvasGroup>();
            //        sequence.Insert(delay, DOTween.To(() => canvasGroup.alpha, juu => canvasGroup.alpha = juu, currentAux.fadeTarget, timeAnim).
            //            SetEase(currentAux.animationCurve).
            //            SetDelay(currentAux.delay).
            //            SetLoops(currentAux.loops).OnComplete(CallBacks).SetUpdate(!useTimeScale));

            //    }
            //    else
            //    {
            //        sequence.Insert(delay, image.DOFade(currentAux.fadeTarget, currentAux.timeAnimation).
            //            SetEase(currentAux.animationCurve).SetDelay(currentAux.delay).
            //            SetLoops(currentAux.loops).SetUpdate(!useTimeScale));
            //    }
            //}
        }

        
    }
}
