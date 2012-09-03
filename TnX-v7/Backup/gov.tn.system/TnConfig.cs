using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gov.tn.system
{
    public class TnConfig
    {
        public static TnSecLayersName Layers { get { return new TnSecLayersName(); } }
        public static TnSecSde Sde { get { return new TnSecSde(); } }
        public static TnSecSqlServer Sql { get { return new TnSecSqlServer(); } }
        public static TnSecProduct Product { get { return new TnSecProduct(); } }
        public static TnSecParamForCalc Param { get { return TnSecParamForCalc.CallMe(); } }
    }
}
