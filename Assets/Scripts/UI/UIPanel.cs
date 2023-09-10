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
        _canvasGroup.blocksRaycasts = false;
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
        UIManager.Instance.UIOpened = true;
        Cursor.lockState = CursorLockMode.None;
        
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.DOFade(1, .5f);
    }

    private void ClosePanel()
    {
        UIManager.Instance.UIOpened = false;
        Cursor.lockState = CursorLockMode.Locked;

        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.DOFade(0, .5f);
    }

    protected abstract void Initialize();
}
