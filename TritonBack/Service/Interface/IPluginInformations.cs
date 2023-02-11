using TritonBack.Model;

namespace TritonBack.Service.Interface
{
    public interface IPluginInformations
    {
        public Task<PluginInformationModel> CreatePluginInformations(PluginInformationsModelDto model);
        public Task<PluginInformationModel> UpdatePluginInformations(int id, PluginInformationsModelDto model);

        public Task DeletePluginInformations(int id);
        public Task<List<PluginInformationModel>> GetPluginInformations();
        public Task<PluginInformationModel> GetPluginInformationsById(int id);
    }
}
