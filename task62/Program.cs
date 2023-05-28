// Напишите программу, которая заполнит спирально массив 4 на 4.
int[,] array = GetArray(5, 5);

PrintArray(array);
Console.WriteLine();

int[,] GetArray(int m, int n)
{
    int[,] array = new int[m, n];
    int count = 1;
    int i = 0;
    int j = 0;
    while (count <= array.GetLength(0) * array.GetLength(1))
    {
        array[i, j] = count;
        count++;
        if (i <= j + 1 && i + j < array.GetLength(1) - 1)
            j++;
        else if (i < j && i + j >= array.GetLength(0) - 1)
            i++;
        else if (i >= j && i + j > array.GetLength(1) - 1)
            j--;
        else
            i--;
    }
    return array;
}

void PrintArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {   
            if (arr[i,j]<10)
            Console.Write($"0{arr[i, j]} ");
            else
            Console.Write($"{arr[i, j]} ");
        }
        Console.WriteLine();
    }
}
