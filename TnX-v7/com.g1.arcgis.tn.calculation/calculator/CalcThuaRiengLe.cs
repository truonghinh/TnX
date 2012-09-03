using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.calculation;
using System.ComponentModel;
using com.g1.arcgis.connection;
using ESRI.ArcGIS.Geodatabase;
using gov.tn.TnDatabaseStructure;
using com.g1.arcgis.database;
using ESRI.ArcGIS.Carto;
using System.Runtime.InteropServices;
using gov.tn.system;
using com.g1.arcgis.tn.calculation.evaluate;
using System.Windows.Forms;

namespace com.g1.arcgis.tn.calculation.calculator
{
    public class CalcThuaRiengLe : Calculator, ICalculator
    {
        public CalcThuaRiengLe()
            : base()
        {
            this._bgwCalculating.DoWork -= new DoWorkEventHandler(_bgwCalculating_DoWork);
            this._bgwCalculating.DoWork += new DoWorkEventHandler(_bgwCalculating_DoWork);
        }

        void _bgwCalculating_DoWork(object sender, DoWorkEventArgs e)
        {
            this.calculate();
        }

        protected override void calculate()
        {
            #region khoi dau
            base.calculate();
            CalculationEventArg evt = new CalculationEventArg();
            evt.CurrentIndexCalculator = this._index;
            List<object> newId = new List<object>();
            newId.Add(_inputParams.OID_THUA_RIENG_LE);
            if (this._inputParams.TINH_THUA_RIENG_LE == 1)
            {
                evt.Log = string.Format("**********  Bắt đầu tính giá cho thửa có id= {0} ********", _inputParams.OID_THUA_RIENG_LE);
                onCalculating(evt);
                CalcLandprice calc = new CalcLandprice(this);
                calc.Calculate(newId);
            }
            #region ----log
            evt.Log = string.Format("\n\n**************************************\n******* Đã tính xong*******\n**********************************");
            //evt.Log += string.Format("\n Số thửa tìm thấy: {0}", sothuatimthay);
            //evt.Log += string.Format("\n Số thửa được tính: {0}", sothuatinhduoc);
            onCalculating(evt);
            #endregion
            evt.Reset();
            evt.ProgressingTotalCount = ".";
            evt.ProgressingTotal = ".";
            onCalculating(evt);

            evt.CurrentIndexCalculator = this._index;
            onFinished(evt);

            
            //evt.Type = EnumTypeOfLoopCalculation.InListCalculators;
            
            
            
            #endregion
        }

        #region ICalculator Members

        void ICalculator.Next(Delegate steps)
        {
            throw new NotImplementedException();
        }

        void ICalculator.Start()
        {
            this._bgwCalculating.RunWorkerAsync();
        }

        void ICalculator.Stop()
        {
            CalculationEventArg evt = new CalculationEventArg();
            //evt.Type = EnumTypeOfLoopCalculation.InListCalculators;
            evt.CurrentIndexCalculator = this._index;

            onFinished(evt);
        }

        event CalculatingEventHandler ICalculator.Calculating
        {
            add { this._calculating += value; }
            remove { this._calculating -= value; }
        }

        event CalculationFinishedEventHandler ICalculator.Finished
        {
            add { this._finished += value; }
            remove { this._finished -= value; }
        }

        int ICalculator.Index
        {
            get
            {
                return this._index;
            }
            set
            {
                this._index = value;
            }
        }

        IInputParams ICalculator.InputParams
        {
            get
            {
                return this._inputParams;
            }
            set
            {
                this._inputParams = value;
            }
        }

        ICurrentConfig ICalculator.CurrentConfig
        {
            get
            {
                return this._currentConfig;
            }
            set
            {
                this._currentConfig = value;
            }
        }

        BackgroundWorker ICalculator.GetBackgroundWorker()
        {
            return this._bgwCalculating;
        }

        void ICalculator.RemoveAllEventHandler()
        {
            //foreach(Delegate d in )
        }

        void ICalculator.TimCachTinh(int vitri, string ma_xa, List<string> ma_duong)
        {

        }

        #endregion
    }
}
