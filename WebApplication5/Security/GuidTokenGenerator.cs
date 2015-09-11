namespace WebApplication5.Security
{
    using System;

    public class GuidTokenGenerator : ITokenGenerator
    {
        public string GenerateToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}