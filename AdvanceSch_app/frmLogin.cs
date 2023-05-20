using AdvanceSch_app;
using CustomControls.RJControls;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_app
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            LoadTheme();
            txt_usr.Select();
        }
        public void LoadTheme()
        {
            var themeColor = WinTheme.GetAccentColor();//Windows Accent Color
            var lightColor = ControlPaint.Light(themeColor);
            var darkColor = ControlPaint.Dark(themeColor);
            //var extradarkColor = ControlPaint.DarkDark(themeColor);
            //---panel color
            pnl_side.BackColor = darkColor;
            //----button color
            btn_close.IconColor = darkColor;

            foreach (Button button in this.Controls.OfType<Button>())
            {
                button.BackColor = themeColor;
            }
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btn_Login_Click(object sender, EventArgs e)
        {
            string user = "ADMIN";
            string pass = "RAH";
            if (txt_usr.Texts == "" && txt_psw.Texts == "")
            {
                lbl_err_usr.Visible = true;
                lbl_err_pass.Visible = true;
                lbl_error.Text = "Input User ID And Password";
            }
            else if (txt_usr.Texts == "")
            {
                lbl_error.Text = "Input User ID";
            }
            else if (txt_psw.Texts == "")
            {
                lbl_error.Text = "Input Password";
            }
            else if (txt_usr.Texts.Count() > 10)
            {
                lbl_error.Text = "Enter only 10 character in User ID";
            }
            else if (txt_psw.Texts.Count() > 5)
            {
                lbl_error.Text = "Enter only 5 character in Password";
            }
            else
            {
                if (txt_usr.Texts.ToUpper() == user && txt_psw.Texts.ToUpper() == pass)
                {
                    frmmain fm = new frmmain();
                    this.Hide();
                    fm.Show();
                }
                else
                {
                    lbl_error.Text = "Incorrect User ID And Password";
                    //txt_usr.Texts = string.Empty;
                    //txt_psw.Texts = string.Empty;
                }

            }
        }
        private void btn_img_lock_MouseDown(object sender, MouseEventArgs e)
        {
            txt_psw.PasswordChar = false;
        }
        private void btn_img_lock_MouseUp(object sender, MouseEventArgs e)
        {
            txt_psw.PasswordChar = true;
        }
        private void txt_usr__TextChanged(object sender, EventArgs e)
        {
            if (txt_usr.Texts == "")
            {
                lbl_err_usr.Visible = true;
                lbl_error.Text = "Please fill the Form !";
            }
            else
            {
                lbl_err_usr.Visible = false;
                lbl_err_usr.Text = string.Empty;
            }
        }
        private void txt_psw__TextChanged(object sender, EventArgs e)
        {
            if (txt_psw.Texts == "")
            {
                lbl_err_pass.Visible = true;
                lbl_error.Text = "Please fill the Form !";
            }
            else
            {
                lbl_err_pass.Visible = false;
                lbl_err_pass.Text = string.Empty;
            }
        }
        private void txt_usr_Click(object sender, EventArgs e)
        {
            if (txt_psw.Texts == "")
            {
                lbl_err_pass.Visible = true;
                lbl_error.Text = "Please fill the Foam !";
            }
            else
            {
                lbl_err_usr.Visible = false;
            }
        }
        private void txt_psw_Click(object sender, EventArgs e)
        {
            if (txt_usr.Texts == "")
            {
                lbl_err_usr.Visible = true;
                lbl_error.Text = "Please fill the Foam !";
            }
            else
            {
                lbl_err_pass.Visible = false;
            }
        }
    }
}
