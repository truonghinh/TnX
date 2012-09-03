using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace com.g1.arcgis.calculation
{
    public interface IExecutor
    {
        void AddCalculator(ICalculator calculator);
        void AddCalculators(List<ICalculator> calculators);
        void Excute();
        void ExcuteList();
        void Stop();
        ICalculator GetCurrentCalculator();
        List<ICalculator> GetCurrentCalculators();
        BackgroundWorker BackgroundWorkerMain { get; }
        void AddTask(int excuteCalcType);
        void AddTasks(List<object> extuteTypes);
        void RemoveTask(int excuteCalcType);
        void RemoveAll();
        event CalculationFinishedEventHandler Finished;
    }
}
