using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LosePanel : UIPanel
{
    [SerializeField] private Button restartButton;

    private void Restart()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    
    protected override void Initialize()
    {
        restartButton.onClick.AddListener(Restart);
    }
}
