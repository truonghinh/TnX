using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.calculation
{
    public interface ICalculationView
    {
        void Start();
        void Stop();
        void SetParams();
        void GetParams();
        IInputParams InputParams { get; set; }
        ICurrentConfig CurrentConfig { get; set; }
        void SetInputParams(IInputParams input);
        List<object> Tasks { get; }
        void AddMonitor(ICalculationMonitor monitor);
        void AddMonitors(List<ICalculationMonitor> monitors);
        int MonitorCount();
        
    }
}
