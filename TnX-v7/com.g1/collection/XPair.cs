using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.collection
{
    public class XPair
    {
        public struct pair{
            private int _id;
            private string _name;
            public pair(int id, string name)
            {
                _id = id;
                _name = name;
            }
            public int Id { get { return _id; } set { _id = value; } }
            public string Name { get { return _name; } set { _name = value; } }
        }
        private List<pair> _listPair;
        public List<pair> ListPair { get { return _listPair; } }

        public void NewPair(int id, string name)
        {
            _listPair.Add(new pair(id, name));
        }
        public void ClearPair()
        {
            _listPair.Clear();
        }
        public XPair()
        {
            _listPair = new List<pair>();
        }

        public int FindId(string name)
        {
            foreach (pair p in _listPair)
            {
                if (name == p.Name)
                {
                    return p.Id;
                }
            }
            return -1;
        }

        public int FindId(int so_thu_tu)
        {
            if (so_thu_tu >= 0 && so_thu_tu < _listPair.Count)
            {
                pair p = _listPair[so_thu_tu];
                return p.Id;
            }
            //foreach (pair p in _listPair)
            //{
            //    if (name == p.Name)
            //    {
            //        return p.Id;
            //    }
            //}
            return -1;
        }

        public string FindName(int id)
        {
            foreach (pair p in _listPair)
            {
                if (id == p.Id)
                {
                    return p.Name;
                }
            }
            return string.Empty;
        }
        
    }
}
