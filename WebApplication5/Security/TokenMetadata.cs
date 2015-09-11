namespace WebApplication5.Security
{
    using System;

    public class TokenMetadata
    {
        public long UserId { get; set; }
        public string Login { get; set; }
        public DateTime LastAccess { get; set; }
    }
}