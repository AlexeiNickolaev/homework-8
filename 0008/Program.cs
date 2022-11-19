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
// Сформировать трехмерный массив и вывести его на экран
int[,,]Create3DMatrix(int rows, int columns, int depth, int min, int max)
{
    int[,,] matrix = new int[rows, columns, depth];
    Random rnd= new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                matrix[i, j, k]= rnd.Next(min, max);
            }
        }
    }
    return matrix;
}
void Print3DMatrix(int[,,]matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write("[");
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                Console.Write($"{matrix[i, j, k],4} ({i}, {j}, {k}), ");
            }
        }
        Console.WriteLine("]");
    }
}
//Показать треугольник Паскаля. Сделать вывод в виде равнобедренного треугольника
void FillTriangle(int[,] triangle) 
{ 
    for (int i = 1; i < triangle.GetLength(0); i++) 
    {
        for (int j = 1; j < i + 1; j++)
        { 
             triangle[i, j] = triangle[i - 1, j] + triangle[i - 1, j - 1]; 
        } 
        
        for (int k = 1; k < triangle.GetLength(0); k++)  
        { 
            triangle[k, 0] = 1;
        } 
    }
} 
void PrintTriagle(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int k = array.GetLength(0); k > i; k--)
            Console.Write("  ");
        for (int j = 0; j < array.GetLength(1); j++)
            if (array[i, j] != 0)
            {
                Console.Write("{0,4}", array[i, j]);
            }
        Console.WriteLine();
    }
}

Console.WriteLine("Найти произведение двух матриц");
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

Console.WriteLine("В двумерном массиве целых чисел удалить строку и столбец, на пересечении которых расположен наименьший элемент.");
PrintMatrix(matr1);
Console.WriteLine();
int[] minPosition = new int[2];
minPosition = MinElement(matr1);
Console.WriteLine($"Строка с минимальным элементом: {minPosition[0]}");
Console.WriteLine($"Столбец с мининимальным элементом: {minPosition[1]}");
int[,] matrix = DeleteRowCol(matr1, minPosition);
Console.WriteLine("Если удалить строку и столбец с минимальным элементом, то получится матрица: ");
PrintMatrix(matrix);
Console.ReadKey();
Console.Clear();

Console.WriteLine("Сформировать трехмерный массив и вывести его на экран");
int[,,]matrix3D=Create3DMatrix(2, 2, 3, 1, 10);
Print3DMatrix(matrix3D);
Console.ReadKey();
Console.Clear();

Console.WriteLine("Показать треугольник Паскаля.Сделать вывод в виде равнобедренного треугольника");
Console.Write("Введите кол-во строк: ");
int n = int.Parse(Console.ReadLine() ?? "0"); 
Console.WriteLine();
int[,] triangle = new int[n+1, 2*n+1]; 
FillTriangle(triangle); 
PrintTriagle(triangle);