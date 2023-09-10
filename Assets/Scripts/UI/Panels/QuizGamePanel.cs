using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizGamePanel : UIPanel
{
    [SerializeField] private List<QuestionConfig> questions = new List<QuestionConfig>();
    [Space]
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private Transform answersHandler;
    [Space]
    [SerializeField] private Button buttonTemplate;

    private QuizGame _quizGame;

    public void StartQuizGame()
    {
        _quizGame.StartGame();
    }

    private void WinGame()
    {
        UIManager.Instance.QuizGamePanel.SetPanelActivity(false);
        UIManager.Instance.WinPanel.SetPanelActivity(true);
    }

    private void LoseGame()
    {
        UIManager.Instance.QuizGamePanel.SetPanelActivity(false);
        UIManager.Instance.LosePanel.SetPanelActivity(true);
    }
    
    protected override void Initialize()
    {
        _quizGame = new QuizGame(questions, questionText, answersHandler, buttonTemplate, WinGame, LoseGame);
    }
}
