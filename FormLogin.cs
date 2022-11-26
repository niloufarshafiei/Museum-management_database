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
namespace ProjectMuseum
{
    public partial class FormLogin : Office2007Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            string username = textBoxUserName.Text;
            string password = textBoxPassword.Text;
            if (username == "" || password == "")
            {
                MessageBox.Show("Please Enter User Information.");
            }
            else
            {
                if (username == "NiloufarShafiei" && password == "9813200044" || username == "HanieTaheri" && password == "9813200047")
                {
                    this.Hide();
                    FormMenu Muno = new FormMenu(textBoxUserName.Text);
                    Muno.Show();                   
                }
                else
                {
                    MessageBox.Show("The User Information Entrered is Incorrect!");
                    textBoxUserName.Text = textBoxPassword.Text = "";
                }
            }
           
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
          
        }
    }
}
