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
    public partial class FormTips : Office2007Form
    {
        public FormTips()
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
            adp.SelectCommand.CommandText = "SELECT * FROM Tips";
            adp.Fill(ds, "Tips");
            dataGridTips.DataSource = ds;
            dataGridTips.DataMember = "Tips";
            //*********************************
            dataGridTips.Columns[0].Width = 150;
            dataGridTips.Columns[1].Width = 150;
        }
        private void FormTips_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textPersonalCodeT.Text == "")
            {
                MessageBox.Show("Please Enter The PersonalCode.");
                return;
            }
            if (textVisitorCodeT.Text == "")
            {
                MessageBox.Show("Please Enter The VisitorCode.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO [Tips] (Visitor_Code, Personal_Code)values(@Visitor_Code, @Personal_Code)";
            cmd.Parameters.AddWithValue("@Visitor_Code", textVisitorCodeT.Text);
            cmd.Parameters.AddWithValue("@Personal_Code", textPersonalCodeT.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("Save Done");
            textVisitorCodeT.Text = textPersonalCodeT.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (textpersonalcodeEdit.Text == "")
            {
                MessageBox.Show("Please Enter The PersonalCode.");
                return;
            }
            if (textvisitorcodeEdit.Text == "")
            {
                MessageBox.Show("Please Enter The VisitorCode.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Tips SET Visitor_Code='" + textvisitorcodeEdit.Text + "' , Personal_Code=" + textpersonalcodeEdit.Text + " WHERE Visitor_Code='" + textVisitorCodeT.Text + "' and Personal_Code=" + textPersonalCodeT.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Edit Done");
            Display();
            textVisitorCodeT.Text = textPersonalCodeT.Text = textvisitorcodeEdit.Text= textpersonalcodeEdit.Text= "";
        }

        private void dataGridTips_MouseUp(object sender, MouseEventArgs e)
        {
            textVisitorCodeT.Text = dataGridTips.CurrentRow.Cells[0].Value.ToString();
            textPersonalCodeT.Text = dataGridTips.CurrentRow.Cells[1].Value.ToString();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT * FROM Tips WHERE Personal_Code like '%' + @Personal_Code + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@Personal_Code", textBoxSearch.Text + "%");
            adp.Fill(ds, "Tips");
            dataGridTips.DataSource = ds;
            dataGridTips.DataMember = "Tips";
        }
        

        private void btnDelet_Click(object sender, EventArgs e)
        {
            var Visitor_Code = dataGridTips.CurrentRow.Cells[0].Value;
            var Personal_Code = dataGridTips.CurrentRow.Cells[1].Value;
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM Tips WHERE Visitor_Code=@Visitor_Code and  Personal_Code=@Personal_Code";
            cmd.Parameters.AddWithValue("@Visitor_Code", Visitor_Code);
            cmd.Parameters.AddWithValue("@Personal_Code", Personal_Code);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("Delet Done");
            textVisitorCodeT.Text = textPersonalCodeT.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
