using Manina.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoIdentifier {
    public partial class ColumnsInfos:Form {

        #region Vars
        public ImageListView ILV_photos;
        #endregion

        #region Init

        public ColumnsInfos() {
            InitializeComponent();
        }
        #endregion

        #region Controls

        private void BT_close_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void CLB_infos_ItemCheck(object sender, ItemCheckEventArgs e) {
            ImageListView.ImageListViewColumnHeader column = ILV_photos.Columns[e.Index];
            column.Visible = (e.NewValue == CheckState.Checked);
        }

        private void ColumnsInfos_Load(object sender, EventArgs e) {
            foreach(ImageListView.ImageListViewColumnHeader column in ILV_photos.Columns) {
                CLB_infos.Items.Add(column.Text, column.Visible);
            }
        }
        #endregion
    }
}
