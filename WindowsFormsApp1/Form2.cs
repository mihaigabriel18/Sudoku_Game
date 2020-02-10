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
    public partial class Form2 : Form
    {
        //depending on which button we press (what difficulty we choose)
        //we will load the correct pattern of the matrix
        public static int[,] matrix = { { 0, 0, 0, 0, 0, 0, 0, 0, 0}
            ,{ 0, 0, 0, 0, 0, 0, 0, 0, 0}
            ,{ 0, 0, 0, 0, 0, 0, 0, 0, 0}
            ,{ 0, 0, 0, 0, 0, 0, 0, 0, 0}
            ,{ 0, 0, 0, 0, 0, 0, 0, 0, 0}
            ,{ 0, 0, 0, 0, 0, 0, 0, 0, 0}
            ,{ 0, 0, 0, 0, 0, 0, 0, 0, 0}
            ,{ 0, 0, 0, 0, 0, 0, 0, 0, 0}
            ,{ 0, 0, 0, 0, 0, 0, 0, 0, 0}};
        Form1 f = new Form1();

        public Form2()
        {
            InitializeComponent();

        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CopyMatrix(int[,] source, int[,] destination)
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    destination[i, j] = source[i, j];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CopyMatrix(Table.matrix1, matrix);
            Hide();
            f.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CopyMatrix(Table.matrix2, matrix);
            Hide();
            f.ShowDialog();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CopyMatrix(Table.matrix3, matrix);
            Hide();
            f.ShowDialog();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CopyMatrix(Table.matrix4, matrix);
            Hide();
            f.ShowDialog();
            Close();
        }
    }
}
