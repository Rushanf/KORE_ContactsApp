using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KORE_ContactManagement.Application.Interfaces
{
    public interface IDbCommandRepository<T> where T : class
    {
        void Add(T t);
        void Delete(int t);
        void Update(T t);
        Task<int> GetLastIndex();
        Task<T> GetById(int id);
        Task<bool> IsEmailNotExists(string email);
    }
}
