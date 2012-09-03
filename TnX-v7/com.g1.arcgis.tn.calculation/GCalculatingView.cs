using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.calculation;
using DevExpress.XtraBars.Docking;
using com.g1.arcgis.landprice;
using com.g1.arcgis.edit;
using gov.tn.TnDatabaseStructure;
using com.g1.arcgis.connection;
using AsYetUnnamed;
using ESRI.ArcGIS.Geodatabase;
using System.Runtime.InteropServices;
using com.g1.arcgis.tn.config;

namespace com.g1.arcgis.tn.calculation
{
    public partial class GCalculatingView : DevExpress.XtraEditors.XtraUserControl, ICalculationMonitor
    {
        private delegate void _watching(object log);
        //private delegate void _progressing(int percent);
        //private delegate void _addList(string obj);
        //private delegate void _progressingTotal(object arg);
        //private delegate void _progressingTotalCount(object arg);
        private delegate void _wathching(object[,] arg);
        //private delegate void _addThuaKhoaGia(object arg);
        private DockPanel _parent;
        //private ILandpriceDetailView _detailView;
        private string _name;
        private ITnFeatureClassName _fcName;
        private ITnTableName _tblName;
        static int numclick = 0;
        private List<object> _thuaTinhGia;
        private List<object> _thuaKhoaGia;
        SdeConnection _conn;
        ISdeConnectionInfo _sdeConn;
        IFeatureWorkspace fw;
        private ILandpriceView _landPriceView;
        private ILandpriceView _landPricePublicView;
        //private FrmLandPriceInfo _frmLandPriceView;
        private ILandprice _landPrice;
        private ILandpriceController _lanpriceController;
        private MultiColumnListBox _curentListBox;
        //FrmLandPriceInfo frmLandPriceView = FrmLandPriceInfo.CallMe;
        //FrmLandPriceInfoPublic frmLandPricePublic = FrmLandPriceInfoPublic.CallMe;
        IFrmLandPriceView frmLandPriceView;
        IFrmLandPriceView frmLandPricePublic;
        private ICurrentConfig _config;
        private IExecutor _executor;
        private ICalculationController _calcController;
        public GCalculatingView()
        {
            InitializeComponent();
            _name = "CalculatingView";
            
            //initPopupMenu();

            _thuaKhoaGia = new List<object>();
            _thuaTinhGia = new List<object>();

            mlbThuaKhoaGia.ColumnWidths[0] = 50;
            mlbThuaKhoaGia.ColumnWidths[1] = 50;
            mlbThuaKhoaGia.ColumnWidths[2] = 50;
            mlbThuaKhoaGia.ColumnWidths[3] = 50;
            mlbThuaKhoaGia.ColumnWidths[3] = 200;

            mlbThuaTinhGia.ColumnWidths[0] = 50;
            mlbThuaTinhGia.ColumnWidths[1] = 50;
            mlbThuaTinhGia.ColumnWidths[2] = 50;
            mlbThuaTinhGia.ColumnWidths[3] = 200;
        }

        private void initPopupMenu()
        {
            MenuItem xemgiadat = new MenuItem("&Xem giá đất");
            MenuItem xemThongTin = new MenuItem("&Xem thông tin");
            MenuItem xemVitri = new MenuItem("&Xem vị trí");
            MenuItem demSoLuong = new MenuItem("&Đếm số lượng");

            MenuItem xemgiadat2 = new MenuItem("&Xem giá đất");
            MenuItem xemThongTin2 = new MenuItem("&Xem thông tin");
            MenuItem xemVitri2 = new MenuItem("&Xem vị trí");
            MenuItem demSoLuong2 = new MenuItem("&Đếm số lượng");

            this.mlbThuaTinhGia.ContextMenu = new ContextMenu();
            this.mlbThuaTinhGia.ContextMenu.MenuItems.Add(xemgiadat);
            this.mlbThuaTinhGia.ContextMenu.MenuItems.Add(xemThongTin);
            this.mlbThuaTinhGia.ContextMenu.MenuItems.Add(xemVitri);
            this.mlbThuaTinhGia.ContextMenu.MenuItems.Add("-");
            this.mlbThuaTinhGia.ContextMenu.MenuItems.Add(demSoLuong);

            this.mlbThuaKhoaGia.ContextMenu = new ContextMenu();
            this.mlbThuaKhoaGia.ContextMenu.MenuItems.Add(xemgiadat2);
            this.mlbThuaKhoaGia.ContextMenu.MenuItems.Add(xemThongTin2);
            this.mlbThuaKhoaGia.ContextMenu.MenuItems.Add(xemVitri2);
            this.mlbThuaKhoaGia.ContextMenu.MenuItems.Add("-");
            this.mlbThuaKhoaGia.ContextMenu.MenuItems.Add(demSoLuong2);

            xemgiadat.Click += new EventHandler(xemgiadat_Click);
            xemThongTin.Click += new EventHandler(xemThongTin_Click);
            xemVitri.Click += new EventHandler(xemVitri_Click);
            demSoLuong.Click += new EventHandler(demSoLuong_Click);

            xemgiadat2.Click+=new EventHandler(xemgiadat_Click);
            xemThongTin2.Click += new EventHandler(xemThongTin_Click);
            xemVitri2.Click += new EventHandler(xemVitri_Click);
            demSoLuong2.Click += new EventHandler(demSoLuong_Click);
        }

