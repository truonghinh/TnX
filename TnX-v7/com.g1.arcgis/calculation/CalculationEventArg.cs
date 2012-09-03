using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.calculation
{
    public class CalculationEventArg:EventArgs
    {
        public EnumTypeOfLoopCalculation Type;
        public int CurrentIndexCalculator;
        public string Log;
        public int progressing;
        public object ProgressingTotal;
        public object ProgressingTotalCount;
        public object ProgressingPart1Count;
        public object ProgressingPart1Total;
        public string mathua;
        public object[,] InfoThuaDuocTinhGia;
        public object[,] InfoThuaKhoaGia;
        public object IdThuaTinhGia;
        public object IdThuaKhoaGia;
        public CalculationEventArg() : base() { }

        public void Reset()
        {
            CurrentIndexCalculator = 0;
            Log = "";
            mathua = "";
            InfoThuaKhoaGia = null;
            InfoThuaDuocTinhGia = null;
            ProgressingTotal = null;
            ProgressingPart1Total = null;
            IdThuaKhoaGia = null;
            IdThuaTinhGia = null;
            //ProgressingTotalCount = -1;
        }
    }
}
