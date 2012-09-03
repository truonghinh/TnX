using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.query;
using System.Data.SqlClient;
using gov.tn;
using com.g1.arcgis.connection;
using com.g1.arcgis.edit;
using DevExpress.XtraGrid;
using com.g1.arcgis.map;
using com.g1.arcgis.landprice;
using gov.tn.TnDatabaseStructure;

namespace com.g1.arcgis.tn.query
{
    public partial class GQueryInfoThuaView : DevExpress.XtraEditors.XtraUserControl,IQueryThuaView
    {
        private object _type;
        private IQueryThuaController _controller;
        private IQueryThua _query;
        private IInfoForQuery _info;
        private IEditTableView _edit;
        private delegate void _getResult(DataSet dataset);
        private delegate void _finished();
        bool _newQuery = true;
        private ContextMenu _contextMenu;
        private string _oid="OBJECTID";
        private IMapView _mapView;
        private ILandpriceDetailView _landpriceView;
        private ITnFeatureClassName _fcName;
        private SdeConnection _conn;
        private ISdeConnectionInfo _sdeConn;
        public GQueryInfoThuaView()
        {
            InitializeComponent();
            _query = new QueryThua(this);
            _controller = new QueryThuaController(_query, this);
            _info = new ThuaInfo();
            _edit = (IEditTableView)this.gTableView1;
            this._query.Querying += new QueryingEventHandler(_query_Querying);
            this._query.Finished += new QueryFinishedEventHandler(_query_Finished);
            initPopup();
            this.gTableView1.ContextMenu = this._contextMenu;
            
        }

        private void initPopup()
        {
            MenuItem zoom = new MenuItem("&Xem bản đồ");
            //MenuItem tinhgiadat = new MenuItem();
            MenuItem xemgiadat = new MenuItem("&Xem giá đất");
            MenuItem tachHang = new MenuItem("&Tách hàng");
            MenuItem gopHang = new MenuItem("&Gộp hàng");
            //MenuItem xemGia = new MenuItem("&Gộp hàng");
            //tachHang.Break = true;
            _contextMenu = new ContextMenu();
            _contextMenu.MenuItems.Add(zoom);
            //((GridControl)sender).ContextMenu.MenuItems.Add(xemgiadat);
            _contextMenu.MenuItems.Add(xemgiadat);
            _contextMenu.MenuItems.Add(tachHang);
            _contextMenu.MenuItems.Add(gopHang);

            zoom.Click += new EventHandler(zoom_Click);
            //tinhgiadat.Click += new EventHandler(tinhgiadat_Click);
            xemgiadat.Click += new EventHandler(xemgiadat_Click);
            tachHang.Click += new EventHandler(tachhang_Click);
            gopHang.Click += new EventHandler(gophang_Click);
        }

        #region popup menu
        private void popupMenu(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                //((GridControl)sender).ContextMenu = _contextMenu;


                _contextMenu.Show(((GridControl)sender), new Point(e.X, e.Y));
            }


        }

        void zoom_Click(object sender, EventArgs e)
        {
            //zoomToSelect();
            int row = this.gTableView1.grvAttributeTable.GetSelectedRows()[0];
            string oid = this.gTableView1.grvAttributeTable.GetDataRow(row)[this._oid].ToString();
            string mathua = this.gTableView1.grvAttributeTable.GetDataRow(row)["mathua"].ToString();
            //MessageBox.Show(string.Format("row:{0},oid:{1},mathua{2}", row, oid, mathua));
            this._mapView.Show();
            this._mapView.Oid = oid;
            this._mapView.Ma = mathua;
            this._mapView.ZoomToSelect();
        }

        void xemgiadat_Click(object sender, EventArgs e)
        {
            _landpriceView.LoaiDat = 0;
            int row = this.gTableView1.grvAttributeTable.GetSelectedRows()[0];
            _landpriceView.MaThua = gTableView1.grvAttributeTable.GetDataRow(row)["mathua"].ToString();
            _landpriceView.Show();
            _landpriceView.Query();
            _landpriceView.ShowDetail();
        }

