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
    public partial class FormMuseum : Office2007Form
    { 
       
        public FormMuseum()
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
            adp.SelectCommand.CommandText = "SELECT * FROM Museum";
            adp.Fill(ds, "Museum");
            dataGridMuseum.DataSource = ds;
            dataGridMuseum.DataMember = "Museum";
            //*********************************
            dataGridMuseum.Columns[0].Width = 150;
            dataGridMuseum.Columns[1].Width = 150;
            dataGridMuseum.Columns[2].Width = 150;
            dataGridMuseum.Columns[3].Width = 150;
            dataGridMuseum.Columns[4].Width = 150;
            dataGridMuseum.Columns[5].Width = 150;
            dataGridMuseum.Columns[6].Width = 150;
           
          
        }
        private void FormMuseum_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (textnumberbranch.Text == "")
            {
                MessageBox.Show("Please Enter The BranchNumber.");
                return;
            }
            DateTime START = Convert.ToDateTime(textstarthoursework.Text);
            DateTime END = Convert.ToDateTime(textendhoursework.Text);

            if (START > END || START == END)
            {
                MessageBox.Show("Please Enter The Museum StartTime && EndTime Again.");
                return;
            }
            //DATE
            string Date = masdatestablishment.Text;
            string DayD = Convert.ToString(Date[9]);
            string DayY = Convert.ToString(Date[8]);
            string MonthD = Convert.ToString(Date[5]);
            string MonthY = Convert.ToString(Date[6]);

            if ((MonthD == "1" && (MonthY == "3" || MonthY == "4" || MonthY == "5" || MonthY == "6" || MonthY == "7" || MonthY == "8" || MonthY == "9")) || MonthD == "2" || MonthD == "3" || MonthD == "4" || MonthD == "5" || MonthD == "6" || MonthD == "7" || MonthD == "8" || MonthD == "9")
            {
                MessageBox.Show("Please Enter The Correct Date.");
                masdatestablishment.Text = "";
                return;
            }

            if ((MonthD == "0" && (MonthY == "1" || MonthY == "2" || MonthY == "3" || MonthY == "4" || MonthY == "5" || MonthY == "6")) && (DayY == "3" && (DayD == "2" || DayD == "3" || DayD == "4" || DayD == "5" || DayD == "6" || DayD == "7" || DayD == "8" || DayD == "9")))
            {
                MessageBox.Show("Please Enter The Correct Date.");
                masdatestablishment.Text = "";
                return;
            }

            if ((MonthD == "0" && ((MonthY == "7" || MonthY == "8" || MonthY == "9")) || (MonthD == "1" && (MonthY == "0" || MonthY == "1" || MonthY == "2"))) && (DayY == "3" && (DayD == "1" || DayD == "2" || DayD == "3" || DayD == "4" || DayD == "5" || DayD == "6" || DayD == "7" || DayD == "8" || DayD == "9")))
            {
                MessageBox.Show("Please Enter The Correct Date.");
                masdatestablishment.Text = "";
                return;
            }
            //TIME
            string TimeS = textstarthoursework.Text;
            string HourD = Convert.ToString(TimeS[11]);
            string HourY = Convert.ToString(TimeS[12]);
            string MinutesD = Convert.ToString(TimeS[14]);
            string SecondsD = Convert.ToString(TimeS[17]);

            if (((HourD == "2" && (HourY == "5" || HourY == "6" || HourY == "7" || HourY == "8" || HourY == "9")) || HourD == "3" || HourD == "4" || HourD == "5" || HourD == "6" || HourD == "7" || HourD == "8" || HourD == "9") ||
                (MinutesD == "6" || MinutesD == "7" || MinutesD == "8" || MinutesD == "9") ||
                (SecondsD == "6" || SecondsD == "7" || SecondsD == "8" || SecondsD == "9"))
            {
                MessageBox.Show("Please Enter The Correct Time.");
                textstarthoursework.Text = "";
                return;
            }

            string TimeE = textendhoursework.Text;
            string Hour = Convert.ToString(TimeE[11]);
            string hourY = Convert.ToString(TimeE[12]);
            string Minutes = Convert.ToString(TimeE[14]);
            string Seconds = Convert.ToString(TimeE[17]);

            if (((Hour == "2" && (hourY == "5" || hourY == "6" || hourY == "7" || hourY == "8" || hourY == "9")) || Hour == "3" || Hour == "4" || Hour == "5" || Hour == "6" || Hour == "7" || Hour == "8" || Hour == "9") ||
                (Minutes == "6" || Minutes == "7" || Minutes == "8" || Minutes == "9") ||
                (Seconds == "6" || Seconds == "7" || Seconds == "8" || Seconds == "9"))
            {
                MessageBox.Show("Please Enter The Correct Time.");
                textstarthoursework.Text = "";
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Museum SET Museum_Name='" + textmuseumname.Text + "',Date_Establishment='" + masdatestablishment.Text + "',Museum_City='" + 
                combomuseumcity.Text + "',Museum_Street='" + textmuseumstreet.Text + "',Start_Working_Hours='" + textstarthoursework.Text + "',End_Working_Hours='" + 
                textendhoursework.Text + "' WHERE Number_Branch=" + textnumberbranch.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Edit Done");
            Display();
            textmuseumname.Text = textnumberbranch.Text = masdatestablishment.Text = combomuseumcity.Text = 
                textmuseumstreet.Text = textstarthoursework.Text = textendhoursework.Text = "";
        }

        private void FormMuseum_MouseUp(object sender, MouseEventArgs e)
        {

          /*  textmuseumname.Text = dataGridMuseum.CurrentRow.Cells[0].Value.ToString();
            textnumberbranch.Text = dataGridMuseum.CurrentRow.Cells[1].Value.ToString();
            masdatestablishment.Text = dataGridMuseum.CurrentRow.Cells[2].Value.ToString();
            combomuseumcity.Text = dataGridMuseum.CurrentRow.Cells[3].Value.ToString();
            textmuseumstreet.Text = dataGridMuseum.CurrentRow.Cells[4].Value.ToString();
            textstarthoursework.Text = dataGridMuseum.CurrentRow.Cells[5].Value.ToString();
            textendhoursework.Text = dataGridMuseum.CurrentRow.Cells[6].Value.ToString();*/
         
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do You Want to Delete?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM [Museum] WHERE Number_Branch=@Number_Branch";
                cmd.Parameters.AddWithValue("@Number_Branch", dataGridMuseum.CurrentRow.Cells["Number_Branch"].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("Delet Done");
                textmuseumname.Text = textnumberbranch.Text = masdatestablishment.Text = combomuseumcity.Text =
                textmuseumstreet.Text = textstarthoursework.Text = textendhoursework.Text = "";
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT * FROM Museum WHERE Number_Branch like '%' + @Number_Branch + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@Number_Branch", textBoxSearch.Text + "%");
            adp.Fill(ds, "Museum");
            dataGridMuseum.DataSource = ds;
            dataGridMuseum.DataMember = "Museum";
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (textnumberbranch.Text == "")
            {
                MessageBox.Show("Please Enter The BranchNumber.");
                return;
            }

            DateTime START = Convert.ToDateTime(textstarthoursework.Text);
            DateTime END = Convert.ToDateTime(textendhoursework.Text);       
            if (START > END || START == END)
            {
                MessageBox.Show("Please Enter The Museum StartTime && EndTime Again.");
                return;
            }

            //DATE
            string Date = masdatestablishment.Text;
            string DayD = Convert.ToString(Date[8]);
            string DayY = Convert.ToString(Date[9]);
            string MonthD = Convert.ToString(Date[5]);
            string MonthY = Convert.ToString(Date[6]);

            if ((MonthD == "1" && (MonthY == "3" || MonthY == "4" || MonthY == "5" || MonthY == "6" || MonthY == "7" || MonthY == "8" || MonthY == "9")) || MonthD == "2" || MonthD == "3" || MonthD == "4" || MonthD == "5" || MonthD == "6" || MonthD == "7" || MonthD == "8" || MonthD == "9")
            {
                MessageBox.Show("Please Enter The Correct Date.");
                masdatestablishment.Text = "";
                return;
            }

            if ((MonthD == "0" && (MonthY == "1" || MonthY == "2" || MonthY == "3" || MonthY == "4" || MonthY == "5" || MonthY == "6")) && (DayD == "3" && (DayY == "2" || DayY == "3" || DayY == "4" || DayY == "5" || DayY == "6" || DayY == "7" || DayY == "8" || DayY == "9")))
            {
                MessageBox.Show("Please Enter The Correct Date.");
                masdatestablishment.Text = "";
                return;
            }

            if ((MonthD == "0" && ((MonthY == "7" || MonthY == "8" || MonthY == "9")) || (MonthD == "1" && (MonthY == "0" || MonthY == "1" || MonthY == "2"))) && (DayD == "3" && (DayY == "1" || DayY == "2" || DayY == "3" || DayY == "4" || DayY == "5" || DayY == "6" || DayY == "7" || DayY == "8" || DayY == "9")))
            {
                MessageBox.Show("Please Enter The Correct Date.");
                masdatestablishment.Text = "";
                return;
            }

            //TIME START
            string TimeS = textstarthoursework.Text;
            string HourD = Convert.ToString(TimeS[0]);
            string HourY = Convert.ToString(TimeS[1]);
            string MinutesD = Convert.ToString(TimeS[3]);
            string SecondsD = Convert.ToString(TimeS[6]);

            if (((HourD == "2" && (HourY == "5" || HourY == "6" || HourY == "7" || HourY == "8" || HourY == "9")) || HourD == "3" || HourD == "4" || HourD == "5" || HourD == "6" || HourD == "7" || HourD == "8" || HourD == "9") ||
                (MinutesD == "6" || MinutesD == "7" || MinutesD == "8" || MinutesD == "9") ||
                (SecondsD == "6" || SecondsD == "7" || SecondsD == "8" || SecondsD == "9"))
            {
                MessageBox.Show("Please Enter The Correct Time.");
                textstarthoursework.Text = "";
                return;
            }

            //TIME END
            string TimeE = textendhoursework.Text;
            string Hour = Convert.ToString(TimeE[0]);
            string hourY = Convert.ToString(TimeE[1]);
            string Minutes = Convert.ToString(TimeE[3]);
            string Seconds = Convert.ToString(TimeE[6]);

            if (((Hour == "2" && (hourY == "5" || hourY == "6" || hourY == "7" || hourY == "8" || hourY == "9")) || Hour == "3" || Hour == "4" || Hour == "5" || Hour == "6" || Hour == "7" || Hour == "8" || Hour == "9") ||
                (Minutes == "6" || Minutes == "7" || Minutes == "8" || Minutes == "9") ||
                (Seconds == "6" || Seconds == "7" || Seconds == "8" || Seconds == "9"))
            {
                MessageBox.Show("Please Enter The Correct Time.");
                textstarthoursework.Text = "";
                return;
            }


            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO [Museum] (Museum_Name,Number_Branch,Date_Establishment,Museum_City,Museum_Street,Start_Working_Hours,End_Working_Hours)values(@Museum_Name,@Number_Branch,@Date_Establishment,@Museum_City,@Museum_Street,@Start_Working_Hours,@End_Working_Hours)";
            cmd.Parameters.AddWithValue("@Museum_Name", textmuseumname.Text);
            cmd.Parameters.AddWithValue("@Number_Branch", textnumberbranch.Text);
            cmd.Parameters.AddWithValue("@Date_Establishment", masdatestablishment.Text);
            cmd.Parameters.AddWithValue("@Museum_City", combomuseumcity.Text);
            cmd.Parameters.AddWithValue("@Museum_Street", textmuseumstreet.Text);
            cmd.Parameters.AddWithValue("@Start_Working_Hours", textstarthoursework.Text);
            cmd.Parameters.AddWithValue("@End_Working_Hours", textendhoursework.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("Save Done");
            textmuseumname.Text = textnumberbranch.Text = masdatestablishment.Text = combomuseumcity.Text = 
                textmuseumstreet.Text = textstarthoursework.Text = textendhoursework.Text = "";
        }

        private void dataGridMuseum_MouseUp(object sender, MouseEventArgs e)
        {
            textmuseumname.Text = dataGridMuseum.CurrentRow.Cells[0].Value.ToString();
            textnumberbranch.Text = dataGridMuseum.CurrentRow.Cells[1].Value.ToString();
            masdatestablishment.Text = dataGridMuseum.CurrentRow.Cells[2].Value.ToString();
            combomuseumcity.Text = dataGridMuseum.CurrentRow.Cells[3].Value.ToString();
            textmuseumstreet.Text = dataGridMuseum.CurrentRow.Cells[4].Value.ToString();
            textstarthoursework.Text = dataGridMuseum.CurrentRow.Cells[5].Value.ToString();
            textendhoursework.Text = dataGridMuseum.CurrentRow.Cells[6].Value.ToString();
        }

      
    }
}
