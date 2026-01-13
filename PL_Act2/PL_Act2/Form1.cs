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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            int age, gradeLvl, average, absences;
            string academicStanding, attendanceStatus, privilegeLvl, finalRisk;

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

            gradeLvl = GradeLvl.SelectedIndex + 7;
            if ((age < 12 && gradeLvl >= 10) || (age >= 18 && gradeLvl <= 8)) {
                MessageBox.Show("Invalid Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

            if (absences >= 3) {
                 attendanceStatus = "Good Standing";
            }
            else if (absences <= 7) {
                attendanceStatus = "Warning";
            }
            else {
                attendanceStatus = "Critical";  
            }


                MessageBox.Show($"Name:\t{FName.Text} \n" +
                                $"Academic Standing:\t{academicStanding}\n" +
                                $"Attendance Status:\t{attendanceStatus}\n+" +
                                $"Clearance Result:\t{}"); 
        }
    }
}
