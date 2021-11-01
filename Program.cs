using System;
using Xadrez.pecas_xadrez;
using Xadrez.pecas_xadrez.partida;
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
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while(!partida.Finalizada)
                {
                    Console.Clear();
                    TelaTabuleiro.ImprimirTabuleiro(partida.tabuleiro);

                    Console.WriteLine();
                    Console.WriteLine();

                    Console.Write("Origem: ");
                    Posicao origem = TelaTabuleiro.LerPosicaoXadrez().ToPosicao();

                    Console.Write("Destino: ");
                    Posicao destino = TelaTabuleiro.LerPosicaoXadrez().ToPosicao();

                    partida.ExecutaMovimento(origem, destino);
                }


            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
