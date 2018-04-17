using System.Collections.Generic;

namespace AutologiaService
{
    public class QuestionsDto
    {
        public List<QuestionTypeDto> questionTypes { get; set; }
    }

    public class QuestionTypeDto
    {
        public int typeId { get; set; }
        public string type { get; set; }
        public List<QuestionDto> list { get; set; }
    }

    public class QuestionDto
    {
        public int id { get; set; }
        public string description { get; set; }
        public List<AnswerDto> answers { get; set; }
        public int next { get; set; }
        public bool mandatory { get; set; }
        public string carsRef { get; set; }
    }

    public class AnswerDto
    {
        public int id { get; set; }
        public string description { get; set; }
        public int questionsSet { get; set; }
        public bool selected { get; set; }
    }
}
