using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
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
                    if(coordinates.i != p && coordinates.j != q)
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
                grid[coordinates.i, coordinates.j] = number;
            }

            if (modifiability == false)
                MessageBox.Show("Please select a valid area ");
            else
            {
                if (!correct)
                    MessageBox.Show("Number you entered is not correct, try again");
            }
        }

        public static int[,] GenerateCopy(int[,] matrix)
        {
             int[,] copy = { { 0, 0, 0, 0, 0, 0, 0, 0, 0}
            ,{ 0, 0, 0, 0, 0, 0, 0, 0, 0}
            ,{ 0, 0, 0, 0, 0, 0, 0, 0, 0}
            ,{ 0, 0, 0, 0, 0, 0, 0, 0, 0}
            ,{ 0, 0, 0, 0, 0, 0, 0, 0, 0}
            ,{ 0, 0, 0, 0, 0, 0, 0, 0, 0}
            ,{ 0, 0, 0, 0, 0, 0, 0, 0, 0}
            ,{ 0, 0, 0, 0, 0, 0, 0, 0, 0}
            ,{ 0, 0, 0, 0, 0, 0, 0, 0, 0}};

            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    copy[i, j] = matrix[i, j];

            return copy;
        }

        public static void BackSpaceDel(int[,] matrix, Button btn, Button[,] arr_btn)
        {
            coords coordinates = new coords();
            coordinates = GetCoordinates(btn, arr_btn);
            matrix[coordinates.i, coordinates.j] = 0;
            btn.Text = "";
        }
    }

    public class SudokuSolution
    {

        public static int[,] solution_matrix = Sudoku.GenerateCopy(Form2.matrix);

        //method to return the first empty field
        public static Sudoku.coords GetEmptyField(int [,] game_board) 
        {
            var field = new Sudoku.coords();
            for (field.i = 0; field.i < 9; field.i++)
                for (field.j = 0; field.j < 9; field.j++)
                    if (game_board[field.i, field.j] == 0)
                        return field;

            return field;
        }

        //method to check if the matrix is completed or not
        public static bool CheckCompletition(int[,] matrix)
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (matrix[i, j] == 0)
                        return false;

            return true;
        }

        //checking if the number entered is correct
        public static bool Checking(int [,] matrix, Sudoku.coords coordinates, int value)
        {
            bool row = true, collumn = true, square = true;
            //checking row
            for (int k = 0; k < 9; k++)
                if (matrix[coordinates.i, k] == value)
                    row = false;

            //checking collumn
            for (int k = 0; k < 9; k++)
                if (matrix[k, coordinates.j] == value)
                    collumn = false;

            //checking square
            int ii = (coordinates.i / 3) * 3;
            int jj = (coordinates.j / 3) * 3;
            for (int p = ii; p < ii + 3; p++)
                for (int q = jj; q < jj + 3; q++)
                    if (matrix[p, q] == value)
                        square = false;

            return row & collumn & square;
        }
        public static bool completed = false;
        //backtracking to get the solution of the Sudoku
        public static void Rezolvare(int[,] matrix, Sudoku.coords coordinates)
        {
            if (CheckCompletition(matrix))
            {
                completed = true;
                return;
            }
            for (int l = 1; l <= 9; l++)
                if (Checking(matrix, coordinates, l))
                {
                    matrix[coordinates.i, coordinates.j] = l;

                    if (completed == false)
                        Rezolvare(matrix, GetEmptyField(matrix));
                    
                    if(completed == false)
                        matrix[coordinates.i, coordinates.j] = 0;

                }
        }
    }

    public class Hint
    {
        public static int hint_uses;
        public static int[,] hint_map = Sudoku.GenerateCopy(SudokuSolution.solution_matrix);

        public static int hint_initializers()
        {
            SudokuSolution.Rezolvare(hint_map, SudokuSolution.GetEmptyField(hint_map));
            
            int k = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (Form1.cp_matrix[i, j] != hint_map[i, j])
                        k++;

                    return k;
        }

        //Verify if a given matrix is the sollution;
        public static bool CheckCompletition(int[,] matrix)
        {
            SudokuSolution.Rezolvare(hint_map, SudokuSolution.GetEmptyField(hint_map));
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (matrix[i, j] != hint_map[i, j])
                        return false;
            return true;
        }

        public static int GetRandom()
        {
            Random rnd = new Random();
            int rnd_nr = rnd.Next(1, hint_initializers());
            return rnd_nr;
        }

        public static Sudoku.coords ReplaceRandom()
        {
            var coordinates = new Sudoku.coords();
            int missing = hint_initializers();
            int k = 0;
            int rnd_pos = GetRandom();
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Form1.cp_matrix[i, j] != hint_map[i, j])
                    {
                        k++;
                        if (k == rnd_pos)
                        {
                            Form1.cp_matrix[i, j] = hint_map[i, j];
                            coordinates.i = i;
                            coordinates.j = j;

                            return coordinates;
                        }
                    }
                }

            return coordinates;
        }
    }
}
