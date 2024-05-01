using System;

namespace GaussElimination
{
    class GaussElimination
    {
        static void Main()
        {
            // Matrisi manuel giriş

            //Console.WriteLine("Matrisin satır sayısını girin:");
            //int rows = int.Parse(Console.ReadLine());
            //Console.WriteLine("Matrisin sütun sayısını girin:");
            //int cols = int.Parse(Console.ReadLine());

            //double[,] matrix = new double[rows, cols];

            //Console.WriteLine("Matris elemanlarını girin:");
            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < cols; j++)
            //    {
            //        matrix[i, j] = double.Parse(Console.ReadLine());
            //    }
            //}

            //+++++++++++++++++++++++++++++++++++++++++++++++++++++
            double[,] matrix = new double[,] {
             { 3, 8, 1, 5, 1, 9 },
             { 2, 10, 6, 5, 4, 3 },
             { 1, 2, 7, 5, 6, 10 },
             { 6, 5, 10, 10, 2, 5 },
             { 6, 7, 3, 5, 5, 9 },
             { 6, 4, 9, 1, 3, 1 }
             };
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            PerformGaussElimination(matrix, rows, cols);

            // Matrisi yazdır
            Console.WriteLine("Düzenlenmiş matris:");
            PrintMatrix(matrix, rows, cols);
        }

        static void PerformGaussElimination(double[,] matrix, int rows, int cols)
        {
            int minDim = Math.Min(rows, cols);
            for (int k = 0; k < minDim; k++)
            {
                // Pivot için maksimum sütun elemanını bul
                int i_max = k;
                for (int i = k + 1; i < rows; i++)
                    if (Math.Abs(matrix[i, k]) > Math.Abs(matrix[i_max, k]))
                        i_max = i;

                // Pivot satırını k ile değiştir
                if (i_max != k)
                    SwapRows(matrix, k, i_max, cols);

                // Tüm alt satırları işle
                for (int i = k + 1; i < rows; i++)
                {
                    double f = matrix[i, k] / matrix[k, k];
                    for (int j = k + 1; j < cols; j++)
                        matrix[i, j] -= matrix[k, j] * f;
                    matrix[i, k] = 0;
                }
            }
        }

        static void SwapRows(double[,] matrix, int row1, int row2, int cols)
        {
            for (int i = 0; i < cols; i++)
            {
                double temp = matrix[row1, i];
                matrix[row1, i] = matrix[row2, i];
                matrix[row2, i] = temp;
            }
        }

        static void PrintMatrix(double[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
        }
    }

}
