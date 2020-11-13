using CustomerWebApiDDD.Domain.Models;
using System.Collections.Generic;

namespace CustomerWebApiDDD.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : BaseModel
    {
        List<T> Get();
        T Get(int id);
        int Insert(T t);
        void Update(int id, T t);
        void Delete(int id);
    }
}
