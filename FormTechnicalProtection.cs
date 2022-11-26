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
    public partial class FormTechnicalProtection : Office2007Form
    {
        public FormTechnicalProtection()
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
            adp.SelectCommand.CommandText = "SELECT * FROM Technical_Protection ";
            adp.Fill(ds, "Technical_Protection ");
            dataGridTecnicalProtection.DataSource = ds;
            dataGridTecnicalProtection.DataMember = "Technical_Protection ";
            //*********************************
            dataGridTecnicalProtection.Columns[0].Width = 150;
            dataGridTecnicalProtection.Columns[1].Width = 150;
        }
        private void FormTechnicalProtection_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textPersonalCodeTp.Text == "")
            {
                MessageBox.Show("Please Enter The PersonalCode.");
                return;
            }
            if (textArtCodeTp.Text == "")
            {
                MessageBox.Show("Please Enter The ArtCode.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO [Technical_Protection ] (WorkOfArt_Code, Personal_Code)values(@WorkOfArt_Code, @Personal_Code)";
            cmd.Parameters.AddWithValue("@WorkOfArt_Code", textArtCodeTp.Text);
            cmd.Parameters.AddWithValue("@Personal_Code", textPersonalCodeTp.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("Save Done");
            textArtCodeTp.Text = textPersonalCodeTp.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (textpersonalcodeTpEdit.Text == "")
            {
                MessageBox.Show("Please Enter The PersonalCode.");
                return;
            }
            if (textartcodeEdit.Text == "")
            {
                MessageBox.Show("Please Enter The ArtCode.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Technical_Protection  SET WorkOfArt_Code='" + textartcodeEdit.Text + "' , Personal_Code=" + textpersonalcodeTpEdit.Text + " WHERE WorkOfArt_Code='" + textArtCodeTp.Text + "' and Personal_Code=" + textPersonalCodeTp.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Edit Done");
            Display();
            textArtCodeTp.Text = textPersonalCodeTp.Text = textpersonalcodeTpEdit.Text= textartcodeEdit.Text= "";
        }

        private void dataGridTecnicalProtection_MouseUp(object sender, MouseEventArgs e)
        {
            textArtCodeTp.Text = dataGridTecnicalProtection.CurrentRow.Cells[0].Value.ToString();
            textPersonalCodeTp.Text = dataGridTecnicalProtection.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            var WorkOfArt_Code = dataGridTecnicalProtection.CurrentRow.Cells[0].Value;
            var Personal_Code = dataGridTecnicalProtection.CurrentRow.Cells[1].Value;
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.CommandText = "DELETE FROM Technical_Protection WHERE WorkOfArt_Code=@WorkOfArt_Code and  Personal_Code=@Personal_Code";
            cmd.Parameters.AddWithValue("@WorkOfArt_Code", WorkOfArt_Code);
            cmd.Parameters.AddWithValue("@Personal_Code", Personal_Code);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("Delet Done");
            textArtCodeTp.Text = textPersonalCodeTp.Text =  "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT * FROM Technical_Protection WHERE Personal_Code like '%' + @Personal_Code + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@Personal_Code", textBoxSearch.Text + "%");
            adp.Fill(ds, "Technical_Protection");
            dataGridTecnicalProtection.DataSource = ds;
            dataGridTecnicalProtection.DataMember = "Technical_Protection";
        }
    }
}
