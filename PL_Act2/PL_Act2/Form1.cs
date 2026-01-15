using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_Act2
{
    public partial class act2 : Form
    {
        public act2()
        {
            InitializeComponent();
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            int age, gradeLvl, average, absences;
            string academicStanding, attendanceStatus, privilegeLvl = "", clearanceApproval = "";
            string clearanceType = Clearance.Text, payment = Payment.Text, disciplinaryMethod = DisciplinaryMethod.Text;
            //1
            if (string.IsNullOrEmpty(FName.Text) ||
                string.IsNullOrEmpty(Age.Text) ||
                string.IsNullOrEmpty(Average.Text) ||
                string.IsNullOrEmpty(Absences.Text) ||
                Clearance.SelectedIndex == -1 ||
                GradeLvl.SelectedIndex == -1 ||
                DisciplinaryMethod.SelectedIndex == -1 ||
                Payment.SelectedIndex == -1) {
                MessageBox.Show("Please fill out all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else if (!int.TryParse(Age.Text, out age)) {
                MessageBox.Show("Invalid Age", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else if (!int.TryParse(Average.Text, out average)) {
                MessageBox.Show("Invalid Average", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else if (!int.TryParse(Absences.Text, out absences)) {
                MessageBox.Show("Invalid Absences.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //2
            gradeLvl = GradeLvl.SelectedIndex + 7;
            if ((age < 12 && gradeLvl >= 10) || (age >= 18 && gradeLvl <= 8)) {
                MessageBox.Show("Invalid Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //3
            if (average >= 90) {
                academicStanding = "Outstanding";
            }
            else if (average >= 85) {
                academicStanding = "Very Satisfactory";
            }
            else if (average >= 75) {
                academicStanding = "Satisfactory";
            }
            else
                academicStanding = "At Risk";
            //4
            if (absences <= 3) {
                 attendanceStatus = "Good Standing";
            }
            else if (absences <= 7) {
                attendanceStatus = "Warning";
            }
            else {
                attendanceStatus = "Critical";  
            }
            //5
            if (clearanceType == "Academmic")
            {
                if (average >= 75)
                {
                    clearanceApproval = "Accepted";
                }
                else
                {
                    clearanceApproval = "Denied";
                }
            }
            else if (clearanceType == "Library")
            {
                if (payment == "Paid")
                {
                    clearanceApproval = "Accepted";
                }
                else
                {
                    clearanceApproval = "Denied";
                }
            }
            else if (clearanceType == "Full")
            {
                if (payment == "Full" && disciplinaryMethod == "No" && average >= 75)
                {
                    clearanceApproval = "Accepted";
                }
                else
                {
                    clearanceApproval = "Denied";
                }
            }
            //6
            switch (gradeLvl)
            {
                case 7:
                case 8:
                    privilegeLvl = "Basic Privileges";
                    break;
                case 9:
                case 10:
                    privilegeLvl = "Intermidiate Privileges";
                    break;
                case 11:
                case 12:
                    privilegeLvl = "Advanced Privileges";
                    break;
                default:
                    break;
            }
            //7
            string finalRisk = (academicStanding == "At Risk" || attendanceStatus == "Critical" || disciplinaryMethod == "Yes")? "High Risk" : "Low Risk";


            MessageBox.Show($"Name:  {FName.Text} \n" +
                                $"Academic Standing:  {academicStanding}\n" +
                                $"Attendance Status:  {attendanceStatus}\n" +
                                $"Clearance Result:  {clearanceApproval}\n" +
                                $"Privelege Level:  {privilegeLvl}\n" +
                                $"Final Risk:  {finalRisk}"); 
        }
    }
}
