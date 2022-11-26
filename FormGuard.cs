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
    public partial class FormGuard : Office2007Form
    {
        public FormGuard()
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
            adp.SelectCommand.CommandText = "SELECT * FROM Guard";
            adp.Fill(ds, "Guard");
            dataGridGuard.DataSource = ds;
            dataGridGuard.DataMember = "Guard";
            //*********************************
            dataGridGuard.Columns[0].Width = 150;
            dataGridGuard.Columns[1].Width = 150;
            dataGridGuard.Columns[2].Width = 150;
            dataGridGuard.Columns[3].Width = 150;
            dataGridGuard.Columns[4].Width = 150;
            dataGridGuard.Columns[5].Width = 150;
            dataGridGuard.Columns[6].Width = 150;
        }
        private void FormGuard_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textpersonalcodeGr.Text == "")
            {
                MessageBox.Show("Please Enter The PerconalCode.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO [Guard] (Personal_Code, Room_Number, Work_Shift,  Working_Hours_Guard,	Overtime_Guard, Delaytime_Guard)" +
                "values(@Personal_Code, @Room_Number, @Work_Shift,  @Working_Hours_Guard,	@Overtime_Guard, @Delaytime_Guard)";
            cmd.Parameters.AddWithValue("@Personal_Code", textpersonalcodeGr.Text);
            cmd.Parameters.AddWithValue("@Room_Number", textroomnumberGr.Text);
            cmd.Parameters.AddWithValue("@Work_Shift", comboworkshiftGr.Text);
            cmd.Parameters.AddWithValue("@Working_Hours_Guard", textworkinghourseGr.Text);
            cmd.Parameters.AddWithValue("@Overtime_Guard", textovertimeGr.Text);
            cmd.Parameters.AddWithValue("@Delaytime_Guard", textdelaytimeGr.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("Save Done");
            textpersonalcodeGr.Text = comboworkshiftGr.Text = textroomnumberGr.Text = textworkinghourseGr.Text = textovertimeGr.Text = textdelaytimeGr.Text= "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (textpersonalcodeGr.Text == "")
            {
                MessageBox.Show("Please Enter The PerconalCode.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Guard SET Room_Number='" + textroomnumberGr.Text +
                "',Work_Shift='" + comboworkshiftGr.Text + "',Working_Hours_Guard='" + textworkinghourseGr.Text
              + "',Overtime_Guard='" + textovertimeGr.Text + "',Delaytime_Guard='" + textdelaytimeGr.Text
              + "' WHERE Personal_Code=" + textpersonalcodeGr.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Edit Done");
            Display();
            textpersonalcodeGr.Text = comboworkshiftGr.Text = textroomnumberGr.Text = textworkinghourseGr.Text = textovertimeGr.Text = textdelaytimeGr.Text = "";
        }

        private void dataGridGuard_MouseUp(object sender, MouseEventArgs e)
        {
            textpersonalcodeGr.Text = dataGridGuard.CurrentRow.Cells[0].Value.ToString();
            textroomnumberGr.Text = dataGridGuard.CurrentRow.Cells[1].Value.ToString();
            comboworkshiftGr.Text = dataGridGuard.CurrentRow.Cells[2].Value.ToString();
            textsalaryGr.Text = dataGridGuard.CurrentRow.Cells[3].Value.ToString();
            textworkinghourseGr.Text = dataGridGuard.CurrentRow.Cells[4].Value.ToString();
            textovertimeGr.Text = dataGridGuard.CurrentRow.Cells[5].Value.ToString();
            textdelaytimeGr.Text = dataGridGuard.CurrentRow.Cells[6].Value.ToString();
            
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do You Want to Delete?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM [Guard] WHERE Personal_Code=@Personal_Code";
                cmd.Parameters.AddWithValue("@Personal_Code", dataGridGuard.CurrentRow.Cells["Personal_Code"].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("Delet Done");
                textpersonalcodeGr.Text = comboworkshiftGr.Text = textroomnumberGr.Text = textworkinghourseGr.Text = textovertimeGr.Text = textdelaytimeGr.Text = "";
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT * FROM Guard WHERE Personal_Code like '%' + @Personal_Code + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@Personal_Code", textBoxSearch.Text + "%");
            adp.Fill(ds, "Guard");
            dataGridGuard.DataSource = ds;
            dataGridGuard.DataMember = "Guard";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
