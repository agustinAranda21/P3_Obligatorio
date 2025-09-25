using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Dominio.RepositoryInterfaces
{
   public interface IRepositorio<T> where T : class
    {
        public void Add(T nuevo);
        public void Update(T actualizar);
        public void Remove(int id);
        public T FindById(int id);
        public IEnumerable<T> FindAll();

    }
}
