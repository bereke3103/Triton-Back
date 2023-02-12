using TritonBack.Model;

namespace TritonBack.Service.Interface
{
    public interface IUser
    {
        public Task<UserModel> Register(UserModelDto model);

        public Task<TokenModel> Authentication(UserModelDto model);
    }
}
