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
    public partial class FormRelatives : Office2007Form
    {
        public FormRelatives()
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
            adp.SelectCommand.CommandText = "SELECT * FROM Relatives";
            adp.Fill(ds, "Relatives");
            dataGridRelatives.DataSource = ds;
            dataGridRelatives.DataMember = "Relatives";
            //*********************************
            dataGridRelatives.Columns[0].Width = 150;
            dataGridRelatives.Columns[1].Width = 150;
            dataGridRelatives.Columns[2].Width = 150;
            dataGridRelatives.Columns[3].Width = 150;
            dataGridRelatives.Columns[4].Width = 150;
            dataGridRelatives.Columns[5].Width = 150;
        }
        private void FormRelatives_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textFirstnamer.Text == "")
            {
                MessageBox.Show("Please Enter The FirstName.");
                return;
            }
            if (textlastnamer.Text == "")
            {
                MessageBox.Show("Please Enter The LastName.");
                return;
            }
            if (textprsonalcoder.Text == "")
            {
                MessageBox.Show("Please Enter The PersonalCode.");
                return;
            }
            string BirthDate = textbirthdater.Text;
            string DayD = Convert.ToString(BirthDate[9]);
            string DayY = Convert.ToString(BirthDate[8]);
            string MonthD = Convert.ToString(BirthDate[5]);
            string MonthY = Convert.ToString(BirthDate[6]);

            if ((MonthD == "1" && (MonthY == "3" || MonthY == "4" || MonthY == "5" || MonthY == "6" || MonthY == "7" || MonthY == "8" || MonthY == "9")) || MonthD == "2" || MonthD == "3" || MonthD == "4" || MonthD == "5" || MonthD == "6" || MonthD == "7" || MonthD == "8" || MonthD == "9")
            {
                MessageBox.Show("Please Enter The Correct Date.");
                textbirthdater.Text = "";
                return;
            }

            if ((MonthD == "0" && (MonthY == "1" || MonthY == "2" || MonthY == "3" || MonthY == "4" || MonthY == "5" || MonthY == "6")) && (DayY == "3" &&( DayD == "2" || DayD == "3" || DayD == "4" || DayD == "5" || DayD == "6" || DayD == "7" || DayD == "8" || DayD == "9")))
            {
                MessageBox.Show("Please Enter The Correct Date.");
                textbirthdater.Text = "";
                return;
            }

            if ((MonthD == "0" && ((MonthY == "7" || MonthY == "8" || MonthY == "9")) || (MonthD == "1" && (MonthY == "0" || MonthY == "1" || MonthY == "2"))) && (DayY == "3" && (DayD == "1" || DayD == "2" || DayD == "3" || DayD == "4" || DayD == "5" || DayD == "6" || DayD == "7" || DayD == "8" || DayD == "9")))
            {
                MessageBox.Show("Please Enter The Correct Date.");
                textbirthdater.Text = "";
                return;
            }

            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO [Relatives] (Relative_FName, Relative_LName, Relation, Sex, Birth_Date, Personal_Code)values(@Relative_FName, @Relative_LName, @Relation, @Sex, @Birth_Date, @Personal_Code)";
            cmd.Parameters.AddWithValue("@Relative_FName", textFirstnamer.Text);
            cmd.Parameters.AddWithValue("@Relative_LName", textlastnamer.Text);
            cmd.Parameters.AddWithValue("@Relation", comborelation.Text);
            cmd.Parameters.AddWithValue("@Sex", combosexr.Text);
            cmd.Parameters.AddWithValue("@Birth_Date", textbirthdater.Text);
            cmd.Parameters.AddWithValue("@Personal_Code", textprsonalcoder.Text);


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("Save Done");
            textFirstnamer.Text = textlastnamer.Text = comborelation.Text = combosexr.Text = textbirthdater.Text = textprsonalcoder.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (textEditfirstname.Text == "")
            {
                MessageBox.Show("Please Enter The FirstName.");
                return;
            }
            if (textEditlastname.Text == "")
            {
                MessageBox.Show("Please Enter The LastName.");
                return;
            }
            if (textEditpersonalcode.Text == "")
            {
                MessageBox.Show("Please Enter The PersonalCode.");
                return;
            }
            string BirthDate = textbirthdater.Text;
            string DayD = Convert.ToString(BirthDate[9]);
            string DayY = Convert.ToString(BirthDate[8]);
            string MonthD = Convert.ToString(BirthDate[5]);
            string MonthY = Convert.ToString(BirthDate[6]);

            if ((MonthD == "1" && (MonthY == "3" || MonthY == "4" || MonthY == "5" || MonthY == "6" || MonthY == "7" || MonthY == "8" || MonthY == "9")) || MonthD == "2" || MonthD == "3" || MonthD == "4" || MonthD == "5" || MonthD == "6" || MonthD == "7" || MonthD == "8" || MonthD == "9")
            {
                MessageBox.Show("Please Enter The Correct Date.");
                textbirthdater.Text = "";
                return;
            }

            if ((MonthD == "0" && (MonthY == "1" || MonthY == "2" || MonthY == "3" || MonthY == "4" || MonthY == "5" || MonthY == "6")) && (DayY == "3" && ( DayD == "2" || DayD == "3" || DayD == "4" || DayD == "5" || DayD == "6" || DayD == "7" || DayD == "8" || DayD == "9")))
            {
                MessageBox.Show("Please Enter The Correct Date.");
                textbirthdater.Text = "";
                return;
            }

            if ((MonthD == "0" && ((MonthY == "7" || MonthY == "8" || MonthY == "9")) || (MonthD == "1" && (MonthY == "0" || MonthY == "1" || MonthY == "2"))) && (DayY == "3" && (DayD == "1" || DayD == "2" || DayD == "3" || DayD == "4" || DayD == "5" || DayD == "6" || DayD == "7" || DayD == "8" || DayD == "9")))
            {
                MessageBox.Show("Please Enter The Correct Date.");
                textbirthdater.Text = "";
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Relatives SET Relative_FName='" + textEditfirstname.Text + "',Relative_LName='" + textEditlastname.Text +
                "',Relation='" + comborelation.Text + "',Sex='" + combosexr.Text + "',Birth_Date='" + textbirthdater.Text + "',Personal_Code='" + textEditpersonalcode.Text + "' WHERE Relative_FName='" + textFirstnamer.Text + "' and Relative_LName='" + textlastnamer.Text + "' and Personal_Code='" + textprsonalcoder.Text+ "'";
            con.Open();   
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Edit Done");
            Display();
            textFirstnamer.Text = textlastnamer.Text = comborelation.Text = combosexr.Text = textbirthdater.Text = textprsonalcoder.Text = textEditpersonalcode.Text = textFirstnamer.Text= textlastnamer.Text="";
        }

        private void dataGridRelatives_MouseUp(object sender, MouseEventArgs e)
        {
            textFirstnamer.Text = dataGridRelatives.CurrentRow.Cells[0].Value.ToString();
            textlastnamer.Text = dataGridRelatives.CurrentRow.Cells[1].Value.ToString();
            comborelation.Text = dataGridRelatives.CurrentRow.Cells[2].Value.ToString();
            combosexr.Text = dataGridRelatives.CurrentRow.Cells[3].Value.ToString();
            textbirthdater.Text = dataGridRelatives.CurrentRow.Cells[4].Value.ToString();
            textprsonalcoder.Text = dataGridRelatives.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do You Want to Delete?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                var Relative_FName = dataGridRelatives.CurrentRow.Cells[0].Value;
                var Relative_LName = dataGridRelatives.CurrentRow.Cells[1].Value;
                var Personal_Code = dataGridRelatives.CurrentRow.Cells[5].Value;
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM Relatives WHERE Relative_FName=@Relative_FName and  Relative_LName=@Relative_LName and  Personal_Code=@Personal_Code";
                cmd.Parameters.AddWithValue("@Relative_FName", Relative_FName);
                cmd.Parameters.AddWithValue("@Relative_LName", Relative_LName);
                cmd.Parameters.AddWithValue("@Personal_Code", Personal_Code);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("Delet Done");
                textFirstnamer.Text = textlastnamer.Text = comborelation.Text = combosexr.Text = textbirthdater.Text = textprsonalcoder.Text = "";
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT * FROM Relatives WHERE Personal_Code like '%' + @Personal_Code + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@Personal_Code", textBoxSearch.Text + "%");
            adp.Fill(ds, "Relatives");
            dataGridRelatives.DataSource = ds;
            dataGridRelatives.DataMember = "Relatives";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }
    }
}
