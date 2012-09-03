using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.connection;
using System.Data.SqlClient;
using com.g1.arcgis.database;
using com.g1.arcgis.map;
using ESRI.ArcGIS.Geodatabase;

namespace com.g1.arcgis.dataManagement
{
    public partial class FrmDeleteLayers : DevExpress.XtraEditors.XtraForm
    {
        private IMapView _mapView;
        ISDETableQuery qrf;
        public FrmDeleteLayers()
        {
            InitializeComponent();
            
            this.Load += new EventHandler(FrmAddLayers_Load);
        }

        private void loadData()
        {
            qrf = new SDETable();
            List<string> layers = qrf.GetLayers();
            if (chkbLayers.Items.Count > 0)
            {
                chkbLayers.Items.Clear();
            }
            foreach (string s in layers)
            {
                chkbLayers.Items.Add(s);
            }
            lblLayersCount.Text = chkbLayers.Items.Count.ToString();
        }

        void FrmAddLayers_Load(object sender, EventArgs e)
        {
            loadData();
        }

        public void SetMapView(IMapView mapView)
        {
            _mapView = mapView;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = (ISdeConnectionInfo)conn;
            
            int len=chkbLayers.CheckedItems.Count;
            //string[] layers =new string[len];
            string layer = "";
            for(int i=0;i<len;i++)
            {
                layer = chkbLayers.CheckedItems[i].ToString();
                try
                {
                    ITable table = ((IFeatureWorkspace)sdeConn.Workspace).OpenTable(layer);
                    FeatureClassManagement.DeleteFeatureClass((IDataset)table);
                    //chkbLayers.Items.Remove(chkbLayers.CheckedItems[i]);
                    //chkbLayers.Items.RemoveAt(i);
                }
                catch (Exception ex) {MessageBox.Show(String.Format("line 60 FrmDeleteLayers, \nexp={0}",ex)); continue; }
            }
            loadData();
            //_mapView.AddLayer(layers);
            //this.Close();
        }
    }
}