        void demSoLuong_Click(object sender, EventArgs e)
        {
            MessageBox.Show(((MultiColumnListBox)sender).Items.Count.ToString());
        }

        void xemVitri_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void xemThongTin_Click(object sender, EventArgs e)
        {
            //FrmLandPriceInfo frm = FrmLandPriceInfo.CallMe;
            //frm.ShowDialog();
        }
        
        void xemgiadat_Click(object sender, EventArgs e)
        {
            

            #region cu
            /*
            _detailView.LoaiDat = 0;
            _detailView.MaThua = this.mlbThuaKhoaGia.Text;//.SelectedItem.ToString();
            _detailView.Show();
            if (numclick == 0)
            {
                ICurrentConfig config=CurrentConfig.CallMe();
                //SdeConnection conn=new SdeConnection();
                //ISdeConnectionInfo sdeConn=(ISdeConnectionInfo)conn;
                //_tblName = new TnTableName(sdeConn.Workspace);
                //string tnn = string.Format("{0}_{1}", _tblName.THUA_GIADAT_NN, config.NamApDung);
                //string tpnnnt = string.Format("{0}_{1}", _tblName.THUA_GIADAT_PNN_NONGTHON, config.NamApDung);
                //string tpnndt = string.Format("{0}_{1}", _tblName.THUA_GIADAT_PNN_DOTHI, config.NamApDung);
                //_detailView.SetTablesName(tnn, tpnnnt, tpnndt);
                _detailView.CurrentYear = config.NamApDung;
                _detailView.ReLoad();
            }
            _detailView.Query();
            _detailView.ShowDetail();
            numclick = 1;
             * */
            #endregion
        }

        #region ICalculationMonitor Members

        void ICalculationMonitor.Progressing(object report)
        {
            if (this.progressBar1.InvokeRequired)
            {
                _watching progressDelegate = new _watching(((ICalculationMonitor)this).Progressing);
                this.progressBar1.Invoke(progressDelegate, new object[] { report });
            }
            else
            {
                this.progressBar1.EditValue = (int)report;
                this.progressBar1.Text = report.ToString();
            }
        }

        void ICalculationMonitor.Watching(object arg)
        {
            if (this.rtbDtLog.InvokeRequired)
            {
                _watching watchingDelegate = new _watching(((ICalculationMonitor)this).Watching);
                this.rtbDtLog.Invoke(watchingDelegate, new object[] { arg });
            }
            else
            {
                this.rtbDtLog.AppendText(arg.ToString());
                this.rtbDtLog.SelectionStart = this.rtbDtLog.Text.Length;
                this.rtbDtLog.ScrollToCaret();
            }
        }

        void ICalculationMonitor.Finished()
        {
            if (this.progressBar1.InvokeRequired)
            {
                _watching progressDelegate = new _watching(((ICalculationMonitor)this).Progressing);
                this.progressBar1.Invoke(progressDelegate, new object[] { 0 });
            }
            else
            {
                this.progressBar1.EditValue = 0;
            }
            MessageBox.Show("Đã tính xong");
        }

        void ICalculationMonitor.Begining()
        {
            _thuaKhoaGia.Clear();
            _thuaTinhGia.Clear();

            numclick = 0;
            if (this.rtbDtLog.InvokeRequired)
            {
                _watching watchingDelegate = new _watching(((ICalculationMonitor)this).Watching);
                this.rtbDtLog.Invoke(watchingDelegate, new object[] { "" });
            }
            else
            {
                this.rtbDtLog.Clear();
            }
            if (this.mlbThuaKhoaGia.InvokeRequired)
            {
                _watching watchingDelegate = new _watching(((ICalculationMonitor)this).Watching);
                this.mlbThuaKhoaGia.Invoke(watchingDelegate, new object[] { "" });
            }
            else
            {
                this.mlbThuaKhoaGia.DataSource=null;
            }

            if (this.mlbThuaTinhGia.InvokeRequired)
            {
                _watching watchingDelegate = new _watching(((ICalculationMonitor)this).Watching);
                this.mlbThuaTinhGia.Invoke(watchingDelegate, new object[] { "" });
            }
            else
            {
                this.mlbThuaTinhGia.DataSource = null;
            }

        }

