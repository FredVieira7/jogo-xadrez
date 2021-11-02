using Xadrez.tabuleiro;

namespace Xadrez.pecas_xadrez
{
    class Rei : Peca
    {
        public Rei(Cor cor, Tabuleiro tabuleiro) :base(cor, tabuleiro)
        {

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

            return matriz;
        }

    }
}
