using System.Text.Json.Serialization;

namespace TritonBack.Model
{
    public class ChoisingModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
