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
        private readonly int col;

        private readonly SortOrder innerOrder;

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

        public int Compare(object x, object y)
        {
            return this.Compare((ListViewItem)x, (ListViewItem)y);
        }

        public int Compare(ListViewItem x, ListViewItem y)
        {
            if (this.innerOrder == SortOrder.Ascending)
            {
                return string.Compare(x.SubItems[this.col].Text, y.SubItems[this.col].Text);
            }
            return string.Compare(y.SubItems[this.col].Text, x.SubItems[this.col].Text);
        }
    }
}
