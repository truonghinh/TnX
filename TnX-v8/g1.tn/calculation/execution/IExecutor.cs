using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using g1.tn.calculation;
using g1.tn.calculation.calculator;

namespace g1.tn.execution
{
    public interface IExecutor
    {
        void AddCalculator(Calculator calculator);
        void AddCalculators(List<Calculator> calculators);
        void Excute();
        void ExcuteList();
        void Stop();
        Calculator GetCurrentCalculator();
        List<Calculator> GetCurrentCalculators();
        BackgroundWorker BackgroundWorkerMain { get; }
        void AddTask(int excuteCalcType);
        void AddTasks(List<object> extuteTypes);
        void RemoveTask(int excuteCalcType);
        void RemoveAll();
        event CalculationFinishedEventHandler Finished;
    }
}
