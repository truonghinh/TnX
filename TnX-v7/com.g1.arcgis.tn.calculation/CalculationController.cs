using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.calculation;
using com.g1.arcgis;

namespace com.g1.arcgis.tn.calculation
{
    public class CalculationController:ICalculationController
    {
        #region event
        private event FinishedEventHandler _finished;
        private event ChangedEventHandler _changed;

        protected virtual void OnChanged(EventArgs e)
        {
            if (_changed != null)
                _changed(this, e);
        }

        protected virtual void OnFinished(EventArgs e)
        {
            if (_finished != null)
                _finished(this, e);
        }
        #endregion

        private ICalculation _calc;
        private ICalculationView _calcView;
        private IParams _params;

        public CalculationController() : this(null, null) { }

        public CalculationController(ICalculationView calcView, ICalculation calc)
        {
            if (!(calc == null || calcView == null))
            {
                this._calc = calc;
                this._calcView = calcView;
                this._calc.Controller = this;
            }
        }

        #region ICalculationController Members

        event ChangedEventHandler ICalculationController.DoWork
        {
            add { this._changed += value; }
            remove { this._changed -= value; }
        }

        void ICalculationController.ReqStart()
        {
            _calc.InputParams = _calcView.InputParams;
            _calc.CurrentConfig = _calcView.CurrentConfig;
            _calc.Tasks = _calcView.Tasks;
            _calc.Start();
        }

        void ICalculationController.ReqStop()
        {
            _calc.Stop();
        }

        event FinishedEventHandler ICalculationController.Finished
        {
            add { this._finished += value; }
            remove { this._finished -= value; }
        }

        #endregion

        #region ICalculationController Members


        void ICalculationController.SetCalculation(ICalculation calc)
        {
            this._calc = calc;
            this._calc.Controller = this;
        }

        void ICalculationController.SetView(ICalculationView view)
        {
            this._calcView = view;
        }

        #endregion
    }
}
