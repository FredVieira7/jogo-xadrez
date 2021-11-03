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
                    try
                    {
                        Console.Clear();
                        TelaTabuleiro.ImprimirTabuleiro(partida.tabuleiro);

                        Console.WriteLine();

                        Console.WriteLine("Turno: " + partida.Turno);
                        Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);

                        Console.WriteLine();
                        Console.WriteLine();

                        Console.Write("Origem: ");
                        Posicao origem = TelaTabuleiro.LerPosicaoXadrez().ToPosicao();

                        partida.ValidarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tabuleiro.peca(origem).MovimentosPossiveis();


                        Console.Clear();
                        TelaTabuleiro.ImprimirTabuleiro(partida.tabuleiro, posicoesPossiveis);


                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = TelaTabuleiro.LerPosicaoXadrez().ToPosicao();

                        partida.ValidarPosicaoDeDestino(origem, destino);

                        partida.RealizaJogada(origem, destino);
                    }catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                    
                }


            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
