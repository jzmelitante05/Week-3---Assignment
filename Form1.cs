using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UserRegistrationForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Add countries to ComboBox
            cmbCountry.Items.Add("Philippines");
            cmbCountry.Items.Add("Japan");
            cmbCountry.Items.Add("South Korea");
            cmbCountry.Items.Add("Canada");
            cmbCountry.Items.Add("United States");

            cmbCountry.SelectedIndex = -1;

            // Hide password characters
            txtPassword.PasswordChar = '*';
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool valid = true;

            // Clear previous errors
            errorProvider1.Clear();

            // Full Name Validation
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider1.SetError(txtName, "Full Name is required.");
                valid = false;
            }

            // Email Validation
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Email is required.");
                valid = false;
            }
            else
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                if (!Regex.IsMatch(txtEmail.Text, pattern))
                {
                    errorProvider1.SetError(txtEmail, "Invalid email format.");
                    valid = false;
                }
            }

            // Password Validation
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Password is required.");
                valid = false;
            }

            // Country Validation
            if (cmbCountry.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbCountry, "Please select a country.");
                valid = false;
            }

            // Gender Validation
            if (!rbMale.Checked && !rbFemale.Checked && !rbOther.Checked)
            {
                errorProvider1.SetError(rbOther, "Please select a gender.");
                valid = false;
            }

            // Terms and Conditions Validation
            if (!chkTerms.Checked)
            {
                errorProvider1.SetError(chkTerms, "You must agree to terms.");
                valid = false;
            }

            // If all validations pass
            if (valid)
            {
                MessageBox.Show(
                    "Registration Successful!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ClearForm();
            }
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();

            cmbCountry.SelectedIndex = -1;

            rbMale.Checked = false;
            rbFemale.Checked = false;
            rbOther.Checked = false;

            chkTerms.Checked = false;
        }
    }
}
