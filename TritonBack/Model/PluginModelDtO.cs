namespace TritonBack.Model
{
    public class PluginModelDtO
    {
        public string Title { get; set; }
        
        public string ShortInfo { get; set; }

        public List<PluginInformationModel> pluginInformationModels { get;  }
    }
}
