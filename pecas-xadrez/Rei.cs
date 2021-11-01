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
    }
}