        void tachhang_Click(object sender, EventArgs e)
        {
            gTableView1.grvAttributeTable.OptionsView.AllowCellMerge = false;
        }
        void gophang_Click(object sender, EventArgs e)
        {
            gTableView1.grvAttributeTable.OptionsView.AllowCellMerge = true;
        }
        #endregion

        void _query_Finished(object sender, QueryEventArg e)
        {
            //if(this.barStaticItem1.i)
            
            this.barStaticItem1.Caption = e.Data.ToString();


            //finished();
        }
        private void finished()
        {
            if (this.InvokeRequired)
            {
                _finished fi = new _finished(finished);
                this.Invoke(fi, null);
            }
            else
            {
                this.Cursor = Cursors.Arrow;
            }
            
        }

        void _query_Querying(object sender, QueryEventArg e)
        {
            this.barStaticItem1.Caption=e.Data.ToString();
        }

        private void setAliasFieldName()
        {
            List<string[,]> fieldList = new List<string[,]>();
            fieldList.Add(new string[,] { { _fcName.FC_THUA.MA_THUA, "Mã thửa" } });
            //fieldList.Add(new string[,] { { "tenchu", "Tên chủ" } });
            //fieldList.Add(new string[,] { { "diachi", "Địa chỉ" } });
            fieldList.Add(new string[,] { { _fcName.FC_THUA.GHI_CHU, "Ghi chú" } });
            fieldList.Add(new string[,] { { _fcName.FC_THUA.MA_XA, "Mã xã" } });
            //fieldList.Add(new string[,] { { "mavung", "Mã vùng" } });
            fieldList.Add(new string[,] { { _fcName.FC_THUA.SO_TO, "Số tờ" } });
            fieldList.Add(new string[,] { { _fcName.FC_THUA.SO_THUA, "Số thửa" } });
            fieldList.Add(new string[,] { { _fcName.FC_THUA.DIEN_TICH, "Diện tích" } });
            fieldList.Add(new string[,] { { _fcName.FC_THUA.LOAI_DAT, "Loại đất" } });
            fieldList.Add(new string[,] { { _fcName.FC_THUA.LOCKED, "Khóa vị trí" } });
            _edit.AliasFieldName = fieldList;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //gridControl1.MainView = cardView1;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            
            //gridControl1.MainView = gridView1;
        }

        private void setCurrentPanel(object sender)
        {
            _type = ((Control)sender).Tag;
            //MessageBox.Show(_currentPanel.ToString());
        }
        //su kien nut tim
        #region su kien nut tim

        private void setInfo4Tim0()
        {
            _info.Xa = txtXa.Text.ToString();
            _info.ChuSoHuu = txtChuSoHuu.Text.ToString();
            _info.DiaChi = txtDiaChi.Text.ToString();
            _info.SoTo = txtSoTo.Text.ToString();
            _info.SoThua = txtSoThua.Text.ToString();
            _info.MaThua = txtMaThua.Text.ToString();
        }
        private void setInfo4Tim1()
        {
            _info.LoaiDat = txtLoaiDat.Text.ToString();
            _info.SoCachTinh = txtSoCachTinh.Text.ToString();
            _info.SoMatTien = txtSoMatTien.Text.ToString();
            _info.SoMatHem = txtSoMatHem.Text.ToString();
        }
        private void setInfo4Tim2()
        {
            _info.ViTri = txtViTri.Text.ToString();
            _info.KhuVuc = txtKhuVuc.Text.ToString();
        }
        private void setInfo4Tim3()
        {
            _info.DienTich = txtDienTich.Text.ToString();
        }
        private void btnTim0_MouseDown(object sender, MouseEventArgs e)
        {
            _newQuery = true;
            setCurrentPanel(sender);
            setInfo4Tim0();
            ((IQueryThuaView)this).Query();
        }

