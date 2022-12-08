namespace DiyanetNamazVakti.Api.Core
{
    public interface ICacheService
    {
        /// <summary>
        /// �nbelle�e de�er ekler
        /// </summary>
        /// <typeparam name="T">Eklenecek veya Getirilecek verinin tipi</typeparam>
        /// <param name="key">Anahtar Kelime</param>
        /// <param name="generatorAsync">Cachede olmamas� durumunda verinin al�naca�� Asenkron (Zaman Uyumsuz) metod</param>
        /// <returns></returns>
        Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> generatorAsync, DateTime expiredTime = default);

        /// <summary>
        /// �nbellekteki de�eri istenilen t�rde d�nd�r�r.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">Anahtar</param>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// �nbellekte olup olmad���n� kontrol eder.
        /// </summary>
        /// <param name="key">Anahtar</param>
        /// <returns></returns>
        bool Any(string key);

        /// <summary>
        /// �nbelle�e de�er ekler
        /// </summary>
        /// <param name="key">Anahtar</param>
        /// <param name="value">De�er</param>
        void Add(string key, object value);

        /// <summary>
        /// �nbellekteki kayd� siler.
        /// </summary>
        /// <param name="key">Anahtar</param>
        void Remove(string key);

        /// <summary>
        /// �nbellekteki t�m kayd� siler.
        /// </summary>
        void Clear();

        /// <summary>
        /// �nbellekteki parametre ile ba�layan t�m kayd� siler.
        /// </summary>
        /// <param name="prefix">Anahtar</param>
        void StartsWithClear(string prefix);

        /// <summary>
        /// �nbellekteki anahtar listesini d�nd�r�r.
        /// </summary>
        List<string> GetAllKeys();
    }
}