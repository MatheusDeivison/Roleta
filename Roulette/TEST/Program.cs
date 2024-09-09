using System;

namespace RodaDeRoleta
{
    class MainClass
    {
        // ----------- Métodos -------------
        static void Escrever(string str)
        {
            Console.Write(str);
        }
        static void Escrever(char chr)
        {
            Console.Write(chr);
        }
        static void Escrever(int intr)
        {
            Console.Write(intr);
        }

        static string Ler()
        {
            string temp = Console.ReadLine();
            return temp;
        }

        static void PularLinhas(int quantas)
        {
            do
            {
                Console.WriteLine();
                quantas--;

            } while (quantas > 0);
        }

        static int GerarNumeroAleatorio(Random rnd)
        {
            int numeroAleatorio = rnd.Next(1, 37);
            // Número aleatório entre 1 e 36

            return numeroAleatorio;
        }

        static int VencerAposta(int aposta, int numeroAleatorio)
        {
            if (aposta == numeroAleatorio)
            {
                Console.WriteLine("A roleta está girando... \nEla para no número " + numeroAleatorio + ".\nVocê ganha, a aposta é multiplicada por 5!");
                return 5;
            }

            Console.WriteLine("A roleta está girando... \nEla para no número " + numeroAleatorio + ".\nVocê perdeu, a aposta é igual a 0!");
            return 0;
        }

        static int VencerPorCor(int numeroAleatorio, int[] array)
        {
            foreach (int num in array)
            {
                if (num == numeroAleatorio)
                {
                    Console.WriteLine("A roleta está girando tão rápido!\nEla para exatamente na sua cor.\nParabéns, você ganha: aposta multiplicada por 2");
                    return 2;
                }
            }
            Console.WriteLine("Você perdeu, não é a cor certa.\nQue pena: aposta igual a 0.");
            return 0;
        }

        // ------------ Variáveis -------------
        static int[] numerosVermelhos = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36 };

        static int[] numerosPretos = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35 };

        static Random rand = new Random();
        static int aposta;

        // --------------- Classe ---------------
        public class Sold
        {
            private int saldo;

            public Sold()
            {
                saldo = 100;
            }

            public void MostrarSaldo()
            {
                Console.WriteLine("Saldo: " + saldo + "$");
            }

            public void Adicionar(int aposta)
            {
                saldo += aposta;
            }

            public void Subtrair(ref int aposta)
            {
                if ((saldo - aposta) < 0)
                {
                    aposta = saldo;
                    Console.WriteLine("Aposta ajustada para " + aposta + ".");
                }
                saldo -= aposta;
            }
            public bool VerificarFimDeJogo()
            {
                if (saldo <= 0)
                {
                    return true;
                }
                return false;
            }
        }

        public static void Main(string[] args)
        {
            Sold jogador = new Sold();

            Escrever("Olá e bem-vindo ao meu jogo de roleta.\nEspero que você se divirta :)");

            PularLinhas(3);

            Escrever("Você começa o jogo com 100$.\nVocê pode apostar em um número ou em uma cor.\nAposta em cor multiplicará sua aposta por 2, enquanto uma aposta em número multiplicará por 5.\nPara apostar, apenas escreva um número entre 1 e 36 ou vermelho ou preto.\nBoa sorte e divirta-se :) \n");

            PularLinhas(2);

            while (true)
            {
                try
                {
                    PularLinhas(1);
                    jogador.MostrarSaldo();

                    Escrever("Aposta? ");
                    aposta = Convert.ToInt32(Ler());

                }
                catch (Exception)
                {
                    Escrever("Você deve apostar, então sua aposta é 10.\n");
                    aposta = 10;

                }

                jogador.Subtrair(ref aposta);
                int numeroAleatorio = GerarNumeroAleatorio(rand);
                int multiplicador = 0;

                Escrever("Em quê? ");
                string escolha = Ler().ToLower();

                if (escolha.Equals("vermelho"))
                {
                    multiplicador = VencerPorCor(numeroAleatorio, numerosVermelhos);

                }
                else if (escolha.Equals("preto"))
                {
                    multiplicador = VencerPorCor(numeroAleatorio, numerosPretos);

                }
                else
                {
                    try
                    {
                        int apostaNumero = Convert.ToInt32(escolha);
                        multiplicador = VencerAposta(apostaNumero, numeroAleatorio);

                    }
                    catch (Exception)
                    {
                        Escrever("Entrada inválida, você perdeu sua aposta.");

                    }
                }

                jogador.Adicionar(aposta * multiplicador);

                if (jogador.VerificarFimDeJogo()) goto derrota;
            }

        derrota:
            PularLinhas(2);
            Escrever("Você perdeu, tente novamente outra hora :D");
        }
    }
}
