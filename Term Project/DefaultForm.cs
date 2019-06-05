using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Term_Project
{
    public partial class DefaultForm : Form
    {
        public DefaultForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Wave Editor";
        }

        private void DefaultForm_Load(object sender, EventArgs e)
        {

        }
        
       
        /** Creates a new Display Form.*/
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f1 = new DisplayForm();
            f1.Show(); // Shows DisplayForm
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
