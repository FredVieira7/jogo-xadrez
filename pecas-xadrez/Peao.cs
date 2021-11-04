using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez.pecas_xadrez.partida;
using Xadrez.tabuleiro;

namespace Xadrez.pecas_xadrez
{
    class Peao : Peca
    {

        private PartidaDeXadrez Partida;
        public Peao(Cor cor, Tabuleiro tabuleiro, PartidaDeXadrez partida) : base(cor, tabuleiro)
        {
            Partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = tabuleiro.peca(pos);
            return p != null && p.cor != cor;
        }

        private bool Livre(Posicao pos)
        {
            return tabuleiro.peca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[tabuleiro.linhas, tabuleiro.colunas];


            Posicao pos = new Posicao(0, 0);

            if(cor == Cor.Branco)
            {
                pos.DefinirValores(posicao.Linha - 1, posicao.Coluna);
                if(tabuleiro.PosicaoValida(pos) && Livre(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(posicao.Linha - 2, posicao.Coluna);
                if (tabuleiro.PosicaoValida(pos) && Livre(pos) && QtdMovimentos == 0)
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(posicao.Linha - 1, posicao.Coluna - 1);
                if (tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(posicao.Linha - 1, posicao.Coluna + 1);
                if (tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                //Jogada especial: En Passant
                if(posicao.Linha == 3)
                {
                    Posicao esquerda = new Posicao(posicao.Linha, posicao.Coluna - 1);

                    if(tabuleiro.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && tabuleiro.peca(esquerda) == Partida.VulneravelEnPassant)
                    {
                        matriz[esquerda.Linha, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(posicao.Linha, posicao.Coluna + 1);

                    if (tabuleiro.PosicaoValida(direita) && ExisteInimigo(direita) && tabuleiro.peca(direita) == Partida.VulneravelEnPassant)
                    {
                        matriz[direita.Linha, direita.Coluna] = true;
                    }
                }

            }else
            {
                pos.DefinirValores(posicao.Linha + 1, posicao.Coluna);
                if (tabuleiro.PosicaoValida(pos) && Livre(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(posicao.Linha + 2, posicao.Coluna);
                if (tabuleiro.PosicaoValida(pos) && Livre(pos) && QtdMovimentos == 0)
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(posicao.Linha + 1, posicao.Coluna - 1);
                if (tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(posicao.Linha + 1, posicao.Coluna + 1);
                if (tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                //Jogada especial: En Passant
                if (posicao.Linha == 4)
                {
                    Posicao esquerda = new Posicao(posicao.Linha, posicao.Coluna - 1);

                    if (tabuleiro.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && tabuleiro.peca(esquerda) == Partida.VulneravelEnPassant)
                    {
                        matriz[esquerda.Linha, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(posicao.Linha, posicao.Coluna + 1);

                    if (tabuleiro.PosicaoValida(direita) && ExisteInimigo(direita) && tabuleiro.peca(direita) == Partida.VulneravelEnPassant)
                    {
                        matriz[direita.Linha, direita.Coluna] = true;
                    }
                }
            }

            return matriz;
        }

    }
}
