using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp23
{
    public partial class Form1 : Form
    {
        public static Worker worker = new Worker();
        Form5AddTable addTable = new Form5AddTable();
        FormEdit edit = new FormEdit();
        public Form1()
        {
            InitializeComponent();
            splitContainer1.Visible = false;
            panel1.Visible = false;

        }
      public static List<Person> people = new List<Person>() { new Person() { Username = "Admin", Password = "Admin", Roles = "Admin" } };
        private void LogIn_Click(object sender, EventArgs e)
        {
            Form2USER form2USER = new Form2USER();
            Form3Manager form3Manager = new Form3Manager();
            

            var a = people.Exists(x => x.Username == textBox1.Text && x.Password == textBox2.Text);
            var b = people.SingleOrDefault(x => x.Username == textBox1.Text && x.Password == textBox2.Text);
            if (a)
            {
                switch (b.Roles)
                {
                    case "User":
                        
                        form2USER.Visible = true;
                        break;
                    case "Manager":
                        form3Manager.Visible = true;
                        break;
                    case "Admin":
                        splitContainer1.Visible = true;
                        ComboboxUsnames.Items.Clear();
                        ComboboxUsnames.Items.AddRange(people.Select(x => x.Username).Skip(1).ToArray());
                        comboBoxRole.Items.Clear();
                        comboBoxRole.Items.Add("User");
                        comboBoxRole.Items.Add("Manager");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Belə istifadəçi yoxdur");
            }
          
        }

        public  void AddListview(Worker worker)
        {
            ListViewItem listViewItem = new ListViewItem(new string[] { worker.ID++.ToString(), worker.Name, worker.Surname, worker.Age.ToString() });
            listView1.Items.Add(listViewItem);
        }

        public   class Person
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string Roles { get; set; } = "User";
        }

       public class Worker {

            public int ID { get; set; } = 0;
            public string Name { get; set; }
            public string Surname { get; set; }
            public int Age { get; set; }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //admin
        {
            Form4Registr form4Registr = new Form4Registr();
            form4Registr.Visible = true;
                
        }

        private void ChangeRole_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void ShowTable_Click(object sender, EventArgs e) //admin
        {
            panel1.Visible = true;
        }

        private void ComboboxUsnames_SelectedIndexChanged(object sender, EventArgs e)
        {
            var person = people.SingleOrDefault(x=>x.Username==ComboboxUsnames.Text);

            comboBoxRole.Text = person.Roles;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            splitContainer1.Visible = false;
        }

        private void comboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            var person = people.SingleOrDefault(x => x.Username == ComboboxUsnames.Text);
            person.Roles = comboBoxRole.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            addTable.ShowDialog();
            ListViewItem listViewItem = new ListViewItem(new string[] { worker.ID++.ToString(), worker.Name, worker.Surname, worker.Age.ToString() });
            listView1.Items.Add(listViewItem);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                listView1.SelectedItems[0].Remove();
                button3.BackColor = Color.WhiteSmoke;
            }
            catch (Exception)
            {
                button3.BackColor = Color.Red;
            }
        }

        private void button4_Click(object sender, EventArgs e) //edit
        {
            //listView1.SelectedItems[0];
            edit.GetTextbox1 = listView1.SelectedItems[0].SubItems[1].Text;
            edit.GetTextbox2 = listView1.SelectedItems[0].SubItems[2].Text;
            edit.GetTextbox3 = listView1.SelectedItems[0].SubItems[3].Text.ToString();
            edit.ShowDialog();
            if (edit.SaveTrue)
            {
                listView1.SelectedItems[0].SubItems[1].Text = edit.GetTextbox1;
                listView1.SelectedItems[0].SubItems[2].Text = edit.GetTextbox2;
                listView1.SelectedItems[0].SubItems[3].Text = edit.GetTextbox3;
            }
            //Close();
        }
    }
}
