using tabuleiro;

namespace xadrez
{
    class Dama : Peca
    {
        public Dama(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "D";
        }

        //método auxiliar (private )no qual somente a classe Torre irá acessar
        //neste método, será checado se a torre pode ou não movimentar 
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

            //esquerda
            pos.definirValores(posicao.Linha, posicao.Coluna - 1);

            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                //checa se a posição está nula ou se a cor
                //da peça é a do adversário                
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break; //forço a parada
                }
                //caso a situação acima não for verdade
                //posição coluna recebe -1
                pos.Coluna = pos.Coluna - 1;
            }
            //direita
            pos.definirValores(posicao.Linha, posicao.Coluna + 1);

            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                //checa se a posição está nula ou se a cor
                //da peça é a do adversário                
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break; //forço a parada
                }
                //caso a situação acima não for verdade
                //posição coluna recebe +1
                pos.Coluna = pos.Coluna + 1;
            }
            //acima
            pos.definirValores(posicao.Linha - 1, posicao.Coluna);

            //A torre precisa checar até o fim do tabuleiro
            //Checa se a casa está livre ou há peça adversária            
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                //checa se a posição está nula ou se a cor
                //da peça é a do adversário                
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break; //forço a parada
                }
                //caso a situação acima não for verdade
                //posição linha recebe -1
                pos.Linha = pos.Linha - 1;
            }
            //abaixo
            pos.definirValores(posicao.Linha + 1, posicao.Coluna);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                //checa se a posição está nula ou se a cor
                //da peça é a do adversário                
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break; //forço a parada
                }
                //caso a situação acima não for verdade
                //posição linha recebe +1
                pos.Linha = pos.Linha + 1;
            }
            //NO
            pos.definirValores(posicao.Linha - 1, posicao.Coluna - 1);


            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                //checa se a posição está nula ou se a cor
                //da peça é a do adversário                
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break; //forço a parada
                }
                //caso a situação acima não for verdade                
                pos.definirValores(pos.Linha - 1, pos.Coluna - 1);
            }

            //NE
            pos.definirValores(posicao.Linha - 1, posicao.Coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                //checa se a posição está nula ou se a cor
                //da peça é a do adversário                
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break; //forço a parada
                }
                //caso a situação acima não for verdade                
                pos.definirValores(pos.Linha - 1, pos.Coluna + 1);
            }

            //SE
            pos.definirValores(posicao.Linha + 1, posicao.Coluna + 1);

            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                //checa se a posição está nula ou se a cor
                //da peça é a do adversário                
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break; //forço a parada
                }
                //caso a situação acima não for verdade                
                pos.definirValores(posicao.Linha + 1, posicao.Coluna + 1);
            }

            //SO
            pos.definirValores(posicao.Linha + 1, posicao.Coluna - 1);

            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                //checa se a posição está nula ou se a cor
                //da peça é a do adversário                
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break; //forço a parada
                }
                //caso a situação acima não for verdade
                //posição coluna recebe -1
                pos.definirValores(posicao.Linha + 1, posicao.Coluna - 1);
            }



            return mat;
        }

    }
}
