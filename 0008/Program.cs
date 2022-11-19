// Найти произведение двух матриц
int[,] CreateMatrix(int rows, int columns, int min, int max)
{
    int[,] matrix = new int[rows, columns];
    Random rnd = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(min, max);
        }
    }
    return matrix;

}
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write("[");
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j < matrix.GetLength(1) - 1) Console.Write($"{matrix[i, j],4}, ");
            else Console.Write($"{matrix[i, j],4}");
        }
        Console.WriteLine("]");
    }
}
int[,] MultiplicationMatrix(int[,] matrix1, int[,] matrix2)
{
    int[,] prodmatrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix2.GetLength(1); j++)
        {
            for (int k = 0; k < matrix2.GetLength(0); k++)
            {
                prodmatrix[i, j] += matrix1[i, k] * matrix2[k, j];
            }
        }
    }
    return prodmatrix;
}
// В двумерном массиве целых чисел удалить строку и столбец, 
// на пересечении которых расположен наименьший элемент.
int[] MinElement(int[,] array)
{
    int[] position = new int[2];
    int min = array[0, 0];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            if (array[i, j] < min)
            {
                min = array[i, j];
                position[0] = i;
                position[1] = j;
            }
    }
    return position;
}
int[,] DeleteRowCol(int[,] matrix, int[] array)
{
    int[,] delrow = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
    for (int i = 0; i < delrow.GetLength(0); i++)
    {
        for (int j = 0; j < delrow.GetLength(1); j++)
            if (i < array[0])
                delrow[i, j] = matrix[i, j];
            else
                delrow[i, j] = matrix[i + 1, j];

    }
    int[,] delcol = new int[delrow.GetLength(0), delrow.GetLength(1) - 1];
    {
        for (int i = 0; i < delcol.GetLength(0); i++)
        {
            for (int j = 0; j < delcol.GetLength(1); j++)
            {
                if (j < array[1])
                    delcol[i, j] = delrow[i, j];
                else
                    delcol[i, j] = delrow[i, j + 1];
            }
        }
    }
    return delcol;
}


int[,] matr1 = CreateMatrix(4, 4, 1, 10);
PrintMatrix(matr1);
Console.WriteLine();
int[,] matr2 = CreateMatrix(4, 4, 1, 10);
PrintMatrix(matr2);
Console.WriteLine();

if(matr1.GetLength(1)==matr2.GetLength(0))
{
    int[,]prodmatr=MultiplicationMatrix(matr1, matr2);
    PrintMatrix(prodmatr);
}
else Console.WriteLine("Матрицы перемножать нельзя!");
Console.WriteLine();
Console.ReadKey();
Console.Clear();

PrintMatrix(matr1);
Console.WriteLine();
int[] minPosition = new int[2];
minPosition = MinElement(matr1);
Console.WriteLine($"Строка с мин элементом {minPosition[0]}");
Console.WriteLine($"Столбец с мин элементом {minPosition[1]}");
int[,] matrix = DeleteRowCol(matr1, minPosition);
PrintMatrix(matrix);