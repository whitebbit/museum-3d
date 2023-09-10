
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Source/Quiz/QuestionConfig", fileName = "QuestionConfig", order = 0)]
public class QuestionConfig : ScriptableObject
{
    [TextArea(3, 5)][SerializeField] private string question;
    [SerializeField] private List<Answer> answers = new List<Answer>();

    public string Question => question;
    public List<Answer> Answers => answers;
}
