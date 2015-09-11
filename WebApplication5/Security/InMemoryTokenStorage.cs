namespace WebApplication5.Security
{
    using System;
    using System.Collections.Concurrent;

    public class InMemoryTokenStorage : ITokenStorage
    {
        private static readonly ConcurrentDictionary<string, TokenMetadata> Storage = new ConcurrentDictionary<string, TokenMetadata>();

        public TokenMetadata GetMetadata(string token)
        {
            TokenMetadata metadata;
            bool success = Storage.TryGetValue(token, out metadata);

            return success ? metadata : null;
        }

        public bool Add(string token, TokenMetadata tokenMetadata)
        {
            return Storage.TryAdd(token, tokenMetadata);
        }

        public bool Delete(string token)
        {
            TokenMetadata metadata;
            return Storage.TryRemove(token, out metadata);
        }

        public void UpdateLastAccess(string token, DateTime accessDate)
        {
            TokenMetadata metadata;
            bool success = Storage.TryGetValue(token, out metadata);

            if (success)
            {
                metadata.LastAccess = DateTime.Now;
            }
            Storage.TryUpdate(token, metadata, metadata);
        }
    }
}