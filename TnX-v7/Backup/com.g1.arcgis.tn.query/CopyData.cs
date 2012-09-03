using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.query;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;
using com.g1.arcgis.edit;

namespace com.g1.arcgis.tn.query
{
    public class CopyData:ICopyData
    {
        private DataTable _data;
        private BackgroundWorker _bwk;
        private ICopyDataView _view;
        private string _fromYear;
        private string _toYear;
        public CopyData()
        {
            _bwk = new BackgroundWorker();
        }

        #region ICopyData Members

        void ICopyData.Copy()
        {
            DataRow[] result=_data.Select(string.Format("namapdung='{0}'",_fromYear));
            ColValPair pair = new ColValPair();
            pair.ColName = "namapdung";
            pair.ColValue = _toYear;
            int c = _data.Columns.Count;
            int index = 0;
            object[] newRow = new object[c];
            //DataRow row = _data.Rows[0];
            foreach (DataRow row in result)
            {
                //for (int i = 0; i < c; i++)
                //{
                //    //newRow[i] = row[i];
                index = _data.Rows.IndexOf(row);
                    
                //    //tao hang trong datatable
                //    //_data.Rows.Add(newRow);
                //}
                //tao hang trong
                //them gia tri vao hang vua tao
                _view.Paste(index, pair);
            }
            if (_view != null)
            {
                _view.Update();
            }
            
            

        }

        void ICopyData.SetView(ICopyDataView view)
        {
            this._view=view;
        }

        DataTable ICopyData.Data
        {
            get
            {
                return this._data;
            }
            set
            {
                this._data=value;
            }
        }

        #endregion

        #region ICopyData Members


        event QueryFinishedEventHandler ICopyData.Finished
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        event QueryingEventHandler ICopyData.Copying
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        #endregion
    
#region ICopyData Members


string  ICopyData.FromYear
{
	  get 
	{ 
		return this._fromYear; 
	}
	  set 
	{ 
		this._fromYear=value; 
	}
}

string  ICopyData.ToYear
{
	  get 
	{ 
		return this._toYear; 
	}
	  set 
	{ 
		this._toYear=value; 
	}
}

#endregion
}
}
