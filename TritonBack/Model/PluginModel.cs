using System.Text.Json.Serialization;

namespace TritonBack.Model
{
    public class PluginModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortInfo { get; set; }
      
        public List<PluginInformationModel> PluginInformations { get; set; }
    }
}
