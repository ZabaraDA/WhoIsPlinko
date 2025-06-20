using UnityEngine;

public class QuizPresenter : IQuizPresenter
{
    private IQuizView _quizView;
    private IQuizModel _quizModel;
    public QuizPresenter(IQuizView quizView, IQuizModel quizModel) 
    {
        _quizModel = quizModel;
        _quizView = quizView;
    }

    public void Init()
    {

    }
}
