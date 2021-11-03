using System.Collections.Generic;
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
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;

        public PartidaDeXadrez()
        {
            tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branco;
            Finalizada = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
;        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tabuleiro.RetirarPeca(origem);
            p.IncrementarQtdMovimentos();
            Peca pecaCapturada = tabuleiro.RetirarPeca(destino);

            tabuleiro.ColocarPeca(p, destino);

            if(pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }

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

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach(Peca x in Capturadas)
            {
                if(x.cor == cor)
                {
                    aux.Add(x);
                }
            }

            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca x in Pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }

            aux.ExceptWith(PecasCapturadas(cor));

            return aux;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('a', 1, new Torre(Cor.Branco, tabuleiro));
            ColocarNovaPeca('h', 1, new Torre(Cor.Branco, tabuleiro));
            ColocarNovaPeca('d', 1, new Rei(Cor.Branco, tabuleiro));

            ColocarNovaPeca('a', 8, new Torre(Cor.Amarela, tabuleiro));
            ColocarNovaPeca('h', 8, new Torre(Cor.Amarela, tabuleiro));
            ColocarNovaPeca('e', 8, new Rei(Cor.Amarela, tabuleiro));


        }
    }
}
