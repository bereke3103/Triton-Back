using System.ComponentModel.DataAnnotations.Schema;

namespace TritonBack.Model
{
    public class PluginModelDtO
    {
        public string Title { get; set; }
        public string TitleKZ { get; set; }
        public string TitleENG { get; set; }

        public string ShortInfo { get; set; }
        public string ShortInfoKZ { get; set; }
        public string ShortInfoENG { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        public string NameFile { get; set; }

    }
}
