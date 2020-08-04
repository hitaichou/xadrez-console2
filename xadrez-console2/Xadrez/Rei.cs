using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        //método auxiliar (private )no qual somente a classe Rei irá acessar
        //neste método, será checado se o rei pode ou não movimentar 
        //para a posição desejada
        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos); //pega a peça q está na posição
            //irá retornar se a posição está livre
            //ou se a cor é adversária.
            return p == null || p.cor != cor;
        }


        //é usado override para sobrescrever o método
        //da superclasse
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);
            //acima
            pos.definirValores(posicao.Linha - 1, posicao.Coluna); //está na mesma coluna mas na linha acima.
            //teste se a posição acima é a peça adversária ou está livre
            if(tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //nordeste
            pos.definirValores(posicao.Linha - 1, posicao.Coluna + 1); //está na mesma coluna mas na linha acima.
            //teste se a posição acima é a peça adversária ou está livre
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //direita
            pos.definirValores(posicao.Linha, posicao.Coluna + 1); //está na mesma coluna mas na linha acima.
            //teste se a posição acima é a peça adversária ou está livre
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //sudeste
            pos.definirValores(posicao.Linha + 1, posicao.Coluna + 1); //está na mesma coluna mas na linha acima.
            //teste se a posição acima é a peça adversária ou está livre
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //abaixo
            pos.definirValores(posicao.Linha + 1, posicao.Coluna); //está na mesma coluna mas na linha acima.
            //teste se a posição acima é a peça adversária ou está livre
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //sudoeste
            pos.definirValores(posicao.Linha + 1, posicao.Coluna - 1); //está na mesma coluna mas na linha acima.
            //teste se a posição acima é a peça adversária ou está livre
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //esquerda
            pos.definirValores(posicao.Linha, posicao.Coluna - 1); //está na mesma coluna mas na linha acima.
            //teste se a posição acima é a peça adversária ou está livre
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //noroeste
            pos.definirValores(posicao.Linha - 1, posicao.Coluna -1); //está na mesma coluna mas na linha acima.
            //teste se a posição acima é a peça adversária ou está livre
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            return mat;
        }
    }
}