        string ICalculationMonitor.Name
        {
            get
            {
                return this._name;
            }

        }

        void ICalculationMonitor.Show()
        {
            this._parent.Show();
        }

        void ICalculationMonitor.AddListObject(string obj)
        {
            //if (this.lbcDtListThua.InvokeRequired)
            //{
            //    _addList addListDelegate = new _addList(((ICalculationMonitor)this).AddListObject);
            //    this.lbcDtListThua.Invoke(addListDelegate, new object[] { obj });
            //}
            //else
            //{
            //    //MessageBox.Show(obj);
            //    this.lbcDtListThua.Items.Add(obj);
            //    //this.lbcDtListThua.s
            //    //this.rtbDtLog.SelectionStart = this.rtbDtLog.Text.Length;
            //    //this.rtbDtLog.ScrollToCaret();
            //}
        }

        void ICalculationMonitor.SetParentControl(DockPanel parent)
        {
            this._parent = parent;
        }

        #endregion

        private void btnDtClose_Click(object sender, EventArgs e)
        {
            this._parent.Hide();
        }

        #region ICalculationMonitor Members


        //void ICalculationMonitor.SetDetailView(ILandpriceDetailView view)
        //{
        //    this._detailView = view;
        //}

        #endregion

        private void mlbThuaKhoaGia_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void mlbThuaTinhGia_MouseUp(object sender, MouseEventArgs e)
        {
            _curentListBox = (MultiColumnListBox)sender;
        }

        #region IComparable<ICalculationMonitor> Members

        int IComparable<ICalculationMonitor>.CompareTo(ICalculationMonitor other)
        {
            return string.Compare(this._name, other.Name);
        }

        #endregion

        #region ICalculationMonitor Members


