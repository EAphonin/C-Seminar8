// Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.
int minValue = GetUserNumber("Введите минимальное значение массива: ", "Ошибка ввода");
int maxValue = GetUserNumber("Введите максимальное значение массива: ", "Ошибка ввода");

int[,] array = GetArray(4, 6, minValue, maxValue);

PrintArray(array);
Console.WriteLine();

int result = FindMinSumLine(array);

Console.WriteLine($"Строка с наименьшей суммой элементов: {result}");

int FindMinSumLine(int[,] arr)
{
    int count = 0;
    int sum = FindSumLine(array, 0);
    for (int i = 1; i < arr.GetLength(0); i++)
    {
        if (sum > FindSumLine(array, i))
        {
            sum = FindSumLine(array, i);
            count = i + 1;
        }
    }
    return count;
}

int FindSumLine(int[,] arr, int i)
{
    int sum = 0;
    for (int j = 0; j < arr.GetLength(1); j++)
    {
        sum += arr[i, j];
    }
    return sum;
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