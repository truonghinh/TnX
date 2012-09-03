using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ExtensionDevExpressFormAPI
{
    public class DialogState
    {
        public DialogResult result;
        public FileDialog dialog;
 

        public void ThreadProcShowDialog()
        {
            result = dialog.ShowDialog();
        }
    }
}
