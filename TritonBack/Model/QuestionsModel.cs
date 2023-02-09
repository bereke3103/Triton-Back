using System.Text.Json.Serialization;

namespace TritonBack.Model
{
    public class QuestionsModel
    {
       
        public int Id { get; set; } 
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
