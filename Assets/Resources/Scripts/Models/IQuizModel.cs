using System.Collections.Generic;

public interface IQuizModel
{
    ICollection<Question> QuestionList { get; set; }
    int CurrentQuestion {  get; set; }
    int QuestionCount { get; set; }
}
