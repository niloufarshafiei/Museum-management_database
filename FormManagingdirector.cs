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
    public partial class FormManagingdirector : Office2007Form
    {
        public FormManagingdirector()
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
            adp.SelectCommand.CommandText = "SELECT * FROM Managing_Director";
            adp.Fill(ds, "Managing_Director");
            dataGridManageDirector.DataSource = ds;
            dataGridManageDirector.DataMember = "Managing_Director";
            //*********************************
            dataGridManageDirector.Columns[0].Width = 150;
            dataGridManageDirector.Columns[1].Width = 150;
            dataGridManageDirector.Columns[2].Width = 150;
            dataGridManageDirector.Columns[3].Width = 150;
            dataGridManageDirector.Columns[4].Width = 150;
        }

        private void FormManagingdirector_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textpersonalcodeM.Text == "")
            {
                MessageBox.Show("Please Enter The PerconalCode.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO [Managing_Director] (Education, Personal_Code, Working_Hours_Managing_Director, Delaytime_Managing_Director)values(@Education, @Personal_Code, @Working_Hours_Managing_Director, @Delaytime_Managing_Director)";
            cmd.Parameters.AddWithValue("@Education", comboeducationM.Text);
            cmd.Parameters.AddWithValue("@Personal_Code", textpersonalcodeM.Text);
            cmd.Parameters.AddWithValue("@Working_Hours_Managing_Director", textworkinghourseM.Text);
            cmd.Parameters.AddWithValue("@Delaytime_Managing_Director", textdelaytimeM.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("Save Done");
            comboeducationM.Text = textpersonalcodeM.Text = textworkinghourseM.Text = textdelaytimeM.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (textpersonalcodeM.Text == "")
            {
                MessageBox.Show("Please Enter The PerconalCode.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Managing_Director SET Education='" + comboeducationM.Text +
                "',Working_Hours_Managing_Director='" + textworkinghourseM.Text + "',Delaytime_Managing_Director='" + textdelaytimeM.Text +
               "' WHERE Personal_Code=" + textpersonalcodeM.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Edit Done");
            Display();
            comboeducationM.Text = textpersonalcodeM.Text = textworkinghourseM.Text = textdelaytimeM.Text = "";
        }

        private void dataGridManageDirector_MouseUp(object sender, MouseEventArgs e)
        {
            textpersonalcodeM.Text = dataGridManageDirector.CurrentRow.Cells[0].Value.ToString();
            comboeducationM.Text = dataGridManageDirector.CurrentRow.Cells[1].Value.ToString();
            textsalaryM.Text = dataGridManageDirector.CurrentRow.Cells[2].Value.ToString();
            textworkinghourseM.Text = dataGridManageDirector.CurrentRow.Cells[3].Value.ToString();
            textdelaytimeM.Text = dataGridManageDirector.CurrentRow.Cells[4].Value.ToString();
            
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT * FROM Managing_Director WHERE Personal_Code like '%' + @Personal_Code + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@Personal_Code", textBoxSearch.Text + "%");
            adp.Fill(ds, "Managing_Director");
            dataGridManageDirector.DataSource = ds;
            dataGridManageDirector.DataMember = "Managing_Director";
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do You Want to Delete?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM [Managing_Director] WHERE Personal_Code=@Personal_Code";
                cmd.Parameters.AddWithValue("@Personal_Code", dataGridManageDirector.CurrentRow.Cells["Personal_Code"].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("Delet Done");
                comboeducationM.Text = textpersonalcodeM.Text = textworkinghourseM.Text = textdelaytimeM.Text = "";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
