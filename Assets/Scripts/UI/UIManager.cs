using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UIManager : Singleton<UIManager>
{ 
    [SerializeField] private InfoPanel infoPanel;
    [SerializeField] private QuizGamePanel quizGamePanel;
    [SerializeField] private WinPanel winPanel;
    [SerializeField] private LosePanel losePanel;
    public InfoPanel InfoPanel => infoPanel;
    public QuizGamePanel QuizGamePanel => quizGamePanel;
    public WinPanel WinPanel => winPanel;
    public LosePanel LosePanel => losePanel;

    public bool UIOpened { get; set; }
}
