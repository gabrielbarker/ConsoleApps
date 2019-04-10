using System;

namespace Fibonacci
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int i = 0;
            long i1;
            long i2;
            long n1 = 0;
            long n2 = 1;
            long c = 0;
            char input;
            int c1;
            int k;

            Run();

            void Run()
            {
                i = 0;
                n1 = 0;
                n2 = 1;
                c = 0;

                Logo();

                Console.WriteLine("Welcome to the Fibonacci system.");
                Console.WriteLine("Press 'L' for a list of 90 Fibonacci numbers");
                Console.WriteLine("Press 'C' to check whether a number is Fibonacci or not");
                Console.WriteLine("Press 'N' for the n-th Fibonacci number");
                Console.WriteLine("Press 'I' to set the initial conditions of the sequence");
                Console.WriteLine();
                Console.WriteLine("Press 'M' at any time to return here");
                Console.WriteLine();
                input = Console.ReadKey(true).KeyChar;

                if(input == 'L' || input == 'l')
                {
                    List();
                }
                else if (input == 'C' || input == 'c')
                {
                    Console.WriteLine("Which number would you like to check?");
                    Console.WriteLine();
                    c1 = int.Parse(Console.ReadLine());
                    Check(c1);
                }
                else if (input == 'N' || input == 'n')
                {
                    Console.WriteLine("Which number in the sequence would you like to know?");
                    Console.WriteLine();
                    k = int.Parse(Console.ReadLine());
                    Nth(k);
                }
                else if (input == 'I' || input == 'i')
                {
                    Initial();
                }
                else
                {
                    Console.Clear();
                    Run();
                }

                Console.ReadKey(true);
                Console.Clear();
                Run();
            }

            void Generator (int m, long a, long b)
            {
                while(i < m)
                {
                    Console.Write(b + " ");

                    c = a + b;
                    a = b;
                    b = c;
                    c = 0;
                    i++;
                }
            }

            void List()
            {
                Generator(90, 0, 1);
                Console.WriteLine();
                i = 0;
            }

            void Check(int n)
            {
                c = 0;
                n1 = 0;
                n2 = 1;

                while (n2 <= n)
                {
                    c = n1 + n2;
                    n1 = n2;
                    n2 = c;
                    c = 0;

                    if (n2 == n)
                    {
                        Console.WriteLine(n + " is Fibonacci");
                        Console.ReadKey(true);
                        Console.Clear();
                        Run();
                    }
                    
                }

                Console.WriteLine(n + " is not Fibonacci");
                Console.ReadKey(true);
                Console.Clear();
                Run();
            }

            void Nth(int d)
            {
                n1 = 0;
                n2 = 1;

                while (i < d-2 || i == 0)
                {  
                    c = n1 + n2;
                    n1 = n2;
                    n2 = c;
                    c = 0;
                    i++;
                }


                Console.Write((n1 + n2) + " is the " + d + "-th Fibonacci number");
                Console.WriteLine();

                Console.ReadKey(true);
                Console.Clear();
                Run();

            }

            void Initial()
            {
                Console.WriteLine("What is the first initial condition?");
                Console.WriteLine();
                i1 = int.Parse(Console.ReadLine());
                Console.WriteLine("What is the second initial condition?");
                Console.WriteLine();
                i2 = int.Parse(Console.ReadLine());

                Console.WriteLine();

                Generator(50, i1, i2);

            }


            void Logo()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("00000  0000  0000    000   00    0      0      000    000    0000");
                Console.WriteLine("00      00   00 00  00  0  00 0  0     00     00  0  00  0    00");
                Console.WriteLine("0000    00   0000   00  0  00  0 0    00 0    00     00       00 ");
                Console.WriteLine("00      00   00 00  00  0  00    0   00   0   00  0  00  0    00");
                Console.WriteLine("00     0000  0000    000   00    0  00     0   000    000    0000");
                Console.WriteLine("-----------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;

            }
        }
    }
}
