using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.tn.calculation.calculator;
using com.g1.arcgis.calculation;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.g1.arcgis.tn.calculation.fulfil
{
    public class Executor:IExecutor,ICalculation
    {
        private ICalculator _calculator;
        private List<ICalculator> _lstCalculator;
        //private Dictionary<string, ICalculationMonitor> _monitors;
        private List<object> _tasks;
        private IInputParams _inputParams;
        private ICurrentConfig _currentConfig;
        private List<ICalculationMonitor> _lstMonitor;
        private int _task;
        private delegate void steps(object o, RunWorkerCompletedEventArgs e);
        private delegate void TinhgiaDatDelegate();
        private static TinhgiaDatDelegate excute;
        private BackgroundWorker _bgwMain;
        private ICalculationController _controller;

        #region events
        event CalculationFinishedEventHandler _finished;
        public virtual void onFinished(CalculationEventArg ea)
        {
            if (_finished != null)
                _finished(null/*this*/, ea);
        }
        event CalculatingEventHandler _calculating;
        public virtual void onCalculating(CalculationEventArg ea)
        {
            if (_calculating != null)
                _calculating(null/*this*/, ea);
        }
        #endregion

        private void initTask(steps next) { }

        #region Constructor
        public Executor():this(null)
        {

        }
        public Executor(ICalculationMonitor monitor)
        {
            this._calculator = null;
            this._lstCalculator = new List<ICalculator>();
            this._tasks = new List<object>();
            this._lstMonitor = new List<ICalculationMonitor>();
            if (monitor != null)
            {
                this._lstMonitor.Add(monitor);
            }
            _bgwMain = new BackgroundWorker();
            
        }
        #endregion

        #region IExecutor Members

        void IExecutor.AddCalculator(ICalculator calculator)
        {
            this._calculator=calculator;
        }

        void IExecutor.AddCalculators(List<ICalculator> calculators)
        {
            this._lstCalculator=calculators;
        }

        void IExecutor.Excute()
        {
            this._calculator.Calculating += calculator_Calculating;
            //removeAllEventHandlerOfCalc();
            
            
            this._calculator.Finished += calculator_Finished;
            this._calculator.GetBackgroundWorker().ProgressChanged -= calculator_ProgressChanged;
            this._calculator.GetBackgroundWorker().ProgressChanged += calculator_ProgressChanged;
            begining();
            this._calculator.Start() ;
        }

        private void removeAllEventHandlerOfCalc()
        {
            
        }

        private void begining()
        {
            if (this._lstMonitor.Count > 0)
            {
                foreach (ICalculationMonitor m in this._lstMonitor)
                {
                    m.Begining();
                }
            }
        }

        void calculator_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (this._lstMonitor.Count > 0)
            {
                foreach (ICalculationMonitor m in this._lstMonitor)
                {
                    m.Progressing(e.ProgressPercentage);
                }
            }
        }

        void calculator_Finished(object sender, CalculationEventArg e)
        {
            onFinished(e);
            if (this._lstMonitor.Count > 0)
            {
                foreach (ICalculationMonitor m in this._lstMonitor)
                {
                    m.Finished();
                }
            }
            //bo het cac monitor
            //_lstMonitor.Clear();
            this._calculator.Calculating -= calculator_Calculating;
            this._calculator.Finished -= calculator_Finished;
        }

        void calculator_Calculating(object sender, CalculationEventArg e)
        {
            //onCalculating(e);
            //MessageBox.Show(e.Log);
            if (this._lstMonitor.Count > 0)
            {
                foreach (ICalculationMonitor m in this._lstMonitor)
                {
                    if (e.Log != null && e.Log != "")
                    {
                        m.Watching(e.Log);
                    }
                    if (e.mathua != null && e.mathua!="")
                    {
                        m.AddListObject(e.mathua);
                    }
                    //if (e.InfoThuaDuocTinhGia != null)
                    //{
                    //    m.AddListThuaDuocTinhGia(e.InfoThuaDuocTinhGia);
                    //}
                    //if (e.InfoThuaKhoaGia != null)
                    //{
                    //    m.AddListThuaKhoaGia(e.InfoThuaKhoaGia);
                    //}

                    if (e.ProgressingTotal != null )
                    {
                        m.ProgressingTotal(e.ProgressingTotal);
                    }
                    if (e.ProgressingTotalCount != null)
                    {
                        m.ProgressingTotalCount(e.ProgressingTotalCount);
                    }

                    if (e.ProgressingPart1Total != null)
                    {
                        m.ProgressingPart1Total(e.ProgressingPart1Total);
                    }
                    if (e.ProgressingPart1Count != null)
                    {
                        m.ProgressingPart1Count(e.ProgressingPart1Count);
                    }

                    if (e.IdThuaTinhGia != null)
                    {
                        m.AddListThuaDuocTinhGia(e.IdThuaTinhGia,e.mathua);
                    }
                    if (e.IdThuaKhoaGia != null)
                    {
                        m.AddListThuaKhoaGia(e.IdThuaKhoaGia,e.mathua);
                    }
                }
            }
        }

        void IExecutor.Stop()
        {
            this._calculator.Stop();
        }

        ICalculator IExecutor.GetCurrentCalculator()
        {
            return this._calculator;
        }

        List<ICalculator> IExecutor.GetCurrentCalculators()
        {
            return this._lstCalculator;
        }

        BackgroundWorker IExecutor.BackgroundWorkerMain
        {
            get { return this._bgwMain; }
        }

        void IExecutor.AddTask(int excuteCalcType)
        {
            this._task=excuteCalcType;
            this._calculator=CalculatorContext.CallMe().GetCalculator(excuteCalcType);
        }

        void IExecutor.RemoveTask(int excuteCalcType)
        {
            throw new NotImplementedException();
        }

        void IExecutor.RemoveAll()
        {
            throw new NotImplementedException();
        }

        void IExecutor.ExcuteList()
        {
            if (this._lstCalculator.Count > 0)
            {
                //CalculationEventArg evt=new CalculationEventArg();
                //evt.Type = EnumTypeOfLoopCalculation.InListCalculators;
                //evt.CurrentIndexCalculator = 0;
                
                this._lstCalculator[0].Calculating += ExecuteList_Calculating;
                
                this._lstCalculator[0].Finished += ExecuteList_Finished;
                this._lstCalculator[0].GetBackgroundWorker().ProgressChanged -= calculator_ProgressChanged;
                this._lstCalculator[0].GetBackgroundWorker().ProgressChanged += calculator_ProgressChanged;
                begining();
                this._lstCalculator[0].Start();

            }
        }

        void ExecuteList_Finished(object sender, CalculationEventArg e)
        {
            //MessageBox.Show(string.Format("line 234 Excutor index={0}",e.CurrentIndexCalculator));
            this._lstCalculator[e.CurrentIndexCalculator].Calculating -= new CalculatingEventHandler(ExecuteList_Calculating);
            this._lstCalculator[e.CurrentIndexCalculator].Finished -= new CalculationFinishedEventHandler(ExecuteList_Finished);
            if (e.CurrentIndexCalculator < this._lstCalculator.Count - 1)
            {
                int i = e.CurrentIndexCalculator + 1;
                this._lstCalculator[i].Calculating += new CalculatingEventHandler(ExecuteList_Calculating);
                this._lstCalculator[i].Finished += new CalculationFinishedEventHandler(ExecuteList_Finished);
                this._lstCalculator[i].GetBackgroundWorker().ProgressChanged -= new ProgressChangedEventHandler(calculator_ProgressChanged);
                this._lstCalculator[i].GetBackgroundWorker().ProgressChanged += new ProgressChangedEventHandler(calculator_ProgressChanged);
                this._lstCalculator[i].Start();
            }
            else
            {
                onFinished(e);
                if (this._lstMonitor.Count > 0)
                {
                    foreach (ICalculationMonitor m in this._lstMonitor)
                    {
                        m.Finished();
                    }
                }
                //_lstMonitor.Clear();
            }    
        }

        void ExecuteList_Calculating(object sender, CalculationEventArg e)
        {
            if (this._lstMonitor.Count > 0)
            {
                foreach (ICalculationMonitor m in this._lstMonitor)
                {
                    if (e.Log != null && e.Log != "")
                    {
                        m.Watching(e.Log);
                    }
                    if (e.mathua != null && e.mathua != "")
                    {
                        m.AddListObject(e.mathua);
                    }
                    //if (e.InfoThuaDuocTinhGia != null)
                    //{
                    //    m.AddListThuaDuocTinhGia(e.InfoThuaDuocTinhGia);
                    //}
                    //if (e.InfoThuaKhoaGia != null)
                    //{
                    //    m.AddListThuaKhoaGia(e.InfoThuaKhoaGia);
                    //}

                    if (e.ProgressingTotal != null)
                    {
                        m.ProgressingTotal(e.ProgressingTotal);
                    }
                    if (e.ProgressingTotalCount != null)
                    {
                        m.ProgressingTotalCount(e.ProgressingTotalCount);
                    }
                    if (e.ProgressingPart1Total != null)
                    {
                        m.ProgressingPart1Total(e.ProgressingPart1Total);
                    }
                    if (e.ProgressingPart1Count != null)
                    {
                        m.ProgressingPart1Count(e.ProgressingPart1Count);
                    }

                    if (e.IdThuaTinhGia != null)
                    {
                        m.AddListThuaDuocTinhGia(e.IdThuaTinhGia, e.mathua);
                    }
                    if (e.IdThuaKhoaGia != null)
                    {
                        m.AddListThuaKhoaGia(e.IdThuaKhoaGia, e.mathua);
                    }

                }
            }
        }

        void IExecutor.AddTasks(List<object> extuteTypes)
        {
            this._tasks=extuteTypes;
        }

        event CalculationFinishedEventHandler IExecutor.Finished
        {
            add { this._finished+=value; }
            remove { this._finished-=value; }
        }

        #endregion

        #region ICalculation Members

        ICurrentConfig ICalculation.CurrentConfig
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

        IInputParams ICalculation.InputParams
        {
            get
            {
                return this._inputParams;
            }
            set
            {
                _inputParams = value;
            }
        }

        void ICalculation.Start()
        {
            //((IExecutor)this).BackgroundWorkerMain.DoWork -= new DoWorkEventHandler(BackgroundWorkerMain_DoWork);
            //((IExecutor)this).BackgroundWorkerMain.DoWork += new DoWorkEventHandler(BackgroundWorkerMain_DoWork);
            int len = this._tasks.Count;
            //MessageBox.Show(len.ToString());
            if (len == 1)
            {
                if (this._tasks[0] == null)
                {
                    return;
                }
                this._task = int.Parse(this._tasks[0].ToString());
                this._calculator = CalculatorContext.CallMe().GetCalculator(this._task);
                if (this._calculator == null)
                {
                    return;
                }
                this._calculator.CurrentConfig = this._currentConfig;
                this._calculator.InputParams = this._inputParams;
                ((IExecutor)this).Excute();
            }
            else if (len > 1)
            {
                this._lstCalculator.Clear();
                int i = 0;
                foreach (object task in this._tasks)
                {
                    int t = int.Parse(task.ToString());
                    ICalculator calc = CalculatorContext.CallMe().GetCalculator(t);
                    if (calc == null)
                    {
                        continue;
                    }
                    calc.Index = i;
                    calc.CurrentConfig = this._currentConfig;
                    calc.InputParams = this._inputParams;
                    this._lstCalculator.Add(calc);
                    i++;
                }
                ((IExecutor)this).ExcuteList();
            }
        }

        void BackgroundWorkerMain_DoWork(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }

        void ICalculation.Stop()
        {
            throw new NotImplementedException();
        }

        List<object> ICalculation.Tasks
        {
            get
            {
                return this._tasks;
            }
            set
            {
                ((IExecutor)this).AddTasks(value);
            }
        }

        void ICalculation.AddMonitor(ICalculationMonitor monitor)
        {
            monitor.Executor = this;
            if (_controller != null)
            {
                monitor.CalcController = _controller;
            }
            this._lstMonitor.Add(monitor);
            
        }

        void ICalculation.ClearMonitor()
        {
            this._lstMonitor.Clear();
        }

        void ICalculation.RemoveMonitor(ICalculationMonitor monitor)
        {
            this._lstMonitor.Remove(monitor);
        }

        void ICalculation.AddMonitors(List<ICalculationMonitor> monitors)
        {
            this._lstMonitor = monitors;
            foreach (ICalculationMonitor m in _lstMonitor)
            {
                m.Executor = this;
                if (_controller != null)
                {
                    m.CalcController = _controller;
                }
            }
        }

        #endregion

        #region ICalculation Members


        List<ICalculationMonitor> ICalculation.Monitors
        {
            get
            {
                return _lstMonitor;
            }
            set
            {
                _lstMonitor = value;
                foreach (ICalculationMonitor m in _lstMonitor)
                {
                    m.Executor = this;
                    if (_controller != null)
                    {
                        m.CalcController = _controller;
                    }
                }
            }
        }

        #endregion

        #region ICalculation Members


        ICalculationController ICalculation.Controller
        {
            get
            {
                return _controller;
            }
            set
            {
                _controller = value;
                if (_lstMonitor != null)
                {
                    foreach (ICalculationMonitor m in _lstMonitor)
                    {
                        m.CalcController = _controller;
                    }
                }
            }
        }

        #endregion
    }
}
