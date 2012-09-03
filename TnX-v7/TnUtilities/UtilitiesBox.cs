using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Xml;
using System.IO;
using System.Data.SqlClient;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;

namespace TnUtilities
{
    public class UtilitiesBox : ITnUtilitiesFile, ITnUtilities //:ITnUtilitiesFile,ITnUtilComponent,ITnUtilities
    {
        SqlConnection sqlConn = null;

        #region Dung cho treeList
        private object _cellValue = null;

        public object CellValue
        {
            get { return _cellValue; }
            set { _cellValue = value; }
        }
        #endregion

        public UtilitiesBox()
        {

        }
        public UtilitiesBox(SqlConnection sqlConnection)
        {
            sqlConn = sqlConnection;
        }
        public string GetNameFromPathIncludeDot(string path, char[] split)
        {
            //string strName = "";
            string[] arrPath = null;
            char[] charSplit = split;
            arrPath = path.Split(charSplit);
            //for (int i = 0; i < arrPath.Length; i++)
            //{

            //}

            return arrPath[arrPath.Length - 1];
        }
        public string GetPathWithoutName(string path, char[] split)
        {
            string[] arrPath = null;
            string strName = "";
            char[] charSplit = split;
            arrPath = path.Split(charSplit);
            strName = arrPath[arrPath.Length - 1];
            //MessageBox.Show(path.Substring(0, path.Length - strName.Length));
            return path.Substring(0, path.Length - strName.Length - 1);
        }


        public static void StartService(string service_name, int timeoutMilliseconds)
        {

            ServiceController service = new ServiceController(service_name);
            if (service.Status.Equals(ServiceControllerStatus.Running))
            {
                return;
            }
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                //throw new InvalidCastException();
                //return true;
            }
            catch
            {
                //MessageBox.Show("starting service 'esri-sde' ...");
                //return false;
            }
        }


        #region ITnUtilitiesFile Members

