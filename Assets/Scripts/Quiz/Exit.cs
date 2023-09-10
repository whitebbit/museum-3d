using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour, IInteractive
{

    private bool _used;
    public void Interact()
    {
        if(_used)
            return;
        
        UIManager.Instance.QuizGamePanel.SetPanelActivity(true);
        UIManager.Instance.QuizGamePanel.StartQuizGame();
    }

    public void FinishInteract()
    {
        
    }
}
