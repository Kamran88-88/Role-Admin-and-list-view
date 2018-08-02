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
    public partial class Form5AddTable : Form
    {
        public static ListViewItem listViewItem = new ListViewItem();
        public Form5AddTable()
        {
            InitializeComponent();
        }

       


        private void Save_Click(object sender, EventArgs e)
        {
            Form1.worker.Name = textBox1.Text;
            Form1.worker.Surname = textBox2.Text;
            Form1.worker.Age = Convert.ToInt32(textBox3.Text);
            Close();
        }

        private void Form5AddTable_Load(object sender, EventArgs e)
        {

        }
    }
}
