using System;
using Xadrez.tabuleiro;
namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tabuleiro = new Tabuleiro(8, 8);
            TelaTabuleiro.ImprimirTabuleiro(tabuleiro);
        }
    }
}
