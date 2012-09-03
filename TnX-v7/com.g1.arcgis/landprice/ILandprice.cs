using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.calculation;

namespace com.g1.arcgis.landprice
{
    public interface ILandprice
    {
        double CurrentLandprice { get; set; }
        double CurrentArea { get; set; }
        double CurrentLandpriceWithArea { get; set; }
        int CurrentLockStatus { get; set; }
        object CurrentMathua { get; set; }
        object CurrentThuaId { get; set; }
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
        void UpdateLandprice();
        void SetView(ILandpriceView view);
        ICurrentConfig Config { get; set; }
        string TableName{get;set;}
        void StartEdit();
        void SaveEdit();
        void StopEdit();
        void StopEditWithoutSaving();
        List<object[,]> ListOfValueThuaGiaDat { get; set; }
        List<object[,]> ListOfValueThua { get; set; }
        object CurrentThuaGiaDatId { get; set; }
        void Remove(object oid);
    }
}
