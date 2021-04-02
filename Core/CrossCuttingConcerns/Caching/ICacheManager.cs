using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    //teknoloji bağımsız interface
    public interface ICacheManager
    {
        T Get<T>(string key); //CACHE DEN GETİRİRKEN HANGİ TİPTE GETİRİLMESİ-generic

        object Get(string key);

        //duration: cache de ne kadar duracağı
        void Add(string key, object value, int duration);

        bool IsAdd(string key); //cache de var mı?
        void Remove(string key); //cacheden uçurma
        void RemoveByPattern(string pattern); //başı sonu önemli değil içi get olanlar gibi
    }
}
