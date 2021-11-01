using Xadrez.tabuleiro;
using System;

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
                    if(tabuleiro.peca(i, j) == null)
                    {
                        Console.Write("- ");
                    }else
                    {
                        ImprimirPeca(tabuleiro.peca(i, j));
                        Console.Write(" ");
                    }
                    
                }
                Console.WriteLine( );
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirPeca(Peca peca)
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
        }
    }
}
