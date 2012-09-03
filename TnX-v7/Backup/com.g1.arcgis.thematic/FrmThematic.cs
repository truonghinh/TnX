using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Controls;

namespace com.g1.arcgis.thematic
{
    public partial class FrmThematic : DevExpress.XtraEditors.XtraForm
    {
        IThematicView _view;
        IThematic _thematic;
        IThematicController _controller;
        IMapControl3 _mapControl;
        ITOCControl2 _tocControl;
        public FrmThematic()
        {
            InitializeComponent();
            _view = (IThematicView)this.thematicView1;
            _view.SetParent(this);
            this.Load += new EventHandler(FrmThematic_Load);
        }

        void FrmThematic_Load(object sender, EventArgs e)
        {
            //_view.SetMapControl(_mapControl);
            //_view.SetTocControl(_tocControl);
            //_thematic = new Thematic(_mapControl);
            //_controller = new ThematicController(_thematic, _view);
        }
        public void SetControls(IMapControl3 map, ITOCControl2 toc)
        {
            _mapControl = map;
            _tocControl = toc;
            _view.SetMapControl(_mapControl);
            _view.SetTocControl(_tocControl);
            //_thematic = new Thematic(_mapControl);
            //_thematic.SetTocControl(_tocControl);
            //_controller = new ThematicController(_thematic, _view);
        }
    }
}