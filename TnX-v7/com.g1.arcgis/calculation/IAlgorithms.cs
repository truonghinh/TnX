using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.calculation
{
    public interface IAlgorithms
    {
        void Attach(IAlgorithm algorithm);
        void Accept(IVisitor visitor);
        int Count { get; }
    }
}
