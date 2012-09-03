using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.landprice;
using gov.tn.TnDatabaseStructure;
using com.g1.arcgis.calculation;

namespace com.g1.arcgis.tn.landprice
{
    public partial class FrmLandPriceInfoPublic : DevExpress.XtraEditors.XtraForm,IFrmLandPriceView
    {
        private static readonly FrmLandPriceInfoPublic _meForm = new FrmLandPriceInfoPublic();
        private ILandpriceView _view;
        //private ICurrentConfig _conf;
        private static bool isShown = false;
        
        private FrmLandPriceInfoPublic()
        {
            InitializeComponent();
            //_landprice = new GLandprice(); 
            _view = (ILandpriceView)this.gLandPriceView1;
            _view.LandpriceTableName=DataNameTemplate.Thua_Gia_Dat;
            _view.SetContainer(this);
            _view.MapView.SetLandpriceView("giadatcongbo", _view);
            _view.IsAllowRecalcPoistion(false);
            //_landprice.SetView(_view);
            //_controller = new GLandpriceController(_landprice, _view);
        }

        #region singleton
        public static FrmLandPriceInfoPublic CallMe
        {
            get { return _meForm; }
        }
        static FrmLandPriceInfoPublic()
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

        public void SetMaThua(object mathua)
        {
            _view.CurrentMathua = mathua;
            _view.LoadPrice();
        }

        public void SetId(object id)
        {

        }

        public void SetConfig(ICurrentConfig conf)
        {
            _view.Config = conf;
        }

        public ILandpriceView GetView()
        {
            return _view;
        }

        #region IFrmLandPriceView Members

        void IFrmLandPriceView.Show()
        {
            this.Show();
        }

        void IFrmLandPriceView.ShowDialog()
        {
            this.ShowDialog();
        }

        void IFrmLandPriceView.Close()
        {
            this.Close();
        }

        #endregion
    }
}