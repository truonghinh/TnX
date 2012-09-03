using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.calculation
{
    public interface IVisitor
    {
        void Visit(IAlgorithm alg);
        void SetBag(IVisitorBag bag);
        int GetCurrentIndex();
        void Reset();
    }
}
