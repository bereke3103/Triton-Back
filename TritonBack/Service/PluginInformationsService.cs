using Microsoft.Extensions.Hosting;
using System;
using TritonBack.Data;
using TritonBack.Model;
using TritonBack.Service.Interface;

namespace TritonBack.Service
{
    public class PluginInformationsService : IPluginInformations
    {
        private readonly DataContext context;

        public PluginInformationsService(DataContext context)
        {
            this.context = context;
        }
        public async Task<PluginInformationModel> CreatePluginInformations(PluginInformationsModelDto model)
        {
            if (model.ItemInformations == string.Empty)
            {
                throw new Exception("Информация не может быть пустым");
            }

            var pluginId = context.pluginModelModels.FirstOrDefault(p=> p.Id == model.PluginId);

            if (pluginId == null)
            {
                throw new Exception("Такого плагина не существует");
            }

            var newPluginInformations = new PluginInformationModel()
            {
                PluginModelId = model.PluginId,
                ItemInformation= model.ItemInformations,
            };

            context.pluginInformationModels.Add(newPluginInformations);
            context.SaveChanges();
            return newPluginInformations;
        }

        public async Task DeletePluginInformations(int id)
        {
            var findPluginInformationModels = context.pluginInformationModels.FirstOrDefault(i=> i.Id == id && i.Id == i.PluginModelId);

            if (findPluginInformationModels != null)
            {
                context.pluginInformationModels.Remove(findPluginInformationModels);
                context.SaveChanges();
            }


        }

        public async Task<List<PluginInformationModel>> GetPluginInformations()
        {
            var response = context.pluginInformationModels.Where(p => p.PluginModelId == p.Id).ToList();

            if (response.Count == 0)
            {
                throw new Exception("У вас нет ни одной записи");
            }

            return response;
        }

        public async Task<PluginInformationModel> UpdatePluginInformations(int id, PluginInformationsModelDto model)
        {
            var findPost = context.pluginInformationModels.FirstOrDefault(p => p.Id == id && p.Id == p.PluginModelId);

            if (findPost != null)
            {
                findPost.ItemInformation = model.ItemInformations;
                context.Update(findPost);
                context.SaveChanges();
                return findPost;

            }
            else
            {
                throw new Exception("такого поста нет");
            }

        }
    }
}
