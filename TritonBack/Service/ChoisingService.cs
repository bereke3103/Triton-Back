using TritonBack.Data;
using TritonBack.Model;
using TritonBack.Service.Interface;
using static System.Net.Mime.MediaTypeNames;

namespace TritonBack.Service
{
    public class ChoisingService : IChoising
    {
        private readonly DataContext context;

        public ChoisingService(DataContext context)
        {
            this.context = context;
        }

        public async Task<ChoisingModel> CreateChoisingModel(ChoisingModel choising)
        {
            if (choising == null)
            {
                throw new Exception("Список пуст");
            }

            if (choising.Title == string.Empty)
            {
                throw new Exception("Заполните Вопрос");
            }
           
            if (choising.Text == string.Empty)
            {
                throw new Exception("Заполните Вопрос");
            }

            var newChoisingModel = new ChoisingModel()
            {
                Title = choising.Title,
                Text = choising.Text,
            };

            await context.choisingModels.AddAsync(newChoisingModel);
            await context.SaveChangesAsync();
            return newChoisingModel;
        }

        public async Task<List<ChoisingModel>> GetChoisingModel()
        {
            var response = context.choisingModels.ToList();
            return response;
        }

        public async Task<ChoisingModel> UpdateChoisingModel(int id, ChoisingModel choisingModel)
        {
            var findChoising = context.choisingModels.FirstOrDefault(choisingModel => choisingModel.Id == id);

            if (findChoising == null)
            {
                throw new Exception("Такого поста не существует");
            }
            else
            {
                findChoising.Title = choisingModel.Title;
                findChoising.Text = choisingModel.Text;
                context.Update(findChoising);
                context.SaveChanges();
                return findChoising;
            }
        }
    }
}
