﻿using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Table
    {
		public static  int [,] matrix1 = { {1,0,0,4,8,9,0,0,6},
			   {7,3,0,0,0,0,0,4,0},
			   {0,0,0,0,0,1,2,9,5},
			   {0,0,7,1,2,0,6,0,0},
			   {5,0,0,7,0,3,0,0,8},   //EASY
			   {0,0,6,0,9,5,7,0,0},
			   {9,1,4,6,0,0,0,0,0},
			   {0,2,0,0,0,0,0,3,7},
			   {8,0,0,5,1,2,0,0,4} };
		public static int [,] matrix2 = { {0,2,0,6,0,8,0,0,0},
			   {5,8,0,0,0,9,7,0,0},
			   {0,0,0,0,4,0,0,0,0},
			   {3,7,0,0,0,0,5,0,0},    //INTERMEDIATE
			   {6,0,0,0,0,0,0,0,4},
			   {0,0,8,0,0,0,0,1,3},
			   {0,0,0,0,2,0,0,0,0},
			   {0,0,9,8,0,0,0,3,6},
			   {0,0,0,3,0,6,0,9,0} };
		public static int [,] matrix3 = { {2,0,0,3,0,0,0,0,0},
				{8,0,4,0,6,2,0,0,3},
				{0,1,3,8,0,0,2,0,0},
				{0,0,0,0,2,0,3,9,0},    //HARD
				{5,0,7,0,0,0,6,2,1},
				{0,3,2,0,0,6,0,0,0},
				{0,2,0,0,0,9,1,4,0},
				{6,0,1,2,5,0,8,0,9},
				{0,0,0,0,0,1,0,0,2} };
		public static int [,] matrix4 = { {0,2,0,0,0,0,0,0,0},
				{0,0,0,6,0,0,0,0,3},
				{0,7,4,0,8,0,0,0,0},
				{0,0,0,0,0,3,0,0,2},
				{0,8,0,0,4,0,0,1,0},    //INSANE
				{6,0,0,5,0,0,0,0,0},
				{0,0,0,0,1,0,7,8,0},
				{5,0,0,0,0,9,0,0,0},
				{0,0,0,0,0,0,0,4,0} };
        public static Button set_box(Button button, char value)
        {
            button.Text = value.ToString();
            return button;
        }
	}
}