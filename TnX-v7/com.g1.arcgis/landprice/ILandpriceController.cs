using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.landprice
{
    public interface ILandpriceController
    {
        void LoadPrice();
        void LoadPriceFromOid();
        void LoadPriceFromKey();
        void ReCalcWithCurPos();
        void ReCalcWithNewPos();
        void ReCalcMethod();
        void CalcLandpriceWithArea();
        void LockAutoMethod();
        void LockAllMethod();
        void Unlock();
        void CommitLandprice();
        void SetView(ILandpriceView view);
        void SetEngine(ILandprice engine);
        void StartEdit();
        void SaveEdit();
        void StopEdit();
        void StopEditWithoutSaving();
        void Remove(object oid);
    }
}
