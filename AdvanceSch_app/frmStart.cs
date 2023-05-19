using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_app
{
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i <= 1000; i++)
            {
                if(i == 1000)
                {
                    frmmain fm = new frmmain();
                    this.Hide();
                    fm.Show();
                    timer1.Stop();
                }
            }
        }

        private void frmStart_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
