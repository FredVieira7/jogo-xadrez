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
        public bool Xeque { get; private set; }

        public PartidaDeXadrez()
        {
            tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branco;
            Finalizada = false;
            Xeque = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
;        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tabuleiro.RetirarPeca(origem);
            p.IncrementarQtdMovimentos();
            Peca pecaCapturada = tabuleiro.RetirarPeca(destino);

            tabuleiro.ColocarPeca(p, destino);

            if(pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }


            //Jogada especial: Roque Pequeno
            if(p is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna + 1);

                Peca T = tabuleiro.RetirarPeca(origemTorre);
                T.IncrementarQtdMovimentos();
                tabuleiro.ColocarPeca(T, destinoTorre);
            }

            //Jogada especial: Roque Grande
            if (p is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna - 1);

                Peca T = tabuleiro.RetirarPeca(origemTorre);
                T.IncrementarQtdMovimentos();
                tabuleiro.ColocarPeca(T, destinoTorre);
            }

            return pecaCapturada;

        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tabuleiro.RetirarPeca(destino);
            p.DecrementarQtdMovimentos();

            if(pecaCapturada != null)
            {
                tabuleiro.ColocarPeca(pecaCapturada, destino);
                Capturadas.Remove(pecaCapturada);
            }

            tabuleiro.ColocarPeca(p, origem);

            //Jogada especial: Roque Pequeno
            if (p is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna + 1);

                Peca T = tabuleiro.RetirarPeca(destinoTorre);
                T.IncrementarQtdMovimentos();
                tabuleiro.ColocarPeca(T, origemTorre);
            }

            //Jogada especial: Roque Grande
            if (p is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna - 1);

                Peca T = tabuleiro.RetirarPeca(destinoTorre);
                T.IncrementarQtdMovimentos();
                tabuleiro.ColocarPeca(T, origemTorre);
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);

            if(EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            if(EstaEmXeque(Adversario(JogadorAtual)))
            {
                Xeque = true;
            }else
            {
                Xeque = false;
            }

            if(TesteXequemate(Adversario(JogadorAtual)))
            {
                Finalizada = true;
            }else
            {
                Turno++;
                MudaJogador();
            }

            
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
            if(!tabuleiro.peca(origem).MovimentoPossivel(destino))
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

        private Cor Adversario(Cor cor)
        {
            if(cor == Cor.Branco)
            {
                return Cor.Amarela;
            }else
            {
                return Cor.Branco;
            }
        }

        private Peca Rei(Cor cor)
        {
            foreach(Peca x in PecasEmJogo(cor))
            {
                if(x is Rei)
                {
                    return x;
                }
            }

            return null;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca rei = Rei(cor);

            if(rei == null)
            {
                throw new TabuleiroException($"Não tem rei da cor {cor} no tabuleiro!");
            }

            foreach(Peca x in PecasEmJogo(Adversario(cor)))
            {
                bool[,] matriz = x.MovimentosPossiveis();

                if(matriz[rei.posicao.Linha, rei.posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public bool TesteXequemate(Cor cor)
        {
            if(!EstaEmXeque(cor))
            {
                return false;
            }

            foreach(Peca x in PecasEmJogo(cor))
            {
                bool[,] matriz = x.MovimentosPossiveis();

                for(int i = 0; i < tabuleiro.linhas; i++)
                {
                    for(int j = 0; j < tabuleiro.colunas; j++)
                    {
                        if(matriz[i, j])
                        {

                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool TesteXeque = EstaEmXeque(cor);

                            DesfazMovimento(origem, destino, pecaCapturada);

                            if(!TesteXeque)
                            {
                                return false;
                            }
                        
                        }
                    }
                }
            }

            return true;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }

        private void ColocarPecas()
        {
            //Peças brancas
            ColocarNovaPeca('a', 1, new Torre(Cor.Branco, tabuleiro));
            ColocarNovaPeca('b', 1, new Cavalo(Cor.Branco, tabuleiro));
            ColocarNovaPeca('c', 1, new Bispo(Cor.Branco, tabuleiro));
            ColocarNovaPeca('d', 1, new Dama(Cor.Branco, tabuleiro));
            ColocarNovaPeca('e', 1, new Rei(Cor.Branco, tabuleiro));
            ColocarNovaPeca('f', 1, new Bispo(Cor.Branco, tabuleiro));
            ColocarNovaPeca('g', 1, new Cavalo(Cor.Branco, tabuleiro));
            ColocarNovaPeca('h', 1, new Torre(Cor.Branco, tabuleiro));
            ColocarNovaPeca('a', 2, new Peao(Cor.Branco, tabuleiro));
            ColocarNovaPeca('b', 2, new Peao(Cor.Branco, tabuleiro));
            ColocarNovaPeca('c', 2, new Peao(Cor.Branco, tabuleiro));
            ColocarNovaPeca('d', 2, new Peao(Cor.Branco, tabuleiro));
            ColocarNovaPeca('e', 2, new Peao(Cor.Branco, tabuleiro));
            ColocarNovaPeca('f', 2, new Peao(Cor.Branco, tabuleiro));
            ColocarNovaPeca('g', 2, new Peao(Cor.Branco, tabuleiro));
            ColocarNovaPeca('h', 2, new Peao(Cor.Branco, tabuleiro));

            //Peças amarelas
            ColocarNovaPeca('a', 8, new Torre(Cor.Amarela, tabuleiro));
            ColocarNovaPeca('b', 8, new Cavalo(Cor.Amarela, tabuleiro));
            ColocarNovaPeca('c', 8, new Bispo(Cor.Amarela, tabuleiro));
            ColocarNovaPeca('d', 8, new Rei(Cor.Amarela, tabuleiro));
            ColocarNovaPeca('e', 8, new Dama(Cor.Amarela, tabuleiro));
            ColocarNovaPeca('f', 8, new Bispo(Cor.Amarela, tabuleiro));
            ColocarNovaPeca('g', 8, new Cavalo(Cor.Amarela, tabuleiro));
            ColocarNovaPeca('h', 8, new Torre(Cor.Amarela, tabuleiro));
            ColocarNovaPeca('a', 7, new Peao(Cor.Amarela, tabuleiro));
            ColocarNovaPeca('b', 7, new Peao(Cor.Amarela, tabuleiro));
            ColocarNovaPeca('c', 7, new Peao(Cor.Amarela, tabuleiro));
            ColocarNovaPeca('d', 7, new Peao(Cor.Amarela, tabuleiro));
            ColocarNovaPeca('e', 7, new Peao(Cor.Amarela, tabuleiro));
            ColocarNovaPeca('f', 7, new Peao(Cor.Amarela, tabuleiro));
            ColocarNovaPeca('g', 7, new Peao(Cor.Amarela, tabuleiro));
            ColocarNovaPeca('h', 7, new Peao(Cor.Amarela, tabuleiro));


        }
    }
}
