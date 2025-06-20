using UnityEngine;
using System.Collections.Generic;

public class QuizModel : IQuizModel
{
    public ICollection<Question> QuestionList { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int CurrentQuestion { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int QuestionCount { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
}