using System;
using System.Windows.Forms; 

namespace WindowsFormsApp1
{
    public class Sudoku
    {
        public struct coords
        {
           public int i, j;
        };

        //method that receives a button and returns its coordinates
        //within the given matrix
        public static coords GetCoordinates(Button btn, Button[,] btn_array)
        {
            coords coordinates = new coords();
            for (coordinates.i = 0; coordinates.i < 9; coordinates.i++)
                for (coordinates.j = 0; coordinates.j < 9; coordinates.j++)
                {
                    if (btn_array[coordinates.i, coordinates.j] == btn)
                        return coordinates;
                }

            //impossible case 
            //MessageBox.Show(coordinates.i.ToString(), coordinates.j.ToString());
            return coordinates; 
        }

        public static bool Checking(coords coordinates, string text, Button[,] array_btn)
        {
            bool row = true, collumn = true, square = true;
            //checking row
            for (int k = 0; k < 9; k++)
                if (coordinates.j != k)
                    if (array_btn[coordinates.i, k].Text == text)
                        row = false;

            //checking collumn
            for (int k = 0; k < 9; k++)
                if (coordinates.i != k)
                    if (array_btn[k,coordinates.j].Text == text)
                        collumn = false;

            //checking square
            //getting the position of the square
            int ii = (coordinates.i / 3) * 3;
            int jj = (coordinates.j / 3) * 3;
            for (int p = ii; p < ii + 3; p++)
                for (int q = jj; q < jj + 3; q++)
                    if(coordinates.i != ii && coordinates.j != jj)
                        if (array_btn[p, q].Text == text)
                            square = false;

            return square & collumn & row;
        }

        //method that checks if the number is modifiable or not(if it
        //was already in the matrix before this)
        public static bool ModifiabilityCheck(coords coordinates, int [,] matrix)
        {
            if (matrix[coordinates.i, coordinates.j] != 0)
                return false;
            return true;
        }


        //method that check is the number you entered is correct or not
        //and handles the cases
        public static void CheckCorrect_Replace(int[,] grid, char input, Button btn, Button[,] array_btn)
        {
            int number = input - '0'; //converting the char input into a working number
            bool correct, modifiability;
            coords coordinates = new coords();

            coordinates = GetCoordinates(btn, array_btn);
            correct = Checking(coordinates, input.ToString(), array_btn);
            modifiability = ModifiabilityCheck(coordinates, grid);

            if (correct && modifiability)
            {
                array_btn[coordinates.i, coordinates.j].Text = input.ToString();
                //grid[coordinates.i, coordinates.j] = number;
            }

            if (modifiability == false)
                MessageBox.Show("Please select a valid area ");
            else
            {
                if (!correct)
                    MessageBox.Show("Number you entered is not correct, try again");
            }
        }
    }
}
