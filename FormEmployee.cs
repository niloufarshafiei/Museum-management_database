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
    public partial class FormEmployee : Office2007Form
    {
        public FormEmployee()
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
            adp.SelectCommand.CommandText = "SELECT * FROM Employee";
            adp.Fill(ds, "Employee");
            dataGridEmployee.DataSource = ds;
            dataGridEmployee.DataMember = "Employee";
            //*********************************
            dataGridEmployee.Columns[0].Width = 150;
            dataGridEmployee.Columns[1].Width = 150;
            dataGridEmployee.Columns[2].Width = 150;
            dataGridEmployee.Columns[3].Width = 150;
            dataGridEmployee.Columns[4].Width = 150;
            dataGridEmployee.Columns[5].Width = 150;
            dataGridEmployee.Columns[6].Width = 150;
            dataGridEmployee.Columns[7].Width = 150;
            dataGridEmployee.Columns[8].Width = 150;
            dataGridEmployee.Columns[9].Width = 150;
            dataGridEmployee.Columns[10].Width = 150;
            dataGridEmployee.Columns[11].Width = 150;
        }
        private void FormEmployee_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
         
            if (textpersonalcodeE.Text == "")
            {
                MessageBox.Show("Please Enter The PersonalCode.");
                return;
            }
            if (textnumberbranchE.Text == "")
            {
                MessageBox.Show("Please Enter The BranchNumber.");
                return;
            }
            if (textnatinalcode.Text == "")
            {
                MessageBox.Show("Please Enter The NatinalCode.");
                return;
            }
            string natinalcode = textnatinalcode.Text;
            if (natinalcode.Length < 10 || natinalcode.Length > 10)
            {
                MessageBox.Show("Please Enter The again NatinalCode.");
                return;
            }

            string BirthDate = textbirthdate.Text;
            string DayD = Convert.ToString(BirthDate[9]);
            string DayY = Convert.ToString(BirthDate[8]);
            string MonthD = Convert.ToString(BirthDate[5]);
            string MonthY = Convert.ToString(BirthDate[6]);

            if ((MonthD == "1" && (MonthY == "3" || MonthY == "4" || MonthY == "5" || MonthY == "6" || MonthY == "7" || MonthY == "8" || MonthY == "9")) || MonthD == "2" || MonthD == "3" || MonthD == "4" || MonthD == "5" || MonthD == "6" || MonthD == "7" || MonthD == "8" || MonthD == "9")
            {
                MessageBox.Show("Please Enter The Correct Date.");
                textbirthdate.Text = "";
                return;
            }
            if ((MonthD == "0" && (MonthY == "1" || MonthY == "2" || MonthY == "3" || MonthY == "4" || MonthY == "5" || MonthY == "6")) && (DayY == "3" && (DayD == "2" || DayD == "3" || DayD == "4" || DayD == "5" || DayD == "6" || DayD == "7" || DayD == "8" || DayD == "9")))
            {
                MessageBox.Show("Please Enter The Correct Date.");
                textbirthdate.Text = "";
                return;
            }
            if ((MonthD == "0" && ((MonthY == "7" || MonthY == "8" || MonthY == "9")) || (MonthD == "1" && (MonthY == "0" || MonthY == "1" || MonthY == "2"))) && (DayY == "3" && (DayD == "1" || DayD == "2" || DayD == "3" || DayD == "4" || DayD == "5" || DayD == "6" || DayD == "7" || DayD == "8" || DayD == "9")))
            {
                MessageBox.Show("Please Enter The Correct Date.");
                textbirthdate.Text = "";
                return;
            }

            string Datejion = textdatejoin.Text;
            string DayDj = Convert.ToString(Datejion[9]);
            string DayYj = Convert.ToString(Datejion[8]);
            string MonthDj = Convert.ToString(Datejion[5]);
            string MonthYj = Convert.ToString(Datejion[6]);

            if ((MonthDj == "1" && (MonthYj == "3" || MonthYj == "4" || MonthYj == "5" || MonthYj == "6" || MonthYj == "7" || MonthYj == "8" || MonthYj == "9")) || MonthDj == "2" || MonthDj == "3" || MonthDj == "4" || MonthDj == "5" || MonthDj == "6" || MonthDj == "7" || MonthDj == "8" || MonthDj == "9")
            {
                MessageBox.Show("Please Enter The Correct Date.");
                textdatejoin.Text = "";
                return;
            }
            if ((MonthDj == "0" && (MonthYj == "1" || MonthYj == "2" || MonthYj == "3" || MonthYj == "4" || MonthYj == "5" || MonthYj == "6")) && (DayYj == "3" && (DayDj == "2" || DayDj == "3" || DayDj == "4" || DayDj == "5" || DayDj == "6" || DayDj == "7" || DayDj == "8" || DayDj == "9")))
            {
                MessageBox.Show("Please Enter The Correct Date.");
                textdatejoin.Text = "";
                return;
            }
            if ((MonthDj == "0" && ((MonthYj == "7" || MonthYj == "8" || MonthYj == "9")) || (MonthDj == "1" && (MonthYj == "0" || MonthYj == "1" || MonthYj == "2"))) && (DayYj == "3" && (DayDj == "1" || DayDj == "2" || DayDj == "3" || DayDj == "4" || DayDj == "5" || DayDj == "6" || DayDj == "7" || DayDj == "8" || DayDj == "9")))
            {
                MessageBox.Show("Please Enter The Correct Date.");
                textdatejoin.Text = "";
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "INSERT into [Employee] (Personal_Code, Natinal_Code, F_Name, L_Name, Sex, Employee_City, Employee_Street, Position, Birth_Date, Date_join, Insurance, Number_Branch)" +
            "values(@Personal_Code, @Natinal_Code, @F_Name, @L_Name, @Sex, @Employee_City, @Employee_Street, @Position, @Birth_Date, @Date_join, @Insurance, @Number_Branch)";
            cmd.Parameters.AddWithValue("@Personal_Code", textpersonalcodeE.Text);
            cmd.Parameters.AddWithValue("@Natinal_Code", textnatinalcode.Text);
            cmd.Parameters.AddWithValue("@F_Name", textFirstname.Text);
            cmd.Parameters.AddWithValue("@L_Name", textlastname.Text);
            cmd.Parameters.AddWithValue("@Sex", combosex.Text);
            cmd.Parameters.AddWithValue("@Employee_City", comboEmployeecity.Text);
            cmd.Parameters.AddWithValue("@Employee_Street", textEmployeestreet.Text);
            cmd.Parameters.AddWithValue("@Position", comboposition.Text);
            cmd.Parameters.AddWithValue("@Birth_Date", textbirthdate.Text);
            cmd.Parameters.AddWithValue("@Date_join", textdatejoin.Text);
            cmd.Parameters.AddWithValue("@Insurance", comboinsurance.Text);
            cmd.Parameters.AddWithValue("@Number_Branch", textnumberbranchE.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("Save Done");
            textpersonalcodeE.Text = textnatinalcode.Text = textFirstname.Text = textlastname.Text = combosex.Text = comboEmployeecity.Text
   = textEmployeestreet.Text = comboposition.Text = textbirthdate.Text = textdatejoin.Text = comboinsurance.Text = textpersonalcodeE.Text = textnumberbranchE.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string BirthDate = textbirthdate.Text;
            string DayD = Convert.ToString(BirthDate[9]);
            string DayY = Convert.ToString(BirthDate[8]);
            string MonthD = Convert.ToString(BirthDate[5]);
            string MonthY = Convert.ToString(BirthDate[6]);

            if ((MonthD == "1" && (MonthY == "3" || MonthY == "4" || MonthY == "5" || MonthY == "6" || MonthY == "7" || MonthY == "8" || MonthY == "9")) || MonthD == "2" || MonthD == "3" || MonthD == "4" || MonthD == "5" || MonthD == "6" || MonthD == "7" || MonthD == "8" || MonthD == "9")
            {
                MessageBox.Show("Please Enter The Correct Date.");
                textbirthdate.Text = "";
                return;
            }

            if ((MonthD == "0" && (MonthY == "1" || MonthY == "2" || MonthY == "3" || MonthY == "4" || MonthY == "5" || MonthY == "6")) && (DayY == "3" && (DayD == "2" || DayD == "3" || DayD == "4" || DayD == "5" || DayD == "6" || DayD == "7" || DayD == "8" || DayD == "9")))
            {
                MessageBox.Show("Please Enter The Correct Date.");
                textbirthdate.Text = "";
                return;
            }

            if ((MonthD == "0" && ((MonthY == "7" || MonthY == "8" || MonthY == "9")) || (MonthD == "1" && (MonthY == "0" || MonthY == "1" || MonthY == "2"))) && (DayY == "3" && (DayD == "1" || DayD == "2" || DayD == "3" || DayD == "4" || DayD == "5" || DayD == "6" || DayD == "7" || DayD == "8" || DayD == "9")))
            {
                MessageBox.Show("Please Enter The Correct Date.");
                textbirthdate.Text = "";
                return;
            }

            string Datejion = textdatejoin.Text;
            string DayDj = Convert.ToString(Datejion[9]);
            string DayYj = Convert.ToString(Datejion[8]);
            string MonthDj = Convert.ToString(Datejion[5]);
            string MonthYj = Convert.ToString(Datejion[6]);

            if ((MonthDj == "1" && (MonthYj == "3" || MonthYj == "4" || MonthYj == "5" || MonthYj == "6" || MonthYj == "7" || MonthYj == "8" || MonthYj == "9")) || MonthDj == "2" || MonthDj == "3" || MonthDj == "4" || MonthDj == "5" || MonthDj == "6" || MonthDj == "7" || MonthDj == "8" || MonthDj == "9")
            {
                MessageBox.Show("Please Enter The Correct Date.");
                textdatejoin.Text = "";
                return;
            }

            if ((MonthDj == "0" && (MonthYj == "1" || MonthYj == "2" || MonthYj == "3" || MonthYj == "4" || MonthYj == "5" || MonthYj == "6")) && (DayYj == "3" && (DayDj == "2" || DayDj == "3" || DayDj == "4" || DayDj == "5" || DayDj == "6" || DayDj == "7" || DayDj == "8" || DayDj == "9")))
            {
                MessageBox.Show("Please Enter The Correct Date.");
                textdatejoin.Text = "";
                return;
            }

            if ((MonthDj == "0" && ((MonthYj == "7" || MonthYj == "8" || MonthYj == "9")) || (MonthDj == "1" && (MonthYj == "0" || MonthYj == "1" || MonthYj == "2"))) && (DayYj == "3" && (DayDj == "1" || DayDj == "2" || DayDj == "3" || DayDj == "4" || DayDj == "5" || DayDj == "6" || DayDj == "7" || DayDj == "8" || DayDj == "9")))
            {
                MessageBox.Show("Please Enter The Correct Date.");
                textdatejoin.Text = "";
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Employee set Natinal_Code='" + textnatinalcode.Text + "',F_Name='" + textFirstname.Text + "',L_Name='" +
                textlastname.Text + "',Sex='" + combosex.Text + "',Employee_City='" + comboEmployeecity.Text + "',Employee_Street='" + textEmployeestreet.Text + "',Position='" +
                comboposition.Text + "',Birth_Date='" + textbirthdate.Text + "',Date_join='" + textdatejoin.Text + "',Insurance='"
                + comboinsurance.Text+ "',Number_Branch='" + textnumberbranchE.Text + "' WHERE Personal_Code=" + textpersonalcodeE.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Edit Done");
            Display();
            textpersonalcodeE.Text = textnatinalcode.Text = textFirstname.Text = textlastname.Text = combosex.Text = comboEmployeecity.Text
             = textEmployeestreet.Text = comboposition.Text = textbirthdate.Text = textdatejoin.Text = comboinsurance.Text = textpersonalcodeE.Text = textnumberbranchE.Text ="";
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("Do You Want to Delete?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM [Employee] WHERE Personal_Code=@Personal_Code ";
                cmd.Parameters.AddWithValue("@Personal_Code", dataGridEmployee.CurrentRow.Cells["Personal_Code"].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("Delet Done");
                textpersonalcodeE.Text = textnatinalcode.Text = textFirstname.Text = textlastname.Text = combosex.Text = comboEmployeecity.Text
    = textEmployeestreet.Text = comboposition.Text = textbirthdate.Text = textdatejoin.Text = comboinsurance.Text = textpersonalcodeE.Text = textnumberbranchE.Text = "";
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT * FROM Employee WHERE Personal_Code like '%' + @Personal_Code + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@Personal_Code", textBoxSearch.Text + "%");
            adp.Fill(ds, "Employee");
            dataGridEmployee.DataSource = ds;
            dataGridEmployee.DataMember = "Employee";
        }

        private void dataGridEmployee_MouseUp(object sender, MouseEventArgs e)
        {
            textpersonalcodeE.Text = dataGridEmployee.CurrentRow.Cells[0].Value.ToString();
            textnatinalcode.Text = dataGridEmployee.CurrentRow.Cells[1].Value.ToString();
            textFirstname.Text = dataGridEmployee.CurrentRow.Cells[2].Value.ToString();
            textlastname.Text = dataGridEmployee.CurrentRow.Cells[3].Value.ToString();
            combosex.Text = dataGridEmployee.CurrentRow.Cells[4].Value.ToString();
            comboEmployeecity.Text = dataGridEmployee.CurrentRow.Cells[5].Value.ToString();
            textEmployeestreet.Text = dataGridEmployee.CurrentRow.Cells[6].Value.ToString();
            comboposition.Text = dataGridEmployee.CurrentRow.Cells[7].Value.ToString();
            textbirthdate.Text = dataGridEmployee.CurrentRow.Cells[8].Value.ToString();
            textdatejoin.Text = dataGridEmployee.CurrentRow.Cells[9].Value.ToString();
            comboinsurance.Text = dataGridEmployee.CurrentRow.Cells[10].Value.ToString();
            textnumberbranchE.Text = dataGridEmployee.CurrentRow.Cells[11].Value.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
