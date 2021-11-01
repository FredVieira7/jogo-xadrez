using System;
using Xadrez.pecas_xadrez;
using Xadrez.tabuleiro;
namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tabuleiro = new Tabuleiro(8, 8);
            tabuleiro.ColocarPecas(new Torre(Cor.Preto, tabuleiro), new Posicao(0, 0));
            tabuleiro.ColocarPecas(new Torre(Cor.Preto, tabuleiro), new Posicao(1, 3));
            tabuleiro.ColocarPecas(new Rei(Cor.Preto, tabuleiro), new Posicao(2, 4));
            TelaTabuleiro.ImprimirTabuleiro(tabuleiro);
        }
    }
}
