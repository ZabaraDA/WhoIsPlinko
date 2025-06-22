using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizPresenter : IQuizPresenter
{
    private IQuizView _quizView;
    private IQuizModel _quizModel;
    private IQuestionPresenter _questionPresenter;
    public QuizPresenter(IQuizView quizView, IQuizModel quizModel) 
    {
        _quizModel = quizModel;
        _quizView = quizView;
    }

    public void Dispose()
    {
        _quizModel.OnModelCurrentQuestionChanged -= OnModelCurrentQuestionChanged;
        _questionPresenter.Dispose();
    }

    public void Initialize()
    {
        _quizView.OnNextButtonClicked += LoadNextQuestion;
        _quizView.OnBackButtonClicked += LoadBackQuestion;
        _quizModel.OnModelCurrentQuestionChanged += OnModelCurrentQuestionChanged;
        LoadNextQuestion();
    }

    public void LoadBackQuestion()
    {

        if (_quizModel.TryGetBackQuestion(out IQuestionModel questionModel))
        {
            _quizModel.LoadQuestion(questionModel);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void LoadNextQuestion()
    {

        if (_quizModel.TryGetNextQuestion(out IQuestionModel questionModel))
        {
            _quizModel.LoadQuestion(questionModel);
        }
        else
        {

        }
    }

    //public bool TryGetBackQuestion()
    //{
    //    return _quizModel.TryGetBackQuestion(out IQuestionModel questionModel);
    //}

    //public bool TryGetNextQuestion()
    //{
    //    return _quizModel.TryGetNextQuestion(out IQuestionModel questionModel);
    //}

    private void OnModelCurrentQuestionChanged(IQuestionModel questionModel)
    {
        if (_questionPresenter != null)
        {
            _questionPresenter.Dispose();
        }
        _quizView.SetText(questionModel.Id + "/" + _quizModel.QuestionList.Count);
        IQuestionView questionView = _quizView.GetQuestionView();
        IQuestionPresenter questionPresenter = new QuestionPresenter(questionView, questionModel);

        questionPresenter.Initialize();

        _questionPresenter = questionPresenter;
    }
}
