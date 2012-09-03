using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.calculation
{
    /// <summary>
    /// Các form quy định các thông số tính giá sẽ implement
    /// </summary>
    public interface IConfigView
    {
        void LoadConfig();
        void SaveConfig();
        void SetOpenAndSaveView(IOpenConfigView openView, ISaveConfigView saveView);
        void SetBuddy(List<IConfigView> buddies);
        void ShowDialog();
        void KeepFollow();
        void Show();

    }
}
