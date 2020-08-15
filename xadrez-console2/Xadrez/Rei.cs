using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez partida;

        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
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

        //Método que testa se a peça que estiver nesta posição
        //é uma torre e da cor esperada e é elegível a jogada Roque
        private bool testeTorreParaRoque(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.qteMovimentos == 0;

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
            //#jogadaespecial Roque
            if(qteMovimentos == 0 && !partida.xeque)
            {
                //#jogadaespecial roque pequeno
                Posicao posT1 = new Posicao(posicao.Linha, posicao.Coluna + 3);
                //teste para testar se posição está vaga
                if (testeTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(posicao.Linha, posicao.Coluna + 1);
                    Posicao p2 = new Posicao(posicao.Linha, posicao.Coluna + 2);
                    //se as posição estão livres
                    if(tab.peca(p1) == null && tab.peca(p2) == null)
                    {
                        mat[posicao.Linha, posicao.Coluna + 2] = true;
                    }
                }
                //------------------
                //#jogadaespecial roque grande
                Posicao posT2 = new Posicao(posicao.Linha, posicao.Coluna - 4);
                //teste para testar se posição está vaga
                if (testeTorreParaRoque(posT2))
                {
                    Posicao p1 = new Posicao(posicao.Linha, posicao.Coluna - 1);
                    Posicao p2 = new Posicao(posicao.Linha, posicao.Coluna - 2);
                    Posicao p3 = new Posicao(posicao.Linha, posicao.Coluna - 3);
                    //se as posição estão livres
                    if (tab.peca(p1) == null && tab.peca(p2) == null && tab.peca(p3) == null)
                    {
                        mat[posicao.Linha, posicao.Coluna - 2] = true;
                    }
                }

            }

            return mat;
        }
    }
}
