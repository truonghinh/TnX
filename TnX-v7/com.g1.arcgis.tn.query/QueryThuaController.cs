using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.query;

namespace com.g1.arcgis.tn.query
{
    public class QueryThuaController:IQueryThuaController
    {
        private IQueryThua _query;
        private IQueryThuaView _view;
        public QueryThuaController(IQueryThua qrt, IQueryThuaView view)
        {
            this._query = qrt;
            this._view = view;
        }
        #region IQueryThuaController Members

        void IQueryThuaController.Query()
        {
            this._query.TypeOfQuery=this._view.TypeOfQuery;
            this._query.Info = this._view.Info;
            this._query.Query();
        }

        #endregion
    }
}
