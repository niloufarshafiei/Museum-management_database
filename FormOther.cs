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
    public partial class FormOther : Office2007Form
    {
        public FormOther()
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
            adp.SelectCommand.CommandText = "SELECT * FROM Other";
            adp.Fill(ds, "Other");
            dataGridother.DataSource = ds;
            dataGridother.DataMember = "Other";
            //*********************************
            dataGridother.Columns[0].Width = 150;
            dataGridother.Columns[1].Width = 150;
        }
        private void FormOther_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textartcodeO.Text == "")
            {
                MessageBox.Show("Please Enter the ArtCode.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO [Other] (WorkOfArt_Code, Type_Other)values(@WorkOfArt_Code, @Type_Other)";
            cmd.Parameters.AddWithValue("@WorkOfArt_Code", textartcodeO.Text);
            cmd.Parameters.AddWithValue("@Type_Other", texttypeO.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("Save Done");
            textartcodeO.Text = texttypeO.Text = "";
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do You Want to Delete?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM [Other] WHERE WorkOfArt_Code=@WorkOfArt_Code";
                cmd.Parameters.AddWithValue("@WorkOfArt_Code", dataGridother.CurrentRow.Cells["WorkOfArt_Code"].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("Delet Done");
                textartcodeO.Text = texttypeO.Text = "";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (textartcodeO.Text == "")
            {
                MessageBox.Show("Please Enter the ArtCode.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Other SET Type_Other='" + texttypeO.Text + "' WHERE WorkOfArt_Code=" + textartcodeO.Text;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Edit Done");
            Display();
            textartcodeO.Text = texttypeO.Text = "";
        }

        private void dataGridother_MouseUp(object sender, MouseEventArgs e)
        {
            textartcodeO.Text = dataGridother.CurrentRow.Cells[0].Value.ToString();
            texttypeO.Text = dataGridother.CurrentRow.Cells[1].Value.ToString();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT * FROM Other WHERE WorkOfArt_Code like '%' + @WorkOfArt_Code + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@WorkOfArt_Code", textBoxSearch.Text + "%");
            adp.Fill(ds, "Work_Of_Art");
            dataGridother.DataSource = ds;
            dataGridother.DataMember = "Work_Of_Art";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
