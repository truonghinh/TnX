using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.connection;
using ESRI.ArcGIS.Geodatabase;
using gov.tn.TnDatabaseStructure;
using com.g1.arcgis.calculation;
using com.g1.arcgis.tn.config;
using System.Windows.Forms;
using com.g1.arcgis.database;
using System.Runtime.InteropServices;
using System.ComponentModel;
using com.g1.arcgis.util;

namespace com.g1.arcgis.tn.calculation.calculator
{
    public class FilterLandprice
    {
        public static void GetMaxValueWithDistinctKey(List<landpriceInfo> source, out List<landpriceInfo> output)
        {
            ICurrentConfig _config = CurrentConfig.CallMe();
            //CalculationEventArg evt = new CalculationEventArg();
            #region Cach 1
            //List<landpriceInfo> resultList = source;
            //ICurrentConfig _config=CurrentConfig.CallMe();
            //int len = source.Count;
            //if (len == 0)
            //{
            //    output = null;
            //    return;
            //}
            //else if (len != 1)
            //{
            //    object id1 = 0;
            //    object hesok1 = 0;
            //    double dongia1 = 0;
            //    int smt1 = 1;
            //    object id2 = 0;
            //    object hesok2 = 0;
            //    double dongia2 = 0;
            //    int smt2 = 0;
            //    int decLen = 0;
            //    int afterLen = len;
            //    for (int i = 0; i < len - decLen; i++)
            //    {
            //        hesok1 = source[i].Hesok;
            //        dongia1 = source[i].Dongia;
            //        id1 = source[i].Id;
            //        smt1 = 1;
            //        //smt1 = source[i].Somattien;
            //        afterLen = source.Count;
            //        for (int j = 0; j < afterLen; j++)
            //        {
            //            hesok2 = source[j].Hesok;
            //            dongia2 = source[j].Dongia;

            //            if (string.Compare(hesok1.ToString(), hesok2.ToString()) == 0)
            //            {
            //                MessageBox.Show(string.Format("line 76 FilterLandprice, dongia1={0},dongia2={1},somt1={2}", dongia1, dongia2, smt1));
            //                if (dongia1 >= dongia2)
            //                {

            //                    if (j != i)
            //                    {
            //                        resultList.RemoveAt(j);
            //                        resultList.RemoveAt(i);
            //                        smt1 += 1;
            //                        if (smt1 == 2)
            //                        {
            //                            dongia1 = dongia1 * _config.K2MatTien;
            //                        }
            //                        else if (smt1 == 3)
            //                        {
            //                            dongia1 = dongia1 * _config.K3MatTien;
            //                        }
            //                        else if (smt1 == 4)
            //                        {
            //                            dongia1 = dongia1 * _config.K4MatTien;
            //                        }
            //                        //MessageBox.Show("line 76 FilterLandprice, dongia1=" + dongia1.ToString());
            //                        resultList.Add(new landpriceInfo(id1, hesok1, dongia1, smt1));
            //                        //evt.Reset();
            //                        //evt.Log = string.Format("\n\n Bỏ vùng giá có id={0}, đơn giá={1}--i={2},j={3}", resultList[j].Id, dongia2, i, j);
            //                        //_caller.onCalculating(evt);
            //                    }
            //                    decLen++;
            //                    continue;
            //                }
            //                else if (dongia1 < dongia2)
            //                {
            //                    //evt.Reset();
            //                    //evt.Log = string.Format("\n\n Bỏ vùng giá có id={0}, đơn giá={1}--i={2},j={3}", resultList[j].Id, dongia1, i, j);
            //                    //_caller.onCalculating(evt);

            //                    resultList.RemoveAt(j);
            //                    resultList.RemoveAt(i);
            //                    smt1 += 1;
            //                    if (smt1 == 2)
            //                    {
            //                        dongia2 = dongia2 * _config.K2MatTien;
            //                    }
            //                    else if (smt1 == 3)
            //                    {
            //                        dongia2 = dongia2 * _config.K3MatTien;
            //                    }
            //                    else if (smt1 == 4)
            //                    {
            //                        dongia2 = dongia2 * _config.K4MatTien;
            //                    }
            //                    //MessageBox.Show("line 76 FilterLandprice, dongia1=" + dongia1.ToString());
            //                    resultList.Add(new landpriceInfo(id1, hesok1, dongia1, smt1));

            //                    decLen++;
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //}
            #endregion

            #region cach 2
            //phan loai he so vi tri
            LandPriceInfoTree tree = new LandPriceInfoTree();
            foreach (landpriceInfo land in source)
            {
                int id = int.Parse(land.Id.ToString());
                int hsk = int.Parse(land.Hesok.ToString());
                tree.insert(id, hsk, land.Dongia, land.Somattien);
            }
            //MessageBox.Show("line 132 FilterLandprice tree.count=" + tree.count().ToString());
            List<List<TTreeNode>> lst = tree.FindNodesSameHsk();
            List<landpriceInfo> result = new List<landpriceInfo>();
            int[] datmattien = new int[] { 3010, 4010, 5010, 3011, 4011, 5011 };
            int dmtLen=datmattien.Length;
            foreach (List<TTreeNode> lstNode in lst)
            {
                bool isMatTien = false;
                for (int i = 0; i < dmtLen; i++)
                {
                    if (lstNode[0].hesok == datmattien[i])
                    {
                        isMatTien = true;
                        break;
                    }
                }
                double max = lstNode[0].dongia;
                int idMax = lstNode[0].oid;
                int l = lstNode.Count;
                for (int j = 1; j < l; j++)
                {
                    if (max < lstNode[j].dongia)
                    {
                        max = lstNode[j].dongia;
                        idMax = lstNode[j].oid;
                    }
                }
                if (isMatTien)
                {
                    
                    if (l == 2)
                    {
                        max = max * _config.K2MatTien;
                    }
                    else if (l == 3)
                    {
                        max = max * _config.K3MatTien;
                    }
                    else if (l == 4)
                    {
                        max = max * _config.K4MatTien;
                    }

                }
                MessageBox.Show(string.Format("line 175 FilterLandprice,idmax={0}, hsk={1}, dongia={2},smt={3}",idMax,lstNode[0].hesok,max,l));
                result.Add(new landpriceInfo(idMax, lstNode[0].hesok, max, l));

            }
            #endregion
            output = result;
        }   
    }
}