        void ICalculationMonitor.Watching(CalculationEventArg e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ICalculationMonitor Members


        void ICalculationMonitor.Watching(object[,] arg)
        {
            
        }

        #endregion

        #region ICalculationMonitor Members


        void ICalculationMonitor.AddListThuaDuocTinhGia(object[,] args)
        {
            if (this.mlbThuaTinhGia.InvokeRequired)
            {
                _wathching addListDelegate = new _wathching(((ICalculationMonitor)this).AddListThuaDuocTinhGia);
                this.mlbThuaTinhGia.Invoke(addListDelegate, new object[] { args });
            }
            else
            {
                DataSet ds = DataArray.ToDataSet(args);
                DataTable dt = ds.Tables[0];
                DataTable curTb = (DataTable)mlbThuaTinhGia.DataSource;
                if (curTb != null)
                {
                    curTb.Merge(dt);
                }
                else
                {
                    curTb = dt;
                }
                mlbThuaTinhGia.DataSource = curTb;

            }
  
        }

        void ICalculationMonitor.AddListThuaKhoaGia(object[,] args)
        {
            //MessageBox.Show(args[0, 0].ToString());
            if (this.mlbThuaKhoaGia.InvokeRequired)
            {
                _wathching addListDelegate = new _wathching(((ICalculationMonitor)this).AddListThuaKhoaGia);
                this.mlbThuaKhoaGia.Invoke(addListDelegate, new object[] { args });
            }
            else
            {
                DataSet ds = DataArray.ToDataSet(args);
                DataTable dt = ds.Tables[0];
                DataTable curTb = (DataTable)mlbThuaKhoaGia.DataSource;
                if (curTb != null)
                {
                    curTb.Merge(dt);
                }
                else
                {
                    curTb = dt;
                }
                mlbThuaKhoaGia.DataSource = curTb;

            }
        }

        #endregion

        #region ICalculationMonitor Members


        void ICalculationMonitor.ProgressingTotal(object arg)
        {

            if (this.lblTotalProgress.InvokeRequired)
            {
                _watching myDelegate = new _watching(((ICalculationMonitor)this).ProgressingTotal);
                this.lblTotalProgress.Invoke(myDelegate, new object[] { arg });
            }
            else
            {
                this.lblTotalProgress.Text = arg.ToString();
                //this.lblTotalProgress.Visible = true;
            }
        }

        void ICalculationMonitor.ProgressingTotalCount(object arg)
        {
            if (arg == null)
            {
                return;
            }
            if (this.lblTotalCount.InvokeRequired)
            {
                _watching myDelegate = new _watching(((ICalculationMonitor)this).ProgressingTotalCount);
                this.lblTotalCount.Invoke(myDelegate, new object[] { arg });
            }
            else
            {
                this.lblTotalCount.Text = arg.ToString();
                //this.lblTotalCount.Visible = true;
            }
        }

        #endregion

        private void mlbThuaKhoaGia_SelectedIndexChanged(object sender, EventArgs e)
        {
           //MessageBox.Show(((MultiColumnListBox)sender).Text);
        }

        private void mlbThuaKhoaGia_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void mlbThuaKhoaGia_DrawSubItem(object sender, DrawSubItemEventArgs e)
        {

        }

        private void mlbThuaKhoaGia_MeasureSubItem(object sender, MeasureSubItemEventArgs e)
        {
            MultiColumnListBox lb = (MultiColumnListBox)sender;
            SizeF s = e.Graphics.MeasureString("O", lb.Font);
            e.ItemWidth = (int)s.Width;
            e.ItemHeight = (int)s.Height + 4;
        }

        private void mniRefresh_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(mlbThuaTinhGia.GetItemAt(0).ToString());
            //MessageBox.Show(mlbThuaTinhGia.Value.ToString());
            _config = CurrentConfig.CallMe();
            int c = mlbThuaTinhGia.Items.Count;
            //MessageBox.Show(string.Format("line 423 - GCalculatingView\n{0}",c));
            IQueryFilter qrf = new QueryFilterClass();
            List<object> lstMathua = new List<object>();
            List<object> lstSothua = new List<object>();
            List<object> lstSoto = new List<object>();
            List<object> lstDiachi = new List<object>();
            _conn = new SdeConnection();
            _sdeConn = (ISdeConnectionInfo)_conn;
            fw = (IFeatureWorkspace)_sdeConn.Workspace;
            _tblName = new TnTableName(_sdeConn.Workspace);
            _fcName = new TnFeatureClassName(_sdeConn.Workspace);
            object[,] data = new object[c,5];
            List<object[]> lstObj = new List<object[]>();
            string thuaName = string.Format("{0}_{1}", DataNameTemplate.Thua, _config.NamApDung);
            for (int i = 0; i < c; i++)
            {
                object id = mlbThuaTinhGia.GetItemAt(i, 0);
                object mathua = mlbThuaTinhGia.GetItemAt(i,1);

                //lstMathua.Add(mathua);
                data[i, 0] = id;
                data[i, 1] = mathua;
                object soto = "";
                object sothua = "";


                ITable thuaTable = null;
                try
                {
                    thuaTable = fw.OpenTable(thuaName);
                }
                catch (Exception e1)
                {
                    MessageBox.Show(string.Format("line 445 GcalculatingView\n{0}", e1));
                    return;
                }
                
                qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_THUA.MA_THUA, mathua);
                ICursor cur = thuaTable.Search(qrf, false);
                IRow row = null;
                try
                {
                    row = cur.NextRow();
                    if (row != null)
                    {
                        sothua = row.get_Value(row.Fields.FindField(_fcName.FC_THUA.SO_THUA));
                        soto = row.get_Value(row.Fields.FindField(_fcName.FC_THUA.SO_TO));

                        
                        //lstSothua.Add(sothua);
                        //lstSoto.Add(soto);
                    }
                    else
                    {
                        sothua = "";
                        soto="";
                    }
                    data[i, 2] = soto;
                    data[i, 3] = sothua;
                    //lstSothua.Add(sothua);
                    //lstSoto.Add(soto);
                }
                catch (Exception e2)
                {
                    MessageBox.Show(string.Format("line 473 GcalculatingView\n{0}", e2));
                    //lstSothua.Add(sothua);
                    //lstSoto.Add(soto);
                    data[i, 2] = "";
                    data[i, 3] = "";
                }
                finally
                {
                    //lstDiachi.Add("");
                    data[i, 4] = "";
                    Marshal.ReleaseComObject(cur);
                }
            }
            //for (int i = 0; i < c; i++)
            //{
            //    object[] obj = new object[] { lstMathua[i], lstSoto[i], lstSothua[i], lstDiachi[i] };
            //    lstObj.Add(obj);
            //}
            //data = new object[c, 2];
                //MessageBox.Show(string.Format("{0}\n{1}\n{2}", data[0, 0].ToString(), data[0, 1].ToString(), data[0, 2].ToString()));
            DataSet ds=DataArray.ToDataSet(data);
            mlbThuaTinhGia.DataSource = ds.Tables[0];
            

        }

