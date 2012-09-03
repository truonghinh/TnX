// File:    TnExMemory.cs
// Author:  HT
// Created: Saturday, October 22, 2011 7:19:01 AM
// Purpose: Definition of Class TnExMemory

using System;

namespace gov.tn.system
{
    public class TnSystemTempPath : ITnSystemTempPath
    {
        private static string _tempPath;
        private static string _tempMdb;
        private static string _tempFullPath;
        private static string _tempFullPathNoEnd;
        private static string _nameMdb;
        private static string _tempDataPath;
        private static string _connectionFileFullPath;
        private static string _connectionFileName;
        private static string _connectionFilePath;
        public TnSystemTempPath()
        {
            _tempFullPath = "C:/tn/temp/tempmdb.mdb/";
            _tempMdb = "tempmdb.mdb";
            _tempPath = "C:/tn/temp";
            _tempFullPathNoEnd = "C:/tn/temp/tempmdb.mdb";
            _nameMdb = "tempmdb";
            _connectionFileFullPath="C:\\tn\\temp\\tn.sde";
            _connectionFileName = "tnx.sde";
            _connectionFilePath = "C:/tn/temp/";

            //_tempDataPath=
        }

        /// <summary>
        /// C:\\tn\\temp\\tn.sde
        /// </summary>
        public static string ConnectionFileFullPath
        {
            get { return _connectionFileFullPath; }
            set { _connectionFileFullPath = value; }
        }

        public static string ConnectionFileName
        {
            get { return _connectionFileName; }
            set { _connectionFileName = value; }
        }

        public static string ConnectionFilePath
        {
            get { return _connectionFilePath; }
            set { _connectionFilePath = value; }
        }

        /// <summary>
        /// C:/tn/temp
        /// </summary>
        public static string TempPath
        {
            get { return _tempPath; }
            set { _tempPath = value; }
        }

        /// <summary>
        /// C:/tn/temp/tempmdb.mdb/
        /// </summary>
        public static string TempFullPath
        {
            get { return _tempFullPath; }
            set { _tempFullPath = value; }
        }

        /// <summary>
        /// tempmdb.mdb
        /// </summary>
        public static string TempMdb
        {
            get { return _tempMdb; }
            set { _tempMdb = value; }
        }

        /// <summary>
        /// C:/tn/temp/tempmdb.mdb
        /// </summary>
        public static string TempFullPathNoEnd
        {
            get { return _tempFullPathNoEnd; }
            set { _tempFullPathNoEnd = value; }
        }

        /// <summary>
        /// tempmdb
        /// </summary>
        public static string NameMdb
        {
            get { return _nameMdb; }
            set { _nameMdb = value; }
        }

        /// <summary>
        /// C:/tn/temp
        /// </summary>
        string ITnSystemTempPath.TempPath
        {
            get { return _tempPath; }
            set { _tempPath = value; }
        }

        /// <summary>
        /// tempmdb.mdb
        /// </summary>
        string ITnSystemTempPath.TempMdb
        {
            get { return _tempMdb; }
            set { _tempMdb = value; }
        }

        /// <summary>
        /// tempmdb
        /// </summary>
        string ITnSystemTempPath.NameMdb
        {
            get { return _nameMdb; }
            set { _nameMdb = value; }
        }

        /// <summary>
        /// C:/tn/temp/tempmdb.mdb/
        /// </summary>
        string ITnSystemTempPath.TempFullPath
        {
            get { return _tempFullPath; }
            set { _tempFullPath = value; }
        }

        /// <summary>
        /// C:/tn/temp/tempmdb.mdb
        /// </summary>
        string ITnSystemTempPath.TempFullPathNoEnd
        {
            get { return _tempFullPathNoEnd; }
            set { _tempFullPathNoEnd = value; }
        }

        void ITnSystemTempPath.Clear()
        {
            _tempFullPath = "";
            _tempMdb = "";
            _tempPath = "";
            _tempFullPathNoEnd = "";
        }


    }
}
