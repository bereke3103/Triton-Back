using System.Text.Json.Serialization;

namespace TritonBack.Model
{
    public class ChoisingModel
    {
   
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleKZ { get; set; }
        public string TitleENG { get; set; }
        public string Text { get; set; }
        public string TextKZ { get; set; }
        public string TextENG { get; set; }
    }
}
