using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.util.queryString
{
    public class QueryStringBuilder
    {
        public static string CreateOrQueryString(string fieldName,params object[] args)
        {
            int c = args.Length;
            string result="";
            for(int i=0;i<c;i++)
            {
                if (i == c - 1)
                {
                    result += string.Format("{0}='{1}'", fieldName, args[i]);
                }
                else
                {

                    result += string.Format("{0}='{1}' or ",fieldName,args[i]);
                }
            }
            return result;
        }
    }
}
