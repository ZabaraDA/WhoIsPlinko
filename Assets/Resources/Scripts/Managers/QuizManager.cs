using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [SerializeField]
    private Button _nextButton;
    [SerializeField]
    private Button _backButton;
    [SerializeField]
    private Button _toStartButton;
    [SerializeField]
    private GameObject _answerPanel;

    private List<Question> _questionList;
    private List<AnswerView> _answerViewList;
    private Question _currentQuestion;

    private int _minQuestionId;
    private int _maxQuestionId;


    private void Start()
    {
        _questionList = GetQuizData();
        _minQuestionId = _questionList.Min(x => x.Id);
        _maxQuestionId = _questionList.Max(x => x.Id);
        _answerViewList = new List<AnswerView>();
        LoadQuestion(_minQuestionId);
        

    }

    public void LoadQuestion(int questionId)
    {
        DestroyAllAnswer();
        _currentQuestion = _questionList.FirstOrDefault(x => x.Id == questionId);

        foreach (Answer answer in _currentQuestion.AnswerList)
        {
            GameObject loadedPrefab = Resources.Load<GameObject>("Prefabs/Answer");
            var answerGameObject = Instantiate(loadedPrefab);
            answerGameObject.transform.SetParent(_answerPanel.transform);
            var answerView = answerGameObject.GetComponent<AnswerView>();

            answerView.Id = answer.Id;
            answerView.Text = answer.Text;
            answerView.IsCorrect = answer.IsCorrect;
            answerView.SetColor(Color.white);
            answerView.OnAnswerClicked += ChangeAnswer;
            _answerViewList.Add(answerView);
        }


    }

    public void ChangeAnswer(int answerId)
    {
        
        foreach (var answerView in _answerViewList)
        {
            if (answerView.Id == answerId)
            {
                answerView.SetColor(new Color(255 / 255f, 62 / 255f, 0 / 255f, 255 / 255f));
            }
            else
            {
                answerView.SetColor(Color.white);
            }
        }
    }
    public void LoadNextQuestion()
    {
        LoadQuestion(_currentQuestion.Id + 1);
    }
    public void LoadBackQuestion()
    {
        LoadQuestion(_currentQuestion.Id - 1);
    }

    public void CreateQuiz()
    {
        //IQuizModel model = new QuizModel();
        //IQuizView view = new QuizView();
        //IQuizPresenter presenter = new QuizPresenter(view, model);
       // presenter.Init();
    }

    private List<Question> GetQuizData()
    {
        TextAsset text = Resources.Load<TextAsset>("Json/QuizJson");
        Debug.Log("QuizJson success read");
        var quizContainer = JsonConvert.DeserializeObject<JsonContainer<List<Question>>>(text.text);

        return quizContainer.Value;
    }
    private void DestroyAllAnswer()
    {
        _answerViewList.Clear();
        List<GameObject> childrenToDestroy = new List<GameObject>();

        for (int i = 0; i < _answerPanel.transform.childCount; i++)
        {
            Transform child = _answerPanel.transform.GetChild(i);
            if (child.gameObject.GetComponent<AnswerView>() != null)
            {
                childrenToDestroy.Add(child.gameObject);
            }
        }

        foreach (GameObject child in childrenToDestroy)
        {
            Debug.Log("Destroy " + child.name);
            Destroy(child);
        }
    }

}
