using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.calculation;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using System.Windows.Forms;
using com.g1.arcgis.connection;
using gov.tn.TnDatabaseStructure;

namespace com.g1.arcgis.tn.calculation.algorithm
{
    public class AlgorithmTimDuong:SpatialAlgorithm,IAlgorithmTimDuong
    {
        private IFeatureClass _frmFc;
        private IFeatureClass _byFc;
        private delegate void excuteDelegate();
        public AlgorithmTimDuong():this(null,null)
        { }
        public AlgorithmTimDuong(IFeatureLayer fromLayer, IFeatureLayer byLayer)
        {
            this._queryByLayer = new QueryByLayerClass();
            this._queryByLayer.UseSelectedFeatures = true;
            this._queryByLayer.FromLayer = this._fromLayer;
            this._queryByLayer.ByLayer = this._byLayer;
            this._fromLayer = fromLayer;
            this._byLayer = byLayer;

        }
        #region IAlgorithm Members

        void IAlgorithm.Execute()
        {
            if (this._fromLayer == null || this._byLayer == null)
            {
                return;
            }
            this._resultSelectionSet=this._queryByLayer.Select();
            this._resultFeatureSelection = (IFeatureSelection)this._resultLayer;
            this._resultFeatureSelection.SelectionSet = this._resultSelectionSet;
        }

        #endregion

        #region ISpatialAlgrorithm Members

        void ISpatialAlgrorithm.SetLayers(IFeatureLayer fromLayer, IFeatureLayer byLayer)
        {
            this._fromLayer = fromLayer;
            this._byLayer = byLayer;
        }

        #endregion

        #region ISpatialAlgrorithm Members

        IFeatureLayer ISpatialAlgrorithm.GetResultLayer()
        {
            return this._resultLayer;
        }

        ISelectionSet ISpatialAlgrorithm.GetResultSelectionSet()
        {
            return this._resultSelectionSet;
        }

        void ISpatialAlgrorithm.IsUseSelected(bool useSelected)
        {
            this._queryByLayer.UseSelectedFeatures = useSelected;
        }

        void ISpatialAlgrorithm.SetBufferDistance(double buffer)
        {
            this._queryByLayer.BufferDistance=buffer;
        }

        void ISpatialAlgrorithm.SetMethod(esriLayerSelectionMethod method)
        {
            this._queryByLayer.LayerSelectionMethod = method;
        }

        void ISpatialAlgrorithm.SetResultType(esriSelectionResultEnum resultType)
        {
            this._queryByLayer.ResultType = resultType;
        }

        ISelectionSet ISpatialAlgrorithm.Execute()
        {
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
            IFeatureWorkspace fw = (IFeatureWorkspace)sdeConn.Workspace;
            ITnFeatureClassName fcName = new TnFeatureClassName(sdeConn.Workspace);
            ITnTableName tblName = new TnTableName(sdeConn.Workspace);
            IFeatureClass xaFeatureClass = fw.OpenFeatureClass(fcName.FC_RANH_XA_POLY.NAME);
            IFeatureLayer xaFeatureLayer = new FeatureLayerClass();
            xaFeatureLayer.FeatureClass = xaFeatureClass;
            IFeatureClass duongFeatureClass = fw.OpenFeatureClass(fcName.FC_DUONG.NAME);
            IFeatureLayer duongFeatureLayer = new FeatureLayerClass();
            duongFeatureLayer.FeatureClass = duongFeatureClass;
            //IQueryFilter qrf = new QueryFilterClass();
            //qrf.WhereClause = string.Format("{0}='{1}'", fcName.FC_RANH_XA_POLY.MA_XA, 5);
            //ISelectionSet xaSelectionSet = xaFeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionOnlyOne, sdeConn.Workspace);
            //IFeatureSelection xaFeatureSelection = (IFeatureSelection)xaFeatureLayer;
            //xaFeatureSelection.SelectionSet = xaSelectionSet;
            //if (this._fromLayer == null || this._byLayer == null)
            //{
            //    return null;
            //}
            //this._resultSelectionSet=this._queryByLayer.Select();
            //IFeatureLayer f=new FeatureLayerClass();
            //f.FeatureClass=this._frmFc;
            //IFeatureLayer b=new FeatureLayerClass();
            //b.FeatureClass = this._byFc;
            //IFeatureSelection fs = (IFeatureSelection)this._byLayer;
            //MessageBox.Show(fs.SelectionSet.Count.ToString());
            IQueryByLayer qrbl = new QueryByLayerClass();
            qrbl.FromLayer = duongFeatureLayer;
            qrbl.ByLayer = xaFeatureLayer;
            qrbl.LayerSelectionMethod = esriLayerSelectionMethod.esriLayerSelectIntersect;
            qrbl.ResultType = esriSelectionResultEnum.esriSelectionResultNew;
            qrbl.UseSelectedFeatures = true;

            ISelectionSet sl = qrbl.Select();
            MessageBox.Show("Line 125 AlgTimDuong:"+sl.Count.ToString());
            //MessageBox.Show(xaFeatureLayer.FeatureClass.AliasName);
            try
            {
                //this._resultSelectionSet = this._queryByLayer.Select();
                //this._resultSelectionSet =qrbl.Select();
                //MessageBox.Show(string.Format("line 120 AlgrithmTimDuong, so luong duong:{0}", this._resultSelectionSet.Count));
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
            //this._resultSelectionSet = sls;
            //Dang bi loi cho nay
            this._resultFeatureSelection = (IFeatureSelection)this._resultLayer;
            this._resultFeatureSelection.SelectionSet = this._resultSelectionSet;
            return this._resultSelectionSet;
        }

        #endregion

        #region IAlgorithm Members


        void IAlgorithm.SetResultLayer(IFeatureLayer resultLayer)
        {
            this._resultLayer=resultLayer;
        }

        #endregion

        #region IAlgorithm Members


        string IAlgorithm.Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        #endregion

        #region ISpatialAlgrorithm Members

        IFeatureLayer ISpatialAlgrorithm.ByLayer
        {
            get
            {
                return this._byLayer;
            }
            set
            {
                this._byLayer=value;
            }
        }

        IFeatureLayer ISpatialAlgrorithm.FromLayer
        {
            get
            {
                return this._fromLayer;
            }
            set
            {
                this._fromLayer=value;
            }
        }

        #endregion

        #region ISpatialAlgrorithm Members

        IFeatureClass ISpatialAlgrorithm.ByFeatureClass
        {
            get
            {
                return this._byFc;
            }
            set
            {
                this._byFc = value;
            }
        }

        IFeatureClass ISpatialAlgrorithm.FromFeatureClass
        {
            get
            {
                return this._frmFc;
            }
            set
            {
                this._frmFc=value;
            }
        }

        #endregion
    }
}
