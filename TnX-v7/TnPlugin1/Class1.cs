using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtensibleAPI;
using DevExpress.XtraBars;

namespace TnPlugin1
{
    public class Class1:IBarButtonProvider
    {
        BarButtonItem barButtonItem;
        #region IBarButtonProvider Members

        public BarButtonItem[] GetBarButtons()
        {
            
            this.barButtonItem = new BarButtonItem();
            this.barButtonItem.Caption = "plugin1";
            //this.barButtonItem.Id = 142;
            //this.barButtonItem.Name = "bbiPlugin1";
            this.barButtonItem.ItemClick += new ItemClickEventHandler(barButtonItem_ItemClick);
            this.barButtonItem.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem.LargeGlyph = global::TnPlugin1.Properties.Resources.plugin_template_48;
            BarButtonItem[] buttons = new BarButtonItem[] { this.barButtonItem };
            
            return buttons;
        }

        void barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraForm1 fr = new XtraForm1();
            fr.Show();
        }

        #endregion
    }
}
