using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InfoPanel: UIPanel
{
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private Image media;
    [Space]
    [SerializeField] private Button closeButton;

    [SerializeField] private ScrollRect scrollRect;
    private readonly float _maxWidth = 400f;
    private readonly float _maxHeight = 400f;
    public void SetDescription(string text)
    {
        description.text = text;
    }

    public void SetMedia(Sprite image)
    {
        media.sprite = image;
        
        var width = image.rect.width;
        var height = image.rect.height;
        
        float aspectRatio = width / height;
        
        if (width > _maxWidth)
        {
            width = _maxWidth;
            height = width / aspectRatio;
        }
        if (height > _maxHeight)
        {
            height = _maxHeight;
            width = height * aspectRatio;
        }
        
        media.rectTransform.sizeDelta = new Vector2(width, height);
    }
    
    public void SetCloseButtonAction(UnityAction action)
    {
        closeButton.onClick.AddListener(action);
    }
    
    private void Close()
    {
        SetPanelActivity(false);
        Cursor.lockState = CursorLockMode.Locked;
        scrollRect.verticalScrollbar.value = 1;
    }

    protected override void Initialize()
    {
        SetCloseButtonAction(Close);
    }
    
}

