using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.tn.calculation.evaluate
{
    public class DefaultExpressions
    {
        /// <summary>
        /// ChonThuaTheoDuong([INTERSECT],[NEW_SELECTION],1) then ChonThuaTheoDuong([CONTAINED_BY],[AND_SELECTION],100)
        /// </summary>
        public static readonly string _1010 = string.Format("{0}({1},{2},{3}) {4} {5}({6},{7},{8})",
            ExpressionFunctions.ChonThuaTheoDuong, ExpressionParameters.IntersectWb, ExpressionParameters.NewSelectionWb, 1,
            ExpressionKeyWords.Then,
            ExpressionFunctions.ChonThuaTheoDuong, ExpressionParameters.ContainedByWb, ExpressionParameters.AndSelectionWb, 100);

        /// <summary>
        /// ChonThuaTheoDuong([INTERSECT],[NEW_SELECTION],1) then ChonThuaTheoDuong([CONTAINED_BY],[SUBTRACT_SELECTION],100)
        /// </summary>
        public static readonly string _1011 = string.Format("{0}({1},{2},{3}) {4} {5}({6},{7},{8})",
            ExpressionFunctions.ChonThuaTheoDuong, ExpressionParameters.IntersectWb, ExpressionParameters.NewSelectionWb, 1,
            ExpressionKeyWords.Then,
            ExpressionFunctions.ChonThuaTheoDuong, ExpressionParameters.ContainedByWb, ExpressionParameters.SubtractSelectionWb, 100);

        /// <summary>
        /// ChonThuaTheoDuong([INTERSECT],[NEW_SELECTION],1) then ChonThuaTheoTtXa([CONTAINED_BY],[AND_SELECTION],500)
        /// </summary>
        public static readonly string _2110 = string.Format("{0}({1},{2},{3}) {4} {5}({6},{7},{8})",
            ExpressionFunctions.ChonThuaTheoDuong, ExpressionParameters.IntersectWb, ExpressionParameters.NewSelectionWb, 1,
            ExpressionKeyWords.Then,
            ExpressionFunctions.ChonThuaTheoTtXa, ExpressionParameters.ContainedByWb, ExpressionParameters.AddSelectionWb, 500);

        /// <summary>
        /// ChonThuaTheoDuong([INTERSECT],[NEW_SELECTION],1) then ChonThuaTheoDuong([CONTAINED_BY],[SUBTRACT_SELECTION],100)
        /// </summary>
        public static readonly string _1020 = string.Format("{0}({1},{2},{3}) {4} {5}({6},{7},{8})",
            ExpressionFunctions.ChonThuaTheoDuong, ExpressionParameters.IntersectWb, ExpressionParameters.NewSelectionWb, 1,
            ExpressionKeyWords.Then,
            ExpressionFunctions.ChonThuaTheoDuong, ExpressionParameters.ContainedByWb, ExpressionParameters.SubtractSelectionWb, 100);

        /// <summary>
        /// ChonThuaTheoDuong([INTERSECT],[NEW_SELECTION],1) then ChonThuaTheoDuong([CONTAINED_BY],[AND_SELECTION],50)
        /// </summary>
        public static readonly string _3010 = string.Format("{0}({1},{2},{3}) {4} {5}({6},{7},{8})",
            ExpressionFunctions.ChonThuaTheoHemChinh, ExpressionParameters.IntersectWb, ExpressionParameters.NewSelectionWb, 1,
            ExpressionKeyWords.Then,
            ExpressionFunctions.ChonThuaTheoDuong, ExpressionParameters.ContainedByWb, ExpressionParameters.AndSelectionWb, 50);

        /// <summary>
        /// ChonThuaTheoDuong([INTERSECT],[NEW_SELECTION],1) then ChonThuaTheoDuong([CONTAINED_BY],[SUBTRACT_SELECTION],50)
        /// </summary>
        public static readonly string _3011 = string.Format("{0}({1},{2},{3}) {4} {5}({6},{7},{8})",
            ExpressionFunctions.ChonThuaTheoHemChinh, ExpressionParameters.IntersectWb, ExpressionParameters.NewSelectionWb, 1,
            ExpressionKeyWords.Then,
            ExpressionFunctions.ChonThuaTheoDuong, ExpressionParameters.ContainedByWb, ExpressionParameters.SubtractSelectionWb, 50);

        /// <summary>
        /// ChonThuaTheoDuong([INTERSECT],[NEW_SELECTION],1) then ChonThuaTheoDuong([CONTAINED_BY],[SUBTRACT_SELECTION],50)
        /// </summary>
        public static readonly string _3020 = string.Format("{0}({1},{2},{3}) {4} {5}({6},{7},{8})",
            ExpressionFunctions.ChonThuaTheoHemChinh, ExpressionParameters.IntersectWb, ExpressionParameters.NewSelectionWb, 1,
            ExpressionKeyWords.Then,
            ExpressionFunctions.ChonThuaTheoDuong, ExpressionParameters.ContainedByWb, ExpressionParameters.SubtractSelectionWb, 50);

        /// <summary>
        /// ChonThuaTheoHemChinh([INTERSECT],[NEW_SELECTION],1) then ChonThuaTheoDuong([CONTAINED_BY],[AND_SELECTION],100)
        /// </summary>
        public static readonly string _3111 = string.Format("{0}({1},{2},{3}) {4} {5}({6},{7},{8})",
            ExpressionFunctions.ChonThuaTheoHemChinh,ExpressionParameters.IntersectWb,ExpressionParameters.NewSelectionWb,1,
            ExpressionKeyWords.Then,
            ExpressionFunctions.ChonThuaTheoDuong,ExpressionParameters.ContainedByWb,ExpressionParameters.AndSelectionWb,100);

        /// <summary>
        /// ChonThuaTheoHemChinh([INTERSECT],[NEW_SELECTION],1) then ChonThuaTheoDuong([CONTAINED_BY],[AND_SELECTION],200) then ChonThuaTheoDuong([CONTAINED_BY],[SUBTRACT_SELECTION],200)
        /// </summary>
        public static readonly string _3112 = string.Format("{0}({1},{2},{3}) {4} {5}({6},{7},{8}) {9} {10}({11},{12},{13})",
            ExpressionFunctions.ChonThuaTheoHemChinh,ExpressionParameters.IntersectWb,ExpressionParameters.NewSelectionWb,1,
            ExpressionKeyWords.Then,
            ExpressionFunctions.ChonThuaTheoDuong,ExpressionParameters.ContainedByWb,ExpressionParameters.AndSelectionWb,200,
            ExpressionKeyWords.Then,
            ExpressionFunctions.ChonThuaTheoDuong,ExpressionParameters.ContainedByWb,ExpressionParameters.SubtractSelectionWb,100);

        
    }
}
