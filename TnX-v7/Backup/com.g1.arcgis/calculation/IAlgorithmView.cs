using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.calculation
{
    public interface IAlgorithmView
    {
        void SetDefault();
        void Save();
        void Cancel();
        void Help();
        void LoadAlgorithm();
        void UpdateIntoLocalAlg();
        void UpdateIntoResultAlg();
    }
}
