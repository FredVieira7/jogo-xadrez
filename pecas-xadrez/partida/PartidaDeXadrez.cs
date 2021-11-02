using Xadrez.pecas_xadrez.posicoes_xadrez;
using Xadrez.tabuleiro;

namespace Xadrez.pecas_xadrez.partida
{
    class PartidaDeXadrez
    {
        public Tabuleiro tabuleiro { get; private set; }
        private int Turno;
        private Cor JogadorAtual;
        public bool Finalizada { get; private set; }

        public PartidaDeXadrez()
        {
            tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branco;
            Finalizada = false;
            ColocarPecas();
;        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tabuleiro.RetirarPeca(origem);
            p.IncrementarQtdMovimentos();
            Peca pecaCapturada = tabuleiro.RetirarPeca(destino);

            tabuleiro.ColocarPeca(p, destino);

        }

        private void ColocarPecas()
        {
            tabuleiro.ColocarPeca(new Torre(Cor.Amarela, tabuleiro), new PosicaoXadrez('c', 1).ToPosicao());
            tabuleiro.ColocarPeca(new Torre(Cor.Amarela, tabuleiro), new PosicaoXadrez('c', 2).ToPosicao());
            tabuleiro.ColocarPeca(new Torre(Cor.Amarela, tabuleiro), new PosicaoXadrez('e', 1).ToPosicao());
            tabuleiro.ColocarPeca(new Torre(Cor.Amarela, tabuleiro), new PosicaoXadrez('e', 2).ToPosicao());
            tabuleiro.ColocarPeca(new Rei(Cor.Amarela, tabuleiro), new PosicaoXadrez('d', 1).ToPosicao());
        }
    }
}
