using Xadrez.tabuleiro;
using System;
using Xadrez.pecas_xadrez.posicoes_xadrez;

namespace Xadrez
{
    class TelaTabuleiro
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for(int i = 0; i < tabuleiro.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for(int j = 0; j < tabuleiro.colunas; j++)
                {
                    ImprimirPeca(tabuleiro.peca(i, j));
                    
                }
                Console.WriteLine( );
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tabuleiro.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabuleiro.colunas; j++)
                {
                    if(posicoesPossiveis[i, j] == true)
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    
                    ImprimirPeca(tabuleiro.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");

            return new PosicaoXadrez(coluna, linha);

        }



        public static void ImprimirPeca(Peca peca)
        {
            if(peca == null)
            {
                Console.Write("- ");
            }else
            {
                if(peca.cor == Cor.Branco)
                {
                    Console.Write(peca);
                }else if(peca.cor == Cor.Amarela)
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                else if (peca.cor == Cor.Azul)
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                else if (peca.cor == Cor.Verde)
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
