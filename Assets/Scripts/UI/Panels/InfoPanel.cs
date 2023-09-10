using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InfoPanel: UIPanel
{
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private Image media;
    [Space]
    [SerializeField] private Button closeButton;

    public void SetDescription(string text)
    {
        description.text = text;
    }

    public void SetMedia(Sprite image)
    {
        media.sprite = image;
        media.rectTransform.sizeDelta = new Vector2(image.rect.width, image.rect.height);
    }

    private void Close()
    {
        SetPanelActivity(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    protected override void Initialize()
    {
        closeButton.onClick.AddListener(Close);
    }
}

