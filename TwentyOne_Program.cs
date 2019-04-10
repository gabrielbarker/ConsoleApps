using System;

namespace App1
{
    class MainClass
    {
        public static void Main(string[] args)
        {

                Logo();
                Console.WriteLine("Let's Play 21!");
                Console.WriteLine();
                Console.WriteLine("Hit 'R' for the rules or hit 'P' to play!");
                Console.WriteLine();

                bool imp = false;

                int yourChoice = 0;
                int compChoice = 0;
                int currentTotal = 0;
                Random rnd = new Random();

                char yourChoiceKey = 'Z';
                char firstKey = Console.ReadKey(true).KeyChar;
                char firstOrSecond = 'Z';

                char currentTurn = 'Z';

            PlayOrRules(firstKey);

            void FirstOrSecond()
            {
                Console.WriteLine("Hit 'F' to play first or 'S'to play second ... or press 'I' if you want to lose!");
                Console.WriteLine();

                firstOrSecond = Console.ReadKey(true).KeyChar;

                if (firstOrSecond == 'I' || firstOrSecond == 'i')
                {
                    imp = true;
                    firstOrSecond = 'F';
                }

                if (firstOrSecond == 'S' || firstOrSecond == 's')
                {
                    CompTurn();
                }
                else if (firstOrSecond == 'F' || firstOrSecond == 'f')
                {
                    YourTurn();
                }
                else
                {
                    Console.WriteLine("No, Hit 'F' or 'S'or 'I'");
                    Console.WriteLine();
                    FirstOrSecond();
                }
            }

            void YourTurn()
                {
                    Console.WriteLine("Choose 1, 2 or 3");
                    Console.WriteLine();

                yourChoiceKey = Console.ReadKey(true).KeyChar;

                yourChoice = YourChoice(yourChoiceKey);


                    currentTotal = yourChoice + currentTotal;
                    Console.WriteLine("So the current total is " + currentTotal.ToString());
                    Console.WriteLine();

                    currentTurn = 'C';

                if (Endgame(currentTotal) == false && imp == false)
                {
                    CompTurn();
                }
                else if (imp == true)
                {
                    Impossible();
                }
                else if (Endgame(currentTotal) == true)
                {
                    Ender(currentTurn, currentTotal);
                }

                }


                void CompTurn()
                {
                if (Endgame(currentTotal) == false)
                {
                    compChoice = rnd.Next(1, 4);
                    currentTotal = compChoice + currentTotal;
                    Console.WriteLine("I choose " + compChoice.ToString() + " so the current total is " + currentTotal.ToString());
                    Console.WriteLine();

                    currentTurn = 'Y';
                    YourTurn();
                }
                else
                {
                    Ender(currentTurn, currentTotal);
                }

            }

                void Impossible()
                {
                    compChoice = 4 - yourChoice;
                    currentTotal = compChoice + currentTotal;
                    Console.WriteLine("I choose " + compChoice.ToString() + " so the current total is " + currentTotal.ToString());
                    Console.WriteLine();

                    currentTurn = 'Y';

                if (Endgame(currentTotal) == false)
                {
                    YourTurn();
                }
                else
                {
                    Ender(currentTurn, currentTotal);
                }

            }

            void PlayOrRules(char f)
            {
                if (f == 'R' || f == 'r')
                {
                    Console.WriteLine("You and the computer take it in turns to say a number, 1, 2 or 3. " +
                        "The second number is added to the first, and so on until the number 21 is reached.");
                    Console.WriteLine("The object of the game is to NOT LAND ON 21!");
                    Console.WriteLine("Good Luck!");
                    Console.WriteLine();
                    Console.WriteLine();
                    f = 'P';
                }

                if (f == 'P' || f == 'p')
                {
                    FirstOrSecond();
                }
                else
                {
                    Console.WriteLine("No, Hit 'R' for the rules or hit 'P' to play!");
                    Console.WriteLine();
                    firstKey = Console.ReadKey(true).KeyChar;
                    PlayOrRules(firstKey);

                }
            }

            int YourChoice(char k)
            {
                if (char.IsDigit(k) == true)
                {
                    yourChoice = int.Parse(yourChoiceKey.ToString());

                    if (yourChoice <= 4)
                    {
                        return yourChoice;
                    }
                    else if (Endgame(currentTotal) == false)
                    {
                        Console.WriteLine("No, Choose 1, 2 or 3");
                        Console.WriteLine();
                        yourChoiceKey = Console.ReadKey(true).KeyChar;
                        return YourChoice(yourChoiceKey);
                    }
                    else if (21 - currentTotal == 2)
                    {
                        Console.WriteLine("No, Choose 1");
                        Console.WriteLine();
                        yourChoiceKey = Console.ReadKey(true).KeyChar;
                        return YourChoice(yourChoiceKey);
                    }
                    else if (21 - currentTotal == 3)
                    {
                        Console.WriteLine("No, Choose 1 or 2");
                        Console.WriteLine();
                        yourChoiceKey = Console.ReadKey(true).KeyChar;
                        return YourChoice(yourChoiceKey);
                    }
                    else
                    {
                        Console.WriteLine("Error263");
                        return 0;
                    }
                }
                else
                {
                    Console.WriteLine("No, Choose 1, 2 or 3");
                    Console.WriteLine();
                    yourChoiceKey = Console.ReadKey(true).KeyChar;
                    return YourChoice(yourChoiceKey);
                }
            }

            bool Endgame(int t)
            {
                if (t <= 17)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            void Ender(char turn, int total)
            {
                if (turn == 'Y')
                {
                    if (total == 18)
                    {
                        Console.WriteLine("Choose 1 or 2");
                        Console.WriteLine();
                        yourChoiceKey = Console.ReadKey(true).KeyChar;
                        currentTotal = (yourChoiceKey);
                        currentTurn = 'C';
                    }
                    else if (total == 19)
                    {
                        Console.WriteLine("Choose 1 or 2");
                        Console.WriteLine();
                        yourChoiceKey = Console.ReadKey(true).KeyChar;
                        currentTotal = (yourChoiceKey);
                        currentTurn = 'C';
                    }
                    else if (total == 20)
                    {
                        Console.WriteLine("Ha, you have to say 21...I WIN!");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to play again");
                        Console.WriteLine();
                        Again();
                    }
                }
                else if (currentTurn == 'C')
                {
                    if (total == 18)
                    {
                        compChoice = rnd.Next(1, 3);
                        currentTotal = compChoice + currentTotal;
                        Console.WriteLine("I choose " + compChoice.ToString() + " so the current total is " + currentTotal.ToString());
                        Console.WriteLine();
                        currentTurn = 'Y';
                        Ender(currentTurn, currentTotal);
                    }
                    else if (total == 19)
                    {
                        compChoice = 1;
                        currentTotal = compChoice + currentTotal;
                        Console.WriteLine("I choose " + compChoice.ToString() + " so the current total is " + currentTotal.ToString());
                        Console.WriteLine();
                        currentTurn = 'Y';
                        Ender(currentTurn, currentTotal);

                    }
                    else if (total == 20)
                    {
                        Console.WriteLine("Aw, I have to say 21...YOU WIN!");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to play again");
                        Console.WriteLine();
                        Again();
                    }
                    else
                    {
                        Console.WriteLine("Error 344");
                    }
                }
                else
                {
                    Console.WriteLine("Error 349");
                }
            }
                void Logo()
                {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("         222222          11111");
                    Console.WriteLine("       2222222222       111111");
                    Console.WriteLine("      22222  22222     1111111");
                    Console.WriteLine("     22222    2222    11111111");
                    Console.WriteLine("             22222       11111");
                    Console.WriteLine("           22222         11111");
                    Console.WriteLine("         22222           11111");
                    Console.WriteLine("       22222             11111");
                    Console.WriteLine("     22222   2222        11111");
                    Console.WriteLine("    2222222222222        11111");
                    Console.WriteLine("    2222222222222        11111");
                    Console.WriteLine("----------------------------------------");
                }

            void Again()
            {
                Console.ReadKey(true);
                Console.Clear();
                currentTotal = 0;
                Logo();
                FirstOrSecond();
            }

        }
    }
}
