using Microsoft.EntityFrameworkCore;
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
                TitleKZ= choising.TitleKZ,
                TitleENG = choising.TitleENG,
                Text = choising.Text,
                TextKZ = choising.TextKZ,
                TextENG = choising.TextENG,
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

        public async Task<ChoisingModel> GetChoisingModelById(int id)
        {
            var response = await context.choisingModels.FirstOrDefaultAsync(p => p.Id == id);

            if(response == null)
            {
                throw new Exception("Такого поста не существует");
            }

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
                findChoising.TitleKZ = choisingModel.TitleKZ;
                findChoising.TitleENG = choisingModel.TitleENG;
                findChoising.Text = choisingModel.Text;
                findChoising.TextKZ = choisingModel.TextKZ;
                findChoising.TextENG = choisingModel.TextENG;
                context.Update(findChoising);
                context.SaveChanges();
                return findChoising;
            }
        }
    }
}
