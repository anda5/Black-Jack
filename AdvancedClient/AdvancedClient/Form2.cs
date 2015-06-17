using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedClient
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        String text;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                this.Hide();
                Form1 gameForm = new Form1(textBox1.Text);
                gameForm.ShowDialog();
                text = textBox1.Text;

            }
            else
            {
                MessageBox.Show("Fill the textBox");
            }
        }
       

        public String getText()
        {
            return text;
        }
    }
}
