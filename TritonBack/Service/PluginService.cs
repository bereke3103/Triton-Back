using TritonBack.Data;
using TritonBack.Model;
using TritonBack.Service.Interface;

namespace TritonBack.Service
{
    public class PluginService : IPlugin
    {
        private readonly DataContext context;

        public PluginService(DataContext context)
        {
            this.context = context;
        }
        public async Task<PluginModel> CreatePlugin(PluginModelDtO model)
        {


            //if (model == null)
            //{
            //    throw new Exception("Описание не может быть пустым");
            //}
            if (model.Title == string.Empty)
            {
                throw new Exception("Заголовок не может быть пустым");
            }

            if (model.ShortInfo == string.Empty)
            {
                throw new Exception("Информация должна быть заполнена!");
            }

            //foreach (var item in model.PluginInformations)
            //{
            //    if (item.ItemInformation == string.Empty)
            //    {
            //        throw new Exception("Это поле должно быть заполнено");
            //    }
            //}

            var newPlugin = new PluginModel()
            {
                Title = model.Title,
                ShortInfo = model.ShortInfo,
                PluginInformations = model.pluginInformationModels,
            };

            await context.pluginModelModels.AddAsync(newPlugin);
            await context.SaveChangesAsync();
            return newPlugin;
        }

        public async Task DeletePlugin(int id)
        {
            var findPlugin = context.pluginModelModels.FirstOrDefault(p => p.Id == id);

            if (findPlugin != null)
            {
                context.pluginModelModels.Remove(findPlugin);
                context.SaveChanges();
            }
            
        }

        public async Task<List<PluginModel>> GetPlugin()
        {
            var response = context.pluginModelModels.ToList();
            return response;
        }

        public async Task<PluginModel> UpdatePlugin(int id, PluginModelDtO model)
        {
            var finPlugin = context.pluginModelModels.FirstOrDefault(plugin => plugin.Id == id);

            if (finPlugin == null)
            {
                throw new Exception("Такого поста не существует");
            }
            else
            {
                finPlugin.Title = model.Title;
                finPlugin.ShortInfo = model.ShortInfo;
                context.Update(finPlugin);
                context.SaveChanges();
                return finPlugin;
            }
        }
    }
}
