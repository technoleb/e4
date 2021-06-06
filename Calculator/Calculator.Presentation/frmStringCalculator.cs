using Calculator.Service;
using System;
using System.Windows.Forms;

namespace Calculator.Presentation
{
    public partial class frmStringCalculator : Form
    {
        public frmStringCalculator()
        {
            InitializeComponent();
        }

        //On button click it shows answer.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            StringCalculator objStrCal = new StringCalculator();
            lblAnswer.Text = objStrCal.StringAdd(txtInput.Text.ToString().Trim()).ToString();
        }

        //On Cancle button click it clears everything and set foucus on input textbox.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";
            lblAnswer.Text = "";
            txtInput.Focus();
        }
    }
}
