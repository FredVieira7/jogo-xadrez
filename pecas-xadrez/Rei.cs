using Xadrez.pecas_xadrez.partida;
using Xadrez.tabuleiro;

namespace Xadrez.pecas_xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez Partida;

        public Rei(Cor cor, Tabuleiro tabuleiro, PartidaDeXadrez partida) :base(cor, tabuleiro)
        {
            Partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = tabuleiro.peca(pos);

            return p == null || p.cor != cor;
        }

        //Checando se é possível fazer a jogada especial Roque
        public bool TesteTorreParaRoque(Posicao pos)
        {
            Peca p = tabuleiro.peca(pos);

            return p != null && p is Torre && p.cor == cor && p.QtdMovimentos == 0; ;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[tabuleiro.linhas, tabuleiro.colunas];


            Posicao pos = new Posicao(0, 0);

            //Acima
            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna);
            if(tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //Nordeste
            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna + 1);
            if (tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //Direita
            pos.DefinirValores(posicao.Linha, posicao.Coluna + 1);
            if (tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //Sudeste
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna + 1);
            if (tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //Abaixo
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna);
            if (tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //Sudoeste
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna - 1);
            if (tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //Esquerda
            pos.DefinirValores(posicao.Linha, posicao.Coluna - 1);
            if (tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //Noroeste
            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna - 1);
            if (tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }


            //Jogada especial: Roque
            if (QtdMovimentos == 0 && !Partida.Xeque)
            {
                //Jogada especial: Roque Pequeno
                Posicao posTorreP = new Posicao(posicao.Linha, posicao.Coluna + 3);
                if(TesteTorreParaRoque(posTorreP))
                {
                    Posicao p1 = new Posicao(posicao.Linha, posicao.Coluna + 1);
                    Posicao p2 = new Posicao(posicao.Linha, posicao.Coluna + 2);
                    
                    if(tabuleiro.peca(p1) == null && tabuleiro.peca(p2) == null)
                    {
                        matriz[posicao.Linha, posicao.Coluna + 2] = true;
                    }
                }

                //Jogada especial: Roque Grande
                Posicao posTorreG = new Posicao(posicao.Linha, posicao.Coluna - 4);
                if (TesteTorreParaRoque(posTorreG))
                {
                    Posicao p1 = new Posicao(posicao.Linha, posicao.Coluna - 1);
                    Posicao p2 = new Posicao(posicao.Linha, posicao.Coluna - 2);
                    Posicao p3 = new Posicao(posicao.Linha, posicao.Coluna - 3);

                    if (tabuleiro.peca(p1) == null && tabuleiro.peca(p2) == null && tabuleiro.peca(p3) == null
                    {
                        matriz[posicao.Linha, posicao.Coluna - 2] = true;
                    }
                }
            }

            return matriz;
        }

    }
}
