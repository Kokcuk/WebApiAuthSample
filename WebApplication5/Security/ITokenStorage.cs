namespace WebApplication5.Security
{
    using System;

    public interface ITokenStorage
    {
        TokenMetadata GetMetadata(string token);
        bool Add(string token, TokenMetadata tokenMetadata);
        bool Delete(string token);
        void UpdateLastAccess(string token, DateTime accessDate);
    }
}