using System;
using System.Collections;
using System.Windows.Forms;

namespace Privatezilla
{
    /* Modified ListView sort example from https://support.microsoft.com/en-us/kb/319401
       which will not only sort ascending but both ways */

    public class ListViewItemComparer : IComparer
    {
        private readonly int col;
        private readonly bool bAsc = false;

        public ListViewItemComparer()
        {
            col = 0;
        }

        public ListViewItemComparer(int column, bool b)
        {
            col = column;
            bAsc = b;
        }

        public int Compare(object x, object y)
        {
            if (bAsc)
            {
                return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
               // bAsc = false;
            }
            else
            {
                return String.Compare(((ListViewItem)y).SubItems[col].Text, ((ListViewItem)x).SubItems[col].Text);
               //  bAsc = true;
            }
        }
    }
}