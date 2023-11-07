using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Futurez.Xrm.Tools
{
    public partial class RelationshipSelectionDialog : Form
    {
        public RelationshipSelectionDialog(IOrganizationService service, EntityMetadata emd, List<string> selectedRelationships)
        {
            InitializeComponent();

            lvOneToMany.Items.AddRange(emd.OneToManyRelationships.Select(r => new ListViewItem(r.SchemaName) { SubItems = { new ListViewItem.ListViewSubItem { Text = r.ReferencingEntity } }, Checked = selectedRelationships.Contains(r.SchemaName) }).ToArray());
            lvManyToOne.Items.AddRange(emd.ManyToOneRelationships.Select(r => new ListViewItem(r.SchemaName) { SubItems = { new ListViewItem.ListViewSubItem { Text = r.ReferencedEntity } }, Checked = selectedRelationships.Contains(r.SchemaName) }).ToArray());
            lvManyToMany.Items.AddRange(emd.ManyToManyRelationships.Select(r => new ListViewItem(r.SchemaName) { SubItems = { new ListViewItem.ListViewSubItem { Text = r.Entity1LogicalName == emd.LogicalName ? r.Entity2LogicalName : r.Entity1LogicalName } }, Checked = selectedRelationships.Contains(r.SchemaName) }).ToArray());
        }

        public List<string> SelectedRelationships
        {
            get
            {
                return (lvOneToMany.CheckedItems.Cast<ListViewItem>().Select(i => i.Text)
                    .Union(lvManyToOne.CheckedItems.Cast<ListViewItem>().Select(i => i.Text))
                    .Union(lvManyToMany.CheckedItems.Cast<ListViewItem>().Select(i => i.Text))).ToList();
            }
        }

        private void lvOneToMany_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var lv = (ListView)sender;

            if (lv.ListViewItemSorter is ListViewItemComparer lvic)
            {
                if (lvic.Column != e.Column)
                {
                    lvic.Column = e.Column;
                    lvic.Order = SortOrder.Ascending;
                }
                else
                {
                    lvic.Order = lvic.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
                }
            }
            else
            {
                lv.ListViewItemSorter = new ListViewItemComparer(e.Column, SortOrder.Ascending);
            }

            lv.Sort();
        }
    }
}