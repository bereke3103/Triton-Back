using System.Text.Json.Serialization;

namespace TritonBack.Model
{
    public class FeedbackModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Questions { get; set; }
        [JsonIgnore]
        public DateTime dateTime { get; set; } = DateTime.UtcNow;

    }
}
