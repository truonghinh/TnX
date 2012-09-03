using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.query;

namespace com.g1.arcgis.tn.query
{
    public class AttributeQueryController:IAttributeQueryController
    {
        private IAttributeQuery _query;
        private IAttributeQueryView _queryView;

        public AttributeQueryController(IAttributeQueryView queryView, IAttributeQuery query)
        {
            this._query = query;
            this._queryView = queryView;
        }
        #region IAttributeQueryController Members

        void IAttributeQueryController.Excute()
        {
            this._query.SqlCommand = this._queryView.SqlCommand;
            this._query.Excute();
        }

        void IAttributeQueryController.ReceiveResult(System.Data.SqlClient.SqlDataReader data)
        {
            throw new NotImplementedException();
        }

        void IAttributeQueryController.ReceiveResult(System.Data.DataSet data)
        {
            throw new NotImplementedException();
        }

        void IAttributeQueryController.ExcuteForDataSet()
        {
            ((IInfoQuery)this._query).ThuaInfo = ((IInfoQueryView)this._queryView).ThuaInfo;
            this._query.SelectSqlCommand = this._queryView.SelectSqlCommand;
            this._query.ExcuteForDataSet();
        }

        #endregion
    }
}
