using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.calculation
{
    public interface ICalculation
    {
        void Start();
        void Stop();
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
