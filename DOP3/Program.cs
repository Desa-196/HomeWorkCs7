/*
Задача №364. Заполнение диагоналями

Даны числа n и m. Создайте массив A[n][m] и заполните его, как показано на примере.

Пример:
4 10

0   1   3   6   10  14  18  22  26  30
2   4   7   11  15  19  23  27  31  34
5   8   12  16  20  24  28  32  35  37
9   13  17  21  25  29  33  36  38  39

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

void FillRandomArray(int[,] array)
{
    int count = 0;
    //Проходимся по всем столбцам и начиная с верхней строки двигаемся по диаганали
    for (int j = 0; j < array.GetLength(1); j++)
    {
        for (int i = 0, k = j; i < array.GetLength(0) && k >= 0; i++, k--)
        {
            array[i, k] = count;
            count++;
        }
    }
    // Как только прошлись по всем столбцам, дозаполняем диагонали начинающиеся с концов строк, кроме нулевой строки.
    for(int i=1; i < array.GetLength(0); i++)
    {
        for(int k=i, j=array.GetLength(1) - 1; k < array.GetLength(0) && j >= 0; k++, j--)
        {
            array[k, j] = count;
            count++;
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



//Считываем из консоли размерность массива
int[] PositionArray = ReadPositionArrayElement();
//Создаем массив
int[,] array = new int[PositionArray[0], PositionArray[1]];
//Заполняем случайными числами
FillRandomArray(array);
//выводим получившийся массив
PrintArray(array);