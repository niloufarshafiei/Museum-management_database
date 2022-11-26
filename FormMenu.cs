using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.SqlClient;
namespace ProjectMuseum
{
    public partial class FormMenu : Office2007Form
    {
        Timer timer = new Timer();
        public FormMenu()
        {
            InitializeComponent();
            label2.Text = DateTime.Now.ToString("dd/MM/yyyy");
            label1.Text = DateTime.Now.ToString("HH:mm:ss tt");
            timer.Interval = 800;
            timer.Start();
        }
        public FormMenu( string name)
        {
            InitializeComponent();
            label9.Text = name;
        }
        private void FormMenu_Load(object sender, EventArgs e)
        {
            
            label1.Text = DateTime.Now.ToString("HH:mm:ss tt");
           
        }

        private void metroTileItem1_Click(object sender, EventArgs e)
        {
            FormMuseum frm = new FormMuseum();
            frm.ShowDialog();

        }

        private void metroTileItem2_Click(object sender, EventArgs e)
        {
            FormMuseum_Contacts frm = new FormMuseum_Contacts();
            frm.ShowDialog();
        }

        private void metroTileItem3_Click(object sender, EventArgs e)
        {
            FormVisitor frm = new FormVisitor();
            frm.ShowDialog();
        }

        private void metroTileItem4_Click(object sender, EventArgs e)
        {

            FormTicket frm = new FormTicket();
            frm.ShowDialog();
        }

        private void metroTileItem21_Click(object sender, EventArgs e)
        {
            FormEmployee frm = new FormEmployee();
            frm.ShowDialog();
        }

        private void metroTileItem23_Click(object sender, EventArgs e)
        {
            FormEmployee_ContactS frm = new FormEmployee_ContactS();
            frm.ShowDialog();
        }

        private void metroTileItem5_Click(object sender, EventArgs e)
        {
            FormRelatives frm = new FormRelatives();
            frm.ShowDialog();
        }

        private void metroTileItem7_Click(object sender, EventArgs e)
        {
            FormGuide frm = new FormGuide();
            frm.ShowDialog();
        }

        private void metroTileItem14_Click(object sender, EventArgs e)
        {
            FormExpert frm = new FormExpert();
            frm.ShowDialog();
        }

        private void metroTileItem9_Click(object sender, EventArgs e)
        {
            FormGuard frm = new FormGuard();
            frm.ShowDialog();
        }

        private void metroTileItem13_Click(object sender, EventArgs e)
        {
            FormTicketseller frm = new FormTicketseller();
            frm.ShowDialog();
        }

        private void metroTileItem10_Click(object sender, EventArgs e)
        {
            FormManagingdirector frm = new FormManagingdirector();
            frm.ShowDialog();
        }

        private void metroTileItem8_Click(object sender, EventArgs e)
        {
            FormTips frm = new FormTips();
            frm.ShowDialog();
        }

        private void metroTileItem15_Click(object sender, EventArgs e)
        {

            FormTechnicalProtection frm = new FormTechnicalProtection();
            frm.ShowDialog();
        }

        private void metroTileItem11_Click(object sender, EventArgs e)
        {
            FormArt frm = new FormArt();
            frm.ShowDialog();
        }

        private void metroTileItem12_Click(object sender, EventArgs e)
        {
            FormSculpture frm = new FormSculpture();
            frm.ShowDialog();
        }

        private void metroTileItem16_Click(object sender, EventArgs e)
        {
            FormPainting frm = new FormPainting();
            frm.ShowDialog();
        }

        private void metroTileItem17_Click(object sender, EventArgs e)
        {
            FormLineboard frm = new FormLineboard();
            frm.ShowDialog();
        }

        private void metroTileItem18_Click(object sender, EventArgs e)
        {
            FormOther frm = new FormOther();
            frm.ShowDialog();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
