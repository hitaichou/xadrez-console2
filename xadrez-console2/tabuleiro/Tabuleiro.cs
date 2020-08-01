
namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas { get; set; }

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            //A variável Peca é criado como matriz e recebe de parâmetro as linhas e colunas
            //do construtor.
            pecas = new Peca[linhas, colunas];
        }

        //Como o atributo Peca é privativo, crio um método
        //no qual insere no atributo o valor de linha e coluna.
        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        //Sobrecarga do método peça 
        //recebe uma posição pos
        //retorna matriz peca
        public Peca peca(Posicao pos)
        {
            return pecas[pos.Linha, pos.Coluna];
        }

        //Este método valida se existe a peça na posição        
        public bool existePeca(Posicao pos)
        {
            //Chamo o método de validação de posição para validar
            //se está correta a posição lançada.
            //Se NÃO for verdade, o programa já corta a execução.
            validarPosicao(pos);
            //Se for verdade, vai avisar que existe uma peça na posição
            return peca(pos) != null;
        }


        //Vou na matriz (acesso a matriz) de peças na posição.
        //recebo a peça p e adiciono na matriz na posição pos.linha, pos.coluna
        public void colocarPeca(Peca p, Posicao pos)
        {
            if(existePeca(pos)) //checo se existe peça na posição
            {
                //com o método de Exceção, é possível personalizar as mensagens
                throw new TabuleiroException("Já existe peça nesta posição."); 
            }
            pecas[pos.Linha, pos.Coluna] = p;
            p.posicao = pos; //vou na peça p e digo que a posição dela agora é pos
        }

        //Método que valida se as dimensões da matriz estão corretas
        //Qualquer coisa fora dela, é para retornar erro.
        public bool posicaoValida(Posicao pos)
        {
            if(pos.Linha < 0 || pos.Linha >= linhas || pos.Coluna < 0 || pos.Coluna >= colunas)
            {
                return false;
            }
            return true;
        }
        public void validarPosicao(Posicao pos)
        {
            //Checa abaixo Se a posição NÃO é válida
            //! --> a checagem começa com NÃO.
            if(!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição Invalida."); //usa a exceção do tabuleiro
            }
        }


    }
    
}
