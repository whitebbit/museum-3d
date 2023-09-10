using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class ScrollViewWithLimits : MonoBehaviour
{
    private ScrollRect _scrollRect;
    [SerializeField] private float maxScrollValue = 1.0f;
    [SerializeField] private float minScrollValue = 0.0f;

    private void Awake()
    {
        _scrollRect = GetComponent<ScrollRect>();
    }

    private void Start()
    {
        if (_scrollRect != null)
        {
            _scrollRect.onValueChanged.AddListener(OnScrollValueChanged);
        }
    }

    private void OnScrollValueChanged(Vector2 value)
    {
        float clampedValue = Mathf.Clamp(value.y, minScrollValue, maxScrollValue);
        _scrollRect.verticalNormalizedPosition = clampedValue;
    }
}
