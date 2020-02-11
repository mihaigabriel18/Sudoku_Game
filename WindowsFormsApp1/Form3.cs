using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            //TextBox textBox2 = new TextBox();
            //Console.WriteLine("plm");
            //textBox2.Text += "You have used";// + Hint.hint_uses.ToString() + "hints";
            InitializeComponent();
        }

        private void Form3_Load_1(object sender, EventArgs e)
        {
            //TextBox textBox2 = new TextBox();
            //Console.WriteLine("plm");
            textBox2.Text += "You have used " + Hint.hint_uses.ToString() + " hints";
        }
    }
}
