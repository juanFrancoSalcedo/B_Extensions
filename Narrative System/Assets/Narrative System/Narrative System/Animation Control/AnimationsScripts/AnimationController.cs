using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class AnimationController : BaseDoAnimationController
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

    public override void ActiveAnimation(string origin = "")
    {
        if (currentAnimation == 0)
        {
            OnStartedCallBack?.Invoke();
        }
        Sequence sequence = DOTween.Sequence();
        var currentAux = listAux[currentAnimation];
        var delay = currentAux.delay;
        var timeAnim = currentAux.timeAnimation;

        if (currentAux.displayPosition)
        {
            if (currentAux.atractor != null)
            {
                sequence.Insert(delay, transform.DOMove(currentAux.atractor.position, timeAnim).
                    SetEase(currentAux.animationCurve).
                    SetDelay(currentAux.delay).
                    SetLoops(currentAux.loops).SetUpdate(!useTimeScale));
            }
            else
            {
                sequence.Insert(delay, transform.DOLocalMove(currentAux.targetPosition, timeAnim).
                    SetEase(currentAux.animationCurve).
                    SetLoops(currentAux.loops).
                    SetUpdate(!useTimeScale));
            }
        }

        if (currentAux.displayScale)
            sequence.Insert(delay, transform.DOScale(currentAux.targetScale, timeAnim).
                SetEase(currentAux.animationCurve).
                SetLoops(currentAux.loops).SetUpdate(!useTimeScale));
        if (currentAux.displayRotation)
            sequence.Insert(delay, transform.DORotate(currentAux.targetRotation, timeAnim, RotateMode.LocalAxisAdd).
                SetEase(currentAux.animationCurve).
                SetDelay(currentAux.delay).
                SetLoops(currentAux.loops).SetUpdate(!useTimeScale));

        sequence.OnComplete(CallBacks);
    }
}
