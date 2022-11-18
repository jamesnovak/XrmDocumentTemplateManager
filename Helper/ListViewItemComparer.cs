using System;
using System.Collections;
using System.Windows.Forms;

namespace Futurez.Xrm.Tools
{
    /// <summary>
    /// ListView Item Compare taken from XrmToolbox:
    /// https://github.com/MscrmTools/XrmToolBox/blob/master/Plugins/MsCrmTools.MetadataDocumentGenerator/Helper/ListViewItemComparer.cs
    /// </summary>
    internal class ListViewItemComparer : IComparer
    {
        private int col;

        private SortOrder innerOrder;

        public ListViewItemComparer()
        {
            this.col = 0;
            this.innerOrder = SortOrder.Ascending;
        }

        public ListViewItemComparer(int column, SortOrder order)
        {
            this.col = column;
            this.innerOrder = order;
        }

        public int Column
        {
            get { return col; }
            set { col = value; }
        }

        public SortOrder Order
        {
            get { return innerOrder; }
            set { innerOrder = value; }
        }

        public int Compare(object x, object y)
        {
            return this.Compare((ListViewItem)x, (ListViewItem)y);
        }

        public int Compare(ListViewItem x, ListViewItem y)
        {
            if (DateTime.TryParse(x.SubItems[this.col].Text, out DateTime dtx))
            {
                if (DateTime.TryParse(y.SubItems[this.col].Text, out DateTime dty))
                {
                    if (this.innerOrder == SortOrder.Ascending)
                    {
                        return dtx > dty ? 1 : -1;
                    }
                    return dtx < dty ? 1 : -1;
                }
            }

            if (this.innerOrder == SortOrder.Ascending)
            {
                return string.Compare(x.SubItems[this.col].Text, y.SubItems[this.col].Text);
            }
            return string.Compare(y.SubItems[this.col].Text, x.SubItems[this.col].Text);
        }
    }
}