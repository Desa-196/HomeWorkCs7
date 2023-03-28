/*
Задана целочисленная матрица, состоящая из N строк и M столбцов. Требуется транспонировать ее относительно горизонтали.

Входные данные
Первая строка входного файла INPUT.TXT содержит два натуральных числа N и M – количество строк и столбцов матрицы. 
В каждой из последующих N строк записаны M целых чисел – элементы матрицы. Все числа во входных данных не превышают 100 по абсолютной величине.

Выходные данные
В выходной файл OUTPUT.TXT выведите матрицу, полученную транспонированием исходной матрицы относительно горизонтали.

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

void TranspositionMatrix(int[,] array)
{
    int temp;

    for (int i = 0; i < array.GetLength(0) / 2; i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            temp = array[i,j];
            array[i,j] = array[array.GetLength(0) - 1 - i, j] ;
            array[array.GetLength(0) - 1 - i, j]  = temp;
        }
    }
}

//Считываем из консоли размерность массива
int[] PositionArray = ReadPositionArrayElement();
//Создаем массив
int[,] array = new int[PositionArray[0], PositionArray[1]];
//Заполняем случайными числами
FillRandomArray(array, -100, 100);
//выводим получившийся массив
PrintArray(array);
Console.WriteLine();
//Транспонируем матрицу
TranspositionMatrix(array);
//выводим получившийся массив
PrintArray(array);

