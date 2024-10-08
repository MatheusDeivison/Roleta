﻿using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace MasterClasses
{
    public static class Shorts
    {
        public static void Write(string str)
        {
            Console.Write(str);
        }
        public static void AddSpace(int num)
        {
            do
            {
                Console.WriteLine();
                num--;
            } while (num > 0);

        }
        public static string ConsoleInput()
        {
            string conInput = Console.ReadLine();
            return conInput;
        }
    }
    public static class FullScreen
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;

        public static void WideScreenMethod()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
        }
    }
    public static class DivideScreen
    {
        public static int consoleWidth = Console.WindowWidth;
        public static int dividedWidth = consoleWidth / 2;
        public static string spaces = ' '.Repeat(dividedWidth);
    }

    public static class CharExtensions
    {
        public static string Repeat(this char c, int count)
        {
            return new String(c, count);
        }
    }

    public static class ASCII_Art
    {
        //Text Color White
        public static void TextColorWhite()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Text Color Red
        public static void TextColorRed()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }

        //Text Color Black
        public static void TextColorBlack()
        {
            Console.ForegroundColor = ConsoleColor.Black;
        }

        //Background Black
        public static void BackColorBlack()
        {
            Console.BackgroundColor = ConsoleColor.Black;
        }

        //Background Green
        public static void BackColorGreen()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
        }

        //Background Red
        public static void BackColorRed()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
        }
     
          
    public static class TryAgainMessage
    {
        public static string tryAgainResponse = "S";
        public static bool TryAgain()
        {
            Console.WriteLine("Jogar de novo? [S] ou [N]");
            var response = Console.ReadLine().ToUpper();
            if (response == "N")
            {
                return false;
            }
            else
            {
                Console.Clear();
                return true;
            }
        }
    }
    public static class Account
    {
        //Define a variável dinheiro como um número inteiro
        public static int currentMoney = 500;
        //Este método mostra o saldo da conta a partir do dinheiro variável na classe de conta
        public static void Bank()
        {
            Shorts.Write($"Saldo em Conta: ${currentMoney}.00\n");
        }
        public static int CheckMoneyStatus()
        {
            return currentMoney;
        }
        //Este método irá adicionar o dinheiro da conta corrente e o valor que foi apostado
        public static void Add(int bet)
        {
            currentMoney = currentMoney + bet;
        }
        public static void Subtract(ref int wage)
        {
            if ((currentMoney - wage) < 0)
            {
                wage = currentMoney;
                Shorts.AddSpace(1);
                Shorts.Write($"Desculpe, mas de acordo com nosso banco você não tem o suficiente para fazer essa aposta.  Sua conta mostra: $" + wage + ".00\n");
            }
            else
            {
                currentMoney = currentMoney - wage;
            }
        }
    }
    public static class GameOverConditions
    {
        public static bool DetermineIfGameOver()
        {
            //Se o dinheiro for zero ou menos, retorne verdadeiro
            if (Account.currentMoney <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool GameOver()
        {
            Console.WriteLine("GAME OVER - Obrigado por jogar");
            return Game.rouletteConditional = false;

        }
    }
    public static class Game
    {
        public static bool rouletteConditional = true;
        public static int currentBankAmount = Account.CheckMoneyStatus();
        public static int amountWaged;
        public static int ballNumber = 0;
        public static void AddMoney(ref int money)
        {
            if (money > 0)
            {
                Account.currentMoney = money;
                Shorts.AddSpace(1);
                Shorts.Write($"Legal! Sua conta mostra: $" + money + ".00\n");
            }
            else
            {
                GameOverConditions.DetermineIfGameOver();
            }
        }
        public static void WageSelection()
        {
            Shorts.Write("Quanto você gostaria de apostar? \n");
            if (currentBankAmount > 0)
            {

                amountWaged = Convert.ToInt32(Shorts.ConsoleInput());

                if (amountWaged > 0)
                {
                    Console.Clear();
                    //se o valor atual for igual ao valor apostado - All in!
                    if (amountWaged == Account.CheckMoneyStatus())
                    {
                        if (GameOverConditions.DetermineIfGameOver() == true)
                        {
                            Shorts.AddSpace(1);
                            Shorts.Write("CERTO, VOCÊ ESTÁ DENTRO\n");
                            Shorts.Write("Boa Sorte!!!\n");
                            Shorts.AddSpace(1);

                            Account.Subtract(ref amountWaged);
                            Game.SelectionBetMenu();
                        }
                        else
                        {
                            rouletteConditional = false;
                        }
                    }
                    else if (amountWaged > Convert.ToInt32(Account.CheckMoneyStatus()))
                    {
                        //Console.WriteLine(amountWaged);
                        //Console.WriteLine(Account.CheckMoneyStatus());
                        Console.WriteLine("Desculpe, mas essa aposta é maior do que o que está em sua conta");
                        Account.Bank();
                        TryAgainMessage.TryAgain();
                    }
                    else
                    {
                        Account.Subtract(ref amountWaged);
                        int newBalance = currentBankAmount - amountWaged;
                        Console.WriteLine($"Você fez uma aposta de: ${amountWaged}.00 deixando um saldo de ${newBalance}.00");
                        Shorts.AddSpace(1);
                        Game.SelectionBetMenu();
                    }
                }
                else
                {
                    GameOverConditions.GameOver();
                }

            }
        }
        public static void SelectionBetMenu()
        {
            Shorts.Write("FAÇA SUA APOSTA:\n");
            Shorts.Write("[ 1]  Escolha um número\n" +
                    "[ 2]  Red\n" +
                    "[ 3]  Black\n" +
                    "[ 4]  Even\n" +
                    "[ 5]  Odd\n" +
                    "[ 6]  Low (1 até 18)\n" +
                    "[ 7]  High (19 até 36)\n" +
                    "[ 8]  Dozens\n" +
                    "[ 9]  Columns\n" +
                    "[10]  Street\n" +
                    "[11]  6 Números\n" +
                    "[12]  Splits\n" +
                    "[13]  Corners\n" +
                    "[14]  PLAY ALL BETS");
            Shorts.AddSpace(2);
         
            Console.WriteLine();
            RouletteGame();
        }
        public static int BallLandsOnThisNUmber()
        {
            Random randAll = new Random();
            //37 and 38 are 0 and 00
            int[] all_numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38 };
            int randomNum = randAll.Next(1, all_numbers.Length);

            //Used to Debug - wage max and pick a number - number 0
            //int[] all_numbers = { 35 };
            //var randomNum = random.Next(35, 35);
            int ballNumber = randomNum;
            return ballNumber;
        }
        public static void BallDrops()
        {
            Console.WriteLine("TODAS AS APOSTAS ESTÃO FECHADAS!");
            Console.WriteLine("A roda gira....");
            Console.WriteLine("Bola cai");
            if (BallLandsOnThisNUmber() == 37)
            {
                Console.WriteLine($"A bola caiu em: 00");
            }
            else if (BallLandsOnThisNUmber() == 38)
            {
                Console.WriteLine($"A bola caiu em: 0");
            }
            else
            {
                Console.WriteLine($"A bola caiu em: {BallLandsOnThisNUmber()}");
            }
        }
        public static void PlayAgainQuestion()
        {

            if (currentBankAmount <= 0)
            {
                GameOverConditions.GameOver();
            }
            else if (currentBankAmount - amountWaged <= 0)//amount - current 
            {
                GameOverConditions.GameOver();
            }
            else
            {
                Console.WriteLine("Quer jogar de novo?");
                var response = Console.ReadLine();
                var responseConverted = response.ToUpper();
                if (responseConverted == "S")
                {
                    Console.Clear();
                   
                    Account.Bank();
                    WageSelection();
                }
                else if (responseConverted == "N")
                {
                    GameOverConditions.GameOver();

                }
                else
                {
                    Console.WriteLine("Forma incorreta, digite [S] ou [N]");
                    PlayAgainQuestion();
                }
            }
        }
        public static void PickANUmber()
        {
            Console.WriteLine("Escolha um número: 0, 00 ou 1 a 36");
            string pickANumber;
            pickANumber = Console.ReadLine();
            int ballNumber = BallLandsOnThisNUmber();
            if (pickANumber == "0" || pickANumber == "00")
            {
                switch (pickANumber)
                {
                    case "00":
                        Console.WriteLine($"Você selecionou 00");
                        BallDrops();
                        if (ballNumber == 37)
                        {
                            Console.WriteLine($"VOCÊ GANHOU ${amountWaged * 35}.00!");
                            currentBankAmount = (amountWaged * 35) + currentBankAmount;
                            Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        }
                        else
                        {
                            Console.WriteLine("Desculpe, você perdeu");
                            Account.Bank();
                        }
                        break;
                    case "0":
                        Console.WriteLine($"Você selecionou Zero");
                        BallDrops();
                        if (ballNumber == 0)
                        {
                            Console.WriteLine($"VOCÊ GANHOU ${amountWaged * 35}.00!");
                            currentBankAmount = (amountWaged * 35) + currentBankAmount;
                            Console.WriteLine($"Você tem ${currentBankAmount}.00");
                            Game.AddMoney(ref currentBankAmount);
                            Account.Bank();
                        }
                        else
                        {
                            Console.WriteLine("Desculpe, você perdeu");
                            Account.Bank();
                        }
                        break;
                }
            }
            else if (pickANumber == "1" || pickANumber == "2" || pickANumber == "3" || pickANumber == "4" || pickANumber == "5" || pickANumber == "6" || pickANumber == "7" || pickANumber == "8" || pickANumber == "9" || pickANumber == "10" || pickANumber == "11" || pickANumber == "12" || pickANumber == "13" || pickANumber == "14" || pickANumber == "15" || pickANumber == "16" || pickANumber == "17" || pickANumber == "18" || pickANumber == "19" || pickANumber == "20" || pickANumber == "21" || pickANumber == "22" || pickANumber == "23" || pickANumber == "24" || pickANumber == "25" || pickANumber == "26" || pickANumber == "27" || pickANumber == "28" || pickANumber == "29" || pickANumber == "30" || pickANumber == "31" || pickANumber == "32" || pickANumber == "33" || pickANumber == "34" || pickANumber == "35" || pickANumber == "36")
            {
                int pickANumberConverted = Convert.ToInt32(pickANumber);
                if (pickANumberConverted > 0 && pickANumberConverted < 37)
                {
                    Console.WriteLine($"Você selecionou {pickANumberConverted}");

                    BallDrops();
                    if (ballNumber == pickANumberConverted)
                    {
                        Console.WriteLine($"VOCÊ GANHOU ${amountWaged * 35}.00!");
                        currentBankAmount = (amountWaged * 35) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                    }
                    else
                    {
                        if (currentBankAmount - amountWaged <= 0)//amount - current 
                        {
                            GameOverConditions.GameOver();
                            rouletteConditional = false;
                        }
                        else
                        {
                            Console.WriteLine("Desculpe, você perdeu");
                            Account.Bank();


                        }
                    }

                }
                else
                {
                    Console.WriteLine($"Esse não é o formato correto.  Você digitou {pickANumber}");
                    PickANUmber();
                }
            }
            else
            {
                Console.WriteLine($"Esse não é o formato correto.  Você digitou {pickANumber}");
                PickANUmber();
            }

        }
        public static void Red()
        {
            //RED CODE
            int[] red_nums = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };

            Console.WriteLine("Você selecionou Red");
            BallLandsOnThisNUmber();
            BallDrops();

            if (red_nums.Any(i => i == ballNumber))
            {
                Console.WriteLine($"É RED - VOCÊ GANHOU! ${amountWaged * 2}.00!");
                currentBankAmount = (amountWaged * 2) + currentBankAmount;
                Console.WriteLine($"Você tem ${currentBankAmount}.00");
                Game.AddMoney(ref currentBankAmount);
                Account.Bank();



            }
            else if (red_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
            {
                Console.WriteLine("Desculpe, é Black, você perdeu");
                Account.Bank();

            }
            else
            {
                Console.WriteLine("VERDE, desculpe, você perdeu");
                Account.Bank();

            }
        }
        public static void Black()
        {
            //BLACK CODE
            int[] black_nums = { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };


            Console.WriteLine("Você selecionou Black");
            BallLandsOnThisNUmber();
            BallDrops();

            if (black_nums.Any(i => i == ballNumber))
            {
                Console.WriteLine($"É BLACK - VOCÊ GANHOU! ${amountWaged * 2}.00!");
                currentBankAmount = (amountWaged * 2) + currentBankAmount;
                Console.WriteLine($"Você tem ${currentBankAmount}.00");
                Game.AddMoney(ref currentBankAmount);
                Account.Bank();
            }
            else if (black_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
            {
                Console.WriteLine("Desculpe, é Red, você perdeu");
                Account.Bank();

            }
            else
            {
                Console.WriteLine("VERDE, desculpe, você perdeu");
                Account.Bank();

            }

        }
        public static void Even()
        {
            //Even CODE
            int[] even_nums = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36 };

            Console.WriteLine("Você selecionou Even");
            BallLandsOnThisNUmber();
            BallDrops();

            if (even_nums.Any(i => i == ballNumber))
            {
                Console.WriteLine($"É EVEN - VOCÊ GANHOU! ${amountWaged * 2}.00!");
                currentBankAmount = (amountWaged * 2) + currentBankAmount;
                Console.WriteLine($"Você tem ${currentBankAmount}.00");
                Game.AddMoney(ref currentBankAmount);
                Account.Bank();
            }
            else if (even_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
            {
                Console.WriteLine("Desculpe, é Odd, voce perdeu");
                Account.Bank();

            }
            else
            {
                Console.WriteLine("VERDE, desculpe, você perdeu");
                Account.Bank();

            }

        }
        public static void Odd()
        {
            //Odd CODE
            int[] odd_nums = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35 };

            Console.WriteLine("Você selecionou Odd");
            BallLandsOnThisNUmber();
            BallDrops();

            if (odd_nums.Any(i => i == ballNumber))
            {
                Console.WriteLine($"É ODD - VOCÊ GANHOU! ${amountWaged * 2}.00!");
                currentBankAmount = (amountWaged * 2) + currentBankAmount;
                Console.WriteLine($"Você tem ${currentBankAmount}.00");
                Game.AddMoney(ref currentBankAmount);
                Account.Bank();
            }
            else if (odd_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
            {
                Console.WriteLine("Desculpe, é Even, voce perdeu");
                Account.Bank();

            }
            else
            {
                Console.WriteLine("VERDE, desculpe, você perdeu");
                Account.Bank();

            }

        }
        public static void Low()
        {
            //Low CODE
            int[] low_nums = { 1, 2, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };

            Console.WriteLine("Você selecionou Low");
            BallLandsOnThisNUmber();
            BallDrops();

            if (low_nums.Any(i => i == ballNumber))
            {
                Console.WriteLine($"É LOW - VOCÊ GANHOU! ${amountWaged * 2}.00!");
                currentBankAmount = (amountWaged * 2) + currentBankAmount;
                Console.WriteLine($"Você tem ${currentBankAmount}.00");
                Game.AddMoney(ref currentBankAmount);
                Account.Bank();
            }
            else if (low_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
            {
                Console.WriteLine("Desculpe, é High, voce perdeu");
                Account.Bank();

            }
            else
            {
                Console.WriteLine("VERDE, desculpe, você perdeu");
                Account.Bank();

            }

        }
        public static void High()
        {
            //High CODE
            int[] high_nums = { 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36 };

            Console.WriteLine("Você selecionou High");
            BallLandsOnThisNUmber();
            BallDrops();

            if (high_nums.Any(i => i == ballNumber))
            {
                Console.WriteLine($"É HIGH - VOCÊ GANHOU! ${amountWaged * 2}.00!");
                currentBankAmount = (amountWaged * 2) + currentBankAmount;
                Console.WriteLine($"Você tem ${currentBankAmount}.00");
                Game.AddMoney(ref currentBankAmount);
                Account.Bank();
            }
            else if (high_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
            {
                Console.WriteLine("Desculpe, é Low, voce perdeu");
                Account.Bank();

            }
            else
            {
                Console.WriteLine("VERDE, desculpe, você perdeu");
                Account.Bank();

            }
        }
        public static void Dozens()
        {
            Console.WriteLine("Escolha uma Dúzia:");
            Console.WriteLine("[1] 1 até 12");
            Console.WriteLine("[2] 13 até 24");
            Console.WriteLine("[3] 25 até 36");
            string pickADozen;
            pickADozen = Console.ReadLine();
            if (pickADozen == "1" || pickADozen == "2" || pickADozen == "3")
            {
                Console.WriteLine($"Você selecionou {pickADozen}");
                if (pickADozen == "1")
                {
                    //1-12 Code
                    int[] lowDozen_nums = { 1, 2, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

                    Console.WriteLine("Você selecionou 1 até 12");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (lowDozen_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É 1 até 12 - VOCÊ GANHOU! ${amountWaged * 2}.00!");
                        currentBankAmount = (amountWaged * 2) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (lowDozen_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são 1 até 12, voce perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                }
                else if (pickADozen == "2")
                {
                    //13-24 Code
                    int[] midDozen_nums = { 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };

                    Console.WriteLine("Você selecionou 13 até 24");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (midDozen_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É 13 até 24 - VOCÊ GANHOU! ${amountWaged * 2}.00!");
                        currentBankAmount = (amountWaged * 2) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (midDozen_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são 13 até 24, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }

                }
                else
                {
                    //25-36 Code
                    int[] highDozen_nums = { 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38 };

                    Console.WriteLine("Você selecionou 25 até 36");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (highDozen_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É 25 até 36 - VOCÊ GANHOU! ${amountWaged * 2}.00!");
                        currentBankAmount = (amountWaged * 2) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (highDozen_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são 25 até 36, voce perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                }
            }
            else
            {
                if (pickADozen == "0")
                {
                    Console.WriteLine($"Você selecionou {pickADozen}");
                }
                else
                {
                    Console.WriteLine($"Você selecionou {pickADozen}");
                    Console.WriteLine("Isso não é uma escolha, tente novamente");
                    Dozens();
                }
            }
        }
        public static void Columns()
        {
            Console.WriteLine("Escolha uma coluna:");
            Console.WriteLine("[1] Coluna 1");
            Console.WriteLine("[2] Coluna 2");
            Console.WriteLine("[3] Coluna 3");
            string pickColumnn;
            pickColumnn = Console.ReadLine();
            if (pickColumnn == "1" || pickColumnn == "2" || pickColumnn == "3")
            {


                Console.WriteLine($"Você selecionou {pickColumnn}");
                if (pickColumnn == "1")
                {
                    //Coluna 1 Code
                    int[] column1_nums = { 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34 };

                    Console.WriteLine("Você selecionou Coluna 1");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (column1_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É Coluna 1 - VOCÊ GANHOU! ${amountWaged * 3}.00!");
                        currentBankAmount = (amountWaged * 3) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (column1_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são Coluna 1, voce perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();

                    }

                }
                else if (pickColumnn == "2")
                {
                    //Coluna 2 Code
                    int[] column2_nums = { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 };

                    Console.WriteLine("Você selecionou Coluna 2");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (column2_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É Coluna 2- VOCÊ GANHOU! ${amountWaged * 3}.00!");
                        currentBankAmount = (amountWaged * 3) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (column2_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são Coluna 2, voce perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();

                    }
                }
                else
                {
                    //Coluna 3 Code
                    int[] column3_nums = { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36 };

                    Console.WriteLine("Coluna 3");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (column3_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É Coluna 3 - VOCÊ GANHOU! ${amountWaged * 3}.00!");
                        currentBankAmount = (amountWaged * 3) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (column3_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são Coluna 3, voce perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                }
            }
            else
            {
                if (pickColumnn == "0")
                {
                    Console.WriteLine($"Você selecionou {pickColumnn}");
                }
                else
                {
                    Console.WriteLine($"Você selecionou {pickColumnn}");
                    Console.WriteLine("Isso não é uma escolha, tente novamente");
                    Columns();
                }
            }
        }
        public static void Street()
        {
            Console.WriteLine("Escolha uma fileira:");
            Console.WriteLine("[ 1] Número 1 até 3");
            Console.WriteLine("[ 2] Número 4 até 6");
            Console.WriteLine("[ 3] Número 7 até 9");
            Console.WriteLine("[ 4] Número 10 até 12");
            Console.WriteLine("[ 5] Número 13 até 15");
            Console.WriteLine("[ 6] Número 16 até 18");
            Console.WriteLine("[ 7] Número 19 até 21");
            Console.WriteLine("[ 8] Número 22 até 24");
            Console.WriteLine("[ 9] Número 25 até 27");
            Console.WriteLine("[10] Número 28 até 30");
            Console.WriteLine("[11] Número 31 até 33");
            Console.WriteLine("[12] Número 34 até 36");

            string pickStreet;
            pickStreet = Console.ReadLine();
            if (pickStreet == "1" || pickStreet == "2" || pickStreet == "3" || pickStreet == "4" || pickStreet == "5" || pickStreet == "6" || pickStreet == "7" || pickStreet == "8" || pickStreet == "9" || pickStreet == "10" || pickStreet == "11" || pickStreet == "12")
            {
                Console.WriteLine($"Você selecionou {pickStreet}");
                if (pickStreet == "1")
                {
                    //Street 1 Code
                    int[] street1_nums = { 1, 2, 3 };

                    Console.WriteLine("Você selecionou Fileira 1");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (street1_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É Fileira 1 - VOCÊ GANHOU! ${amountWaged * 11}.00!");
                        currentBankAmount = (amountWaged * 11) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (street1_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são Fileira 1, voce perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                }
                else if (pickStreet == "2")
                {
                    //Street 2 Code
                    int[] street2_nums = { 4, 5, 6 };

                    Console.WriteLine("Você selecionou Fileira 2");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (street2_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É Fileira 2- VOCÊ GANHOU! ${amountWaged * 11}.00!");
                        currentBankAmount = (amountWaged * 11) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (street2_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são Fileira 2, voce perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }

                }
                else if (pickStreet == "3")
                {
                    //Street 3 Code
                    int[] street3_nums = { 7, 8, 9 };

                    Console.WriteLine("Você selecionou Fileira 3");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (street3_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É Fileira 3 - VOCÊ GANHOU! ${amountWaged * 11}.00!");
                        currentBankAmount = (amountWaged * 11) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (street3_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são Fileira 3, voce perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }

                }
                else if (pickStreet == "4")
                {
                    //Street 4 Code
                    int[] street4_nums = { 10, 11, 12 };

                    Console.WriteLine("Você selecionou Fileira 4");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (street4_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É Fileira 4 - VOCÊ GANHOU! ${amountWaged * 11}.00!");
                        currentBankAmount = (amountWaged * 11) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (street4_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são Fileira 4, voce perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                }
                else if (pickStreet == "5")
                {
                    //Street 5 Code
                    int[] street5_nums = { 13, 14, 15 };

                    Console.WriteLine("Você selecionou Fileira 5");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (street5_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É Fileira 5 - VOCÊ GANHOU! ${amountWaged * 11}.00!");
                        currentBankAmount = (amountWaged * 11) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (street5_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são Fileira 5, voce perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                }
                else if (pickStreet == "6")
                {
                    //Street 6 Code
                    int[] street6_nums = { 16, 17, 18 };

                    Console.WriteLine("Você selecionou Fileira 6");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (street6_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É Fileira 6 - VOCÊ GANHOU! ${amountWaged * 11}.00!");
                        currentBankAmount = (amountWaged * 11) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (street6_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são Fileira 6, voce perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                }
                else if (pickStreet == "7")
                {
                    //Street 7 Code
                    int[] street7_nums = { 19, 20, 21 };

                    Console.WriteLine("Você selecionou Fileira 7");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (street7_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É Fileira 7 - VOCÊ GANHOU! ${amountWaged * 11}.00!");
                        currentBankAmount = (amountWaged * 11) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (street7_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são Fileira 7, voce perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                }
                else if (pickStreet == "8")
                {
                    //Street 8 Code
                    int[] street8_nums = { 22, 23, 24 };

                    Console.WriteLine("Você selecionou Fileira 8");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (street8_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É Fileira 8 - VOCÊ GANHOU! ${amountWaged * 11}.00!");
                        currentBankAmount = (amountWaged * 11) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (street8_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são Fileira 8, voce perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                }
                else if (pickStreet == "9")
                {
                    //Street 9 Code
                    int[] street9_nums = { 25, 26, 27 };

                    Console.WriteLine("Você selecionou Fileira 9");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (street9_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É Fileira 9 - VOCÊ GANHOU! ${amountWaged * 11}.00!");
                        currentBankAmount = (amountWaged * 11) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (street9_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são Fileira 9, voce perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                }
                else if (pickStreet == "10")
                {
                    //Street 10 Code
                    int[] street10_nums = { 28, 29, 30 };

                    Console.WriteLine("Você selecionou Fileira 10");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (street10_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É Fileira 10 - VOCÊ GANHOU! ${amountWaged * 11}.00!");
                        currentBankAmount = (amountWaged * 11) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (street10_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são Fileira 10, voce perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                }
                else if (pickStreet == "11")
                {
                    //Street 11 Code
                    int[] street11_nums = { 31, 32, 33 };

                    Console.WriteLine("Você selecionou Fileira 11");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (street11_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É Fileira 11 - VOCÊ GANHOU! ${amountWaged * 11}.00!");
                        currentBankAmount = (amountWaged * 11) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (street11_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são Fileira 11, voce perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                }
                else if (pickStreet == "12")
                {
                    //Street 12 Code
                    int[] street12_nums = { 34, 35, 36 };

                    Console.WriteLine("Você selecionou Fileira 12");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (street12_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É Fileira 12 - VOCÊ GANHOU! ${amountWaged * 11}.00!");
                        currentBankAmount = (amountWaged * 11) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (street12_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são Fileira 12, voce perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                }
            }
            else
            {
                if (pickStreet == "0")
                {
                    Console.WriteLine($"Você selecionou {pickStreet}");
                }
                else
                {
                    Console.WriteLine($"Você selecionou {pickStreet}");
                    Console.WriteLine("Isso não é uma escolha, tente novamente");
                    Street();
                }
            }
        }
        public static void SixLine()
        {
            Console.WriteLine("Escolha uma linha de seis números:");
            Console.WriteLine("[ 1] Número 1 até 6");
            Console.WriteLine("[ 2] Número 4 até 9");
            Console.WriteLine("[ 3] Número 7 até 12");
            Console.WriteLine("[ 4] Número 10 até 15");
            Console.WriteLine("[ 5] Número 13 até 18");
            Console.WriteLine("[ 6] Número 16 até 21");
            Console.WriteLine("[ 7] Número 19 até 24");
            Console.WriteLine("[ 8] Número 22 até 27");
            Console.WriteLine("[ 9] Número 25 até 30");
            Console.WriteLine("[10] Número 28 até 33");
            Console.WriteLine("[11] Número 31 até 36");

            string pickSixLine;
            pickSixLine = Console.ReadLine();
            if (pickSixLine == "1" || pickSixLine == "2" || pickSixLine == "3" || pickSixLine == "4" || pickSixLine == "5" || pickSixLine == "6" || pickSixLine == "7" || pickSixLine == "8" || pickSixLine == "9" || pickSixLine == "10" || pickSixLine == "11")
            {

                Console.WriteLine($"Você selecionou {pickSixLine}");
                if (pickSixLine == "1")
                {
                    //Six Line 1 Code
                    int[] sixLine1_nums = { 1, 2, 3, 4, 5, 6 };

                    Console.WriteLine("Você selecionou linha de seis 1");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (sixLine1_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É linha de seis 1 - VOCÊ GANHOU! ${amountWaged * 5}.00!");
                        currentBankAmount = (amountWaged * 5) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (sixLine1_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são linha de seis 1, voce perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();

                    }

                }
                else if (pickSixLine == "2")
                {

                    //Six Line 2 Code
                    int[] sixLine2_nums = { 4, 5, 6, 7, 8, 9 };

                    Console.WriteLine("Você selecionou linha de seis 2");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (sixLine2_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É linha de seis 2- VOCÊ GANHOU! ${amountWaged * 5}.00!");
                        currentBankAmount = (amountWaged * 5) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (sixLine2_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são linha de seis 2, voce perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();

                    }

                }
                else if (pickSixLine == "3")
                {
                    //Six Line 3 Code
                    int[] sixLine3_nums = { 7, 8, 9, 10, 11, 12 };

                    Console.WriteLine("Você selecionou linha de seis 3");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (sixLine3_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É linha de seis 3 - VOCÊ GANHOU! ${amountWaged * 5}.00!");
                        currentBankAmount = (amountWaged * 5) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (sixLine3_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são linha de seis 3, voce perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }

                }
                else if (pickSixLine == "4")
                {
                    //Six Line 4 Code
                    int[] sixLine4_nums = { 10, 11, 12, 13, 14, 15 };

                    Console.WriteLine("Você selecionou linha de seis 4");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (sixLine4_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É linha de seis 4 - VOCÊ GANHOU! ${amountWaged * 5}.00!");
                        currentBankAmount = (amountWaged * 5) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (sixLine4_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são linha de seis 4, voce perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                }
                else if (pickSixLine == "5")
                {
                    //Six Line 5 Code
                    int[] sixLine5_nums = { 13, 14, 15, 16, 17, 18 };

                    Console.WriteLine("Você selecionou linha de seis 5");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (sixLine5_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É linha de seis 5 - VOCÊ GANHOU! ${amountWaged * 5}.00!");
                        currentBankAmount = (amountWaged * 5) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (sixLine5_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são linha de seis 5, voce perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                }
                else if (pickSixLine == "6")
                {
                    //Six Line 6 Code
                    int[] sixLine6_nums = { 16, 17, 18, 19, 20, 21 };

                    Console.WriteLine("Você selecionou linha de seis 6");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (sixLine6_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É linha de seis 6 - VOCÊ GANHOU! ${amountWaged * 5}.00!");
                        currentBankAmount = (amountWaged * 5) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (sixLine6_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são linha de seis 6, voce perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                }
                else if (pickSixLine == "7")
                {
                    //Six Line 7 Code
                    int[] sixLine7_nums = { 19, 20, 21, 22, 23, 24 };

                    Console.WriteLine("Você selecionou linha de seis 7");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (sixLine7_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É linha de seis 7 - VOCÊ GANHOU! ${amountWaged * 5}.00!");
                        currentBankAmount = (amountWaged * 5) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (sixLine7_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são linha de seis 7, voce perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                }
                else if (pickSixLine == "8")
                {
                    //Six Line 8 Code
                    int[] sixLine8_nums = { 22, 23, 24, 25, 26, 27 };

                    Console.WriteLine("Você selecionou linha de seis 8");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (sixLine8_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É linha de seis 8 - VOCÊ GANHOU! ${amountWaged * 5}.00!");
                        currentBankAmount = (amountWaged * 5) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (sixLine8_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são linha de seis 8, voce perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                }
                else if (pickSixLine == "9")
                {
                    //Six Line 9 Code
                    int[] sixLine9_nums = { 25, 26, 27, 28, 29, 30 };

                    Console.WriteLine("Você selecionou linha de seis 9");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (sixLine9_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É linha de seis 9 - VOCÊ GANHOU! ${amountWaged * 5}.00!");
                        currentBankAmount = (amountWaged * 5) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (sixLine9_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são linha de seis 9, voce perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                }
                else if (pickSixLine == "10")
                {
                    //Six Line 10 Code
                    int[] sixLine10_nums = { 28, 29, 30, 31, 32, 33 };

                    Console.WriteLine("Você selecionou linha de seis 10");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (sixLine10_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É Fileira 10 - VOCÊ GANHOU! ${amountWaged * 5}.00!");
                        currentBankAmount = (amountWaged * 5) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (sixLine10_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são linha de seis 10, voce perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                }
                else if (pickSixLine == "11")
                {
                    //Six Line 11 Code
                    int[] sixLine11_nums = { 31, 32, 33, 34, 35, 36 };

                    Console.WriteLine("Você selecionou linha de seis 11");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (sixLine11_nums.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É linha de seis 11 - VOCÊ GANHOU! ${amountWaged * 5}.00!");
                        currentBankAmount = (amountWaged * 5) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (sixLine11_nums.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine("Desculpe, não são linha de seis 11, voce perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                }
            }
            else
            {
                if (pickSixLine == "0")
                {
                    Console.WriteLine($"Você selecionou {pickSixLine}");
                }
                else
                {
                    Console.WriteLine($"Você selecionou {pickSixLine}");
                    Console.WriteLine("Isso não é uma escolha, tente novamente");
                    SixLine();
                }
            }
        }
        public static void Spilts()
        {
            Console.WriteLine("Escolha uma divisão");
            Console.WriteLine("Digite dois números com o número mais baixo primeiro");
            Console.WriteLine("exemplo se você quiser dividir os números 4 e 7 digite: \"4 7\"");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1 2":
                    int[] nums1 = { 1, 2 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums1.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums1.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "1 4":
                    int[] nums2 = { 1, 4 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums2.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums2.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "2 3":
                    int[] nums3 = { 2, 3 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums3.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums3.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "3 6":
                    int[] nums4 = { 3, 6 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums4.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums4.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "4 5":
                    int[] nums5 = { 4, 5 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums5.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums5.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "5 6":
                    int[] nums6 = { 5, 6 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums6.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums6.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "4 7":
                    int[] nums7 = { 4, 7 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums7.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums7.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "7 8":
                    int[] nums8 = { 7, 8 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums8.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums8.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "5 8":
                    int[] nums9 = { 5, 8 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums9.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums9.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "6 9":
                    int[] nums10 = { 6, 9 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums10.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums10.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "8 9":
                    int[] nums11 = { 8, 9 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums11.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums11.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "7 10":
                    int[] nums12 = { 7, 10 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums12.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums12.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "10 11":
                    int[] nums13 = { 10, 11 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums13.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums13.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "8 11":
                    int[] nums14 = { 8, 11 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums14.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums14.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "11 12":
                    int[] nums15 = { 11, 12 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums15.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums15.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "9 12":
                    int[] nums16 = { 9, 12 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums16.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums16.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "10 13":
                    int[] nums17 = { 10, 13 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums17.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums17.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "11 14":
                    int[] nums18 = { 11, 14 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums18.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums18.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "12 15":
                    int[] nums19 = { 12, 15 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums19.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums19.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "13 14":
                    int[] num20 = { 13, 14 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (num20.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (num20.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "14 15":
                    int[] nums21 = { 14, 15 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums21.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums21.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "13 16":
                    int[] nums22 = { 13, 16 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums22.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums22.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "14 17":
                    int[] nums23 = { 14, 17 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums23.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums23.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "15 18":
                    int[] nums24 = { 15, 18 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums24.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums24.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "16 17":
                    int[] nums25 = { 16, 17 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums25.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums25.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "17 18":
                    int[] nums26 = { 17, 18 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums26.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums26.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "16 19":
                    int[] nums27 = { 16, 19 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums27.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums27.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "17 20":
                    int[] nums28 = { 17, 20 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums28.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums28.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "18 21":
                    int[] nums29 = { 18, 21 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums29.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums29.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "19 20":
                    int[] nums30 = { 19, 20 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums30.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums30.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "20 21":
                    int[] nums31 = { 20, 21 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums31.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums31.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "19 22":
                    int[] nums32 = { 19, 22 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums32.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums32.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "20 23":
                    int[] nums33 = { 20, 23 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums33.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums33.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "21 24":
                    int[] nums34 = { 21, 24 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums34.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums34.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "22 23":
                    int[] nums35 = { 22, 23 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums35.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums35.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "23 24":
                    int[] nums36 = { 23, 24 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums36.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums36.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "22 25":
                    int[] nums37 = { 22, 25 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums37.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums37.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "23 26":
                    int[] nums38 = { 23, 26 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums38.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums38.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "24 27":
                    int[] nums39 = { 24, 27 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums39.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums39.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "25 26":
                    int[] nums40 = { 25, 26 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums40.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums40.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "26 27":
                    int[] nums41 = { 26, 27 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums41.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums41.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "25 28":
                    int[] nums42 = { 25, 28 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums42.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums42.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "26 29":
                    int[] nums43 = { 26, 29 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums43.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums43.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "27 30":
                    int[] nums44 = { 27, 30 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums44.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums44.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "28 29":
                    int[] nums45 = { 28, 29 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums45.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums45.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "29 30":
                    int[] nums46 = { 29, 30 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums46.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums46.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "28 31":
                    int[] nums47 = { 28, 31 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums47.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums47.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "29 32":
                    int[] nums48 = { 29, 32 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums48.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums48.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "30 33":
                    int[] nums49 = { 30, 33 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums49.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums49.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "31 32":
                    int[] nums50 = { 31, 32 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums50.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums50.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "32 33":
                    int[] nums51 = { 32, 33 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums51.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums51.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "31 34":
                    int[] nums52 = { 31, 34 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums52.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums52.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "32 35":
                    int[] nums53 = { 32, 35 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums53.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums53.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "33 36":
                    int[] nums54 = { 33, 36 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums54.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums54.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "34 35":
                    int[] nums55 = { 34, 35 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums55.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums55.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "35 36":
                    int[] nums56 = { 35, 36 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();

                    if (nums56.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É {input} - VOCÊ GANHOU! ${amountWaged * 17}.00!");
                        currentBankAmount = (amountWaged * 17) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums56.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é {input}, você perdeu");
                        Account.Bank();

                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                default:
                    Console.WriteLine($"Esse não é o formato correto.  Você digitou {input}");
                    Spilts();
                    break;
            }
        }
        public static void Corner()
        {
            Console.WriteLine("Escolha:");
            Console.WriteLine("[ 1] Número 1, 2, 4, 5");
            Console.WriteLine("[ 2] Número 2, 3, 5, 6");
            Console.WriteLine("[ 3] Número 4, 5, 7, 8");
            Console.WriteLine("[ 4] Número 5, 6, 8, 9");
            Console.WriteLine("[ 5] Número 7, 8, 10, 11");
            Console.WriteLine("[ 6] Número 8, 9, 11, 12");
            Console.WriteLine("[ 7] Número 10, 11, 13, 14");
            Console.WriteLine("[ 8] Número 11, 12, 14, 15");
            Console.WriteLine("[ 9] Número 13, 14, 16, 17");
            Console.WriteLine("[10] Número 14, 15, 17, 18");
            Console.WriteLine("[11] Número 16, 17, 19, 20");
            Console.WriteLine("[12] Número 17, 18, 20, 21");
            Console.WriteLine("[13] Número 19, 20, 22, 23");
            Console.WriteLine("[14] Número 20, 21, 23, 24");
            Console.WriteLine("[15] Número 22, 23, 25, 26");
            Console.WriteLine("[16] Número 23, 24, 26, 27");
            Console.WriteLine("[17] Número 25, 26, 28, 29");
            Console.WriteLine("[18] Número 26, 27, 29, 30");
            Console.WriteLine("[19] Número 28, 29, 31, 32");
            Console.WriteLine("[20] Número 29, 30, 32, 33");
            Console.WriteLine("[21] Número 31, 32, 34, 35");
            Console.WriteLine("[22] Número 32, 33, 35, 36");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    int[] nums1 = { 1, 2, 4, 5 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();
                    if (nums1.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É LINHA {input} - VOCÊ GANHOU! ${amountWaged * 8}.00!");
                        currentBankAmount = (amountWaged * 8) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums1.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é LINHA {input}, você perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "2":
                    int[] nums2 = { 2, 3, 5, 6 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();
                    if (nums2.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É LINHA{input} - VOCÊ GANHOU! ${amountWaged * 8}.00!");
                        currentBankAmount = (amountWaged * 8) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums2.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é LINHA {input}, você perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "3":
                    int[] nums3 = { 4, 5, 7, 8 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();
                    if (nums3.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É LINHA{input} - VOCÊ GANHOU! ${amountWaged * 8}.00!");
                        currentBankAmount = (amountWaged * 8) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums3.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é LINHA {input}, você perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "4":
                    int[] nums4 = { 5, 6, 8, 9 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();
                    if (nums4.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É LINHA{input} - VOCÊ GANHOU! ${amountWaged * 8}.00!");
                        currentBankAmount = (amountWaged * 8) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums4.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é LINHA {input}, você perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "5":
                    int[] nums5 = { 7, 8, 10, 11 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();
                    if (nums5.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É LINHA {input} - VOCÊ GANHOU! ${amountWaged * 8}.00!");
                        currentBankAmount = (amountWaged * 8) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums5.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é LINHA {input}, você perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "6":
                    int[] nums6 = { 8, 9, 11, 12 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();
                    if (nums6.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É LINHA {input} - VOCÊ GANHOU! ${amountWaged * 8}.00!");
                        currentBankAmount = (amountWaged * 8) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums6.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é LINHA {input}, você perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "7":
                    int[] nums7 = { 10, 11, 13, 14 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();
                    if (nums7.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É LINHA {input} - VOCÊ GANHOU! ${amountWaged * 8}.00!");
                        currentBankAmount = (amountWaged * 8) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums7.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é LINHA {input}, você perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "8":
                    int[] nums8 = { 11, 12, 14, 15 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();
                    if (nums8.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É LINHA {input} - VOCÊ GANHOU! ${amountWaged * 8}.00!");
                        currentBankAmount = (amountWaged * 8) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums8.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é LINHA {input}, você perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "9":
                    int[] nums9 = { 13, 14, 16, 17 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();
                    if (nums9.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É LINHA {input} - VOCÊ GANHOU! ${amountWaged * 8}.00!");
                        currentBankAmount = (amountWaged * 8) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums9.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é LINHA {input}, você perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "10":
                    int[] nums10 = { 14, 15, 17, 18 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();
                    if (nums10.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É LINHA {input} - VOCÊ GANHOU! ${amountWaged * 8}.00!");
                        currentBankAmount = (amountWaged * 8) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums10.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é LINHA {input}, você perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "11":
                    int[] nums11 = { 16, 17, 19, 20 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();
                    if (nums11.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É LINHA {input} - VOCÊ GANHOU! ${amountWaged * 8}.00!");
                        currentBankAmount = (amountWaged * 8) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums11.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é LINHA {input}, você perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "12":
                    int[] nums12 = { 17, 18, 20, 21 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();
                    if (nums12.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É LINHA {input} - VOCÊ GANHOU! ${amountWaged * 8}.00!");
                        currentBankAmount = (amountWaged * 8) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums12.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é LINHA {input}, você perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "13":
                    int[] nums13 = { 19, 20, 22, 23 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();
                    if (nums13.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É LINHA {input} - VOCÊ GANHOU! ${amountWaged * 8}.00!");
                        currentBankAmount = (amountWaged * 8) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums13.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é LINHA {input}, você perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "14":
                    int[] nums14 = { 20, 21, 23, 24 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();
                    if (nums14.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É LINHA {input} - VOCÊ GANHOU! ${amountWaged * 8}.00!");
                        currentBankAmount = (amountWaged * 8) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums14.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é LINHA {input}, você perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "15":
                    int[] nums15 = { 22, 23, 25, 26 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();
                    if (nums15.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É LINHA {input} - VOCÊ GANHOU! ${amountWaged * 8}.00!");
                        currentBankAmount = (amountWaged * 8) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums15.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é LINHA {input}, você perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "16":
                    int[] nums16 = { 23, 24, 26, 27 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();
                    if (nums16.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É LINHA {input} - VOCÊ GANHOU! ${amountWaged * 8}.00!");
                        currentBankAmount = (amountWaged * 8) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums16.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é LINHA {input}, você perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "17":
                    int[] nums17 = { 25, 26, 28, 29 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();
                    if (nums17.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É LINHA {input} - VOCÊ GANHOU! ${amountWaged * 8}.00!");
                        currentBankAmount = (amountWaged * 8) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums17.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é LINHA {input}, você perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "18":
                    int[] nums18 = { 26, 27, 29, 30 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();
                    if (nums18.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É LINHA {input} - VOCÊ GANHOU! ${amountWaged * 8}.00!");
                        currentBankAmount = (amountWaged * 8) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums18.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é LINHA {input}, você perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "19":
                    int[] nums19 = { 28, 29, 31, 32 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();
                    if (nums19.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É LINHA {input} - VOCÊ GANHOU! ${amountWaged * 8}.00!");
                        currentBankAmount = (amountWaged * 8) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums19.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é LINHA {input}, você perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "20":
                    int[] nums20 = { 29, 30, 32, 33 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();
                    if (nums20.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É LINHA {input} - VOCÊ GANHOU! ${amountWaged * 8}.00!");
                        currentBankAmount = (amountWaged * 8) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums20.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é LINHA {input}, você perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "21":
                    int[] nums21 = { 31, 32, 34, 35 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();
                    if (nums21.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É LINHA {input} - VOCÊ GANHOU! ${amountWaged * 8}.00!");
                        currentBankAmount = (amountWaged * 8) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums21.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é LINHA {input}, você perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                case "22":
                    int[] nums22 = { 32, 33, 35, 36 };

                    Console.WriteLine($"Você selecionou {input}");
                    BallLandsOnThisNUmber();
                    BallDrops();
                    if (nums22.Any(i => i == ballNumber))
                    {
                        Console.WriteLine($"É LINHA {input} - VOCÊ GANHOU! ${amountWaged * 8}.00!");
                        currentBankAmount = (amountWaged * 8) + currentBankAmount;
                        Console.WriteLine($"Você tem ${currentBankAmount}.00");
                        Game.AddMoney(ref currentBankAmount);
                        Account.Bank();
                    }
                    else if (nums22.Any(i => i != ballNumber && ballNumber != 37 && ballNumber != 38))
                    {
                        Console.WriteLine($"Desculpe, não é LINHA {input}, você perdeu");
                        Account.Bank();
                    }
                    else
                    {
                        Console.WriteLine("VERDE, desculpe, você perdeu");
                        Account.Bank();
                    }
                    break;
                default:
                    Console.WriteLine($"Esse não é o formato correto.  Você digitou {input}");
                    Corner();
                    break;
            }

        }
        public static void PlayAllBets()
        {
            PickANUmber();
            Red();
            Black();
            Even();
            Odd();
            Low();
            High();
            Dozens();
            Columns();
            Street();
            SixLine();
            Spilts();
            Corner();
        }
        public static void GambleTime()
        {
            int betSelection;
            betSelection = Convert.ToInt32(Shorts.ConsoleInput());


            if (betSelection == 1)
            {
                PickANUmber();

            }
            else if (betSelection == 2)
            {
                Red();

            }
            else if (betSelection == 3)
            {
                Black();

            }
            else if (betSelection == 4)
            {
                Even();

            }
            else if (betSelection == 5)
            {
                Odd();

            }
            else if (betSelection == 6)
            {
                Low();

            }
            else if (betSelection == 7)
            {
                High();

            }
            else if (betSelection == 8)
            {
                Dozens();

            }
            else if (betSelection == 9)
            {
                Columns();

            }
            else if (betSelection == 10)
            {
                Street();

            }
            else if (betSelection == 11)
            {
                SixLine();

            }
            else if (betSelection == 12)
            {
                Spilts();

            }
            else if (betSelection == 13)
            {
                Corner();

            }
            else if (betSelection == 14)
            {
                PlayAllBets();

            }
            else
            {
                Console.WriteLine($"Esse não é o formato correto.  Você digitou {betSelection}");
                SelectionBetMenu();
            }
            PlayAgainQuestion();


        }
        public static void RouletteGame()
        {
            //If the players money reaches zero or less exit out the while loop
            if (rouletteConditional == true)
            {
                //WageSelection();
                GambleTime();
            }
        }
    }
    public static class Program
    {
        public static void Main(string[] args)
        {
            //MasterClasses.FullScreen.WideScreenMethod();
            Console.Clear();
            Shorts.AddSpace(2);
            Shorts.Write("Bem-vindo ao Cassino!\n");
            Shorts.Write("Vamos jogar roleta\n");
            Shorts.AddSpace(3);
            Account.Bank();
            Shorts.AddSpace(1);
            Game.WageSelection();
        }

    }
    }
}
