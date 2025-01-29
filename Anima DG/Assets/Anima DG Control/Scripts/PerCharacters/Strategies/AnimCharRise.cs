﻿using DG.Tweening;
using UnityEngine;
#if ANIMA_DOTWEEN_PRO
public class AnimCharRise : ITypingAnimaStrategy
{
    public void Animate(DOTweenTMPAnimator animator, float timePerChar, Ease curve)
    {
        Sequence sequence = DOTween.Sequence();
        Sequence sequence2 = DOTween.Sequence();
        for (int i = 0; i < animator.textInfo.characterCount; ++i)
        {
            if (!animator.textInfo.characterInfo[i].isVisible)
                continue;
            Vector3 currCharOffset = animator.GetCharOffset(i);
            sequence.Append(animator.DOOffsetChar(i, currCharOffset + new Vector3(0, 30, 0), timePerChar));
            sequence2.Append(animator.DOFadeChar(i, 1, timePerChar));
        }
    }

    public void PreAnimate(DOTweenTMPAnimator animator)
    {
        for (int i = 0; i < animator.textInfo.characterCount; ++i)
        {
            if (!animator.textInfo.characterInfo[i].isVisible)
                continue;
            Vector3 currCharOffset = animator.GetCharOffset(i);
            animator.DOFadeChar(i, 0, 0);
            animator.DOOffsetChar(i, currCharOffset - new Vector3(0, 30, 0), 0);
        }
    }
}
#endif
