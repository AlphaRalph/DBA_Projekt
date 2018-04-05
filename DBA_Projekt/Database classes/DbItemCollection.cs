using System.Collections;
using System.Collections.Generic;

namespace DBA_Projekt
{
    public class DbItemCollection<T> : IEnumerable<T> where T : IDbItem<T>
    {
        #region private members
        private readonly List<T> _items = new List<T>();
        private int _newId;
        #endregion

        #region properties
        public int Count => _items.Count;
        #endregion

        #region methods
        public void Add(T item)
        {
            if (item == null || Contains(item)) return;

            item.Id = _newId;
            _newId++;
            _items.Add(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items) Add(item);
        }

        public bool Remove(T item) => _items.Remove(item);

        public void Clear() => _items.Clear();

        public bool Contains(T item) => _items.Contains(item);

        public bool GetEqual(T item, out T founditem)
        {
            foreach (var entry in _items)
            {
                if (Equals(item, entry))
                {
                    founditem = entry;
                    return true;
                }
            }

            founditem = default(T);
            return false;
        }
        #endregion

        #region IEnumerable interface
        public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion
    }
}