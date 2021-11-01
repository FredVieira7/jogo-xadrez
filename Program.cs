using System;
using Xadrez.pecas_xadrez;
using Xadrez.pecas_xadrez.posicoes_xadrez;
using Xadrez.tabuleiro;
using Xadrez.tabuleiro.exceptions;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            PosicaoXadrez pos = new PosicaoXadrez('c', 7);
            Console.WriteLine(pos);
            Console.WriteLine(pos.ToPosicao());
            
        }
    }
}
