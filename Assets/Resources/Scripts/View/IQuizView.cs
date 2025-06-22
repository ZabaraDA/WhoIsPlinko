using System;
using UnityEngine;

public interface IQuizView
{
    void SetText(string text);
    void SetVisibilityResults(bool isVisible);
    IQuestionView GetQuestionView();

    event Action OnNextButtonClicked;
    event Action OnBackButtonClicked;
}
