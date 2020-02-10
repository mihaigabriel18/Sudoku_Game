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
    public partial class Form1 : Form
    {
        private Button[,] buttons;

        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            buttons = new[,] {
                { button1, button2, button3, button4, button5, button6, button7, button8, button9, }
                , { button10, button11, button12, button13, button14, button15, button16, button17, button18, }
                , { button19, button20, button21, button22, button23, button24, button25, button26, button27, }
                , { button28, button29, button30, button31, button32, button33, button34, button35, button36, }
                , { button37, button38, button39, button40, button41, button42, button43, button44, button45, }
                , { button46, button47, button48, button49, button50, button51, button52, button53, button54, }
                , { button55, button56, button57, button58, button59, button60, button61, button62, button63, }
                , { button64, button65, button66, button67, button68, button69, button70, button71, button72, }
                , { button73, button74, button75, button76, button77, button78, button79, button80, button81, }
            };


            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    buttons[i, j].Text = Table.matrix1[i, j].ToString();
                    buttons[i, j].Click += new EventHandler(EventClick);
                    buttons[i, j].KeyDown += new KeyEventHandler(EventKeyPressed);
                }
        }

        private void EventClick(object sender, EventArgs e)
        { 

        }

        public void EventKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9)
            {
                Sudoku.CheckCorrect_Replace(Table.matrix1, e.KeyCode.ToString()[1], (Button)sender, buttons);
                //Table.set_box((Button)sender, e.KeyCode.ToString()[1]);
            }
        }

    }
}
