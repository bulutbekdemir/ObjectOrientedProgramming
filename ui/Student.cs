using System;
using System.Windows.Forms;
using personal_info.data;
using personal_info.model;

namespace personal_info.ui
{
    public partial class Student : Form
    {
        private readonly LocationData _locationData;
        private readonly personal_info.logic.Name _nameParser;
        private readonly personal_info.logic.Id _idValidator;

        private personal_info.model.Student _currentStudent;

        public Student()
        {
            InitializeComponent();

            _locationData =
                new LocationData(
                    "C:\\Projects\\week2_hw\\data\\Turkey.json");

            _nameParser =
                new personal_info.logic.Name();

            _idValidator =
                new personal_info.logic.Id();
        }

        private void Student_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
            registerDate.Value = DateTime.Today;
            registerDate.Enabled = false;

            LoadCities();
            LoadClasses();

            district.DataSource = null;
            district.Enabled = false;

            comboBox1.DataSource = null;
            comboBox1.Enabled = false;

            dateTimePicker1.MaxDate = DateTime.Today;
        }

        private void LoadCities()
        {
            var cities = _locationData.GetCities();

            city.DataSource = null;
            city.DataSource = cities;
            city.DisplayMember = "Name";
            city.ValueMember = "Id";
            city.SelectedIndex = -1;

            comboBox2.DataSource = null;
            comboBox2.DataSource = _locationData.GetCities();
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";
            comboBox2.SelectedIndex = -1;
        }

        private void LoadClasses()
        {
            comboBox3.Items.Clear();

            for (int i = 1; i <= 12; i++)
            {
                comboBox3.Items.Add(i);
            }

            comboBox3.SelectedIndex = -1;
        }

        private void city_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            City selectedCity = city.SelectedItem as City;

            if (selectedCity == null)
            {
                district.DataSource = null;
                district.Enabled = false;
                return;
            }

            district.DataSource = null;

            district.DataSource =
                _locationData.GetDistricts(selectedCity.Id);

            district.DisplayMember = "Name";
            district.ValueMember = "Id";

            district.SelectedIndex = -1;
            district.Enabled = true;
        }

        private void birthCity_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            City selectedBirthCity =
                comboBox2.SelectedItem as City;

            if (selectedBirthCity == null)
            {
                comboBox1.DataSource = null;
                comboBox1.Enabled = false;
                return;
            }

            comboBox1.DataSource = null;

            comboBox1.DataSource =
                _locationData.GetDistricts(
                    selectedBirthCity.Id);

            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";

            comboBox1.SelectedIndex = -1;
            comboBox1.Enabled = true;
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            var parsedName =
                _nameParser.Parse(fullName.Text);

            Gender selectedGender =
                GetSelectedGender();

            City selectedCity =
                city.SelectedItem as City;

            District selectedDistrict =
                district.SelectedItem as District;

            City selectedBirthCity =
                comboBox2.SelectedItem as City;

            District selectedBirthDistrict =
                comboBox1.SelectedItem as District;

            int selectedClass =
                (int)comboBox3.SelectedItem;

            _currentStudent =
                new personal_info.model.Student(
                    id.Text.Trim(),
                    parsedName.Name,
                    parsedName.Surname,
                    phone.Text.Trim(),
                    selectedGender,
                    selectedCity,
                    selectedDistrict,
                    addressOther.Text.Trim(),
                    selectedClass,
                    textBox2.Text.Trim(),
                    dateTimePicker1.Value.Date,
                    selectedBirthCity,
                    selectedBirthDistrict);

            MessageBox.Show(
                "Student information has been saved temporarily.",
                "Saved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private bool ValidateForm()
        {
            // ============== ID ==============

            string enteredId = id.Text.Trim();

            if (!_idValidator.IsItId(enteredId))
            {
                MessageBox.Show(
                    "ID must contain exactly 11 digits and cannot start with 0.",
                    "Invalid ID",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                id.Focus();

                return false;
            }

            if (!_idValidator.IsItValid(enteredId))
            {
                MessageBox.Show(
                    "The entered Turkish ID number is not valid.",
                    "Invalid ID",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                id.Focus();

                return false;
            }

            // ============== NAME / SURNAME ==============

            if (string.IsNullOrWhiteSpace(fullName.Text))
            {
                MessageBox.Show(
                    "Name and surname are required.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                fullName.Focus();

                return false;
            }

            var parsedName =
                _nameParser.Parse(fullName.Text);

            if (string.IsNullOrWhiteSpace(parsedName.Name) ||
                string.IsNullOrWhiteSpace(parsedName.Surname))
            {
                MessageBox.Show(
                    "Please enter both name and surname.",
                    "Invalid Name",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                fullName.Focus();

                return false;
            }

            // ============== CLASS ==============

            if (comboBox3.SelectedItem == null)
            {
                MessageBox.Show(
                    "Please select a class.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                comboBox3.Focus();

                return false;
            }

            // ============== STUDENT NUMBER ==============

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show(
                    "Student number is required.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBox2.Focus();

                return false;
            }

            // ============== OTHER REQUIRED DATA ==============

            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show(
                    "Please select a birth city.");

                comboBox2.Focus();

                return false;
            }

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show(
                    "Please select a birth district.");

                comboBox1.Focus();

                return false;
            }

            if (city.SelectedItem == null)
            {
                MessageBox.Show(
                    "Please select a city.");

                city.Focus();

                return false;
            }

            if (district.SelectedItem == null)
            {
                MessageBox.Show(
                    "Please select a district.");

                district.Focus();

                return false;
            }

            if (!genderWomen.Checked &&
                !genderMan.Checked &&
                !genderNonBin.Checked)
            {
                MessageBox.Show(
                    "Please select a gender.");

                return false;
            }

            return true;
        }

        private Gender GetSelectedGender()
        {
            if (genderWomen.Checked)
                return Gender.Woman;

            if (genderMan.Checked)
                return Gender.Male;

            return Gender.NonBinary;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            id.Clear();
            fullName.Clear();

            comboBox3.SelectedIndex = -1;

            textBox2.Clear();

            dateTimePicker1.Value = DateTime.Today;

            comboBox2.SelectedIndex = -1;

            comboBox1.DataSource = null;
            comboBox1.Enabled = false;

            phone.Clear();

            city.SelectedIndex = -1;

            district.DataSource = null;
            district.Enabled = false;

            addressOther.Clear();

            genderWomen.Checked = false;
            genderMan.Checked = false;
            genderNonBin.Checked = false;

            registerDate.Value = DateTime.Today;

            _currentStudent = null;

            id.Focus();
        }

        private void district_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
        }

        private void birthDistrict_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
        }

        private void class_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
        }

        private void studentNumber_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void birthdayPicker_ValueChanged(
            object sender,
            EventArgs e)
        {
        }

        private void genderWomen_CheckedChanged(
            object sender,
            EventArgs e)
        {
        }

        private void genderMan_CheckedChanged(
            object sender,
            EventArgs e)
        {
        }

        private void genderNonBin_CheckedChanged(
            object sender,
            EventArgs e)
        {
        }

        private void addressOther_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void phone_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void email_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void fullName_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void id_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void personalInfo_Enter(
            object sender,
            EventArgs e)
        {
        }
    }
}