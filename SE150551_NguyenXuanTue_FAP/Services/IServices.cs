using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IService<T>
    {
        List<T> GetAll();
        void Add(T item);
        void Delete(T item);
        void Update(T item);
        T GetById(object id);
    }
}
