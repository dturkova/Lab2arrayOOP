using System;

class Matrix
{
    private int[,] Array;
    private int size;

    public Matrix(int size)
    {
        this.size = size;
        Array = new int[size, size];
    }

    public int getMatrixSize
    {
        get { return size; }
    }

    public int this[int i, int j]
    {
        get { return Array[i, j]; }
        set { Array[i, j] = value; }
    }

    public int SumOfNonNegativeColumns()
    {
        int sum = 0;
        for (int j = 0; j < size; j++)
        {
            bool hasNegative = false;
            for (int i = 0; i < size; i++)
            {
                if (Array[i, j] < 0)
                {
                    hasNegative = true;
                    break;
                }
            }
            if (!hasNegative)
            {
                for (int i = 0; i < size; i++)
                {
                    sum += Array[i, j];
                }
            }
        }
        return sum;
    }

    public int MaxSumOfParallelDiagonal()
    {
        int maxSum = int.MinValue;
        for (int k = 1 - size; k < size; k++)
        {
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                int j = i - k;
                if (j >= 0 && j < size)
                {
                    sum += Array[i, j];
                }
            }
            if (sum > maxSum)
            {
                maxSum = sum;
            }
        }
        return maxSum;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Matrix matrix = new Matrix(3);
        //matrix[0, 0] = 1;
        //matrix[0, 1] = -2;
        //matrix[0, 2] = 3;
        //matrix[1, 0] = 27;
        //matrix[1, 1] = 5;
        //matrix[1, 2] = -6;
        //matrix[2, 0] = 7;
        //matrix[2, 1] = -8;
        //matrix[2, 2] = 9;

        Console.WriteLine("Enter elements of the matrix: ");

        for (int i = 0; i < matrix.getMatrixSize; i++)
        {
            for (int j = 0; j < matrix.getMatrixSize; j++)
            {
                Console.Write($"Element [{i}, {j}]: ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        for (int i = 0; i < matrix.getMatrixSize; i++) 
        {
            for (int j = 0; j < matrix.getMatrixSize; j++)
            { Console.Write(matrix[i, j] + " "); }
            Console.WriteLine();
        }


        int sumCol = matrix.SumOfNonNegativeColumns();
        Console.WriteLine($"Sum of non-negative columns: {sumCol}");

        int maxSumDiag = matrix.MaxSumOfParallelDiagonal();
        Console.WriteLine($"Max sum of parallel diagonals: {maxSumDiag}");
    }
}