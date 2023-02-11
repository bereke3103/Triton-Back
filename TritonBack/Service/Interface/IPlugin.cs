using TritonBack.Model;

namespace TritonBack.Service.Interface
{
    public interface IPlugin
    {
        public Task<PluginModel> CreatePlugin(PluginModelDtO model);
        public Task<PluginModel> UpdatePlugin(int id, PluginModelDtO model);

        public Task DeletePlugin(int id);
        public Task<List<PluginModel>> GetPlugin();
        public Task<PluginModel> GetPluginById(int id);
    }
}
