using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.calculation;

namespace com.g1.arcgis.tn.calculation.algorithm
{
    public partial class AlgorithmPage : DevExpress.XtraEditors.XtraUserControl,IAlgorithmView
    {
        public AlgorithmPage()
        {
            InitializeComponent();
        }

        #region IAlgorithmView Members

        void IAlgorithmView.Cancel()
        {
            throw new NotImplementedException();
        }

        void IAlgorithmView.Help()
        {
            throw new NotImplementedException();
        }

        void IAlgorithmView.LoadAlgorithm()
        {
            throw new NotImplementedException();
        }

        void IAlgorithmView.Save()
        {
            throw new NotImplementedException();
        }

        void IAlgorithmView.SetDefault()
        {
            throw new NotImplementedException();
        }

        void IAlgorithmView.UpdateIntoLocalAlg()
        {
            throw new NotImplementedException();
        }

        void IAlgorithmView.UpdateIntoResultAlg()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
