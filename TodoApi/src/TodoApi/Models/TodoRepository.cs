using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class TodoRepository:ITodoRepository
    {
        //To add System.Collections.Concurrent;
        private static ConcurrentDictionary<string, TodoItem> _todos =
              new ConcurrentDictionary<string, TodoItem>();
        public TodoRepository()
        {
            Add(new TodoItem { Name = "Item1" });
        }
        public IEnumerable<TodoItem> GetAll()
        {
            return _todos.Values;
        }
        public void Add(TodoItem item)
        {
            item.key = Guid.NewGuid().ToString();
            _todos[item.key] = item;
        }
        public TodoItem Find(string key)
        {
            TodoItem item;
            _todos.TryGetValue(key, out item);
            return item;
        }

        public TodoItem Remove(string key)
        {
            TodoItem item;
            _todos.TryGetValue(key, out item);
            _todos.TryRemove(key, out item);
            return item;
        }

        public void Update(TodoItem item)
        {
            _todos[item.key] = item;
        }

    }
}
