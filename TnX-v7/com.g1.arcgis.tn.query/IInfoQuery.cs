﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.query;
using gov.tn;

namespace com.g1.arcgis.tn.query
{
    public interface IInfoQuery : IAttributeQuery
    {
        TnThuaInfo ThuaInfo{get;set;}
    }
}