using tabuleiro;
namespace xadrez
{
    class PosicaoXadrez
    {
        //Classe para construir o tabuleiro dentro do contexto do xadrez
        //a1, a2, a3, e assim por diante

        public char coluna { get; set; }
        public int linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;
        }

        //Converte a posição do tabuleiro do xadrez
        //para a dimenção da matriz
        public Posicao toPosicao()
        {
            //"8 - linha" --> é possível encontrar qual é a linha da matriz
            //"Coluna - 'a' " --> o "a" é um número interno dentro do C#,
            //portanto (a - a = 0) e (b - a = 1), ou seja, desta forma é 
            //possível pegar a coluna desejada
            return new Posicao(8 - linha, coluna - 'a');
        }

        public override string ToString()
        {
            return "" + coluna + linha;
        }
    }
}
