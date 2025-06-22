using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizView : MonoBehaviour, IQuizView
{
    [SerializeField]
    private TMP_Text _quizCounterText;
    [SerializeField]
    private GameObject _questionContainer;
    [SerializeField]
    private TMP_Text _resultsText;
    [SerializeField]
    private Button _nextButton;
    [SerializeField]
    private Button _backButton;

    public event Action OnNextButtonClicked;
    public event Action OnBackButtonClicked;

    private void Start()
    {
        SetVisibilityResults(false);
        _nextButton.onClick.AddListener(HandleNextButtonClick);
        _backButton.onClick.AddListener(HandleBackButtonClick);
    }

    void OnDestroy()
    {
        if (_nextButton != null)
        {
            _nextButton.onClick.RemoveListener(HandleNextButtonClick);
        }
        if (_backButton != null)
        {
            _backButton.onClick.RemoveListener(HandleBackButtonClick);
        }
    }

    public IQuestionView GetQuestionView()
    {
        return _questionContainer.GetComponent<QuestionView>();
    }

    public void SetText(string text)
    {
        _quizCounterText.text = text;
    }

    private void HandleNextButtonClick()
    {
        OnNextButtonClicked?.Invoke();
    }

    private void HandleBackButtonClick()
    {
        OnBackButtonClicked?.Invoke();
    }

    public void SetVisibilityResults(bool isVisible)
    {
        _resultsText.SetActive(isVisible);
    }
}
