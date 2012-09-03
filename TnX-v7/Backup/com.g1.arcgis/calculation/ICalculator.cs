using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;

namespace com.g1.arcgis.calculation
{
    public interface ICalculator
    {
        void Next(Delegate steps);
        BackgroundWorker GetBackgroundWorker();
        void Start();
        void Stop();
        event CalculatingEventHandler Calculating;
        event CalculationFinishedEventHandler Finished;
        int Index { get; set; }
        IInputParams InputParams { get; set; }
        ICurrentConfig CurrentConfig { get; set; }
        void RemoveAllEventHandler();
        /// <summary>
        /// Tim cach tinh cho thua nong nghiep
        /// </summary>
        /// <param name="vitri"></param>
        /// <param name="ma_xa"></param>
        /// <param name="ma_duong"></param>
        void TimCachTinh(int vitri, string ma_xa, List<string> ma_duong);
        //void TimCachTinh(int hesok,string ma_xa,List<string> ma_duong)
    }
}
