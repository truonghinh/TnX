using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.g1.arcgis.calculation
{
    public class Algorithms:IAlgorithms
    {
        private List<IAlgorithm> _lstAlgorithm;

        public Algorithms()
        {
            this._lstAlgorithm = new List<IAlgorithm>();
        }

        private bool existAlgorithm(IAlgorithm algorithm)
        {
            if (this._lstAlgorithm.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (IAlgorithm a in this._lstAlgorithm)
                {
                    if (algorithm.Name == a.Name)
                    {
                        MessageBox.Show(string.Format("{0}={1}", algorithm.Name, a.Name));
                        return true;
                    }
                }
                return false;
            }
        }

        #region IAlgorithms Members

        void IAlgorithms.Attach(IAlgorithm algorithm)
        {
            //if (this._lstAlgorithm.Exists(existAlgorithm))
            //{
            //    MessageBox.Show(string.Format("line 43--Algorithms: da co {0}", algorithm.Name));
            //    return;
            //}
            //else
            //{
                this._lstAlgorithm.Add(algorithm);
            //}
        }

        void IAlgorithms.Accept(IVisitor visitor)
        {
            foreach (IAlgorithm a in this._lstAlgorithm)
            {
                visitor.Visit(a);
            }
        }

        #endregion

        #region IAlgorithms Members


        int IAlgorithms.Count
        {
            get { return this._lstAlgorithm.Count; }
        }

        #endregion
    }
}
