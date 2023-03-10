using System.Text.Json.Serialization;

namespace TritonBack.Model
{
    public class PluginInformationModel
    {

        public int Id { get; set; }

        public int Tab { get; set; }

        public string ItemInformation { get; set; }
        public string ItemInformationKZ { get; set; }
        public string ItemInformationENG { get; set; }

        public PluginModel PluginModel { get; set; }

        public int PluginModelId { get; set; }
    }
}
