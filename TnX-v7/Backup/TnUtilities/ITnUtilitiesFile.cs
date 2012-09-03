using System;
using System.Collections.Generic;
using System.Text;

namespace TnUtilities
{
    public interface ITnUtilitiesFile
    {
        void CreateXmlFile(string AuthorName, string[,] obj_with_val, string name, string path);
        void CreateXmlFile(string AuthorName, List<String[]> obj_with_val, string name, string path);
        string[,] ReadUserInfoFromXmlFile(string file_name, string path);
        string[,] ReadLayers4CalcFromXmlFile(string file_name, string path);
        string ReadSqlInfo(string file_name, string path);
        string ReadValueFromXmlFile(string tag_name,string file_name, string path);
        List<List<String>> ReadLayersFormXmlFile(String name, String path);
        bool FileExist(string path);
        void Delete(string path);
    }
}
