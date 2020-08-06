using System;
using tabuleiro;
using xadrez;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set;}

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca; //quem inicia a partida no xadrez é a peça branca
            terminada = false;
            colocarPecas();
        }

        private void colocarPecas()
        {
           
            //Adiciona as peças nas posições
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c',1).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('d', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 2).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 1).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('d', 1).toPosicao());

            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 8).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('d', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 7).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 8).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('d', 8).toPosicao());


        }

        //Este método executa o momento da peça através dos parâmetros
        //de origem e destino
        public void executaMovimento(Posicao origem, Posicao destino)
        {
            //retira a peça da origem
            Peca p = tab.retirarPeca(origem);
            //p.incrementarQteMovimento(); //mexo a peça
            //Controlo a captura da peça
            Peca pecaCapturada = tab.retirarPeca(destino); //retiro a peça se existir na posição destino
            tab.colocarPeca(p, destino); //coloca peça na posição destino
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }

        public void validarPosicaoOrigem(Posicao pos)
        {
            //se a posição escolhida for igual a nulo, então não tem peça.            
            if(tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida.");
            }
            //Se a cor do jogador atual for diferente da cor da peça, lança exceção
            if(jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua.");
            }
            //Se NÃO existe movimentos possíveis para a peça, lança exceção.
            if(!tab.peca(pos).exiteMovimentoPossiveis())
            {
                throw new TabuleiroException("Não há movimento possíveis para a peça de origem escolhida.");
            }
        }

        public void validaPosicaoDestino(Posicao origem, Posicao destino)
        {
            //Se a posição de origem NÃO pode mover para a posição de origem
            if (!tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida.");
            }
        }

        //método será usado somente nesta classe
        //testa o jogador para mudar o jogador
        private void mudaJogador()
        {
            if(jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }
    }
}
