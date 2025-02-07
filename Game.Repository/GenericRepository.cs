using Game.IRepository;
using Game.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly GameStoreContext _context;
        private readonly DbSet<T> _entities;
        public GenericRepository() // khởi tạo một GenericReposity không tham số
        {
            _context = new GameStoreContext();
            _entities = _context.Set<T>();
        }
        public GenericRepository(GameStoreContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }
        public T GetById(int id)
        {
            return _entities.Find(id); //Tìm theo id 
        }
        public int Insert(T entity)
        {
            _entities.Add(entity);
            return _context.SaveChanges(); //Lưu thay đổi 
        }
        public int Update(T entity)
        {
            _entities.Update(entity);
            return _context.SaveChanges();
        }
        public int Delete(int id)
        {
            var entity = GetById(id);
            _entities.Remove(entity);
            return _context.SaveChanges();
        }
    }
}
