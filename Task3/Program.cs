/*
Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.

Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.
*/

int[] ReadPositionArrayElement()
{
    Console.Write("Введите 2 числа позиции элемента в двумерном массиве через пробел: ");

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
            Console.Write($"{array[i, j]}\t");
        }
        Console.WriteLine();
    }
}

//Функция возвращает массив со средне арифметическими значениями по столбцам
double[] ArithmeticalMean(int[,] array)
{
    double[] ArithmeticalMeanColumns = new double[array.GetLength(1)];

    for (int i = 0; i < array.GetLength(1); i++)
    {
        for (int j = 0; j < array.GetLength(0); j++)
        {
            ArithmeticalMeanColumns[i] += array[j, i];
        }
        ArithmeticalMeanColumns[i] = Math.Round(ArithmeticalMeanColumns[i] / array.GetLength(0), 2);
    }
    return ArithmeticalMeanColumns;
}


//Считываем из консоли размерность массива
int[] PositionArray = ReadPositionArrayElement();
//Создаем массив
int[,] array = new int[PositionArray[0], PositionArray[1]];
//Заполняем случайными числами
FillRandomArray(array, 0, 10);
//выводим получившийся массив
PrintArray(array);
Console.WriteLine();
//Выводим массив со средне арифметическими значениями по столбцам
Console.WriteLine(string.Join("\t",ArithmeticalMean(array)));


