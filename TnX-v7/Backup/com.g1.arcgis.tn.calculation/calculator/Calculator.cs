using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using com.g1.arcgis.calculation;
using ESRI.ArcGIS.Carto;
using gov.tn.TnDatabaseStructure;

namespace com.g1.arcgis.tn.calculation.calculator
{
    public abstract class Calculator
    {
        protected int _index = 0;
        protected delegate void steps(object o, RunWorkerCompletedEventArgs e);
        protected event CalculatingEventHandler _calculating;
        protected event CalculationFinishedEventHandler _finished;
        protected IInputParams _inputParams;
        protected ICurrentConfig _currentConfig;
        protected IQueryByLayer _qrBl = new QueryByLayerClass();
        protected ITnFeatureClassName _fcName;
        protected ITnTableName _tblName;
        protected BackgroundWorker _bgwCalculating;

        public virtual void onCalculating(CalculationEventArg ea)
        {
            if (_calculating != null)
                _calculating(null/*this*/, ea);
        }
        public virtual void onFinished(CalculationEventArg ea)
        {
            if (_finished != null)
                _finished(null/*this*/, ea);
        }
        public Calculator()
        {
            this._bgwCalculating = new BackgroundWorker();
            this._bgwCalculating.WorkerReportsProgress = true;
            this._bgwCalculating.WorkerSupportsCancellation = true;
        }
        protected virtual void calculate() { }
    }
}
