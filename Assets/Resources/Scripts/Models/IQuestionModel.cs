using System.Collections.Generic;
using UnityEngine;

public interface IQuestionModel
{
    int Id { get; set; }
    string Text { get; set; }
    ICollection<IAnswerModel> Answers { get; set; }

    void SetSelectedAnswer(IAnswerModel answerModel);

}
