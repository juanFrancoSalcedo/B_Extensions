﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;
using TMPro;

public class AnimationTextController : BaseDoAnimationController
{
    private RectTransform rectTransform;
    public TextMeshProUGUI textComponent { get; set; }
    private string textNarrativeBuffer;

    private void OnValidate()
    {
        print("Este componente no es tan optimo, and many of their behaviours doesn't works. We will improve it in the future");
    }

    private new void OnEnable()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        rectTransform = GetComponent<RectTransform>();
        originPosition = rectTransform.anchoredPosition;
        originScale = rectTransform.localScale;
        base.OnEnable();
    }

    protected new void OnDisable()
    {
        base.OnDisable();
        rectTransform.DOKill();
    }

    public override void ActiveAnimation(string putisima = "")
    {
        if (currentAnimation == 0)
        {
            OnStartedCallBack?.Invoke();
        }
        Sequence sequence = DOTween.Sequence();
        TypeAnimation assd = TypeAnimation.Move;
        switch (assd)
        {
            case TypeAnimation.Move:
                rectTransform.DOMove(listAux[currentAnimation].targetPosition, listAux[currentAnimation].timeAnimation, false).
                    SetEase(listAux[currentAnimation].animationCurve).SetDelay(listAux[currentAnimation].delay).
                    SetLoops(listAux[currentAnimation].loops).SetUpdate(!useTimeScale);
                break;

            case TypeAnimation.MoveLocal:
                rectTransform.DOLocalMove(listAux[currentAnimation].targetPosition, listAux[currentAnimation].timeAnimation, false).
                    SetEase(listAux[currentAnimation].animationCurve).SetDelay(listAux[currentAnimation].delay).
                    SetLoops(listAux[currentAnimation].loops).SetUpdate(!useTimeScale);
                break;

            case TypeAnimation.Scale:
                rectTransform.DOScale(listAux[currentAnimation].targetScale, listAux[currentAnimation].timeAnimation).
                    SetEase(listAux[currentAnimation].animationCurve).SetDelay(listAux[currentAnimation].delay).
                    SetLoops(listAux[currentAnimation].loops).SetUpdate(!useTimeScale);
                break;

            case TypeAnimation.FadeOut:
                textComponent.DOFade(1, 0);
                textComponent.DOFade(0, listAux[currentAnimation].timeAnimation).
                    SetEase(listAux[currentAnimation].animationCurve).SetDelay(listAux[currentAnimation].delay).
                    SetLoops(listAux[currentAnimation].loops).SetUpdate(!useTimeScale);
                break;

            case TypeAnimation.ColorChange:
                textComponent.DOBlendableColor(listAux[currentAnimation].colorTarget, listAux[currentAnimation].timeAnimation).
                    SetEase(listAux[currentAnimation].animationCurve).SetDelay(listAux[currentAnimation].delay).
                    SetLoops(listAux[currentAnimation].loops).SetUpdate(!useTimeScale);
                break;
        }
    }
    
}