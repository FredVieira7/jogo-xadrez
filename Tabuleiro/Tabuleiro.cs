using Xadrez.tabuleiro.exceptions;

namespace Xadrez.tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }

        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public Peca peca(Posicao pos)
        {
            return pecas[pos.Linha, pos.Coluna];
        }

        public bool ExistePeca(Posicao pos)
        {
            validarAPosicao(pos);
            return peca(pos) != null;
        }

        public void ColocarPecas(Peca p, Posicao pos)
        {
            if (ExistePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição");
            }

            pecas[pos.Linha, pos.Coluna] = p;
            p.posicao = pos;
        }

        public bool PosicaoValida(Posicao pos)
        {
            if(pos.Linha < 0 || pos.Linha >= linhas || pos.Coluna < 0 || pos.Coluna >= colunas)
            {
                return false;
            }

            return true;
        }

        public void validarAPosicao(Posicao pos)
        {
            if(!PosicaoValida(pos))
            {
                throw new TabuleiroException("Posição Inválida!!");
            }
        }
    }
}
