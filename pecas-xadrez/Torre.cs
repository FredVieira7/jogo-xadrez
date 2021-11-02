using Xadrez.tabuleiro;

namespace Xadrez.pecas_xadrez
{
    class Torre : Peca
    {
        public Torre(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {

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
            while(tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;

                if(tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }

            //Abaixo
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna);
            while (tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;

                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }

            //Direita
            pos.DefinirValores(posicao.Linha, posicao.Coluna + 1);
            while (tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;

                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }

            //Esquerda
            pos.DefinirValores(posicao.Linha, posicao.Coluna - 1);
            while (tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;

                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }


            return matriz;
        }

        public override string ToString()
        {
            return "T";
        }


    }
}
