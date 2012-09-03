using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace g1.tn.calculation
{
    public interface IEditPositionParamsView
    {
        void Show();
        void Close();
        List<object> MaThua { get; set; }
        List<IFeature> MyFeature { get; set; }
        void ClearMaThua();
    }
}
