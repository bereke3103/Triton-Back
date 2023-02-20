using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using TritonBack.Data;
using TritonBack.Model;
using TritonBack.Service.Interface;

namespace TritonBack.Service
{
    public class PluginService : IPlugin
    {
        private readonly DataContext context;
        private readonly IHttpContextAccessor httpContext;
        private readonly IWebHostEnvironment environment;

   

        public PluginService(DataContext context, IHttpContextAccessor httpContext, IWebHostEnvironment environment)
        {
            this.context = context;
            this.httpContext = httpContext;
            this.environment = environment;
        }
        public async Task<PluginModel> CreatePlugin(PluginModelDtO model)
        {

            var newPlugin = new PluginModel()
            {
                Title = model.Title,
                TitleKZ = model.TitleKZ,
                TitleENG = model.TitleENG,
                ShortInfo = model.ShortInfo,
                ShortInfoKZ = model.ShortInfoKZ,
                NameFile =  UploadFile(model.File),
                ShortInfoENG = model.ShortInfoENG,
           
            };

           

        
            await context.pluginModelModels.AddAsync(newPlugin);
            await context.SaveChangesAsync();
            return newPlugin;
        }



        public string UploadFile(IFormFile model)
        {
            

            if (model.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(environment.WebRootPath + "\\Images\\"))
                    {
                        Directory.CreateDirectory(environment.WebRootPath + "\\Images\\");
                    }

                    using (FileStream fileStream = System.IO.File.Create(environment.WebRootPath + "\\Images\\" + model.FileName))
                    {
                        model.CopyTo(fileStream);
                        fileStream.Flush();
                        return "\\Images\\" + model.FileName;
                    }
                }
                catch (Exception ex)
                {

                    return ex.ToString();
                }
            }
            else
            {
                throw new Exception("Upload Files");
            }
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

        public Task<List<PluginModel>> GetPlugin()
        {
            var response = context.pluginModelModels
                .Include(p => p.PluginInformations).ToListAsync();

            return response;
        }

        public async Task<PluginModel> GetPluginById(int id)
        {
            var response = await context.pluginModelModels.Include(p=> p.PluginInformations).FirstOrDefaultAsync(p=> p.Id == id);

            if (response == null)
            {
                throw new Exception("Такого плагина не сущетсвует");
            }
            else
            {
                return response;
            }
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
                finPlugin.TitleKZ = model.TitleKZ;
                finPlugin.TitleENG = model.TitleENG;
                finPlugin.ShortInfo = model.ShortInfo;
                finPlugin.ShortInfoKZ = model.ShortInfoKZ;
                finPlugin.ShortInfoENG = model.ShortInfoENG;
                context.Update(finPlugin);
                context.SaveChanges();
                return finPlugin;
            }
        }
    }
}
