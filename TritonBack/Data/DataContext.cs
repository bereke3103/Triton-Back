using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using TritonBack.Model;

namespace TritonBack.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
    
        }

        public DbSet<ChoisingModel> choisingModels { get; set; }

        public DbSet<PluginInformationModel> pluginInformationModels { get; set; }

        public DbSet<PluginModel> pluginModelModels { get; set; }

        public DbSet<QuestionsModel> questionsModels { get; set; }

        public DbSet<FeedbackModel> feedbacks { get; set; }
        public DbSet<UserModel> userModels { get; set; }
    }
}
