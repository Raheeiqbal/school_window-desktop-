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
    public partial class Startapp : Form
    {
        private int tick;
        public Startapp()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tick++;
            this.Text = tick.ToString();
            if (tick == 10)
            {
                frmmain show = new frmmain();
                show.Show();
                this.Visible = false;
                timer1.Stop();
            }
        }
    }
}
