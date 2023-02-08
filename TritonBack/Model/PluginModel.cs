using System.Text.Json.Serialization;

namespace TritonBack.Model
{
    public class PluginModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortInfo { get; set; }
        [JsonIgnore]
        public List<PluginInformationModel> PluginInformations { get; set; }
    }
}
