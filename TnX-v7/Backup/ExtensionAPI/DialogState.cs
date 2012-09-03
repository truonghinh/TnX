using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ExtensibleAPI
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
