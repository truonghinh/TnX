using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.g1.arcgis.calculation
{
    public class AlgorithmVisitor:IVisitor
    {
        private IVisitorBag _bag;
        private static int _index;

        public AlgorithmVisitor()
        {
        }

        public AlgorithmVisitor(IVisitorBag bag)
        {
            this._bag = bag;
            _index = 0;
        }
        #region IVisitor Members

        void IVisitor.Visit(IAlgorithm alg)
        {
            //thong tin bang dau:from,by,result duoc dua vao bag truoc
            //khi xet den thuat toan 2, from,result cua bag la result cua thuat toan 1
            //by cua thuat toan tu cai dat san truoc khi duoc visit
            ISpatialBag spBag=(ISpatialBag)this._bag;
            alg.SetResultLayer(spBag.ResultFeatureLayer);
            //MessageBox.Show(_index.ToString());
            ISpatialAlgrorithm spAlg = (ISpatialAlgrorithm)alg;
            //spAlg.SetLayers(spBag.FromFeatureLayer, spBag.ByFeatureLayer);
            spAlg.FromLayer = spBag.FromFeatureLayer;
            spAlg.SetResultLayer(spBag.ResultFeatureLayer);

            spBag.ResultSelectionSet = spAlg.Execute();

            spBag.ResultFeatureLayer = spAlg.GetResultLayer();
            spBag.FromFeatureLayer = spAlg.GetResultLayer();
            _index++;
            
        }

        void IVisitor.SetBag(IVisitorBag bag)
        {
            this._bag=bag;
        }

        int IVisitor.GetCurrentIndex()
        {
            throw new NotImplementedException();
        }

        void IVisitor.Reset()
        {
            _index = 0 ;
        }

        #endregion
    }
}
