using Newtonsoft.Json;

namespace TritonBack.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
    }
}
