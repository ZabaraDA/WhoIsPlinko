using System;
using UnityEngine;
using UnityEngine.UI;

public interface IAnswerView
{
    int Id { get; set;}
    string Text { get; set; }
    bool IsCorrect { get; set;}

    event Action<int> OnAnswerClicked;
}
