using TritonBack.Model;

namespace TritonBack.Service.Interface
{
    public interface IChoising
    {
        public Task<ChoisingModel> CreateChoisingModel (ChoisingModel choising);
        public Task<ChoisingModel> UpdateChoisingModel(int id, ChoisingModel choising);
        public Task<List<ChoisingModel>> GetChoisingModel();
        public Task<ChoisingModel> GetChoisingModelById(int id);

    }
}
