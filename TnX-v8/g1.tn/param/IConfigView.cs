using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace g1.tn.param
{
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
