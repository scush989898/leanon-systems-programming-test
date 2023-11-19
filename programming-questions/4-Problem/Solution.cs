using System;

namespace _4_Problem
{
    internal class Solution
    {
        static char OriginalColor;

        public static void Main(string[] args)
        {
            char[][] matrix = new char[][]
            {
                new char[] { '.', '#', '#', '#', '.', '.' },
                new char[] { '.', '#', '.', '.', '#', '.' },
                new char[] { '.', '#', '#', '#', '.', '.' },
                new char[] { '.', '.', '.', '.', '.', '.' }
            };

            PrintMatrix(matrix);
            Console.WriteLine();
            Console.WriteLine();

            OriginalColor = matrix[0][0];
            Paint(matrix, 0, 0, 'O');


            //OriginalColor = matrix[1][3];
            //Paint(matrix, 1, 3, 'O');

            PrintMatrix(matrix);
        }

        public static void Paint(char[][] matrix, int row, int col, char color)
        {
            if (row < 0 || row >= matrix.Length || col < 0 || col >= matrix[0].Length || matrix[row][col] != OriginalColor)
            {
                return;
            }

            matrix[row][col] = color;

            Paint(matrix, row - 1, col, color);
            Paint(matrix, row + 1, col, color);
            Paint(matrix, row, col - 1, color);
            Paint(matrix, row, col + 1, color);
        }

        public static void PrintMatrix(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
