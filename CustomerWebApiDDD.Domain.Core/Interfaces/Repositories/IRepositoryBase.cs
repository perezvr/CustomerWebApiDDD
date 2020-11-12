using CustomerWebApiDDD.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerWebApiDDD.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : BaseModel
    {
        List<T> Get();
        T Get(int id);
        void Insert(T t);
        void Update(int id, T t);
        void Delete(int id);
    }
}
