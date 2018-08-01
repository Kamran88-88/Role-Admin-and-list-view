using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp23
{
    public partial class Form4Registr : Form
    {
        public Form4Registr()
        {
            InitializeComponent();
        }

        private void SaveUser_Click(object sender, EventArgs e)
        {
            Form1.Person person = new Form1.Person();
            person.Username = Username.Text;
            person.Password = Password.Text;
            person.Roles = "User";
            Form1.people.Add(person);

          //  var table = new ListViewItem(Form1.);

            Close();
        }
    }
}