        private void btnTim1_MouseDown(object sender, MouseEventArgs e)
        {
            setCurrentPanel(sender);
            setInfo4Tim1();
            ((IQueryThuaView)this).Query();
        }

        private void btnTim2_MouseDown(object sender, MouseEventArgs e)
        {
            setCurrentPanel(sender);
            setInfo4Tim2();
            ((IQueryThuaView)this).Query();
        }

        private void btnTim3_Click(object sender, EventArgs e)
        {
            setCurrentPanel(sender);
            setInfo4Tim3();
            ((IQueryThuaView)this).Query();
        }

        #endregion

        #region IQueryThuaView Members

        object IQueryThuaView.TypeOfQuery
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type=value;
            }
        }

        void IQueryThuaView.Query()
        {
            //this.Cursor = Cursors.AppStarting;
            if (_conn == null)
            {
                _conn = new SdeConnection();
                _sdeConn = (ISdeConnectionInfo)_conn;
                _fcName = new TnFeatureClassName(_sdeConn.Workspace);
            }
            _info.SetWorkspace(_sdeConn.Workspace);
            _controller.Query() ;
        }

        void IQueryThuaView.GetResult(SqlDataReader reader)
        {
            if (_newQuery)
            {
                //this.gridView1.DataSource=
            }
            while (reader.Read())
            {
                MessageBox.Show(reader.GetInt32(4).ToString());
            }
        }

        void IQueryThuaView.GetResult(DataSet dataset)
        {
            try
            {
                DataTable curTable = (DataTable)this.gTableView1.grcAttributeTable.DataSource;
                if (dataset == null || dataset.Tables == null || !(dataset.Tables.Count > 0))
                {
                    return;
                }
                DataTable newTable = dataset.Tables[0];
                if (!_newQuery)
                {
                    if (curTable != null)
                    {
                        newTable.Merge(curTable);
                    }
                }
                if (this.gTableView1.grcAttributeTable.InvokeRequired)
                {
                    _getResult getResult = new _getResult(((IQueryThuaView)this).GetResult);
                    this.gTableView1.grcAttributeTable.Invoke(getResult, new object[] { dataset });
                }
                else
                {
                    this.gTableView1.grcAttributeTable.DataSource = newTable;
                }

                setAliasFieldName();
            }
            catch { }
            
        }




        IInfoForQuery IQueryThuaView.Info
        {
            get
            {
                return this._info;
            }
            set
            {
                this._info = value;
            }
        }

        #endregion

        private void btnTimThem0_Click(object sender, EventArgs e)
        {
            _newQuery = false;
            setCurrentPanel(sender);
            setInfo4Tim0();
            ((IQueryThuaView)this).Query();
        }

        private void btnTimThem1_Click(object sender, EventArgs e)
        {
            _newQuery = false;
            setCurrentPanel(sender);
            setInfo4Tim1();
            ((IQueryThuaView)this).Query();
        }

        private void btnTimThem2_Click(object sender, EventArgs e)
        {
            _newQuery = false;
            setCurrentPanel(sender);
            setInfo4Tim2();
            ((IQueryThuaView)this).Query();
        }

        private void btnTimThem3_Click(object sender, EventArgs e)
        {
            _newQuery = false;
            setCurrentPanel(sender);
            setInfo4Tim3();
            ((IQueryThuaView)this).Query();
        }

        #region IQueryThuaView Members


        void IQueryThuaView.SetMapView(IMapView mapView)
        {
            this._mapView = mapView;
        }

        #endregion

        #region IQueryThuaView Members


        void IQueryThuaView.SetLandpriceView(com.g1.arcgis.landprice.ILandpriceDetailView landpriceView)
        {
            this._landpriceView = landpriceView;
        }

        #endregion

    }
}
