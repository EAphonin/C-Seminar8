//Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

int x = GetPositivUserNumber("Задайте размер трехмерного массива X*Y*Z. Введите X: ", "Ошибка ввода");
int y = GetPositivUserNumber("Задайте размер трехмерного массива X*Y*Z. Введите Y: ", "Ошибка ввода");
int z = GetPositivUserNumber("Задайте размер трехмерного массива X*Y*Z. Введите Z: ", "Ошибка ввода");

int[,,] array = GetArray(x, y, z, 10, 99);

PrintArray(array);

int[,,] GetArray(int x, int y, int z, int minValue, int maxValue)
{
    int[,,] array = new int[x, y, z];
    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < y; j++)
        {
            for (int k = 0; k < z; k++)
            {
                int number = new Random().Next(minValue, maxValue + 1);
                while (ArrayCheckNumber(array, number))
                {
                    number = new Random().Next(minValue, maxValue + 1);
                }
                array[i, j, k] = number;
            }
        }
    }
    return array;
}

bool ArrayCheckNumber(int[,,] arr, int numb)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            for (int k = 0; k < arr.GetLength(2); k++)
            {
                if (arr[i, j, k] == numb)
                    return true;
            }
        }
    }
    return false;
}

void PrintArray(int[,,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            for (int k = 0; k < inArray.GetLength(2); k++)
            {
                Console.Write($"{inArray[i, j, k]}({i} {j} {k}) ");
            }
            Console.WriteLine();
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
