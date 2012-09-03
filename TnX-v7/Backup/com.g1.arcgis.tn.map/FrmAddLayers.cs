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

namespace com.g1.arcgis.tn.map
{
    public partial class FrmAddLayers : DevExpress.XtraEditors.XtraForm
    {
        private IMapView _mapView;
        public FrmAddLayers()
        {
            InitializeComponent();
            
            this.Load += new EventHandler(FrmAddLayers_Load);
        }

        void FrmAddLayers_Load(object sender, EventArgs e)
        {
            ISDETableQuery qrf = new SDETable();
            List<string> layers = qrf.GetLayers();
            foreach (string s in layers)
            {
                chkbLayers.Items.Add(s);
            }
        }

        public void SetMapView(IMapView mapView)
        {
            _mapView = mapView;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int len=chkbLayers.CheckedItems.Count;
            string[] layers =new string[len];
            for(int i=0;i<len;i++)
            {
                layers[i] = chkbLayers.CheckedItems[i].ToString();
            }
            _mapView.AddLayer(layers);
            this.Close();
        }
    }
}