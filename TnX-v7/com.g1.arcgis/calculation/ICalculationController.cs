using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.calculation
{
    public interface ICalculationController
    {
        void ReqStart();
        void ReqStop();
        void SetView(ICalculationView view);
        void SetCalculation(ICalculation calc);
        event ChangedEventHandler DoWork;
        event FinishedEventHandler Finished;
        
    }
}
