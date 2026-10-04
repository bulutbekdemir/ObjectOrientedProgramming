using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personal_info.ui
{
    public partial class intro : Form
    {
        public intro()
        {
            InitializeComponent();
        }

        private void userButton_Click(object sender, EventArgs e)
        {
            User userForm = new User();

            userForm.FormClosed += (s, args) =>
            {
                this.Show();
            };

            this.Hide();
            userForm.Show();
        }

        private void studentButton_Click(object sender, EventArgs e)
        {
            Student studentForm = new Student();

            studentForm.FormClosed += (s, args) =>
            {
                this.Show();
            };

            this.Hide();
            studentForm.Show();
        }
    }
}
