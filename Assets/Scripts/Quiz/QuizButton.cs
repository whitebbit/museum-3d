using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuizButton
{
    private readonly Button _button;
    private readonly TextMeshProUGUI _text;
    
    public QuizButton(Button button, TextMeshProUGUI text)
    {
        _button = button;
        _text = text;
    }
    
    
    public void InitializeButton(Answer answer, UnityAction correctAction, UnityAction wrongAction)
    {
        _button.gameObject.SetActive(true);
        _text.text = answer.text;
        SetButtonAction(answer, correctAction, wrongAction);
    }

    public void SetButtonActive(bool active)
    {
        _button.gameObject.SetActive(active);
    }

    private void CreateAction(bool answer, UnityAction action)
    {
        var transform = _button.transform;
        var startColor = _button.image.color;
        var color = answer ? Color.green : Color.red;
        
        _button.image
            .DOColor(color, .5f)
            .OnComplete(() => 
                {
                    _button.image.color = startColor;
                    action?.Invoke();
                });
        
    }
    
    private void SetButtonAction(Answer answer, UnityAction correctAction, UnityAction wrongAction)
    {
        _button.onClick.RemoveAllListeners();
        UnityAction action = answer.accuracy ? correctAction : wrongAction;
        
        _button.onClick.AddListener(() => CreateAction(answer.accuracy, action));
    }

}
