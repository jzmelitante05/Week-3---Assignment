# User Registration Form

A complete Windows Forms User Registration System using C# with full input validation, ErrorProvider handling, ComboBox, RadioButton, CheckBox, and Submit functionality.

---

# Project Overview

This project is a simple but complete User Registration Form created using:

- C#
- Windows Forms (.NET Framework)
- Visual Studio

The system validates all user inputs before allowing registration.

---

# Features

- Full Name input
- Email validation
- Password field with hidden characters
- Country selection using ComboBox
- Gender selection using RadioButtons
- Terms and Conditions checkbox
- ErrorProvider validation
- Success message after valid registration
- Form reset after successful submission

---

# Controls Used

| Control | Purpose |
|---|---|
| Label | Display text |
| TextBox | User input |
| ComboBox | Country selection |
| RadioButton | Gender selection |
| CheckBox | Terms agreement |
| Button | Submit form |
| ErrorProvider | Show validation errors |

---

# Form Design

```text
-----------------------------------------
        USER REGISTRATION FORM
-----------------------------------------

Full Name:
[________________________]

Email:
[________________________]

Password:
[________________________]

Country:
[ Select Country ▼ ]

Gender:
(o) Male
(o) Female
(o) Other

[ ] I agree to terms and conditions

            [ Submit ]

-----------------------------------------
```

---

# Requirements

The project must include:

1. ComboBox with at least 5 countries
2. RadioButtons for gender
3. CheckBox for terms agreement
4. TextBoxes for:
   - Full Name
   - Email
   - Password
5. ErrorProvider validation
6. Submit button validation

---

# Step-by-Step Setup

## Step 1: Create New Project

1. Open Visual Studio
2. Click:
   ```text
   Create New Project
   ```
3. Select:
   ```text
   Windows Forms App (.NET Framework)
   ```
4. Project Name:
   ```text
   UserRegistrationForm
   ```
5. Click Create

---

# Step 2: Add Controls to Form

Drag these controls from the Toolbox:

| Control | Name |
|---|---|
| TextBox | txtName |
| TextBox | txtEmail |
| TextBox | txtPassword |
| ComboBox | cmbCountry |
| RadioButton | rbMale |
| RadioButton | rbFemale |
| RadioButton | rbOther |
| CheckBox | chkTerms |
| Button | btnSubmit |
| ErrorProvider | errorProvider1 |

---

# Step 3: Set Text Properties

| Control | Text |
|---|---|
| Label | Full Name |
| Label | Email |
| Label | Password |
| Label | Country |
| Label | Gender |
| RadioButton | Male |
| RadioButton | Female |
| RadioButton | Other |
| CheckBox | I agree to terms and conditions |
| Button | Submit |

---

# Full Source Code

## Form1.cs

```csharp
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

            // Add countries
            cmbCountry.Items.Add("Philippines");
            cmbCountry.Items.Add("Japan");
            cmbCountry.Items.Add("South Korea");
            cmbCountry.Items.Add("Canada");
            cmbCountry.Items.Add("United States");

            // No selected item initially
            cmbCountry.SelectedIndex = -1;

            // Hide password characters
            txtPassword.PasswordChar = '*';
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool valid = true;

            // Clear old errors
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
                    errorProvider1.SetError(txtEmail, "Invalid Email Format.");
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
            if (!rbMale.Checked &&
                !rbFemale.Checked &&
                !rbOther.Checked)
            {
                errorProvider1.SetError(rbOther, "Please select gender.");
                valid = false;
            }

            // Terms Validation
            if (!chkTerms.Checked)
            {
                errorProvider1.SetError(chkTerms, "You must agree first.");
                valid = false;
            }

            // Success
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
```

---

# Code Explanation

---

## 1. Adding Countries to ComboBox

```csharp
cmbCountry.Items.Add("Philippines");
```

Adds items to the ComboBox dropdown menu.

---

## 2. Password Security

```csharp
txtPassword.PasswordChar = '*';
```

Hides password characters.

Example:

```text
mypassword
```

Displays as:

```text
**********
```

---

## 3. Validation System

```csharp
bool valid = true;
```

Tracks if all fields are valid.

If any validation fails:

```csharp
valid = false;
```

---

## 4. ErrorProvider

```csharp
errorProvider1.SetError(txtName, "Full Name is required.");
```

Displays an error icon beside the control.

---

## 5. Email Validation

```csharp
Regex.IsMatch(txtEmail.Text, pattern)
```

Checks if email format is correct.

Valid:

```text
sample@gmail.com
```

Invalid:

```text
samplegmail.com
```

---

## 6. Gender Validation

```csharp
if (!rbMale.Checked &&
    !rbFemale.Checked &&
    !rbOther.Checked)
```

Ensures one RadioButton is selected.

---

## 7. Terms and Conditions Validation

```csharp
if (!chkTerms.Checked)
```

User must agree before submitting.

---

## 8. Success Message

```csharp
MessageBox.Show("Registration Successful!");
```

Shows success dialog when validation passes.

---

# Sample Output

## Invalid Submission

Errors displayed:
- Full Name required
- Invalid email
- Password required
- Country required
- Gender required
- Terms agreement required

---

# Successful Submission

## Sample Input

| Field | Value |
|---|---|
| Full Name | Juan Dela Cruz |
| Email | juan@gmail.com |
| Password | 12345 |
| Country | Philippines |
| Gender | Male |
| Terms | Checked |

---

## Output

```text
Registration Successful!
```

---

# Validation Rules

| Field | Validation |
|---|---|
| Full Name | Cannot be empty |
| Email | Must follow email format |
| Password | Cannot be empty |
| Country | Must select one |
| Gender | Must select one |
| Terms | Must be checked |

---

# Evaluation Criteria

| Criteria | Description |
|---|---|
| Controls Used Correctly | Proper implementation |
| ErrorProvider Works | Errors appear correctly |
| Validation Works | Invalid inputs blocked |
| User Friendly | Clean and easy interface |

---

# Possible Improvements

Future features may include:

- Confirm Password
- Show/Hide Password
- Phone Number Validation
- Age Validation
- Database Integration
- Profile Picture Upload
- Login System
- Export to PDF or CSV

---

# Technologies Used

- C#
- Windows Forms
- .NET Framework
- Visual Studio

---

# Author

Joezainne Q. Melitante

BSIT Student

---

# Conclusion

This project demonstrates:
- GUI Design
- Form Validation
- User Input Handling
- Error Handling
- Windows Forms Programming

The application provides a beginner-friendly but complete registration system using C# Windows Forms.