        #region ICalculationMonitor Members


        void ICalculationMonitor.CatchThuaTinhGia(List<object> arg)
        {
            _thuaTinhGia = arg;
        }

        void ICalculationMonitor.CatchThuaKhoaGia(List<object> arg)
        {
            throw new NotImplementedException();
        }

        void ICalculationMonitor.CatchThuaTinhGia(object arg)
        {
            _thuaTinhGia.Add(arg);
        }

        void ICalculationMonitor.CatchThuaKhoaGia(object arg)
        {
            _thuaKhoaGia.Add(arg);
        }


        

        void ICalculationMonitor.Watching(List<object> arg)
        {
            throw new NotImplementedException();
        }

        void ICalculationMonitor.Watching(int report)
        {
            throw new NotImplementedException();
        }

        #endregion

        private void btnDtDetail_Click(object sender, EventArgs e)
        {
            cmnOption.Show(System.Windows.Forms.Cursor.Position);
        }

        private void mniXemChiTietThua_Click(object sender, EventArgs e)
        {
            if (_landPriceView == null)
            {
                return;
            }
            if(_curentListBox.DataSource!=null)
            {
                //_landPriceView = frmLandPriceView.GetView();
                _landPriceView.Config = CurrentConfig.CallMe();
                _landPriceView.CurrentMathua = _curentListBox.GetItemAt(1);
                _landPriceView.Excutor = this._executor;
                _landPriceView.CalcController = this._calcController;
                _landPriceView.Show();
                _landPriceView.LoadPrice();
            }
        }

        #region ICalculationMonitor Members


        void ICalculationMonitor.AddListThuaDuocTinhGia(params object[] args)
        {
            object[,] ids = new object[,] { { args[0], args[1], "", "","" } };
            ((ICalculationMonitor)this).AddListThuaDuocTinhGia(ids);
            
        }

        void ICalculationMonitor.AddListThuaKhoaGia(params object[] args)
        {
            object[,] ids = new object[,] { { args[0], args[1], "", "","" } };
            ((ICalculationMonitor)this).AddListThuaKhoaGia(ids);
        }

        #endregion

        #region ICalculationMonitor Members


        void ICalculationMonitor.ProgressingPart1Total(object arg)
        {
            if (this.lblPart1Total.InvokeRequired)
            {
                _watching myDelegate = new _watching(((ICalculationMonitor)this).ProgressingPart1Total);
                this.lblPart1Total.Invoke(myDelegate, new object[] { arg });
            }
            else
            {
                this.lblPart1Total.Text = arg.ToString();
                //this.lblPart1Total.Visible = true;
            }
        }

        void ICalculationMonitor.ProgressingPart1Count(object arg)
        {
            if (this.lblPart1Count.InvokeRequired)
            {
                _watching myDelegate = new _watching(((ICalculationMonitor)this).ProgressingPart1Count);
                this.lblPart1Count.Invoke(myDelegate, new object[] { arg });
            }
            else
            {
                this.lblPart1Count.Text = arg.ToString();
                //this.lblPart1Count.Visible = true;
            }
        }

        #endregion

        private void mniXemVungGiaCongBo_Click(object sender, EventArgs e)
        {
            if (_landPricePublicView == null)
            {
                return;
            }
            if (_curentListBox.DataSource != null)
            {
                //_landPricePublicView = frmLandPricePublic.GetView();
                _landPricePublicView.Config = CurrentConfig.CallMe();
                _landPricePublicView.CurrentMathua = _curentListBox.GetItemAt(1);
                _landPricePublicView.Show();
                _landPricePublicView.LoadPrice();
            }
        }

        #region ICalculationMonitor Members


        void ICalculationMonitor.SetDetailView(ILandpriceView calcView, ILandpriceView publicView)
        {
            this._landPriceView = calcView;
            this._landPricePublicView = publicView;
        }

        #endregion

        #region ICalculationMonitor Members


        IExecutor ICalculationMonitor.Executor
        {
            get
            {
                return this._executor;
            }
            set
            {
                this._executor = value;
            }
        }

        #endregion

        #region ICalculationMonitor Members


        ICalculationController ICalculationMonitor.CalcController
        {
            get
            {
                return _calcController;
            }
            set
            {
                _calcController = value;
            }
        }

        #endregion
    }
}
