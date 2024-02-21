using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueryPal
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = "QueryPal v." + Application.ProductVersion;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmQueryPal frmQueryPal = new frmQueryPal();
            frmQueryPal.TopLevel = true;
            frmQueryPal.ShowDialog();

        }
    }
}
