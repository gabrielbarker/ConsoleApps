using System;

namespace PokerDice
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] yourDice = new int[6];
            int[] compDice = new int[6];

            int[] yourScore = new int[6];
            int[] compScore = new int[6];

            int yourHigh = 1;
            int compHigh = 1;

            int yourHighValue = 1;
            int compHighValue = 1;

            int yourSecHigh = 0;
            int compSecHigh = 0;

            int yourHighDice = 1;
            int compHighDice = 1;

            int[] yourNotMain = new int[3];
            int[] compNotMain = new int[3];

            int index1 = 0;
            int index2 = 0;

            string playerString;
            string playerString1;

            int rank;
            int yourRank;
            int compRank;

            string[,] yourDisplay = new string[3, 5];
            string[,] compDisplay = new string[3, 5];

            bool yourFullHouse = false;
            bool compFullHouse = false;

            int yourTotal = 0;
            int compTotal = 0;

            Logo();

            Console.WriteLine("Welcome to Poker Dice!");
            Console.WriteLine();
            Console.WriteLine("Press any key to roll...");

            Console.ReadKey(true);

            Run();

            void Run()
            {

                yourHigh = 1;
                compHigh = 1;

                yourHighValue = 1;
                compHighValue = 1;

                yourSecHigh = 0;
                compSecHigh = 0;

                yourHighDice = 1;
                compHighDice = 1;

                index1 = 0;
                index2 = 0;

                rank = 0;
                yourRank = 0;
                compRank = 0;



                for (int i = 0; i < 6; i++)
                {
                    yourScore[i] = 0;
                    compScore[i] = 0;
                }

                Roll();
                AssignScore();

                Console.ReadKey(true);


                Console.Clear();

                Run();
            }

            void Roll()
            {
                for(int i = 0; i < 5; i++)
                {
                    yourDice[i] = rnd.Next(1, 7);
                    compDice[i] = rnd.Next(1, 7);
                }

                
            }

            void AssignScore()
            {
            for (int j = 1; j < 7; j++)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (yourDice[i] == j)
                        {
                            yourScore[j-1]++;
                        }

                        if (compDice[i] == j)
                        {
                            compScore[j-1]++;
                        }
                    }

                }

                for (int j = 1; j < 7; j++)
                {
                    if (yourScore[j-1] > yourHigh)
                    {
                        yourHigh = yourScore[j-1];
                        yourHighValue = j;
                    }
                    if (compScore[j-1] > compHigh)
                    {
                        compHigh = compScore[j-1];
                        compHighValue = j;
                    }
                }



                switch (yourHigh)
                {
                    case 1:
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                if (yourDice[i] > yourHighDice)
                                {
                                    yourHighDice = yourDice[i];
                                }
                            }

                            yourHighValue = yourHighDice;

                                break;
                        }
                    case 2:
                        {
                            for (int j = 1; j < 6; j++)
                            {
                                if (yourDice[j - 1] != yourHighValue)
                                {
                                    yourNotMain[index1] = yourDice[j-1];
                                    index1++;
                                }
                            }

                            index1 = 0;

                            for(int m = 0; m < 3; m++)
                                for (int n = 0; n < 3; n++)
                                {
                                    if(m != n)
                                    {
                                        if (yourNotMain[m] == yourNotMain[n])
                                        {
                                            yourSecHigh = yourNotMain[m];
                                        }
                                    }

                                }


                            break;
                        }
                    case 3:
                        {
                            for (int j = 1; j < 7; j++)
                            {
                                if(yourDice[j-1] != yourHighValue)
                                {
                                    yourNotMain[index1] = j;
                                    index1++;
                                }

                            }

                            index1 = 0;

                            if(yourNotMain[0] == yourNotMain[1])
                            {
                                yourSecHigh = yourNotMain[0];
                            }

                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                //TranslateSimpleScore(yourHigh, yourHighValue, 2, yourSecHigh);

                switch (compHigh)
                {
                    case 1:
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                if (compDice[i] > compHighDice)
                                {
                                    compHighDice = compDice[i];
                                }
                            }

                            compHighValue = compHighDice;

                            break;
                        }
                    case 2:
                        {
                            for (int j = 1; j < 6; j++)
                            {
                                if (compDice[j - 1] != compHighValue)
                                {
                                    compNotMain[index2] = compDice[j-1];
                                    index2++;
                                }
                            }

                            index2 = 0;

                            for (int m = 0; m < 3; m++)
                                for (int n = 0; n < 3; n++)
                                {
                                    if(m != n)
                                    {
                                        if (compNotMain[m] == compNotMain[n])
                                        {
                                            compSecHigh = compNotMain[m];
                                        }
                                    }

                                }


                            break;
                        }
                    case 3:
                        {
                            for (int j = 1; j < 7; j++)
                            {
                                if (compDice[j - 1] != compHighValue)
                                {
                                    compNotMain[index2] = j;
                                    index2 = 1;
                                }

                            }

                            if (compNotMain[0] == compNotMain[1])
                            {
                                compSecHigh = compNotMain[0];
                            }

                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                DrawYourDice();
                TranslateSimpleScore(yourHigh, yourHighValue, 2, yourSecHigh, 'Y');
                Console.WriteLine();

                DrawCompDice();
                TranslateSimpleScore(compHigh, compHighValue, 2, compSecHigh, 'C');
                Console.WriteLine();

                index1 = 0;
                index2 = 0;

                if (yourRank > compRank)
                {
                    Console.WriteLine("You Win!");
                    yourTotal++;
                }
                else if (yourRank < compRank)
                {
                    Console.WriteLine("I Win!");
                    compTotal++;
                }
                else if (yourRank == compRank)
                {
                    if(yourFullHouse == true && compFullHouse == true)
                    {
                        if (yourHigh > compHigh)
                        {
                            Console.WriteLine("You Win!");
                            yourTotal++;
                        }
                        else if (compHigh > yourHigh)
                        {
                            Console.WriteLine("I Win!");
                            compTotal++;
                        }
                        else if (compHigh == yourHigh)
                        {
                            Console.WriteLine("It's a Draw!");
                        }

                    }
                    else
                    {
                        Console.WriteLine("It's a Draw!");
                    }
                }

                Console.WriteLine("                                                       You: " + yourTotal + ", Computer: " + compTotal);
                Console.WriteLine();
            }

           void Score()
            {

            }

            void TranslateSimpleScore(int x, int y, int z, int w, char player)
            {
                if(player == 'Y')
                {
                    playerString = "You";
                    playerString1 = "Your";
                }
                else
                {
                    playerString = "I";
                    playerString1 = "My";
                }

                if (w == 0)
                {
                    if (x != 1)
                    {
                        if(x == 2)
                        {
                            Console.WriteLine(playerString + " have a pair of " + y + "'s");
                            rank = 20 + y;
                        }
                        else
                        {
                            Console.WriteLine(playerString + " have " + x + " " + y + "'s!");
                            rank = (x * 10) + y;
                        }
                    }
                    else if(IsStraight() == true)
                    {
                        Console.WriteLine(playerString + " have a " + y + "-high straight!");
                        rank = 32 + y;
                    }
                    else
                    {
                        Console.WriteLine(playerString1 + " highest dice is a " + y);
                        rank = y;
                    }
                }
                else if(x == 3)
                {
                    Console.WriteLine(playerString + " have a full house! With 3 " + y + "'s and 2 " + w +"'s");
                    rank = 39;
                    if (player == 'Y')
                        yourFullHouse = true;
                    else if (player == 'C')
                        compFullHouse = true;
                    
                }
                else if(x == 2)
                {
                    Console.WriteLine(playerString + " have a pair of " + y + "'s and a pair of " + w + "'s!");
                    rank = 18 + y + w;
                }

                if(player == 'C')
                {
                    compRank = rank;
                }
                else if(player == 'Y')
                {
                    yourRank = rank;
                }

                rank = 0;
            }

            bool IsStraight()
            {
                for(int j = 0; j < 5; j++)
                    for(int i = 0; i < 5; i++)
                    {
                        if(i != j)
                        {
                            if (yourDice[i] - yourDice[j] == 0 || yourDice[i] - yourDice[j] == 5 || yourDice[i] - yourDice[j] == -5)
                            {
                                return false;
                            }
                        }

                    }
                return true;
            }

            void DrawYourDice()
            {
                for(int i = 0; i < 5; i++)
                {
                    if (yourDice[i] > 3)
                    {
                        yourDisplay[0, i] = "0   0";
                        yourDisplay[2, i] = "0   0";

                        if(yourDice[i] == 4)
                        {
                            yourDisplay[1, i] = "     ";
                        }
                        else if (yourDice[i] == 5)
                        {
                            yourDisplay[1, i] = "  0  ";
                        }
                        else if(yourDice[i] == 6)
                        {
                            yourDisplay[1, i] = "0   0";
                        }
                    }
                    else if (yourDice[i] != 1)
                    {
                        yourDisplay[0, i] = "0    ";
                        yourDisplay[2, i] = "    0";

                        if (yourDice[i] == 2)
                        {
                            yourDisplay[1, i] = "     ";
                        }
                        else
                        {
                            yourDisplay[1, i] = "  0  ";
                        }
                    }
                    else if (yourDice[i] == 1)
                    {
                        yourDisplay[0, i] = "     ";
                        yourDisplay[1, i] = "  0  ";
                        yourDisplay[2, i] = "     ";
                    }
                }

                Console.WriteLine(" _______        _______        _______        _______        _______       ");
                Console.WriteLine("|       |      |       |      |       |      |       |      |       |      ");
                Console.WriteLine("| " + yourDisplay[0, 0] + " |      | " + yourDisplay[0, 1] + " |      | " + yourDisplay[0, 2] + " |      | " + yourDisplay[0, 3] + " |      | " + yourDisplay[0, 4] + " |      ");
                Console.WriteLine("| " + yourDisplay[1, 0] + " |      | " + yourDisplay[1, 1] + " |      | " + yourDisplay[1, 2] + " |      | " + yourDisplay[1, 3] + " |      | " + yourDisplay[1, 4] + " |      ");
                Console.WriteLine("| " + yourDisplay[2, 0] + " |      | " + yourDisplay[2, 1] + " |      | " + yourDisplay[2, 2] + " |      | " + yourDisplay[2, 3] + " |      | " + yourDisplay[2, 4] + " |      ");
                Console.WriteLine("|       |      |       |      |       |      |       |      |       |      ");
                Console.WriteLine(" -------        -------        -------        -------        -------       ");
                Console.WriteLine("                                                                  YOUR DICE");

                }


            void DrawCompDice()
            {
                for (int i = 0; i < 5; i++)
                {
                    if (compDice[i] > 3)
                    {
                        compDisplay[0, i] = "0   0";
                        compDisplay[2, i] = "0   0";

                        if (compDice[i] == 4)
                        {
                            compDisplay[1, i] = "     ";
                        }
                        else if (compDice[i] == 5)
                        {
                            compDisplay[1, i] = "  0  ";
                        }
                        else if (compDice[i] == 6)
                        {
                            compDisplay[1, i] = "0   0";
                        }
                    }
                    else if (compDice[i] != 1)
                    {
                        compDisplay[0, i] = "0    ";
                        compDisplay[2, i] = "    0";

                        if (compDice[i] == 2)
                        {
                            compDisplay[1, i] = "     ";
                        }
                        else
                        {
                            compDisplay[1, i] = "  0  ";
                        }
                    }
                    else if (compDice[i] == 1)
                    {
                        compDisplay[0, i] = "     ";
                        compDisplay[1, i] = "  0  ";
                        compDisplay[2, i] = "     ";
                    }
                }

                Console.WriteLine(" _______        _______        _______        _______        _______       ");
                Console.WriteLine("|       |      |       |      |       |      |       |      |       |      ");
                Console.WriteLine("| " + compDisplay[0, 0] + " |      | " + compDisplay[0, 1] + " |      | " + compDisplay[0, 2] + " |      | " + compDisplay[0, 3] + " |      | " + compDisplay[0, 4] + " |      ");
                Console.WriteLine("| " + compDisplay[1, 0] + " |      | " + compDisplay[1, 1] + " |      | " + compDisplay[1, 2] + " |      | " + compDisplay[1, 3] + " |      | " + compDisplay[1, 4] + " |      ");
                Console.WriteLine("| " + compDisplay[2, 0] + " |      | " + compDisplay[2, 1] + " |      | " + compDisplay[2, 2] + " |      | " + compDisplay[2, 3] + " |      | " + compDisplay[2, 4] + " |      ");
                Console.WriteLine("|       |      |       |      |       |      |       |      |       |      ");
                Console.WriteLine(" -------        -------        -------        -------        -------       ");
                Console.WriteLine("                                                            OPPONENT'S DICE");

            }


            void Logo()
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("       ____   ____            ____    ____   ");
                Console.WriteLine("      /   /  /    /   /  /   /       /   /   ");
                Console.WriteLine("     /___/  /    /   /__/   /___    /___/");
                Console.WriteLine("    /      /    /   /\\     /       /\\");
                Console.WriteLine("   /      /____/   /  \\   /____   /  \\");
                Console.WriteLine(" _______     _______     _______     _______ ");
                Console.WriteLine("|       |   |       |   |       |   |       |");
                Console.WriteLine("| 0 0   |   |   0   |   | 0 0 0 |   | 0 0 0 |");
                Console.WriteLine("| 0   0 |   |   0   |   | 0     |   | 00    |");
                Console.WriteLine("| 0 0   |   |   0   |   | 0 0 0 |   | 0 0 0 |");
                Console.WriteLine("|_______|   |_______|   |_______|   |_______|");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }


        }
    }
}
