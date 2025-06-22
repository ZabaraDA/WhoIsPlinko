using System.Collections.Generic;
using UnityEngine;

public class QuestionModel : IQuestionModel
{
    public int Id { get; set; }
    public string Text { get; set; }
    public ICollection<IAnswerModel> Answers { get; set; }
    public void SetSelectedAnswer(IAnswerModel answerModel)
    {
        foreach (IAnswerModel model in Answers)
        {
            if (model != answerModel && model.IsSelected)
            {
                model.IsSelected = false;
            }
        }
    }

}
