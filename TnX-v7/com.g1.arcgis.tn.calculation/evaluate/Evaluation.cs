using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using System.Text.RegularExpressions;
using NCalc;
using ESRI.ArcGIS.DataManagementTools;
using com.g1.arcgis.geoprocessorTool;
using ESRI.ArcGIS.Geoprocessor;
using System.Windows.Forms;
using System.Diagnostics;
using com.g1.arcgis.database;
using gov.tn.system;
using ESRI.ArcGIS.Geodatabase;
using com.g1.arcgis.connection;
using com.g1.arcgis.calculation;
using com.g1.arcgis.tn.config;
using gov.tn.TnDatabaseStructure;

namespace com.g1.arcgis.tn.calculation.evaluate
{
    public class Evaluation:GeoprocessorAbstract
    {
        private string _expr = "";
        private IFeatureLayer _thuaFl;
        private IFeatureLayer _duongFl;
        private IFeatureLayer _hemchinhFl;
        private IFeatureLayer _hemphuFl;
        private IFeatureLayer _ktvhxhFl;
        private IFeatureLayer _ranhxaPolyFl;
        private IFeatureLayer _ranhxaLineFl;
        private IFeatureLayer _khudancuFl;
        private IFeatureLayer _ttXaFl;
        private Dictionary<string, object> _dicParams;

        //private ILayer _selectLayer;
        //private ILayer _byLayer;
        IDataManager dataManager = new DataManager();
        ITnSystemTempPath sysTempPath = new TnSystemTempPath();
        private double _giadatduong;
        private object _dientich;
        private object _dientichpl;
        private object _giadatNn;
        private object _giadatPnnNt;
        private ITnFeatureClassName _fcName;
        private ITnTableName _tblName;
        SdeConnection _conn;
        ISdeConnectionInfo _sdeConn;
        IFeatureWorkspace _fw;

        public object Dientichpl
        {
            get { return _dientichpl; }
            set { _dientichpl = value; }
        }

        public object Dientich
        {
            get { return _dientich; }
            set { _dientich = value; }
        }

        public object GiadatNn
        {
            get { return _giadatNn; }
            set { _giadatNn = value; }
        }

        public Dictionary<string, object> Params
        {
            get { return _dicParams; }
            set { _dicParams = value; }
        }

        
        private ICurrentConfig _conf;

        public Evaluation() : this("") { }

        public Evaluation(string expr)
        {
            this._expr = expr;
            _conn = new SdeConnection();
            _sdeConn = (ISdeConnectionInfo)_conn;
            _conf = CurrentConfig.CallMe();
            _fcName = new TnFeatureClassName(_sdeConn.Workspace);
            _tblName = new TnTableName(_sdeConn.Workspace);
            _dicParams = new Dictionary<string, object>();
        }
        

        public double Giadatduong
        {
            get { return _giadatduong; }
            set { _giadatduong = value; }
        }

        public IFeatureLayer DuongLayer
        {
            get { return _duongFl; }
            set { _duongFl = value; }
        }

        public IFeatureLayer ThuaLayer
        {
            get { return _thuaFl; }
            set { _thuaFl = value; }
        }

        public IFeatureLayer HemChinhLayer
        {
            get { return _hemchinhFl; }
            set { _hemchinhFl = value; }
        }

        public IFeatureLayer HemPhuLayer
        {
            get { return _hemphuFl; }
            set { _hemphuFl = value; }
        }

        public IFeatureLayer RanhXaPolyLayer
        {
            get { return _ranhxaPolyFl; }
            set { _ranhxaPolyFl = value; }
        }

        public IFeatureLayer RanhXaLineLayer
        {
            get { return _ranhxaLineFl; }
            set { _ranhxaLineFl = value; }
        }

        public IFeatureLayer KtvhxhLayer
        {
            get { return _ktvhxhFl; }
            set { _ktvhxhFl = value; }
        }

        public IFeatureLayer KhuDcLayer
        {
            get { return _khudancuFl; }
            set { _khudancuFl = value; }
        }

