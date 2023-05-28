// Задайте две матрицы. 
// Напишите программу, которая будет находить произведение двух матриц.

int m = GetPositivUserNumber("Введите количество строк первой матрицы: ", "Ошибка ввода");
int n = GetPositivUserNumber("Введите количество столбцов первой матрицы и строк второй матрицы: ", "Ошибка ввода");
int l = GetPositivUserNumber("Введите количество столбцов второй матрицы: ", "Ошибка ввода");
int minValue = GetUserNumber("Введите минимальное значение матрицы: ", "Ошибка ввода");
int maxValue = GetUserNumber("Введите максимальное значение матрицы: ", "Ошибка ввода");

int[,] matrixA = GetArray(m, n, minValue, maxValue);
int[,] matrixB = GetArray(n, l, minValue, maxValue);

PrintArray(matrixA);
Console.WriteLine();
PrintArray(matrixB);

int[,] result = GetProductMatrix(matrixA, matrixB);

Console.WriteLine("_____________");
PrintArray(result);

int[,] GetProductMatrix(int[,] matA, int[,] matB)
{
    int[,] res = new int[matA.GetLength(0), matB.GetLength(1)];

    for (int i = 0; i < res.GetLength(0); i++)
    {
        for (int j = 0; j < res.GetLength(1); j++)
        {
            int sum = 0;
            for (int k = 0; k < matA.GetLength(1); k++)
            {
                sum += matA[i, k] * matB[k, j];
            }
            res[i, j] = sum;
        }
    }
    return res;
}


int[,] GetArray(int m, int n, int minValue, int maxValue)
{
    int[,] array = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            array[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return array;
}

void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i, j]} ");
        }
        Console.WriteLine();
    }
}

int GetPositivUserNumber(string message, string errorMessage)
{
    while (true)
    {
        Console.Write(message);
        if (int.TryParse(Console.ReadLine(), out int userNumber) && userNumber >= 0)
            return userNumber;
        Console.WriteLine(errorMessage);
    }
}

int GetUserNumber(string message, string errorMessage)
{
    while (true)
    {
        Console.Write(message);
        if (int.TryParse(Console.ReadLine(), out int userNumber))
            return userNumber;
        Console.WriteLine(errorMessage);
    }
}