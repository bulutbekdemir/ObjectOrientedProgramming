using System;
using System.Windows.Forms;
using personal_info.data;
using personal_info.model;

namespace personal_info.ui
{
    public partial class User : Form
    {
        private readonly LocationData _locationData;
        private readonly personal_info.logic.Name _nameParser;
        private readonly personal_info.logic.Id _idValidator;

        private personal_info.model.User _currentUser;

        public User()
        {
            InitializeComponent();

            _locationData =
                new data.LocationData(
                    "C:\\Projects\\week2_hw\\data\\Turkey.json");

            _nameParser =
                new personal_info.logic.Name();

            _idValidator =
                new personal_info.logic.Id();
        }

        private void user_Load(object sender, EventArgs e)
        {
            ShowPersonalInfo();

            InitializeForm();
        }

        private void InitializeForm()
        {
            LoadCities();

            district.DataSource = null;
            district.Enabled = false;
        }

        private void LoadCities()
        {
            city.DataSource = null;

            city.DataSource = _locationData.GetCities();

            city.DisplayMember = "Name";
            city.ValueMember = "Id";

            city.SelectedIndex = -1;
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

        private void save_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            Gender selectedGender = GetSelectedGender();

            City selectedCity =
                city.SelectedItem as City;

            District selectedDistrict =
                district.SelectedItem as District;

            var parsedName =
                _nameParser.Parse(fullName.Text);

            _currentUser =
                new personal_info.model.User(
                    id.Text.Trim(),
                    parsedName.Name,
                    parsedName.Surname,
                    phone.Text.Trim(),
                    selectedGender,
                    selectedCity,
                    selectedDistrict,
                    addressOther.Text.Trim());

            MessageBox.Show(
                "User information has been saved temporarily.",
                "Saved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private bool ValidateForm()
        {
            /// ============== ID RELATED ==============
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
            /// ============== ID RELATED ENDS ==============    

            if (string.IsNullOrWhiteSpace(fullName.Text))
            {
                MessageBox.Show(
                    "Full name is required.");

                fullName.Focus();

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
            phone.Clear();
            addressOther.Clear();

            genderWomen.Checked = false;
            genderMan.Checked = false;
            genderNonBin.Checked = false;

            city.SelectedIndex = -1;

            district.DataSource = null;
            district.Enabled = false;

            _currentUser = null;

            id.Focus();
        }

        private void show_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show(
                    "No user has been saved yet.",
                    "User",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            MessageBox.Show(
                $"ID: {_currentUser.Id}\n" +
                $"Name: {_currentUser.Name}\n" +
                $"Surname: {_currentUser.Surname}\n" +
                $"Phone: {_currentUser.PhoneNumber}\n" +
                $"Gender: {_currentUser.Gender}\n" +
                $"City: {_currentUser.City.Name}\n" +
                $"District: {_currentUser.District.Name}\n" +
                $"Address: {_currentUser.AddressOther}",
                "User Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void personalInformationToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            ShowPersonalInfo();
        }

        private void aboutToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            ShowAbout();
        }

        private void ShowPersonalInfo()
        {
            personalInfo.Show();
            personalInfo.BringToFront();

            about.Hide();

            personalInformationToolStripMenuItem.Checked = true;
            aboutToolStripMenuItem.Checked = false;
        }

        private void ShowAbout()
        {
            about.Show();
            about.BringToFront();

            personalInfo.Hide();

            personalInformationToolStripMenuItem.Checked = false;
            aboutToolStripMenuItem.Checked = true;
        }

        private void id_TextChanged(object sender, EventArgs e)
        {
        }

        private void fullName_TextChanged(object sender, EventArgs e)
        {
        }

        private void phone_TextChanged(object sender, EventArgs e)
        {
        }

        private void email_TextChanged(object sender, EventArgs e)
        {
        }

        private void addressOther_TextChanged(object sender, EventArgs e)
        {
        }

        private void district_SelectedIndexChanged(
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

        private void personalInfo_Enter(
            object sender,
            EventArgs e)
        {
        }

        private void labelAbout_Click(
            object sender,
            EventArgs e)
        {
        }

        private void about_Enter(
            object sender,
            EventArgs e)
        {
        }
    }
}