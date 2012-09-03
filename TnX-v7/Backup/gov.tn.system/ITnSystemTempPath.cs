// File:    ITnExMemDataManager.cs
// Author:  HT
// Created: Saturday, October 22, 2011 7:20:37 AM
// Purpose: Definition of Interface ITnExMemDataManager

using System;

namespace gov.tn.system
{
    public interface ITnSystemTempPath
    {
        string TempPath { get; set; }
        string TempMdb { get; set; }
        string TempFullPath { get; set; }
        string TempFullPathNoEnd { get; set; }
        string NameMdb { get; set; }
        void Clear();

    }
}
