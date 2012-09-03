using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.tn.calculation.evaluate
{
    public class ExpressionParameters
    {
        /// <summary>
        /// [INTERSECT]
        /// </summary>
        public static readonly string Intersect = "INTERSECT";
        public static readonly string IntersectWb = "[INTERSECT]";
        /// <summary>
        /// [CONTAINED_BY]
        /// </summary>
        public static readonly string ContainedBy = "CONTAINED_BY";
        public static readonly string ContainedByWb = "[CONTAINED_BY]";
        /// <summary>
        /// [NEW_SELECTION]
        /// </summary>
        public static readonly string NewSelection = "NEW_SELECTION";
        public static readonly string NewSelectionWb = "[NEW_SELECTION]";
        /// <summary>
        /// [ADD_SELECTION]
        /// </summary>
        public static readonly string AddSelection = "ADD_SELECTION";
        public static readonly string AddSelectionWb = "[ADD_SELECTION]";
        /// <summary>
        /// [AND_SELECTION]
        /// </summary>
        public static readonly string AndSelection = "AND_SELECTION";
        public static readonly string AndSelectionWb = "[AND_SELECTION]";
        /// <summary>
        /// [SUBTRACT_SELECTION]
        /// </summary>
        public static readonly string SubtractSelection = "SUBTRACT_SELECTION";
        public static readonly string SubtractSelectionWb = "[SUBTRACT_SELECTION]";

        public static readonly string GiaDatDuong = "giadatduong";
        public static readonly string GiaDatDuongWb = "[giadatduong]";

        public static readonly string GiaDatHemChinh = "giadathemchinh";
        public static readonly string GiaDatHemChinhWb = "[giadathemchinh]";

        public static readonly string GiaDatHemPhu = "giadathemphu";
        public static readonly string GiaDatHemPhuWb = "[giadathemphu]";

        public static readonly string HeSoDatSxkd = "hesodatsxkd";
        public static readonly string HeSoDatSxkdWb = "[hesodatsxkd]";

        public static readonly string DienTich = "dientich";
        public static readonly string DienTichWb = "[dientich]";

        public static readonly string DienTichPl = "dientichpl";
        public static readonly string DienTichPlWb = "[dientichpl]";

        public static readonly string GiaDatNn = "giadatnongnghiep";
        public static readonly string GiaDatNnWb = "[giadatnongnghiep]";

        public static readonly string GiaDatONT = "giadatONT";
        public static readonly string GiaDatONTWb = "[giadatONT]";
    }
}
