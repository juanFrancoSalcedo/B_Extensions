
using System;
using System.Collections.Generic;
using UnityEngine;

namespace B_Extensions.ScreenFitter
{
    public class PositionRectFitter : MonoBehaviour
    {
        //[SerializeField] Vector3 positionHorizontal;
        //[SerializeField] Vector3 positionVertical;
        [SerializeField] List<PositionFitterSheet> positionsChecks = new List<PositionFitterSheet>();

        Vector2 screenSizeBuffer = Vector2.zero;

        RectTransform _rectTransform;
        private void Awake()
        {
            _rectTransform = (RectTransform)transform;
        }

        private void Update()
        {
            if (screenSizeBuffer.x != Screen.width && screenSizeBuffer.y != Screen.height)
            {
                positionsChecks.ForEach(p => p.Limit(_rectTransform));
                screenSizeBuffer = new Vector2(Screen.width, Screen.height);
            }
        }
    }

    [System.Serializable]
    public class PositionFitterSheet
    {
        public bool useWidth;
        public bool useHeight;
        public float minWidth;
        public float maxWidth;
        public float minHeight;
        public float maxHeight;
        public Vector3 targetPosition;

        public void Limit(RectTransform _rectTra)
        {
            //Screen.width
            if (useWidth && IsInRange(Screen.width, minWidth, maxWidth))
            {
                
                _rectTra.anchoredPosition = targetPosition;
            }

            if (useHeight && IsInRange(Screen.height, minHeight, maxHeight))
            {
                
                _rectTra.anchoredPosition = targetPosition;
            }

        }
        public bool IsInRange(float value, float min, float max)
        {
            return value >= min && value <= max;
        }
    }

}
