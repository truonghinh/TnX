using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.g1.arcgis.query;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;

namespace GCommands
{
    public partial class SelectByLocationView : Form,ISelectByLocationView
    {
        private IMapControl4 _mapControl;
        private static SelectByLocationView _meForm = new SelectByLocationView();
        private static bool isShown = false;
        private ILayer _fromLayer;
        private ILayer _byLayer;
        private double _buffer;
        private bool _applyBuffer;
        private esriUnits _bufferUnit;
        private esriLayerSelectionMethod _method;
        private esriSelectionResultEnum _resultType;
        private bool _useSelected=false;

        private SelectByLocationView()
        {
            InitializeComponent();
            try
            {
                cbxResultType.SelectedIndex = 0;
                cbxMethod.SelectedIndex = 0;
                cbxUnit.SelectedIndex = 2;
            }
            catch { }
            //cbxSelectLayer.SelectedIndex = 0;
            
        }

        #region singleton
        public static SelectByLocationView CallMe
        {
            get {
                if (_meForm == null)
                {
                    _meForm = new SelectByLocationView();
                }
                return _meForm; }
        }
        static SelectByLocationView()
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

        private void cbxSelectLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSelectLayer.Text = cbxSelectLayer.Text;
        }

        #region ISelectByLocationView Members

        IMapControl4 ISelectByLocationView.MapControl
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

        private void getMap()
        {
            //UID uid = new UIDClass();
            //IEnumLayer layers = _mapControl.Map.get_Layers(uid,false);
            ILayer layer = null;
            cbxSelectLayer.Items.Clear();
            lstInputLayer.Items.Clear();
            int c = _mapControl.LayerCount;
            for (int i = 0; i < c; i++)
            {
                layer = _mapControl.get_Layer(i);
                cbxSelectLayer.Items.Add(layer.Name);
                lstInputLayer.Items.Add(layer.Name);
            }
            cbxSelectLayer.SelectedIndex = 0;
        }

        void ISelectByLocationView.Show()
        {
            this.Show();
            getMap();
        }

        void ISelectByLocationView.Close()
        {
            this.Close();
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            selectFeatures();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            selectFeatures();
            this.Close();
        }

        private void selectFeatures()
        {
            
            IQueryByLayer _qrBl = new QueryByLayerClass();
            int method=cbxMethod.SelectedIndex;
            switch (method)
            {
                case 0:
                    _method = esriLayerSelectionMethod.esriLayerSelectIntersect;
                    break;
                case 1:
                    _method = esriLayerSelectionMethod.esriLayerSelectContainedBy;
                    break;
                case 2:
                    _method = esriLayerSelectionMethod.esriLayerSelectContains;
                    break;
                default:
                    _method = esriLayerSelectionMethod.esriLayerSelectIntersect;
                    break;
            }

            int selectLayer = cbxSelectLayer.SelectedIndex;
            _byLayer = _mapControl.get_Layer(selectLayer);
            int resultType=cbxResultType.SelectedIndex;
            switch (resultType)
            {
                case 0:
                    _resultType = esriSelectionResultEnum.esriSelectionResultNew;
                    break;
                case 1:
                    _resultType = esriSelectionResultEnum.esriSelectionResultAdd;
                    break;
                case 2:
                    _resultType = esriSelectionResultEnum.esriSelectionResultSubtract;
                    break;
                case 3:
                    _resultType = esriSelectionResultEnum.esriSelectionResultAnd;
                    break;
                case 4:
                    _resultType = esriSelectionResultEnum.esriSelectionResultXOR;
                    break;
                default:
                    _resultType = esriSelectionResultEnum.esriSelectionResultNew;
                    break;
            }
            if (chkUseSelected.CheckState == CheckState.Unchecked)
            {
                _useSelected = false;
            }
            else
            {
                _useSelected = true;
            }
            bool re = false;
            try
            {
                re = double.TryParse(txtBuffer.Text, out _buffer);
            }
            catch { }
            if (!re)
            {
                _buffer = 0;
            }
            int unit = cbxUnit.SelectedIndex;
            switch (unit)
            {
                case 0:
                    _bufferUnit = esriUnits.esriCentimeters;
                    break;
                case 1:
                    _bufferUnit = esriUnits.esriDecimeters;
                    break;
                case 2:
                    _bufferUnit = esriUnits.esriMeters;
                    break;
                case 3:
                    _bufferUnit = esriUnits.esriKilometers;
                    break;
                default:
                    _bufferUnit = esriUnits.esriMeters;
                    break;
            }
            
            _qrBl.ByLayer = (IFeatureLayer)_byLayer;
            _qrBl.LayerSelectionMethod = _method;
            _qrBl.ResultType = _resultType;
            _qrBl.UseSelectedFeatures = _useSelected;
            _qrBl.BufferDistance = _buffer;
            _qrBl.BufferUnits = _bufferUnit;
            foreach (object o in lstInputLayer.SelectedItems)
            {
                int index = lstInputLayer.Items.IndexOf(o);
                _fromLayer = _mapControl.get_Layer(index);
                
                _qrBl.FromLayer = (IFeatureLayer)_fromLayer;
                ISelectionSet selectionSet;
                IFeatureSelection featureSelection;
                try
                {
                    selectionSet = _qrBl.Select();
                    featureSelection = (IFeatureSelection)_fromLayer;
                    featureSelection.SelectionSet = selectionSet;
                    //MessageBox.Show("line 255 count=" + selectionSet.Count);
                }
                catch(Exception ex)
                { //MessageBox.Show("line 257 SelectByLocation, ex=" + ex); 
                    continue; }
            }
            _mapControl.ActiveView.Refresh();
        }

        
    }
}
