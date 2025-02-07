using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        int Insert(T entity); //Thêm mới
        int Update(T entity);//Cập nhật
        int Delete(int id);//Xóa
    }
}
