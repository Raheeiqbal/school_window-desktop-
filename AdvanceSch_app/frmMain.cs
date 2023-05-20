using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AdvanceSch_app;
using FontAwesome.Sharp;
using Microsoft.Win32;
using Color = System.Drawing.Color;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using school_app.Pages;

namespace school_app
{
    public partial class frmmain : Form
    {
        private UserPreferenceChangedEventHandler UserPreferenceChanged;
        //Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        public frmmain()
        {
            InitializeComponent();
            LoadTheme();
            UserPreferenceChanged = new UserPreferenceChangedEventHandler(SystemEvents_UserPreferenceChanged);
            SystemEvents.UserPreferenceChanged += UserPreferenceChanged;
            this.Disposed += new EventHandler(Form_Disposed);
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            //Form
            this.Text = string.Empty;
            //this.ControlBox = false;
            //this.DoubleBuffered = true;
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        //Structs
        //private struct RGBColors
        //{
        //    public static Color color1 = Color.FromArgb(172, 126, 241);
        //    public static Color color2 = Color.FromArgb(249, 118, 176);
        //    public static Color color3 = Color.FromArgb(253, 138, 114);
        //    public static Color color4 = Color.FromArgb(95, 77, 221);
        //    public static Color color5 = Color.FromArgb(249, 88, 155);
        //    public static Color color6 = Color.FromArgb(24, 161, 251);
        //}
        //Methods
        private void ActivateButton(object senderBtn)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                //currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                //currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                //leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Current Child Form Icon
                iconeHome.IconChar = currentBtn.IconChar;
                //iconeHome.IconColor = color;
                lblDash.Text = currentBtn.Text;
                LoadTheme();
            }

        }
        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //--End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblDash.Text = childForm.Text;
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            if (e.Category == UserPreferenceCategory.General || e.Category == UserPreferenceCategory.VisualStyle)
            {
                LoadTheme();
            }
        }
        private void Form_Disposed(object sender, EventArgs e)
        {
            SystemEvents.UserPreferenceChanged -= UserPreferenceChanged;
        }
        public void LoadTheme()
        {
            var themeColor = WinTheme.GetAccentColor();//Windows Accent Color
            var lightColor = ControlPaint.Light(themeColor);
            var darkColor = ControlPaint.Dark(themeColor);
            //var extradarkColor = ControlPaint.DarkDark(themeColor);



            //---panel color
            panel1.BackColor = lightColor;
            panelMenu.BackColor = darkColor;
            panellogo.BackColor = darkColor;
            panelShadow.BackColor = darkColor;

            //---Dashboard icon color
            iconeHome.IconColor = darkColor;
            lblDash.ForeColor = darkColor;

            //---controlBox button
            iconbtnCLose.BackColor = lightColor;
            btnMinimize.BackColor = lightColor;
            btnMaximize.BackColor = lightColor;


            //---sidebar icone color
            btnSidebar1.IconColor = lightColor;
            btnSidebar2.IconColor = lightColor;
            iconButton3.IconColor = lightColor;
            iconButton4.IconColor = lightColor;
            iconButton5.IconColor = lightColor;


            //---sidebar panel color
            btnSidebar1.BackColor = darkColor;
            btnSidebar2.BackColor = darkColor;
            iconButton3.BackColor = darkColor;
            iconButton4.BackColor = darkColor;
            iconButton5.BackColor = darkColor;

            foreach (Button button in this.Controls.OfType<Button>())
            {
                button.BackColor = themeColor;
            }
        }

        private void frmmain_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnOption1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnOption2(object sender, EventArgs e)
        {
            ActivateButton(sender);

        }

        private void btnOption3(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnOption4(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconeHome.IconChar = IconChar.Dashboard;
            lblDash.Text = "Dashboard";
            LoadTheme();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            //currentChildForm.Close();
            //reset();
            frmmain frm = new frmmain();
            frm.Show();

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelContBox_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconbtnCLose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSidebar1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new frmAddmission());

        }

        private void btnSidebar2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new frmAddmissionDetails());
        }
    }
}
