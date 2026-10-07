using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab04
{
    public class Repository<T> where T : IEntity
    {
        private readonly List<T> _items = new List<T>();

        public void Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _items.Add(entity);
        }

        public bool Remove(string id)
        {
            var item = FindById(id);
            if (item != null)
            {
                return _items.Remove(item);
            }
            return false;
        }

        public T? FindById(string id)
        {
            return _items.FirstOrDefault(x => string.Equals(x.Id, id, StringComparison.OrdinalIgnoreCase));
        }

        // Tìm kiếm/lọc generic bằng Func<T, bool>
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _items.Where(predicate);
        }

        public IReadOnlyList<T> GetAll()
        {
            return _items.AsReadOnly();
        }
    }
}