/*
Задача 19
Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом.
14212 -> нет
12821 -> да
23432 -> да

Задача 21
Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.
A (3,6,8); B (2,1,-7), -> 15.84
A (7,-5, 0); B (1,-1,9) -> 11.53

Задача 23
Напишите программу, которая принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.
3 -> 1, 8, 27
5 -> 1, 8, 27, 64, 125

Дополнительная задача (25): Напишите программу, которая на вход принимает радиус круга 
и находит его площадь округленную до целого числа, необходимо вывести максимальную цифру в полученном 
округлённом значении площади круга
10 -> 4
20 -> 7
30 -> 8

Дополнительная задача (27): Напишите программу, которая на вход принимает букву, 
необходимо создать массив из 5 названий городов, и вывести на экран те (тот), 
где чаще всего встречается введённая буква.

Введённая буква: "о", массив ("Москва", "Тюмень", "Новосибирск") -> "Новосибирск"
*/

Console.Clear();
Console.WriteLine("Какую задачу запустить (19, 21, 23, 25, 27) ?");
int task = int.Parse(Console.ReadLine());
if (task == 19)
{
    Task19();
}
else if (task == 21)
{
    Task21();
}
else if (task == 23)
{
    Task23();
}
else if (task == 25)
{
    Task25();
}
else if (task == 27)
{
    Task27();
}

void Task19()
{
    Console.Write("Введите пятизначное число: ");
    int numbers = int.Parse(Console.ReadLine());
    if (numbers / 10000 > 10 || numbers / 10000 < 1)
    {
        Console.WriteLine("Вы ввели не пятизначное число");
        return;
    }
    if (numbers / 10000 == numbers % 10)
    {
        if ((numbers / 1000) % 10 == (numbers / 10) % 10)
        {
            Console.WriteLine("Да, это число палиндром");
        }
    }
    else
    {
        Console.WriteLine("Нет, это не число палиндром");
    }
}

void Task21()
{
    Console.Write("Введите координату x1: ");
    double x1 = double.Parse(Console.ReadLine());
    Console.Write("Введите координату y1: ");
    double y1 = double.Parse(Console.ReadLine());
    Console.Write("Введите координату z1: ");
    double z1 = double.Parse(Console.ReadLine());
    Console.Write("Введите координату x2: ");
    double x2 = double.Parse(Console.ReadLine());
    Console.Write("Введите координату y2: ");
    double y2 = double.Parse(Console.ReadLine());
    Console.Write("Введите координату z2: ");
    double z2 = double.Parse(Console.ReadLine());

    double result = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2) + Math.Pow((z2 - z1), 2));

    Console.WriteLine(Math.Round(result, 2));
}

void Task23()
{
    Console.Write("Введите число от 1 до N: ");
    int number = int.Parse(Console.ReadLine());
    if (number < 0)
    {
        number = -number;
    }
    else if (number == 0)
    {
        Console.WriteLine("Вы ввели 0");
    }
    int count = 1;
    while (count <= number)
    {
        Console.Write((count * count * count) + " ");
        count++;
    }
}

void Task25()
{
    Console.Write("Введите радиус круга: ");
    double r = double.Parse(Console.ReadLine());
    if (r <= 0) Console.WriteLine("Вы ввели не верное число");
    double s = Math.Round((Math.PI * Math.Pow(r, 2)), 0);
    int value;
    value = (int)s;
    int x = 10;
    int max = value % x;             // 248
    while (value > 0)
    {
        if ((value / x) % 10 > max) max = (value / x) % 10;
        value = value / 10;
    }
    //Console.WriteLine(s);
    Console.WriteLine($"Площадь круга = {s}, максимальная цифра в площади круга = {max}");
}

void Task27()
{
    Console.Write("Введите букву: ");
    string letter = Console.ReadLine();
    string[] cityes = { "Новосибирск", "Москва", "Тюмень", "Иркутск", "Владивосток" };
    int[] value = { 0, 0, 0, 0, 0 };
    for (int a = 0; a < cityes.Length; a++)
    {
        string city = cityes[a];
        city = city.ToLower();
        for (int b = 0; b < city.Length; b++)
        {
            if (Convert.ToString(city[b]) == letter.ToLower())
            {
                value[a] = value[a] + 1;
            }
        }
    }
    int MaxNumber(int a, int b, int c, int d, int e)
    {
        int max = a;
        int[] array = {a, b, c, d, e};
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max) max = array[i];
        }
        return max;
    }
    int cityNumber = MaxNumber(value[0], value[1], value[2], value[3], value[4]);
    for (int j = 0; j < value.Length; j++)
    {
        if (cityNumber == value[j]) Console.WriteLine(cityes[j]);
    }
}