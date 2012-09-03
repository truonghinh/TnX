using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using g1.tn.param;

namespace g1.tn.calculation.calculator
{
    public abstract class Calculator
    {
        int Index { get; set; }
        void Start();
        void Stop();
        void RemoveAllEventHandler();
        IInputParams InputParams { get; set; }
        ICurrentConfig CurrentConfig { get; set; }
        List<object> Tasks { get; set; }
        void AddMonitor(ICalculationMonitor monitor);
        void AddMonitors(List<ICalculationMonitor> monitors);
        void RemoveMonitor(ICalculationMonitor monitor);
        void ClearMonitor();
        List<ICalculationMonitor> Monitors { get; set; }
        ICalculationController Controller { get; set; }
    }
}
