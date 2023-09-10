using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(CanvasGroup))]
public abstract class UIPanel : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private bool _active;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
        Initialize();
    }

    public void SetPanelActivity(bool active)
    {
        if(active == _active)
            return;
        
        if(active)
            OpenPanel();
        else
            ClosePanel();
        
        _active = active;
    }

    private void OpenPanel()
    {
        _canvasGroup.DOFade(1, 1);
    }

    private void ClosePanel()
    {
        _canvasGroup.DOFade(0, 1);
    }

    protected abstract void Initialize();
}
