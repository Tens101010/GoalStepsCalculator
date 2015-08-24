using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACM.BL;

namespace ACM.Win
{
    public partial class PedometerWin : Form
    {
        public PedometerWin()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            var customer = new Customer();

            try
            {
                var result = customer.CalculatePercentOfGoalSteps(GoalTextBox.Text, StepsTextBox.Text);
                ResultLabel.Text = "You reached " + result + "% of your goal!";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Your entry was not valid: " + ex.Message);
                ResultLabel.Text = string.Empty;

                // Don't want to have the exception thrown out, else it will still be handled by global exception handler
                //throw;
            }


        }
    }
}
