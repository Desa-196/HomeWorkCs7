/*
Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, 
и возвращает значение этого элемента или же указание, что такого элемента нет.

Например, задан массив:

1 4 7 2
5 9 2 3
8 4 2 4
1 7 -> такой позиции нет

*/

int[] ReadPositionArrayElement()
{
    Console.Write("Введите 2 числа позиции элемента в двумерном массиве: ");

    int[] IntReadString = new int[2];
    while (true)
    {

        string[] ReadString = Console.ReadLine()!.Split();
        if (ReadString.Length != 2)
        {
            Console.Write("Необходимо ввести 2 числа позиции, повторите ввод: ");
        }
        else if (int.TryParse(ReadString[0], out IntReadString[0]) && int.TryParse(ReadString[1], out IntReadString[1]))
        {
            break;
        }
        else
        {
            Console.Write("Введены некорректные числа, повторите попытку ввода:");
        }
    }
    return IntReadString;
}

void FillRandomArray(int[,] array, int min, int max)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(min, max + 1);
        }
    }
}

//Выводит массив в консоль
void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i,j]}\t");
        }
        Console.WriteLine();
    }
}

//int? - может быть null Функция вернет значение элемента, или null если выходим за пределы индекса
int? GetElementArray(int[,] array, int m, int n )
{
    if(m < array.GetLength(0) && n < array.GetLength(1)) return array[m, n];
    else return null;
}

int[,] array = new int[10, 20];
FillRandomArray(array, -100, 100);
PrintArray(array);

int[] PositionArray = ReadPositionArrayElement();

int? element = GetElementArray(array, PositionArray[0], PositionArray[1]);

if(element != null) Console.WriteLine(element);
else Console.WriteLine("Такого элемента нет");




