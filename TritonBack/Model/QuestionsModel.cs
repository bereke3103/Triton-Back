using System.Text.Json.Serialization;

namespace TritonBack.Model
{
    public class QuestionsModel
    {
       
        public int Id { get; set; } 
        public string Question { get; set; }
        public string QuestionKZ { get; set; }
        public string QuestionENG { get; set; }
        public string Answer { get; set; }
        public string AnswerKZ { get; set; }
        public string AnswerENG { get; set; }
    }
}
