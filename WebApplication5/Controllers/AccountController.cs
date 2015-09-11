namespace WebApplication5.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Models;
    using Security;

    public class AccountController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ITokenStorage _tokenStorage;
        private readonly ITokenGenerator _tokenGenerator;

        public AccountController()
        {
            _dbContext = new ApplicationDbContext();
            _tokenStorage = new InMemoryTokenStorage();
            _tokenGenerator = new GuidTokenGenerator();
        }

        public LoginResultModel Login(LoginModel model)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Login == model.Login && x.Password == model.Password);
            if(user == null)
                return new LoginResultModel{Message = "User not found"};

            var token = _tokenGenerator.GenerateToken();
            _tokenStorage.Add(token, new TokenMetadata
            {
                LastAccess = DateTime.Now,
                UserId = user.Id,
                Login = user.Login
            });
            return new LoginResultModel {Token = token};
        }
    }
}