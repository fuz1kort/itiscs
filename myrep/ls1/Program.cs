﻿/*const int n = 10;
double[] arr = new double[n];

arr[5] = 20;
Random r =new Random();

for(int i = 0; i < n; i++)
{
    arr[i] = r.Next(-100,100);
    Console.WriteLine($"arr[i] = {arr[i]}");
}


double sum = 0, kolPol = 0;
double max = int.MinValue;
for(int i=0; i < n; i++)
{
    sum += arr[i];
    if (arr[i] > 0)
        kolPol++;
    if (arr[i] > max)
        max = arr[i];
}
Console.WriteLine($"sum = {sum}  kolPol = {kolPol}  max = {max}");

int[] mas = { -3, -5, -6, -3, -7, -65, -11, -13 };

bool fl = false;
int fl2 = 1;
for (int i = 0; i < mas.Length; i++)
{
    Console.WriteLine($"mas[i] = {mas[i]}");
    if (mas[i] < 0)
    {
        fl = true;
        if (mas[i] >= 0)
            fl2 = 0;
 
    }
}
if(fl)
{
    Console.WriteLine("Есть отрицательное число");
}
else
{
    Console.WriteLine("Нет отрицательных чисел");
}

if (fl2==1)
{
    Console.WriteLine("все числа в массиве отрицательные");
}
else
{
    Console.WriteLine("не все числа в массиве отрицательные");
}


int[] mas = { -3, 5, 6, -3, -7, -65, 11, -13 };

double max = double.MinValue;
double min = double.MaxValue;
for (int i = 0; i < mas.Length; i++)
{
    if (mas[i] > max & mas[i]<0)
        max = mas[i];
    if (mas[i] < min & mas[i]>0)
        min = mas[i];
}
Console.WriteLine(min);
Console.WriteLine(max);

int[] mas = { -3, 5, 6, -3, -7, -65, 11, -13 };

int ind = 0;
double max = double.MinValue;
for (int i = 0; i < mas.Length; i++)
{
    if (mas[i] > max)
    {
        max = mas[i];
        ind = i;
    }
}
Console.WriteLine(ind+1);
Console.WriteLine(max);

int[] mas = { -3, -7, 6, -3, -7, 65, -7, 13 };
int cntmin = 0;
int posled = 0, pp = 0;
double min = double.MaxValue;
for (int i = 0; i < mas.Length; i++)
{
    if (mas[i] < min)
    {
        min = mas[i];
        cntmin = 0;
        posled = i;
    }
    if (mas[i] == min)
    {
        cntmin++;
        pp = posled;
        posled = i;
 
    }
}
Console.WriteLine(cntmin);
Console.WriteLine(pp +1);
static bool prost(double x)
{
    bool Ok = true;
    for (int i = 0; i < (int)Math.Sqrt(x) + 1; i++)
    {
        if (x % i == 0)
        {
            Ok = false;
            break;
        }
    }
    if (Ok)
        return true;
    else
        return false;
}
int[] mas = { 4, 6, 6, 8, 15 ,12 };
bool prostoy = true;
double min = double.MaxValue;
for (int i = 0; i < mas.Length; i++)
{
    if (prost(mas[i]))
    {
        Console.WriteLine("Есть простое число");
        prostoy = false;
        break;
    }
}
if (prostoy)
{
    Console.WriteLine("Нет простых чисел");
}

int[] mas = { 4, 6, 7, 8, 15, 12 };
bool flag = true;
for (int i = 0; i < mas.Length-1; i++)
{
    for (int j = i + 1; j < mas.Length; j++)
    {
        if (mas[i] == mas[j])
        {
            flag = false;
            break;
        }
    }
    if (!flag)
    {
        Console.WriteLine("Есть повторяющиеся числа");
        break;
    }
}
if (flag)
{
    Console.WriteLine("Нет повторяющихся чисел");
}*/

int[] mas = { 4, 6, 6, 4, 14, 14 };
bool flag1 = true;
for (int i = 0; i < mas.Length; i++)
{
    int cnt = 0;
    for (int j=0; j<mas.Length; j++)
    {
        if (i == j) { continue; }
        if (mas[i] != mas[j])
        {
            cnt++;
        }
    }
    if (cnt == mas.Length - 1) 
    {
        flag1 = false;
        Console.WriteLine("Есть уникальные числа");
        break;
    }
}
if (flag1)
{
    Console.WriteLine("Нет уникальных чисел");
}
