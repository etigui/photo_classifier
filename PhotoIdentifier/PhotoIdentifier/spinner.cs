using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoIdentifier
{
    public partial class spinner : Form
    {
        public spinner()
        {
            InitializeComponent();
        }

        private void spinner_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < 100; i++) {
                progressBar1.Value += (int)0.9;
            }
            
        }
    }
}
