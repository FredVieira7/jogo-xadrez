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

            return p == null || p.cor != this.cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[tabuleiro.linhas, tabuleiro.colunas];
        }

    }
}
