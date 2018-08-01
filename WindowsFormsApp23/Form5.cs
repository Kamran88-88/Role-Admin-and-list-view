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
            //Form1.Worker worker = new Form1.Worker();
            Form1.worker.Name = textBox1.Text;
            Form1.worker.Surname = textBox2.Text;
            Form1.worker.Age = Convert.ToInt32(textBox3.Text);
          
            //Form1 form1 = new Form1();
            //form1.AddListview(worker);
            Close();
        }
    }
}
