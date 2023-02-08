using System.Text.Json.Serialization;

namespace TritonBack.Model
{
    public class QuestionsModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
