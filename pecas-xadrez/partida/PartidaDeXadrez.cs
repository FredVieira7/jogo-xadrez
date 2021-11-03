using Xadrez.pecas_xadrez.posicoes_xadrez;
using Xadrez.tabuleiro;
using Xadrez.tabuleiro.exceptions;

namespace Xadrez.pecas_xadrez.partida
{
    class PartidaDeXadrez
    {
        public Tabuleiro tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
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

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }

        public void ValidarPosicaoDeOrigem(Posicao pos)
        {
            if(tabuleiro.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }

            if(JogadorAtual != tabuleiro.peca(pos).cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é a sua!");
            }

            if(!tabuleiro.peca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if(!tabuleiro.peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private void MudaJogador()
        {
            if(JogadorAtual == Cor.Branco)
            {
                JogadorAtual = Cor.Amarela;
            }else
            {
                JogadorAtual = Cor.Branco;
            }
        }

        private void ColocarPecas()
        {
            tabuleiro.ColocarPeca(new Torre(Cor.Branco, tabuleiro), new PosicaoXadrez('c', 1).ToPosicao());
            tabuleiro.ColocarPeca(new Torre(Cor.Branco, tabuleiro), new PosicaoXadrez('c', 2).ToPosicao());
            tabuleiro.ColocarPeca(new Torre(Cor.Branco, tabuleiro), new PosicaoXadrez('e', 1).ToPosicao());
            tabuleiro.ColocarPeca(new Torre(Cor.Branco, tabuleiro), new PosicaoXadrez('e', 2).ToPosicao());
            tabuleiro.ColocarPeca(new Rei(Cor.Branco, tabuleiro), new PosicaoXadrez('d', 1).ToPosicao());

            tabuleiro.ColocarPeca(new Torre(Cor.Amarela, tabuleiro), new PosicaoXadrez('c', 8).ToPosicao());
            tabuleiro.ColocarPeca(new Torre(Cor.Amarela, tabuleiro), new PosicaoXadrez('c', 7).ToPosicao());
            tabuleiro.ColocarPeca(new Torre(Cor.Amarela, tabuleiro), new PosicaoXadrez('e', 8).ToPosicao());
            tabuleiro.ColocarPeca(new Torre(Cor.Amarela, tabuleiro), new PosicaoXadrez('e', 7).ToPosicao());
            tabuleiro.ColocarPeca(new Rei(Cor.Amarela, tabuleiro), new PosicaoXadrez('d', 8).ToPosicao());
        }
    }
}
