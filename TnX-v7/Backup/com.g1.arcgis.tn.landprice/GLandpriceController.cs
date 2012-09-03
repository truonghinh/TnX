using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.landprice;

namespace com.g1.arcgis.tn.landprice
{
    public class GLandpriceController:ILandpriceController
    {
        ILandpriceView _view;
        ILandprice _engine;
        public GLandpriceController(ILandprice engine, ILandpriceView view)
        {
            this._view = view;
            this._engine = engine;
        }

        #region ILandpriceController Members

        void ILandpriceController.LoadPrice()
        {
            _engine.CurrentMathua = _view.CurrentMathua;
            _engine.CurrentThuaId = _view.CurrentThuaId;
            _engine.Config = _view.Config;
            _engine.TableName = _view.LandpriceTableName;
            _engine.LoadPrice();
        }

        void ILandpriceController.ReCalcWithCurPos()
        {
            _engine.CurrentMathua = _view.CurrentMathua;
            _engine.CurrentThuaId = _view.CurrentThuaId;
            _engine.CurrentLockStatus = _view.CurrentLockStatus;

            _engine.ReCalcWithCurPos();
        }

        void ILandpriceController.ReCalcWithNewPos()
        {
            _engine.CurrentMathua = _view.CurrentMathua;
            _engine.CurrentThuaId = _view.CurrentThuaId;
            _engine.CurrentLockStatus = _view.CurrentLockStatus;
            _engine.ReCalcWithNewPos();
        }

        void ILandpriceController.ReCalcMethod()
        {
            _engine.CurrentThuaId = _view.CurrentThuaId;
            _engine.ReCalcMethod();
        }

        void ILandpriceController.CalcLandpriceWithArea()
        {
            _engine.CurrentLandprice=_view.CurrentLandprice;
            _engine.CurrentArea = _view.CurrentArea;
            
            _engine.CalcLandpriceWithArea();
        }

        void ILandpriceController.LockAutoMethod()
        {
            _engine.CurrentThuaId = _view.CurrentThuaId;
            _engine.LockAutoMethod();
        }

        void ILandpriceController.LockAllMethod()
        {
            _engine.CurrentThuaId = _view.CurrentThuaId;
            _engine.LockAllMethod();
        }

        void ILandpriceController.Unlock()
        {
            _engine.CurrentThuaId = _view.CurrentThuaId;
            _engine.Unlock();
        }

        void ILandpriceController.CommitLandprice()
        {
            _engine.CurrentThuaId = _view.CurrentThuaId;
            _engine.CurrentLandprice = _view.CurrentLandprice;
            _engine.CurrentLockStatus=_view.CurrentLockStatus;
            _engine.CommitLandprice();
        }

        void ILandpriceController.SetView(ILandpriceView view)
        {
            this._view = view;
        }

        void ILandpriceController.SetEngine(ILandprice engine)
        {
            this._engine = engine;
        }

        #endregion

        #region ILandpriceController Members


        void ILandpriceController.LoadPriceFromOid()
        {
            throw new NotImplementedException();
        }

        void ILandpriceController.LoadPriceFromKey()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ILandpriceController Members


        void ILandpriceController.StartEdit()
        {
            _engine.StartEdit();
        }

        void ILandpriceController.SaveEdit()
        {
            _engine.CurrentThuaId = _view.CurrentThuaId;
            _engine.CurrentThuaGiaDatId = _view.CurrentThuaGiaDatId;
            _engine.ListOfValueThua = _view.ListOfValueThua;
            _engine.ListOfValueThuaGiaDat = _view.ListOfValueThuaGiaDat;
            _engine.SaveEdit();
        }

        void ILandpriceController.StopEdit()
        {
            _engine.StopEdit();
        }

        void ILandpriceController.StopEditWithoutSaving()
        {
            _engine.StopEditWithoutSaving();
        }

        #endregion


        #region ILandpriceController Members


        void ILandpriceController.Remove(object oid)
        {
            _engine.Remove(oid);
        }

        #endregion
    }
}
