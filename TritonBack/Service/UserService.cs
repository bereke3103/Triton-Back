using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TritonBack.Data;
using TritonBack.Model;
using TritonBack.Service.Interface;

namespace TritonBack.Service
{
    public class UserService : IUser
    {
        private readonly DataContext context;
        private readonly IConfiguration configuration;

        public UserService(DataContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task<TokenModel> Authentication(UserModelDto model)
        {
            var response = await context.userModels.FirstOrDefaultAsync(u => u.Login == model.Login);

            if (response?.Login != model.Login)
            {
                throw new Exception("Неверный логин");
            }

            if (!BCrypt.Net.BCrypt.Verify(model.Password, response.Password))
            {
                throw new Exception("Неверный пароль");
            }

            var token = CreateToken(response);

            return token;

        }

        public TokenModel CreateToken(UserModel model)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Key").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, model.Login),
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            var response = new TokenModel()
            {
                token = jwtToken,
                username = model.Login
            };

            return response;
        }

        public async Task<UserModel> Register(UserModelDto model)
        {
            var findUser = await context.userModels.FirstOrDefaultAsync(u=> u.Login == model.Login);

            if (findUser !=null)
            {
                throw new Exception("Такой пользователь уже существует");
            }

            UserModel user = new UserModel()
            {
                Login = model.Login,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
            };

            context.Add(user);
            await context.SaveChangesAsync();

            return user;
        }
    }
}
