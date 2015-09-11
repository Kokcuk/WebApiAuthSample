namespace WebApplication5.Controllers
{
    using System.Web.Http;
    using Security;

    [TokenAuthentication]
    public class TestController : ApiController
    {
        public string GetTestData()
        {
            return "foobar";
        }
    }
}