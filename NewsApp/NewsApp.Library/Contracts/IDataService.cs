using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Library.Contracts
{
    public interface IDataService<T> where T : class
    {
        void Insert(T modelObject);
        List<T> Get();
        T GetById(int id);
        void Update(int id, T modelObject);
        void Delete(int id);
    }
}
