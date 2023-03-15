using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    internal class HomeWork2
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размерность массива: ");

            //переменная для хранения размера массива.
            int arraySize = 0;

            try
            {
                arraySize = UInt16.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("\n\t\aОшибка, введите значение: 2 - 65535.\n");
                return;
            }

            //проверяем, чтобы размер массива был строго > 1, т.к. по условию нам нужно вывести ВТОРОЕ наибольшее значение.
            if (arraySize < 2)
            {
                Console.WriteLine("\n\t\aОшибка, введите значение: 2 - 65535.\n");
                return;
            }

            else
            {
                Console.Write("\nВведите значения числового массива: ");
                string numsArray = Console.ReadLine();
                string[] arraySplit = numsArray.Split(',', ' ');

                //проверяем размер введенного массива и записываем в переменную.
                int checkArraySize = arraySplit.Count();

                //сравниваем размер введенного массива с изначальным размером массива.
                if (checkArraySize <= arraySize)
                {
                    for (int i = 0; i < arraySplit.Length; i++)
                    {
                        try
                        {
                            Int32.Parse(arraySplit[i]);
                        }
                        catch (Exception)
                        {
                            Console.Write($"\n\t\aОшибка! Проверьте правильность ввода значений массива.\n\n");
                            return;
                        }
                    }

                }
                else
                {
                    Console.Write("\n\t\aОшибка! Вы ввели количество индексов, превышающее размерность массива.\n");
                    return;
                }

                //преобразуем строчный массив в интовый
                int[] intArray = new int[arraySplit.Length];
                for (int i = 0; i < arraySplit.Length; i++)
                {
                    intArray[i] = Convert.ToInt32(arraySplit[i]);
                }

                //создаём копию массива без дубликатов и будем работать с ней. Вдруг нам понадобится оригинальный массив
                int[] intArrayCopy = intArray.Distinct().ToArray();

                //сортируем, крутим, вертим
                Array.Sort(intArrayCopy);
                Array.Reverse(intArrayCopy);

                //проверяем размерность нового массива, дальше понятно зачем.
                int checkArrayCopySize = intArrayCopy.Count();

                //еще один if на предотвращение ошибки, в случае если все числа в массиве одинаковые.
                if (checkArrayCopySize > 1)
                {
                    Console.Write($"Второе наибольшее число в вашем массиве: {intArrayCopy[1]}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("\n\t\aОшибка! Невозможно вывести второе наибольшее число. В данном массиве только одно наибольшее число.\n");
                }

            }
        }

    }
}