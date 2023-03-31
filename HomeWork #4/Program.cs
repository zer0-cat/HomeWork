using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork__4
{
    
    internal class Program
    {
        class Counter
        {
            public event EventHandler CounterReached;

            public int inputNumber;
            public void CountTo100()
            {

                for (int i = 0; i <= 100; i++)
                {
                    if (i == inputNumber)
                    {
                        OnCounterReached();
                        break;
                    }
                }
            }
            protected virtual void OnCounterReached()
            {
                CounterReached?.Invoke(this, EventArgs.Empty);
            }
        }

        class Handler1
        {
            public int inputNumber;

            public Handler1(int inputNumber)
            {
                this.inputNumber = inputNumber;
            }
            public void HandleCounterReached(object sender, EventArgs e)
            {
                Console.WriteLine($"Пора действовать, ведь уже {inputNumber}");
            }
        }

        class Handler2
        {
            public int inputNumber;

            public Handler2(int inputNumber)
            {
                this.inputNumber = inputNumber;
            }

            public void HandleCounterReached(object sender, EventArgs e)
            {
                Console.WriteLine($"Уже {inputNumber}, давно пора было начать!");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите любое число от 0 до 100: ");
            Counter counter = new Counter();
            
            try { counter.inputNumber = Int16.Parse(Console.ReadLine()); }
            catch (Exception){ Console.WriteLine("\n\aОшибка! Введите числовое значение от 0 до 100!"); return; }

            Handler1 handler1 = new Handler1(counter.inputNumber);
            Handler2 handler2 = new Handler2(counter.inputNumber);

            counter.CounterReached += handler1.HandleCounterReached;
            counter.CounterReached += handler2.HandleCounterReached;

            counter.CountTo100();

            Console.WriteLine("");
        }

       
    }
}
