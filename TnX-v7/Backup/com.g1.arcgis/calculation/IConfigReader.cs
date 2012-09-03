using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.calculation
{
    public interface IConfigReader
    {
        void WriteOut(string fileName,string nam);
        void Read(string fileName,string nam);
        void CreateDefaultConfig();
    }
}
