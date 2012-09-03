using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using g1.tn.calculation.calculator;

namespace g1.tn.calculation
{
    public interface ICalculationController
    {
        void Start();
        void Stop();
        void SetView(ICalculationView view);
        void SetCalculator(Calculator calc);
        event ChangedEventHandler DoWork;
        event FinishedEventHandler Finished;
    }
}
