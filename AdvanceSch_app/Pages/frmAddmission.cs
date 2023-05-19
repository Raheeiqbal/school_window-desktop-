using AdvanceSch_app;
using CustomControls.RJControls;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Ink;
using System.Xml.Resolvers;

namespace school_app.Pages
{
    public partial class frmAddmission : Form

    {
        RJButton rJButton = new RJButton();
        private Color borderColor = Color.Gray;
        public frmAddmission()
        {
            InitializeComponent();
            LoadTheme();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //string value = te.Text;
        }

        private void rjTextBox1__TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFtname__TextChanged(object sender, EventArgs e)
        {

        }
        
        private void LoadTheme()
        {
            //------textbox------
            var themeColor = WinTheme.GetAccentColor();//Windows Accent Color
            var lightColor = ControlPaint.Light(themeColor);
            var darkColor = ControlPaint.Dark(themeColor);
            var extralight = ControlPaint.LightLight(themeColor);

            //---textbox border color
            foreach (RJTextBox rJTextBox in this.Controls.OfType<RJTextBox>())
            {
                rJTextBox.BorderFocusColor = extralight;
                rJTextBox.BorderColor = darkColor;
            }


            foreach (Button button in this.Controls.OfType<Button>())
            {
                button.BackColor = themeColor;
            }
        }
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; LoadTheme(); }
        }
        public TextBox borderC
        {
            get { return borderC; }
            set { borderC = value; LoadTheme(); }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmAddmission_Load(object sender, EventArgs e)
        {
           
        }
    }
}
