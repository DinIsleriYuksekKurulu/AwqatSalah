namespace DiyanetNamazVakti.Api.Core.Caching
{
    public static class CacheExtensions
    {
        public static T Get<T>(this ICacheService cacheService, string key, Func<T> acquire)
        {
            //e�er de�er daha �nce cache edilmi� ise de�eri getir 
            if (cacheService.Any(key))
            {
                return cacheService.Get<T>(key);
            }

            //de�er cache de yok ise ekle
            var result = acquire();
            cacheService.Add(key, result);
            return result;
        }
    }
}