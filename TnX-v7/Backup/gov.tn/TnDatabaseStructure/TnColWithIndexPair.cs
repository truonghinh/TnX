using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gov.tn.TnDatabaseStructure
{
    public class TnColWithIndexPair
    {
        private int _index = 0;
        private string _colName = "";
        public TnColWithIndexPair(int index, string colName)
        {
            _index = index;
            _colName = colName;
        }

        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
            	_index = value;
            }
        }
        public string ColName
        {
            get
            {
                return _colName;
            }
            set { _colName = value; }
        }

    }
}
