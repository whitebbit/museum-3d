using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuizGame
{
    private readonly List<QuestionConfig> _questions;
    private int _currentQuestionIndex;

    private readonly TextMeshProUGUI _questionText;
    private List<QuizButton> _buttons;

    private UnityAction _winAction;
    private UnityAction _loseAction;
    public QuizGame(List<QuestionConfig> questions, TextMeshProUGUI questionText, 
        Transform buttonsHandler, Button buttonTemplate,
        UnityAction winAction, UnityAction loseAction)
    {
        _questions = questions;
        _questionText = questionText;
        _winAction = winAction;
        _loseAction = loseAction;
        InitializeButtons(buttonsHandler, buttonTemplate);
    }

    public void StartGame()
    {
        SetCurrentQuestion();
    }
    
    private void SetCurrentQuestion()
    {
        var currentQuestion = _questions[_currentQuestionIndex];
        _questionText.text = currentQuestion.Question;
        SetCurrentQuestionButtons(currentQuestion);
    }

    private void SetCurrentQuestionButtons(QuestionConfig question)
    {
        DisableButtons();
        var answers = question.Answers; 
        var answersCount = answers.Count;
        
        for (int i = 0; i < answersCount; i++)
        {
            _buttons[i].InitializeButton(answers[i], AnswerCorrect, AnswerWrong);
        }
    }
    
    private void AnswerCorrect()
    {
        NextQuestion();
    }
    
    private void AnswerWrong()
    {
        _loseAction?.Invoke();
    }

    private void NextQuestion()
    {
        _currentQuestionIndex++;
        if (_currentQuestionIndex >= _questions.Count)
        {
            _winAction?.Invoke();
            return;
        }
        SetCurrentQuestion();
    }
    
    private void InitializeButtons(Transform handler, Button template)
    {
        _buttons = new List<QuizButton>();
        for (int i = 0; i < 10; i++)
        {
            var button = Object.Instantiate(template, handler);
            var text = button.GetComponentInChildren<TextMeshProUGUI>();
            var quizButton = new QuizButton(button, text);
            _buttons.Add(quizButton);
        }
        DisableButtons();
    }
    
    private void DisableButtons()
    {
        foreach (var button in _buttons)
        {
            button.SetButtonActive(false);
        }
    }
    
}