        void ITnUtilitiesFile.CreateXmlFile(string AuthorName, string[,] obj_with_val, string name, string path)
        {
            string nameXml = path + name + ".tnx";
            XmlTextWriter writer = new XmlTextWriter(nameXml, System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement(AuthorName);
            for (int i = 0; i < obj_with_val.Length / 2; i++)
            {
                createNode(obj_with_val[i, 0], obj_with_val[i, 1], writer);
            }
            //createNode(value[i], writer);
            //createNode("2", "Product 2", "2000", writer);
            //createNode("3", "Product 3", "3000", writer);
            //createNode("4", "Product 4", "4000", writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }


        #endregion


        private void createNode(string obj, string value, XmlTextWriter writer)
        {
            writer.WriteStartElement(obj);
            writer.WriteString(value);
            writer.WriteEndElement();
            //writer.WriteStartElement("Product_id");
            //writer.WriteString(pID);
            //writer.WriteEndElement();
            //writer.WriteStartElement("Product_name");
            //writer.WriteString(pName);
            //writer.WriteEndElement();
            //writer.WriteStartElement("Product_price");
            //writer.WriteString(pPrice);
            //writer.WriteEndElement();
            //writer.WriteEndElement();
        }

        #region ITnUtilitiesFile Members


        string[,] ITnUtilitiesFile.ReadUserInfoFromXmlFile(string name, string path)
        {
            string[,] objWithVal = new string[,] { { "", "" } };
            try
            {
                XmlDataDocument xmldoc = new XmlDataDocument();
                XmlNodeList xmlnode;
                string nameXml = "";
                if (path != " ")
                {
                    nameXml = path + name + ".tnx";
                }
                else
                {
                    nameXml = name + ".tnx";
                }

                IEncrypt encrypt = new TnEncrypt();
                string _key = "tn";
                FileStream fs = new FileStream(nameXml, FileMode.Open, FileAccess.Read);
                xmldoc.Load(fs);

                xmlnode = xmldoc.GetElementsByTagName("server");
                string server = xmlnode.Item(0).InnerText;

                xmlnode = xmldoc.GetElementsByTagName("database");
                string database = xmlnode.Item(0).InnerText;

                xmlnode = xmldoc.GetElementsByTagName("uid");
                string user = xmlnode.Item(0).InnerText;

                xmlnode = xmldoc.GetElementsByTagName("pwd");
                string pass = encrypt.Decrypt(xmlnode.Item(0).InnerText, _key, true);

                xmlnode = xmldoc.GetElementsByTagName("instance");
                string instance = xmlnode.Item(0).InnerText;

                xmlnode = xmldoc.GetElementsByTagName("version");
                string version = xmlnode.Item(0).InnerText;

                objWithVal = new string[,] { { "server", server }, { "database", database }, { "uid", user }, { "pwd", pass }, { "instance", instance }, { "version", version } };
                fs.Close();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }

            return objWithVal;
        }

        string[,] ITnUtilitiesFile.ReadLayers4CalcFromXmlFile(string name, string path)
        {
            string[,] objWithVal = new string[,] { { "", "" } };
            try
            {
                XmlDataDocument xmldoc = new XmlDataDocument();
                XmlNodeList xmlnode;
                string nameXml = "";
                if (path != " ")
                {
                    nameXml = path + name + ".tnx";
                }
                else
                {
                    nameXml = name + ".tnx";
                }


                FileStream fs = new FileStream(nameXml, FileMode.Open, FileAccess.Read);
                xmldoc.Load(fs);
                xmlnode = xmldoc.GetElementsByTagName("thua");
                string thua = xmlnode.Item(0).InnerText;

                xmlnode = xmldoc.GetElementsByTagName("duong");
                string duong = xmlnode.Item(0).InnerText;

                xmlnode = xmldoc.GetElementsByTagName("hem");
                string hem = xmlnode.Item(0).InnerText;

                xmlnode = xmldoc.GetElementsByTagName("duong_buffer_1m");
                string duong_buffer_1m = xmlnode.Item(0).InnerText;

                xmlnode = xmldoc.GetElementsByTagName("duong_buffer_50m");
                string duong_buffer_50m = xmlnode.Item(0).InnerText;

                xmlnode = xmldoc.GetElementsByTagName("duong_buffer_100m");
                string duong_buffer_100m = xmlnode.Item(0).InnerText;

                xmlnode = xmldoc.GetElementsByTagName("duong_buffer_200m");
                string duong_buffer_200m = xmlnode.Item(0).InnerText;

                xmlnode = xmldoc.GetElementsByTagName("hem_buffer_1m");
                string hem_buffer_1m = xmlnode.Item(0).InnerText;

                xmlnode = xmldoc.GetElementsByTagName("hem_layer_buffer_1m");
                string hem_layer_buffer_1m = xmlnode.Item(0).InnerText;

                xmlnode = xmldoc.GetElementsByTagName("hem_buffer_1m_crt_frm_layer");
                string hem_buffer_1m_crt_frm_layer = xmlnode.Item(0).InnerText;
                //objWithVal = new string[,] { { "thua", thua }, { "duong", duong }, { "hem", hem } };
                objWithVal = new string[,] {{"thua",thua},{"duong",duong},{"hem",hem},{"duong_buffer_1m",duong_buffer_1m},
            {"duong_buffer_50m",duong_buffer_50m},{"duong_buffer_100m",duong_buffer_100m},{"duong_buffer_200m",duong_buffer_200m},
            {"hem_buffer_1m",hem_buffer_1m},{"hem_layer_buffer_1m",hem_layer_buffer_1m},{"hem_buffer_1m_crt_frm_layer",hem_buffer_1m_crt_frm_layer}};
                fs.Close();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }

            return objWithVal;
        }

        List<List<string>> ITnUtilitiesFile.ReadLayersFormXmlFile(String name, String path)
        {
            List<List<string>> objWithVal = new List<List<String>>();
            List<String> lstThua = new List<string>();
            List<String> lstDuong = new List<string>();
            List<String> lstHem = new List<string>();
            List<String> lstGiadat = new List<string>();
            try
            {
                XmlDataDocument xmldoc = new XmlDataDocument();
                XmlNodeList xmlnode;
                string nameXml = "";
                if (path != " ")
                {
                    nameXml = path + name + ".tnx";
                }
                else
                {
                    nameXml = name + ".tnx";
                }


                FileStream fs = new FileStream(nameXml, FileMode.Open, FileAccess.Read);
                xmldoc.Load(fs);
                xmlnode = xmldoc.GetElementsByTagName("thua");
                foreach (XmlNode node in xmlnode)
                {
                    lstThua.Add(node.InnerText);
                }

                xmlnode = xmldoc.GetElementsByTagName("duong");
                foreach (XmlNode node in xmlnode)
                {
                    lstDuong.Add(node.InnerText);
                }

                xmlnode = xmldoc.GetElementsByTagName("hem");
                foreach (XmlNode node in xmlnode)
                {
                    lstHem.Add(node.InnerText);
                }

                xmlnode = xmldoc.GetElementsByTagName("thua_giadat");
                foreach (XmlNode node in xmlnode)
                {
                    lstGiadat.Add(node.InnerText);
                }
                objWithVal.Add(lstThua);
                objWithVal.Add(lstDuong);
                objWithVal.Add(lstHem);
                objWithVal.Add(lstGiadat);
                fs.Close();
            }
            catch { }
            return objWithVal;
        }

        string ITnUtilitiesFile.ReadSqlInfo(string file_name, string path)
        {
            string sqlInfo = "";
            try
            {
                XmlDataDocument xmldoc = new XmlDataDocument();
                XmlNodeList xmlnode;
                string nameXml = "";
                if (path != " ")
                {
                    nameXml = path + file_name + ".tnx";
                }
                else
                {
                    nameXml = file_name + ".tnx";
                }


                FileStream fs = new FileStream(nameXml, FileMode.Open, FileAccess.Read);
                xmldoc.Load(fs);
                xmlnode = xmldoc.GetElementsByTagName("version");
                sqlInfo = xmlnode.Item(0).InnerText;
            }
            catch { }
            return sqlInfo;
        }

        void ITnUtilitiesFile.CreateXmlFile(string AuthorName, List<String[]> obj_with_val, string name, string path)
        {
            //luu y obj_with_val la list cac mang 2 gia tri
            string nameXml = path + name + ".tnx";
            XmlTextWriter writer = new XmlTextWriter(nameXml, System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement(AuthorName);
            for (int i = 0; i < obj_with_val.Count; i++)
            {
                createNode(obj_with_val[i][0], obj_with_val[i][1], writer);
            }
            //createNode(value[i], writer);
            //createNode("2", "Product 2", "2000", writer);
            //createNode("3", "Product 3", "3000", writer);
            //createNode("4", "Product 4", "4000", writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        string ITnUtilitiesFile.ReadValueFromXmlFile(string tag_name, string file_name, string path)
        {
            string value = "";
            try
            {
                XmlDataDocument xmldoc = new XmlDataDocument();
                XmlNodeList xmlnode;
                string nameXml = "";
                if (path != " ")
                {
                    nameXml = path + file_name + ".tnx";
                }
                else
                {
                    nameXml = file_name + ".tnx";
                }


                FileStream fs = new FileStream(nameXml, FileMode.Open, FileAccess.Read);
                xmldoc.Load(fs);
                xmlnode = xmldoc.GetElementsByTagName(tag_name);
                value = xmlnode.Item(0).InnerText;
            }
            catch { }
            return value;
        }

        bool ITnUtilitiesFile.FileExist(string path)
        {
            
            return System.IO.File.Exists(path);
        }

        void ITnUtilitiesFile.Delete(string path)
        {
            try
            {
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            catch { }
        }

        #endregion



        public static string getNameOnly(string fullNameWithDot)
        {
            string[] arrName = fullNameWithDot.Split('.');
            int len = arrName.Length;
            return arrName[len - 1];
        }

        #region ITnUtilities

        List<string[]> ITnUtilities.GetLstOfLayers(List<List<string>> list)
        {
            List<string[]> result = new List<string[]>();
            int len = list[0].Count;
            for (int i = 0; i < len; i++)
            {
                result.Add(new string[] { "thua", list[0][i] });
            }

            len = list[1].Count;
            for (int i = 0; i < len; i++)
            {
                result.Add(new string[] { "duong", list[1][i] });
            }

            len = list[2].Count;
            for (int i = 0; i < len; i++)
            {
                result.Add(new string[] { "hem", list[2][i] });
            }

            len = list[3].Count;
            for (int i = 0; i < len; i++)
            {
                result.Add(new string[] { "thua_giadat", list[3][i] });
            }

            return result;
        }

        #endregion ITnUtilities

        public static string ArrayToString(object[] array)
        {
            string result = String.Empty;
            foreach (object o in array)
            {
                result = o.ToString() + ",";
            }
            result.TrimEnd(',');
            return result;
        }

        public static string ConverUserinfoToConnStr(string[,] userInfo)
        {
            string result = String.Empty;


            return result;
        }

        #region Them tab co chua list tree
        static int noOfTab = 1;
        public XtraTabPage AddNewTab(ref XtraTabControl tab_control, int width, int height, string text, int curTabIndex, RibbonControl ribbonControl)
        {
            XtraTabPage newTab = new XtraTabPage();
            //TreeList newTree = new TreeList();
            GridControl newGrid = new GridControl();

            GridView newGridView = new GridView();


            if (tab_control != null)
            {
                try
                {
                    tab_control.SuspendLayout();

                    tab_control.TabPages.Add(newTab);

                    newTab.Controls.Add(newGrid);
                    //newTab.Name = name;
                    newTab.Size = new System.Drawing.Size(width, height);
                    newTab.Text = text;

                    newGrid.Dock = DockStyle.Fill;
                    newGrid.Location = new System.Drawing.Point(0, 0);
                    newGrid.MainView = newGridView;
                    newGrid.MenuManager = ribbonControl;
                    newGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { newGridView });
                    //newTree.Name = "tab_" + noOfTab;
                    newGrid.TabIndex = curTabIndex++;
                    noOfTab++;
                    newGrid.Click += new EventHandler(newTree_Click);
                    newGridView.GridControl = newGrid;
                    tab_control.ResumeLayout(false);

                }
                catch (Exception e1) { MessageBox.Show(e1.ToString()); }
                return newTab;
            }
            else
            {
                return null;
            }


        }

        void newTree_Click(object sender, EventArgs e)
        {
            _cellValue = noOfTab;
        }


        #endregion

        #region chuyen array thanh dataset

        #endregion

    }
}
