using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gov.tn.system;
using gov.tn.TnDatabaseStructure;

namespace com.g1.arcgis.tn.calculation.calculator
{
    public class CalcTool
    {
        //public static int GetHeSoViTriThuaHem(double dorong, double dosau, string loaidat)
        //{
        //    int hesoVitri = TnHeSoK.DatOHemChinhR3mS100mTronThua;
        //    if (dosau == 100)
        //    {
        //        if (dorong < 3.5)
        //        {
        //            hesoVitri = TnHeSoK.DatOHemChinhR3mS100mTronThua;
        //        }
        //    }
        //    return hesoVitri;
        //}

        public static int GetHeSoViTriThuaHem(double dorong, int hesohem, string loaidat,bool hemphu)
        {
            int hesoVitri = TnHeSoK.DatOHemChinhR3mS100mTronThua;
            //neu la dat nong nghiep thi ko tinh =-1
            foreach (string s in TnLoaiDats.NONG_NGHIEP)
            {
                if (loaidat == s)
                {
                    return -1;
                }
            }
            #region kiem tra dat phi nong nghiep
            bool datpnn = false;
            foreach (string s in TnLoaiDats.PHI_NONG_NGHIEP_DOTHI)
            {
                if (loaidat.Contains(s))
                {
                    datpnn = true;
                    break;
                }
                else
                {
                    datpnn = false;
                }
            }
            #endregion
            #region kiem tra dat honhop
            bool datsxkd = false;
            bool dathonhop = false;
            bool codato = false;
            bool chicodato = false;
            bool chicodatsxkd = false;
            bool datnn = false;
            string loaidatNn = "";

            //evt.Log = string.Format("line 983 mattien, loaidat:{0}", loaidat);
            //onCalculating(evt);
            if (loaidat.Contains("+"))
            {
                //evt.Log = string.Format("line 987 mattien, loaidat:{0}, co +", loaidat);
                //onCalculating(evt);
                dathonhop = true;
                #region kiem tra co dat o
                if (loaidat.Contains("ODT"))
                {
                    //evt.Log = string.Format("line 992 mattien, loaidat:{0}, co odt", loaidat);
                    //onCalculating(evt);

                    codato = true;
                }
                #endregion

                #region kiem tra co dat nong nghiep

                foreach (string s in TnLoaiDats.NONG_NGHIEP)
                {
                    if (loaidat.Contains(s))
                    {
                        datnn = true;
                        loaidatNn = s;

                        break;
                    }
                    else
                    {
                        datnn = false;
                    }
                }
                #endregion

                #region kiem tra chi co dat sxkd
                foreach (string s in TnLoaiDats.PNN_SX_KD)
                {
                    if (loaidat == s)
                    {
                        chicodatsxkd = true;

                        break;
                    }

                    else
                    {
                        chicodatsxkd = false;
                    }
                }
                #endregion
            }
            else
            {
                #region kiem tra chi co dat o

                if (loaidat.Contains("ODT"))
                {
                    //evt.Log = string.Format("line 992 mattien, loaidat:{0}, co odt", loaidat);
                    //onCalculating(evt);
                    chicodato = true;
                }
                else
                {
                    chicodato = false;
                }
                #endregion

                #region kiem tra chi co dat sxkd
                foreach (string s in TnLoaiDats.PNN_SX_KD)
                {
                    if (loaidat == s)
                    {
                        chicodatsxkd = true;

                        break;
                    }

                    else
                    {
                        chicodatsxkd = false;
                    }
                }
                #endregion

            }

            #endregion
            if (hesohem == 1)
            {
                #region
                if (dorong < 3.5)
                {
                    if (chicodato)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatOHemPhuR3mS100mTronThua : TnHeSoK.DatOHemChinhR3mS100mTronThua;
                    }
                    else if (chicodatsxkd)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatSxkdHemPhuR3mS100mTronThua : TnHeSoK.DatSxkdHemChinhR3mS100mTronThua;
                    }
                    else if (dathonhop && codato && datnn)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatONnHemPhuR3mS100mTronThua : TnHeSoK.DatONnHemChinhR3mS100mTronThua;
                    }
                }
                else if (dorong > 6)
                {
                    if (chicodato)
                    {
                        hesoVitri =hemphu?TnHeSoK.DatOHemPhuR6mS100mTronThua:TnHeSoK.DatOHemChinhR6mS100mTronThua;
                    }
                    else if (chicodatsxkd)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatSxkdHemPhuR6mS100mTronThua : TnHeSoK.DatSxkdHemChinhR6mS100mTronThua;
                    }
                    else if (dathonhop && codato && datnn)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatONnHemPhuR6mS100mTronThua : TnHeSoK.DatONnHemChinhR6mS100mTronThua;
                    }
                }
                else
                {
                    if (chicodato)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatOHemPhuR3_6mS100mTronThua : TnHeSoK.DatOHemChinhR3_6mS100mTronThua;
                    }
                    else if (chicodatsxkd)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatSxkdHemPhuR3_6mS100mTronThua : TnHeSoK.DatSxkdHemChinhR3_6mS100mTronThua;
                    }
                    else if (dathonhop && codato && datnn)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatONnHemPhuR3_6mS100mTronThua : TnHeSoK.DatONnHemChinhR3_6mS100mTronThua;
                    }
                }
                #endregion
            }
            else if (hesohem == 2)
            {
                #region
                if (dorong < 3.5)
                {
                    if (chicodato)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatOHemPhuR3mS100_200mTronThua : TnHeSoK.DatOHemChinhR3mS100_200mTronThua;
                    }
                    else if (chicodatsxkd)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatSxkdHemPhuR3mS100_200mTronThua : TnHeSoK.DatSxkdHemChinhR3mS100_200mTronThua;
                    }
                    else if (dathonhop && codato && datnn)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatONnHemPhuR3mS100_200mTronThua : TnHeSoK.DatONnHemChinhR3mS100_200mTronThua;
                    }
                }
                else if (dorong > 6)
                {
                    if (chicodato)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatOHemPhuR6mS100_200mTronThua : TnHeSoK.DatOHemChinhR6mS100_200mTronThua;
                    }
                    else if (chicodatsxkd)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatSxkdHemPhuR6mS100_200mTronThua : TnHeSoK.DatSxkdHemChinhR6mS100_200mTronThua;
                    }
                    else if (dathonhop && codato && datnn)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatONnHemPhuR6mS100_200mTronThua : TnHeSoK.DatONnHemChinhR6mS100_200mTronThua;
                    }
                }
                else
                {
                    if (chicodato)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatOHemPhuR3_6mS100_200mTronThua : TnHeSoK.DatOHemChinhR3_6mS100_200mTronThua;
                    }
                    else if (chicodatsxkd)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatSxkdHemPhuR3_6mS100_200mTronThua : TnHeSoK.DatSxkdHemChinhR3_6mS100_200mTronThua;
                    }
                    else if (dathonhop && codato && datnn)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatONnHemPhuR3_6mS100_200mTronThua : TnHeSoK.DatONnHemChinhR3_6mS100_200mTronThua;
                    }
                }
                #endregion
            }
            else if (hesohem == 3)
            {
                #region
                if (dorong < 3.5)
                {
                    if (chicodato)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatOHemPhuR3mS200mTronThua : TnHeSoK.DatOHemChinhR3mS200mTronThua;
                    }
                    else if (chicodatsxkd)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatSxkdHemPhuR3mS200mTronThua : TnHeSoK.DatSxkdHemChinhR3mS200mTronThua;
                    }
                    else if (dathonhop && codato && datnn)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatONnHemPhuR3mS200mTronThua : TnHeSoK.DatONnHemChinhR3mS200mTronThua;
                    }
                }
                else if (dorong > 6)
                {
                    if (chicodato)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatOHemPhuR6mS200mTronThua : TnHeSoK.DatOHemChinhR6mS200mTronThua;
                    }
                    else if (chicodatsxkd)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatSxkdHemPhuR6mS200mTronThua : TnHeSoK.DatSxkdHemChinhR6mS200mTronThua;
                    }
                    else if (dathonhop && codato && datnn)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatONnHemPhuR6mS200mTronThua : TnHeSoK.DatONnHemChinhR6mS200mTronThua;
                    }
                }
                else
                {
                    if (chicodato)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatOHemPhuR3_6mS200mTronThua : TnHeSoK.DatOHemChinhR3_6mS200mTronThua;
                    }
                    else if (chicodatsxkd)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatSxkdHemPhuR3_6mS200mTronThua : TnHeSoK.DatSxkdHemChinhR3_6mS200mTronThua;
                    }
                    else if (dathonhop && codato && datnn)
                    {
                        hesoVitri = hemphu ? TnHeSoK.DatONnHemPhuR3_6mS200mTronThua : TnHeSoK.DatONnHemChinhR3_6mS200mTronThua;
                    }
                }
                #endregion
            }
            return hesoVitri;
        }
    }
}
