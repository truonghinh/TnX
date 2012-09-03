using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using com.g1.arcgis.property;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.ADF.COMSupport;

namespace com.g1.arcgis.tn.map
{
    public partial class GPropertiesView : DevExpress.XtraEditors.XtraForm,ILabelView
    {
        private IMapControl4 _mapControl;
        private IFeatureLayer _featureLayer;
        private static GPropertiesView _meForm = new GPropertiesView();
        private static bool isShown = false;

        private GPropertiesView()
        {
            InitializeComponent();
        }

        #region singleton
        public static GPropertiesView CallMe
        {
            get {
                if (_meForm == null)
                {
                    _meForm = new GPropertiesView();
                }
                return _meForm; }
        }
        static GPropertiesView()
        {
            _meForm.FormClosing += new FormClosingEventHandler(meForm_FormClosing);
        }

        static void meForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            isShown = false;
            _meForm.Hide();
        }

        public new void ShowDialog()
        {
            if (isShown)
            {
                base.ShowDialog();
            }
            else
            {
                isShown = true;
                base.ShowDialog();
            }
        }

        public new void Show()
        {
            if (isShown)
            {
                base.Show();
            }
            else
            {
                isShown = true;
                base.Show();
            }
        }
        #endregion

        private void applyLabels()
        {
            IGeoFeatureLayer geoflay = _featureLayer as IGeoFeatureLayer;
            IAnnotateLayerPropertiesCollection annopropcol;
            IAnnotateLayerProperties annolayprop;
            IElementCollection enumvisiblecol;
            annopropcol = geoflay.AnnotationProperties;
            annopropcol.QueryItem(0, out annolayprop, out enumvisiblecol, out enumvisiblecol);
            ILabelEngineLayerProperties labengprop = annolayprop as ILabelEngineLayerProperties;

            labengprop.Expression = "["+cbxField.SelectedItem.ToString()+"]";//"[CITY_NAME]";  // field name
            labengprop.Symbol = new TextSymbolClass();
            IRgbColor color = new RgbColorClass();
            color.Blue = ((Color)clrColor.EditValue).B;
            color.Green = ((Color)clrColor.EditValue).G;
            color.Red = ((Color)clrColor.EditValue).R;
            //color.RGB = ((Color)clrColor.EditValue).GetHue();
            //MessageBox.Show("line 88 pro, color=" + ((Color)clrColor.EditValue).ToArgb().ToString());
            labengprop.Symbol.Color = color;//((Color)clrColor.EditValue).ToArgb();
            decimal size = (decimal)spnSize.EditValue;
            //labengprop.Symbol.Font.Size = (decimal)spnSize.EditValue;
            labengprop.Symbol.Font=(stdole.IFontDisp)OLE.GetIFontDispFromFont(new Font("Arial" , (float)size , FontStyle.Bold));
            //MessageBox.Show("line 90 pro, size=" + labengprop.Symbol.Font.Size.ToString());
            if (chkIShow.CheckState == CheckState.Checked)
            {
                geoflay.DisplayAnnotation = true;
            }
            else
            {
                geoflay.DisplayAnnotation = false;
            }
            annolayprop.LabelWhichFeatures = esriLabelWhichFeatures.esriVisibleFeatures;
            _mapControl.ActiveView.Refresh();
        }

        #region ILabelView Members

        void ILabelView.Show()
        {
            this.Show();
        }

        void ILabelView.Close()
        {
            this.Close();
        }

        IFeatureLayer ILabelView.MyLayer
        {
            get
            {
                return _featureLayer;
            }
            set
            {
                _featureLayer = value;
                txtLayer.Text = _featureLayer.FeatureClass.AliasName;
                IFields fields = _featureLayer.FeatureClass.Fields;
                int c = fields.FieldCount;
                cbxField.Properties.Items.Clear();
                for (int i = 0; i < c;i++ )
                {
                    cbxField.Properties.Items.Add(fields.get_Field(i).AliasName);
                }
                cbxField.SelectedIndex = 0;
            }
        }

        IMapControl4 ILabelView.MyMapControl
        {
            get
            {
                return _mapControl;
            }
            set
            {
                _mapControl = value;
            }
        }

        #endregion

        private void btnTry_Click(object sender, EventArgs e)
        {
            applyLabels();
           
            //MessageBox.Show("line 91 GPropertiesView, color=" + clrColor.EditValue);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            applyLabels();
            this.Close();
        }

    }
}