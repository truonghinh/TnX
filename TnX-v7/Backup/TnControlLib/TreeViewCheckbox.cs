using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;


namespace TnControlLib {

    [System.ComponentModel.DesignerCategory("Code")]
    public class TnTreeViewCheckBox : TreeView
    {

        private ImageList imageList1;
        private IContainer components;
        private List<TreeNode> _indeterminateds = new List<TreeNode>();
        private Graphics _graphics;
        private Image _imgIndeterminate;
        private bool _skipCheckEvents = false;
        private List<object> _listNodeChecked = new List<object>();

        public List<object> ListNodeChecked
        {
            get { walkOnTreeGetChecked(); return _listNodeChecked; }
            //set { _listNodeChecked = value; }
        }

        public TnTreeViewCheckBox()
        {
            InitializeComponent();
            base.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            base.CheckBoxes = true;
            _imgIndeterminate = imageList1.Images[2];
            //imageList1.Images.RemoveAt(2);
            base.StateImageList = imageList1;

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing && _graphics != null)
            {
                _graphics.Dispose();
                _graphics = null;
                if (components != null) components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            _graphics = this.CreateGraphics();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (_graphics != null)
            {
                _graphics.Dispose();
                _graphics = this.CreateGraphics();
            }
        }

        protected override void OnBeforeCheck(System.Windows.Forms.TreeViewCancelEventArgs e)
        {
            if (_skipCheckEvents) return;

            if ((e.Node.StateImageIndex == 0) == e.Node.Checked) return;
            /* suppress redundant 
                BeforeCheck-event, if an already checked node programmatically is set to checked */

            base.OnBeforeCheck(e);
        }

        #region Article-Code

        protected override void OnAfterCheck(TreeViewEventArgs e)
        {
            /* Logic: All children of an (un)checked Node inherit its Checkstate
             * Parents recompute their state: if all children of a parent have same state, that one 
             * will be taken over as parents state - otherwise take Indeterminate 
             */
            if (_skipCheckEvents) return;/* changing any Treenodes .Checked-Property will raise 
                                           another Before- and After-Check. Skip'em */
            _skipCheckEvents = true;
            try
            {
                TreeNode nd = e.Node;
                /* uninitialized Nodes have StateImageIndex -1, so I associate StateImageIndex as follows:
                 * -1: Unchecked
                 *  0: Checked
                 *  1: Indeterminate
                 *  That corresponds to the System.Windows.Forms.Checkstate - enumeration, but 1 less.
                 *  Furthermore I ordered the images in that manner
                 */
                int state = nd.StateImageIndex == 0 ? -1 : 0;      /* this state is already toggled.
                Note: -1 (Unchecked) and 1 (Indeterminate) both toggle to 0, that means: Checked */
                if ((state == 0) != nd.Checked) return;       //suppress redundant AfterCheck-event
                InheritCheckstate(nd, state);         // inherit Checkstate to children
                // Parents recompute their state
                nd = nd.Parent;
                while (nd != null)
                {
                    // At Indeterminate (==1) skip the children-query - every parent becomes Indeterminate
                    if (state != 1)
                    {
                        foreach (TreeNode ndChild in nd.Nodes)
                        {
                            if (ndChild.StateImageIndex != state)
                            {
                                state = 1;
                                break;
                            }
                        }
                    }
                    AssignState(nd, state);
                    nd = nd.Parent;
                }
                base.OnAfterCheck(e);
            }
            finally { _skipCheckEvents = false; }
        }

        private void AssignState(TreeNode nd, int state)
        {
            bool ck = state == 0;
            bool stateInvalid = nd.StateImageIndex != state;
            if (stateInvalid) nd.StateImageIndex = state;
            if (nd.Checked != ck)
            {
                nd.Checked = ck;            // changing .Checked-Property raises Invalidating internally
            }
            else if (stateInvalid)
            {
                // in general: the less and small the invalidated area, the less flickering
                // so avoid calling Invalidate() if possible, and only call, if really needed.
                this.Invalidate(GetCheckRect(nd));
            }
        }

        private void InheritCheckstate(TreeNode nd, int state)
        {
            AssignState(nd, state);
            foreach (TreeNode ndChild in nd.Nodes)
            {
                InheritCheckstate(ndChild, state);
            }
        }

        public System.Windows.Forms.CheckState GetState(TreeNode nd)
        {
            // compute the System.Windows.Forms.CheckState from a StateImageIndex is not that complicated
            return (CheckState)nd.StateImageIndex + 1;
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            // here nothing is drawn. Only collect Indeterminated Nodes, to draw them later (in WndProc())
            // because drawing Treenodes properly (Text, Icon(s) Focus, Selection...) is very complicated
            if (e.Node.StateImageIndex == 1) _indeterminateds.Add(e.Node);
            e.DrawDefault = true;
            base.OnDrawNode(e);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_Paint = 15;
            base.WndProc(ref m);
            if (m.Msg == WM_Paint)
            {
                // at that point built-in drawing is completed - and I paint over the Indeterminate-Checkboxes
                foreach (TreeNode nd in _indeterminateds)
                {
                    _graphics.DrawImage(_imgIndeterminate, GetCheckRect(nd).Location);
                }
                _indeterminateds.Clear();
            }
        }

        #endregion Article-Code

        private Rectangle GetCheckRect(TreeNode nd)
        {
            var pt = nd.Bounds.Location;
            pt.X -= this.ImageList == null ? 16 : 35;
            return new Rectangle(pt.X, pt.Y, 16, 16);
        }

        // since ThreeStateTreeview comes along with its own StateImageList, prevent assigning the StateImageList- Property from outside. Shadow and re-attribute original property
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ImageList StateImageList
        {
            get { return base.StateImageList; }
            set { }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TnTreeViewCheckBox));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "UnChecked.ico");
            this.imageList1.Images.SetKeyName(1, "Checked.ico");
            this.imageList1.Images.SetKeyName(2, "Indeterminated.ico");
            // 
            // ThreeStateTreeview
            // 
            this.LineColor = System.Drawing.Color.Black;
            this.ResumeLayout(false);

        }
        public void UncheckedAll()
        {
            TreeViewEventArgs e;
            foreach (TreeNode node in this.Nodes)
            {
                node.Checked = false;

                //MessageBox.Show(GetState(node).ToString());
            }


        }

        private List<object> walkOnNodes(TreeNodeCollection nodes)
        {

            foreach (TreeNode node in nodes)
            {
                if (node.FirstNode == null)
                {//ko co con
                    if (node.Checked && node.Tag != null)
                    {
                        _listNodeChecked.Add(node.Tag);
                    }

                }
                else
                {
                    walkOnNodes(node.Nodes);
                }
            }
            return _listNodeChecked;
        }

        private void walkOnTreeGetChecked()
        {
            _listNodeChecked.Clear();
            _listNodeChecked= walkOnNodes(this.Nodes);
        }

        public void CheckAll()
        {
            foreach (TreeNode node in this.Nodes)
            {
                node.Checked = true;

                //MessageBox.Show(GetState(node).ToString());
            }
        }
    }
}
