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
    public partial class FormGuide : Office2007Form
    {
        public FormGuide()
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
            adp.SelectCommand.CommandText = "SELECT * FROM Guide ";
            adp.Fill(ds, "Guide ");
            dataGridGuide.DataSource = ds;
            dataGridGuide.DataMember = "Guide ";
            //*********************************
            dataGridGuide.Columns[0].Width = 150;
            dataGridGuide.Columns[1].Width = 150;
            dataGridGuide.Columns[2].Width = 150;
            dataGridGuide.Columns[3].Width = 150;
            dataGridGuide.Columns[4].Width = 150;          
        }

        private void FormGuid_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textpersonalcodeG.Text == "")
            {
                MessageBox.Show("Please Enter The PerconalCode.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO [Guide ] (Personal_Code, Education, Working_Hours_Guide, Delaytime_Guide)values(@Personal_Code,@Education,@Working_Hours_Guide,@Delaytime_Guide)";
            cmd.Parameters.AddWithValue("@Personal_Code", textpersonalcodeG.Text);
            cmd.Parameters.AddWithValue("@Education", comboeducation.Text);
            cmd.Parameters.AddWithValue("@Working_Hours_Guide", textworkinghourseG.Text);
            cmd.Parameters.AddWithValue("@Delaytime_Guide", textdelaytime.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("Save Done");
            textpersonalcodeG.Text = comboeducation.Text = textworkinghourseG.Text = textdelaytime.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (textpersonalcodeG.Text == "")
            {
                MessageBox.Show("Please Enter The PerconalCode.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Guide SET Education='" + comboeducation.Text +
                "',Working_Hours_Guide='" + textworkinghourseG.Text + "',Delaytime_Guide='" + textdelaytime.Text +
               "' WHERE Personal_Code=" + textpersonalcodeG.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Edit Done");
            Display();
            textpersonalcodeG.Text = comboeducation.Text = textworkinghourseG.Text = textdelaytime.Text =textsalary.Text= "";
        }

        private void dataGridGuid_MouseUp(object sender, MouseEventArgs e)
        {
            textpersonalcodeG.Text = dataGridGuide.CurrentRow.Cells[0].Value.ToString();
            comboeducation.Text = dataGridGuide.CurrentRow.Cells[1].Value.ToString();
            textsalary.Text = dataGridGuide.CurrentRow.Cells[2].Value.ToString();
            textworkinghourseG.Text = dataGridGuide.CurrentRow.Cells[3].Value.ToString();
            textdelaytime.Text = dataGridGuide.CurrentRow.Cells[4].Value.ToString();
           
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do You Want to Delete?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM [Guide] WHERE Personal_Code=@Personal_Code";
                cmd.Parameters.AddWithValue("@Personal_Code", dataGridGuide.CurrentRow.Cells["Personal_Code"].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("Delet Done");
                textpersonalcodeG.Text = comboeducation.Text = textworkinghourseG.Text = textdelaytime.Text = textsalary.Text = "";
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT * FROM Guide WHERE Personal_Code like '%' + @Personal_Code + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@Personal_Code", textBoxSearch.Text + "%");
            adp.Fill(ds, "Guide");
            dataGridGuide.DataSource = ds;
            dataGridGuide.DataMember = "Guide";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

     
    }
}
