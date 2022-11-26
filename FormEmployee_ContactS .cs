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
    public partial class FormEmployee_ContactS : Office2007Form
    {
        public FormEmployee_ContactS()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("data source=(local);initial catalog=PROJECTMUSEUM;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        void Display()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT * FROM Employee_ContactS";
            adp.Fill(ds, "Employee_ContactS");
            dataGridEmployee_ContactS.DataSource = ds;
            dataGridEmployee_ContactS.DataMember = "Employee_ContactS";
            //*********************************
            dataGridEmployee_ContactS.Columns[0].Width = 150;
            dataGridEmployee_ContactS.Columns[1].Width = 150;
        }
        private void FormEmployee_ContactS_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textPersonalCodeE.Text == "")
            {
                MessageBox.Show("Please Enter The PersonalCode.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO [Employee_ContactS] (Employee_Contact, Personal_Code)values(@Employee_Contact, @Personal_Code)";
            cmd.Parameters.AddWithValue("@Employee_Contact", textemployeecontact.Text);
            cmd.Parameters.AddWithValue("@Personal_Code", textPersonalCodeE.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("Save Done");
            textemployeecontact.Text = textPersonalCodeE.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (textBoxEditpesonalCodeE.Text == "")
            {
                MessageBox.Show("Please Enter The PersonalCode.");
                return;
            }
            if (textBoxEditEmployee_ContactS.Text == "")
            {
                MessageBox.Show("Please Enter The PersonalCode.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Employee_ContactS SET Employee_Contact='" + textBoxEditEmployee_ContactS.Text + "' , Personal_Code=" + textBoxEditpesonalCodeE.Text + " WHERE Employee_Contact='" + textemployeecontact.Text + "' and Personal_Code=" + textPersonalCodeE.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Edit Done");
            Display();
            textemployeecontact.Text = textPersonalCodeE.Text = textBoxEditEmployee_ContactS.Text = textBoxEditpesonalCodeE.Text = "";
        }

        private void dataGridEmployee_ContactS_MouseUp(object sender, MouseEventArgs e)
        {
            textemployeecontact.Text = dataGridEmployee_ContactS.CurrentRow.Cells[0].Value.ToString();
            textPersonalCodeE.Text = dataGridEmployee_ContactS.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do You Want to Delete?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                var Employee_Contact = dataGridEmployee_ContactS.CurrentRow.Cells[0].Value;
                var Personal_Code = dataGridEmployee_ContactS.CurrentRow.Cells[1].Value;
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM Employee_ContactS WHERE Employee_Contact=@Employee_Contact and  Personal_Code=@Personal_Code";
                cmd.Parameters.AddWithValue("@Employee_Contact", Employee_Contact);
                cmd.Parameters.AddWithValue("@Personal_Code", Personal_Code);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("Delet Done");
                textemployeecontact.Text = textPersonalCodeE.Text = "";
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT *  FROM Employee_ContactS WHERE Personal_Code like '%' + @Personal_Code + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@Personal_Code", textBoxSearch.Text + "%");
            adp.Fill(ds, "Employee_ContactS");
            dataGridEmployee_ContactS.DataSource = ds;
            dataGridEmployee_ContactS.DataMember = "Employee_ContactS";

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
             Application.Exit();
        }

        private void textPersonalCodeE_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
