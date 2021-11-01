﻿

namespace Xadrez.tabuleiro
{
    class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int QtdMovimentos { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }

        public Peca(Cor cor, Tabuleiro tabuleiro)
        {
            posicao = null;
            this.cor = cor;
            this.tabuleiro = tabuleiro;
            QtdMovimentos = 0;
        }
    }
}
