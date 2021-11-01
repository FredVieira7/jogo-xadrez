using System;
using Xadrez.pecas_xadrez;
using Xadrez.tabuleiro;
using Xadrez.tabuleiro.exceptions;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro tabuleiro = new Tabuleiro(8, 8);
                tabuleiro.ColocarPecas(new Torre(Cor.Amarela, tabuleiro), new Posicao(0, 0));
                tabuleiro.ColocarPecas(new Torre(Cor.Verde, tabuleiro), new Posicao(1, 3));
                tabuleiro.ColocarPecas(new Rei(Cor.Azul, tabuleiro), new Posicao(0, 2));
                TelaTabuleiro.ImprimirTabuleiro(tabuleiro);
            }catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