        public IFeatureLayer TtXaLayer
        {
            get { return _ttXaFl; }
            set { _ttXaFl = value; }
        }
        

        public string Expr
        {
            get { return _expr; }
            set { _expr = value; }
        }

        public ICurrentConfig Config
        {
            get { return _conf; }
            set { _conf= value; }
        }


        public void EvaluateQuery()
        {
            if (this._expr == "")
            {
                return;
            }
            //SelectLayerByLocation SelectByLocation;
            Geoprocessor gp = new Geoprocessor();
            string[] exprArr = Regex.Split(_expr, ExpressionKeyWords.Then);
            //MessageBox.Show(_expr);
            if (exprArr.Length == 0 || exprArr == null)
            {
                MessageBox.Show("ko co expr");
                return;
            }
            try
            {
                //_selectFLayer.Name = _selectFLayer.FeatureClass.AliasName;
                //_byFLayer.Name = _byFLayer.FeatureClass.AliasName;
                //_selectLayer = (ILayer)_selectFLayer;
                //_byLayer = (ILayer)_byFLayer;
                //string selectLyrFile = string.Format("{0}/{1}", sysTempPath.TempPath, "selectLayer.lyr");
                //string byLyrFile = string.Format("{0}/{1}", sysTempPath.TempPath, "byLayer.lyr");
                //dataManager.SaveToLayerFile(_selectLayer, selectLyrFile);
                //dataManager.SaveToLayerFile(_byLayer, byLyrFile);
                foreach (string s in exprArr)
                {
                    //MessageBox.Show("close");
                    Expression e = new Expression(s.Trim());
                    
                    e.Parameters[ExpressionParameters.Intersect] = ExpressionParameters.Intersect;
                    e.Parameters[ExpressionParameters.NewSelection] = ExpressionParameters.NewSelection;
                    e.Parameters[ExpressionParameters.AndSelection] = ExpressionParameters.AndSelection;
                    e.Parameters[ExpressionParameters.ContainedBy] = ExpressionParameters.ContainedBy;
                    e.Parameters[ExpressionParameters.SubtractSelection] = ExpressionParameters.SubtractSelection;
                    //MessageBox.Show(e.Parameters.Count.ToString());
                    //foreach (string k in e.Parameters.Keys)
                    //{
                    //    MessageBox.Show(k);
                    //    e.Parameters[k] = k;

                    //}

                    //e.EvaluateParameter += delegate(string name, ParameterArgs args)
                    //{
                    //    if (name == "INTERSECT")
                    //        args.Result = "INTERSECT";
                    //    if (name == "NEW_SELECTION")
                    //        args.Result = "NEW_SELECTION";
                    //    if (name == "SUBSET_SELECTION")
                    //        args.Result = "SUBSET_SELECTION";
                    //};
                    //e.EvaluateParameter += delegate(string name, ParameterArgs args)
                    //{
                    //    if (name == "NEW_SELECTION")
                    //        args.Result = "NEW_SELECTION";
                    //};
                    //e.EvaluateParameter += delegate(string name, ParameterArgs args)
                    //{
                    //    if (name == "SUBSET_SELECTION")
                    //        args.Result = "SUBSET_SELECTION";
                    //};
                    
                    e.EvaluateFunction += delegate(string name, FunctionArgs args)
                    {
                        
                        //ham chonglop co 3 tham so: selectMethod,resultType,distance
                        //ham chontheothuoctinh co 2 tham so: resultType,dieukien
                        if (name == ExpressionFunctions.ChonThuaTheoDuong)
                        {
                            IQueryByLayer _qrBl = new QueryByLayerClass();
                            _qrBl.FromLayer = _thuaFl;
                            _qrBl.ByLayer = _duongFl;
                            _qrBl.LayerSelectionMethod = (esriLayerSelectionMethod)GeoprocessorConstant.GetSelectionMethod(args.Parameters[0].Evaluate().ToString());
                            _qrBl.ResultType = (esriSelectionResultEnum)GeoprocessorConstant.GetSelectionResult(args.Parameters[1].Evaluate().ToString());
                            _qrBl.UseSelectedFeatures = true;
                            double buf;
                            
                            bool re = double.TryParse(args.Parameters[2].Evaluate().ToString(), out buf);

                            if (!re)
                            {
                                buf = 0;
                            }
                            _qrBl.BufferDistance = buf; //can them config gia tri nay
                            //MessageBox.Show(string.Format("line 227 Evaluation thua={0},duong={1},buf={2}", _thuaFl.FeatureClass.AliasName,_duongFl.FeatureClass.AliasName,buf));
                            ISelectionSet thuaSelectionSet=null;
                            try
                            {
                                thuaSelectionSet = _qrBl.Select();
                                IFeatureSelection fs = (IFeatureSelection)_thuaFl;
                                fs.SelectionSet = thuaSelectionSet;
                                //MessageBox.Show(string.Format("line 225 Evaluation {0}, {1}", buf, thuaSelectionSet.Count));
                            }
                            catch (Exception ex) { 
                                //MessageBox.Show(String.Format("line 244 Evaluation, ex={0}", ex)); 
                            }
                            

                            //!ko xai duoc cha noi SelectLayerByLocation
                            //MessageBox.Show(thuaSelectionSet.Count.ToString());
                            /*
                            SelectByLocation = new SelectLayerByLocation();

                            SelectByLocation.in_layer = _selectFLayer;
                            SelectByLocation.select_features = _byFLayer;
                            //SelectByLocation.out_layer_or_view = selectLyrFile;
                            
                            SelectByLocation.overlap_type = "INTERSECT";//args.Parameters[0].Evaluate().ToString();
                            SelectByLocation.selection_type = "NEW_SELECTION"; //args.Parameters[1].Evaluate().ToString();
                            SelectByLocation.search_distance = 1;// args.Parameters[2].Evaluate();
                            IFeatureSelection fls = (IFeatureSelection)_byFLayer;
                            MessageBox.Show(fls.SelectionSet.Count.ToString());
                            runTool(gp, SelectByLocation, null);
                            
                            MessageBox.Show(fs.SelectionSet.Count.ToString());
                             * */
                            args.Result = 1;
                        }
                        else if (name == ExpressionFunctions.ChonThuaTheoHemChinh)
                        {
                            IQueryByLayer _qrBl = new QueryByLayerClass();
                            _qrBl.FromLayer = _thuaFl;
                            _qrBl.ByLayer = _hemchinhFl;
                            _qrBl.LayerSelectionMethod = (esriLayerSelectionMethod)GeoprocessorConstant.GetSelectionMethod(args.Parameters[0].Evaluate().ToString());
                            _qrBl.ResultType = (esriSelectionResultEnum)GeoprocessorConstant.GetSelectionResult(args.Parameters[1].Evaluate().ToString());
                            _qrBl.UseSelectedFeatures = true;
                            double buf;
                            bool re = double.TryParse(args.Parameters[2].Evaluate().ToString(), out buf);
                            if (!re)
                            {
                                buf = 0;
                            }
                            _qrBl.BufferDistance = buf; //can them config gia tri nay

                            ISelectionSet thuaSelectionSet=null;
                            try
                            {
                                thuaSelectionSet = _qrBl.Select();
                                IFeatureSelection fs = (IFeatureSelection)_thuaFl;
                                fs.SelectionSet = thuaSelectionSet;
                            }
                            catch { }
                            args.Result = 1;
                        }
                        else if (name == ExpressionFunctions.ChonThuaTheoTtXa)
                        {
                            IQueryByLayer _qrBl = new QueryByLayerClass();
                            _qrBl.FromLayer = _thuaFl;
                            _qrBl.ByLayer = _ttXaFl;
                            _qrBl.LayerSelectionMethod = (esriLayerSelectionMethod)GeoprocessorConstant.GetSelectionMethod(args.Parameters[0].Evaluate().ToString());
                            _qrBl.ResultType = (esriSelectionResultEnum)GeoprocessorConstant.GetSelectionResult(args.Parameters[1].Evaluate().ToString());
                            _qrBl.UseSelectedFeatures = true;
                            double buf;
                            bool re = double.TryParse(args.Parameters[2].Evaluate().ToString(), out buf);
                            if (!re)
                            {
                                buf = 0;
                            }
                            _qrBl.BufferDistance = buf; //can them config gia tri nay

                            ISelectionSet thuaSelectionSet = null;
                            try
                            {
                                thuaSelectionSet = _qrBl.Select();
                                IFeatureSelection fs = (IFeatureSelection)_thuaFl;
                                fs.SelectionSet = thuaSelectionSet;
                            }
                            catch { }
                            args.Result = 1;
                        }
                        else if (name == "ChonTheoThuocTinh")
                        {
                            SdeConnection conn = new SdeConnection();
                            ISdeConnectionInfo sdeConn = (ISdeConnectionInfo)conn;
                            IQueryFilter qrf = new QueryFilterClass();
                            qrf.WhereClause = args.Parameters[0].Evaluate().ToString();
                            ISelectionSet sls = _thuaFl.FeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionNormal, sdeConn.Workspace);
                            IFeatureSelection fs = (IFeatureSelection)_thuaFl;
                            fs.SelectionSet = sls;
                            //MessageBox.Show("chonthuoctinh: "+args.Parameters[0].Evaluate().ToString());
                            args.Result = 1;
                        }
                        else if (name == "Where")
                        {
                            args.Parameters[0].Parameters["dorong"] = "dorong";
                            //MessageBox.Show(args.Parameters[0].Evaluate().ToString());
                            args.Result = args.Parameters[0].Evaluate().ToString();
                        }
                    };
                    //Debug.Assert(1 == (int)e.Evaluate());
                    e.Evaluate();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }
        }

