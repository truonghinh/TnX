using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.tn.calculation.fulfil;
using System.Windows.Forms;
using com.g1.arcgis.calculation;
using com.g1.arcgis.tn.config;

namespace com.g1.arcgis.tn.calculation.calculator
{
    public sealed class CalculatorContext
    {
        private static CalculatorContext _meClass = null;
        private static Dictionary<int, ICalculator> _dic;
        private CalculatorContext()
        {
            _dic = new Dictionary<int, ICalculator>();
            //_dic.Add(TnTasks.THUA_NONG_NGHIEP_VT1, new CalcThuaNnVt1());
            //_dic.Add(TnTasks.THUA_NONG_NGHIEP_VT2, new CalcThuaNnVt2());
            _dic.Add(TnTasks.tinhThuaMatTienTronThua, new CalcPosThuaMatTienTronThua());
            _dic.Add(TnTasks.tinhThuaSau50m, new CalcPosThuaSau50m());
            _dic.Add(TnTasks.tinhThuaMatTienHon50m, new CalcPosThuaMatTienHon50m());
            _dic.Add(TnTasks.tinhThuaHcDuoi100mTronThua,new CalcPosTHCS100TronThua());
            _dic.Add(TnTasks.tinhThuaHc100_200mTronThua, new CalcPosTHCS100_200TronThua());
            _dic.Add(TnTasks.tinhThuaNnVt1TronThua, new CalcPosThuaNnVt1TronThua());
            _dic.Add(TnTasks.tinhThuaNnVt1Hon100m, new CalcPosThuaNnVt1Hon100m());
            _dic.Add(TnTasks.tinhThuaNnVt2Th1TronThua, new CalcPosThuaNnVt2Th1TronThua());
            _dic.Add(TnTasks.tinhThuaRiengLe, new CalcThuaRiengLe());
            _dic.Add(TnTasks.tinhHemSauDuoi100m, new CalcGiaHemChinhDuoi100());
            _dic.Add(TnTasks.tinhHemSau100_200m, new CalcGiaHemChinh100_200());
            _dic.Add(TnTasks.tinhHemSauTren200m, new CalcGiaHemChinhTren200());
            _dic.Add(TnTasks.tinhHemPhuSau100_200m, new CalcGiaHemPhu100_200());
            _dic.Add(TnTasks.tinhHemPhuSauDuoi100m, new CalcGiaHemPhuDuoi100());
            _dic.Add(TnTasks.tinhHemPhuSauTren200m, new CalcGiaHemPhuTren200());
            _dic.Add(TnTasks.tinhThuaHcTuGiaHem, new CalcThuaTuGiaHem());
            _dic.Add(TnTasks.tinhThuaHpTuGiaHem, new CalcPosThuaTuGiaHemPhu());
        }
        public static CalculatorContext CallMe()
        {
            if (_meClass == null)
            {
                _meClass = new CalculatorContext();
            }
            return _meClass;
        }
        public ICalculator GetCalculator(int task)
        {
            //MessageBox.Show(task.ToString());
            ICalculator calc = null;
            try
            {
                calc = _dic[task];
            }
            catch { }
            return calc;
        }
        public void Add(int task, ICalculator calculator)
        {
            _dic.Add(task, calculator);
        }
    }
}
