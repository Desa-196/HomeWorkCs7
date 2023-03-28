/*
Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.

m = 3, n = 4.
0,5 7 -2 -0,2
1 -3,3 8 -9,9
8 7,8 -7,1 9

*/


int read_int_from_console(string message)
{
    int console_int = 0;

    Console.Write($"{message}: ");

    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out console_int))
        {
            break;
        }
        else
        {
            Console.Write("Введено некорректное число, повторите попытку ввода:");
        }
    }
    return console_int;

}
//Заполняем массив случайными вещественными числами от min до max
void FillRandomArray(double[,] array, int min, int max)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i,j] = Math.Round( new Random().NextDouble()*(max - min) + min, 2 );
        }
    }
}
//Выводит массив в консоль
void PrintArray(double[,] array)
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



double[,] array = new double[read_int_from_console("Введите размер массива m"), read_int_from_console("Введите размер массива n")];

Console.WriteLine();
FillRandomArray(array, -100, 100);
PrintArray(array);