        public bool EvaluateCalculating()
        {
            bool result = false;
            if (this._expr == "")
            {
                return false;
            }
            Expression e = new Expression(_expr);
            
            _fw = (IFeatureWorkspace)_sdeConn.Workspace;
            e.Parameters["INTERSECT"] = "INTERSECT";
            e.Parameters["NEW_SELECTION"] = "NEW_SELECTION";
            e.Parameters["AND_SELECTION"] = "AND_SELECTION";
            e.Parameters["CONTAINED_BY"] = "CONTAINED_BY";
            e.Parameters["SUBTRACT_SELECTION"] = "SUBTRACT_SELECTION";
            e.Parameters[_fcName.FC_DUONG.DO_RONG] = _fcName.FC_DUONG.DO_RONG;
            e.Parameters[_fcName.FC_THUA.DIEN_TICH] = _fcName.FC_THUA.DIEN_TICH;
            e.EvaluateFunction += delegate(string name, FunctionArgs args)
            {
                if (name == "VongLap")
                {
                    IFeatureLayer fl=null;
                    try
                    {
                        fl = (IFeatureLayer)args.Parameters[0].Evaluate();
                    }
                    catch(Exception e1) { args.Result = null; }
                    //args.Parameters["doituonglap"]
                    
                    IFeatureSelection fsl=(IFeatureSelection)fl;
                    IFeatureClass fc=fl.FeatureClass;
                    MessageBox.Show(string.Format("line 323 Evaluation selectionset={0}", fsl.SelectionSet.Count));
                    int len = args.Parameters.Length;
                    IDictionary<string,IFeature> dic=new Dictionary<string,IFeature>();
                    if(len==3)
                    {
                        dic=(IDictionary<string,IFeature>)args.Parameters[2].Evaluate();
                        MessageBox.Show(string.Format("line 346 Evaluation lenght={0}", dic.Count));
                    }
                    if (len >= 2)
                    {
                        IEnumIDs eIds = fsl.SelectionSet.IDs;
                        int id;
                        IFeature ft;
                        //MessageBox.Show(string.Format("line 353 Evaluation ids={0}",

                        int numid = fsl.SelectionSet.Count;
                        for (int i = 0; i < numid; i++)
                        {
                            id = eIds.Next();
                            if (id != -1)
                            {
                                //MessageBox.Show(string.Format("line 357 Evaluation name={0}, id={1}", fc.AliasName, id));
                                int id_img = 0;
                                ft = fc.GetFeature(id);
                                try
                                {
                                    dic.Remove(string.Format("{0}_{1}", fc.AliasName, id));
                                }
                                catch { }
                                finally
                                {
                                    dic.Add(string.Format("{0}_{1}", fc.AliasName, id), ft);
                                }
                                //args.Parameters["doituonglapcon"] = ft;
                                args.Parameters[1].Parameters["doituonglap"] = dic;
                                args.Parameters[1].Evaluate();
                                id_img = id;
                                //MessageBox.Show(string.Format("line 373 Evaluation id={0}", id));
                                //ft=fc.GetFeature(id);
                                //MessageBox.Show(string.Format("line 348 Evaluation maduong={0}", ft.get_Value(ft.Fields.FindField("maduong"))));

                            }
                            else
                            {
                                eIds.Reset();
                                i = 0;
                            }
                        }
                    }

                }
                else if (name == "test")
                {
                    IDictionary<string, IFeature> dic = (IDictionary<string, IFeature>)args.Parameters[0].Evaluate();
                    //MessageBox.Show(string.Format("line 371 Evaluation lenght={0}", dic.Count));
                    //IFeature ft = (IFeature)args.Parameters[0].Evaluate();//dic["sde.SDE.thixa_duong"];
                    //MessageBox.Show(string.Format("line 360 Evaluation maduong={0}", ft.get_Value(ft.Fields.FindField("maduong"))));
                    args.Result = 1;
                }
                else if (name == "ChonThuaTheoDuong")
                {
                    IQueryByLayer _qrBl = new QueryByLayerClass();
                    _qrBl.FromLayer = _thuaFl;
                    _qrBl.ByLayer = _duongFl;
                    _qrBl.LayerSelectionMethod = (esriLayerSelectionMethod)GeoprocessorConstant.GetSelectionMethod(args.Parameters[0].Evaluate().ToString());
                    _qrBl.ResultType = (esriSelectionResultEnum)GeoprocessorConstant.GetSelectionResult(args.Parameters[1].Evaluate().ToString());
                    _qrBl.UseSelectedFeatures = true;
                    double buf;
                    bool re = double.TryParse(args.Parameters[2].Evaluate().ToString(), out buf);
                    if (!re)
                    {
                        buf = 0;
                    }
                    _qrBl.BufferDistance = buf; //can them config gia tri nay

                    ISelectionSet thuaSelectionSet = null;
                    try
                    {
                        thuaSelectionSet = _qrBl.Select();
                        IFeatureSelection fs = (IFeatureSelection)_thuaFl;
                        fs.SelectionSet = thuaSelectionSet;
                    }
                    catch { }
                    args.Result = 1;
                }
                else if (name == "ChonThuaTheoHemChinh")
                {
                    IQueryByLayer _qrBl = new QueryByLayerClass();
                    _qrBl.FromLayer = _thuaFl;
                    _qrBl.ByLayer = _hemchinhFl;
                    _qrBl.LayerSelectionMethod = (esriLayerSelectionMethod)GeoprocessorConstant.GetSelectionMethod(args.Parameters[0].Evaluate().ToString());
                    _qrBl.ResultType = (esriSelectionResultEnum)GeoprocessorConstant.GetSelectionResult(args.Parameters[1].Evaluate().ToString());
                    _qrBl.UseSelectedFeatures = true;
                    double buf;
                    bool re = double.TryParse(args.Parameters[2].Evaluate().ToString(), out buf);
                    if (!re)
                    {
                        buf = 0;
                    }
                    _qrBl.BufferDistance = buf; //can them config gia tri nay

                    ISelectionSet thuaSelectionSet = null;
                    try
                    {
                        thuaSelectionSet = _qrBl.Select();
                        IFeatureSelection fs = (IFeatureSelection)_thuaFl;
                        fs.SelectionSet = thuaSelectionSet;
                    }
                    catch { }
                    args.Result = 1;
                }
                else if (name == "ChonDuong")
                {

                    IQueryFilter qrf = new QueryFilterClass();
                    qrf.WhereClause = args.Parameters[0].Evaluate().ToString();
                    ISelectionSet sls = _duongFl.FeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionNormal, _sdeConn.Workspace);
                    IFeatureSelection fs = (IFeatureSelection)_duongFl;
                    fs.SelectionSet = sls;
                    //MessageBox.Show("chonthuoctinh: "+args.Parameters[0].Evaluate().ToString());
                    args.Result = _duongFl;
                }
                else if (name == "ChonThua")
                {

                    IQueryFilter qrf = new QueryFilterClass();
                    qrf.WhereClause = args.Parameters[0].Evaluate().ToString();
                    ISelectionSet sls = _thuaFl.FeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionNormal, _sdeConn.Workspace);
                    IFeatureSelection fs = (IFeatureSelection)_thuaFl;
                    fs.SelectionSet = sls;
                    //MessageBox.Show("chonthuoctinh: "+args.Parameters[0].Evaluate().ToString());
                    args.Result = _thuaFl;
                }
            };
            try
            {
                result = (bool)e.Evaluate();
            }
            catch(Exception e1)
            {
                result = false;
            }
            return result;
        }

        public object EvaluateLandPrice()
        {
            object result = 0;
            //MessageBox.Show(string.Format("line 510 CalcLandprice expr={0}", _expr));
            if (this._expr == "")
            {
                return result;
            }
            //string[] exprArr = Regex.Split(_expr, " Then ");
            //MessageBox.Show(exprArr[1]);
            //if (exprArr.Length == 0 || exprArr == null)
            //{
            //    return result;
            //}
            try
            {
                Expression e = new Expression(_expr.Trim());
                //MessageBox.Show(_dicParams.Count.ToString());
                foreach (string s in _dicParams.Keys)
                {
                    //MessageBox.Show(s);
                    e.Parameters[s] = _dicParams[s];
                }
                //e.Parameters = _dicParams;
                //e.Parameters[ExpressionParameters.GiaDatDuong] = _giadatduong;
                //e.Parameters[ExpressionParameters.HeSoDatSxkd] = _conf.PGiaDatSxkddt;
                //e.Parameters[ExpressionParameters.DienTich] = _dientich;
                //e.Parameters[ExpressionParameters.DienTichPl] = _dientichpl;
                //e.Parameters[ExpressionParameters.GiaDatNn] = _giadatNn;
                //MessageBox.Show(string.Format("line 517 Evaluation, dientich={0}", _dientichpl));
                e.EvaluateFunction += delegate(string name, FunctionArgs args)
                {
                    //ham tinh gia dat o mat tien ko co tham so
                    if (name == "DonGiaOMattienDt")
                    {
                        args.Result = args.Parameters[0].Evaluate();
                    }
                        //ham tinh gia dat sxkd mat tien c 1 ham kem 2 tham so
                    else if (name == "DonGiaSxkdMattienDt")
                    {
                        args.Result = args.Parameters[0].Evaluate();
                    }
                    //ham nhan
                    else if (name == "Multiply")
                    {

                    }
                };
                result = e.Evaluate();
                return result;

            }
            catch (Exception e1)
            {

                MessageBox.Show(e1.ToString());
                return 0;
            }
        }

        public object EvaluateMethod()
        {
            object result = "";
            //if (this._expr == "")
            //{
            //    return result;
            //}

            try
            {
                Expression e = new Expression(_expr.Trim());
                e.Parameters["giadatduong"] = _giadatduong;
                e.Parameters["hesodatsxkd"] = _conf.PGiaDatSxkddt;
                e.Parameters["dientich"] = _dientich;
                e.Parameters["dientichpl"] = _dientichpl;
                result = e.Evaluate();
                return result;

            }
            catch (Exception e1)
            {

                MessageBox.Show(e1.ToString());
                return "";
            }

            
        }
    }
}
