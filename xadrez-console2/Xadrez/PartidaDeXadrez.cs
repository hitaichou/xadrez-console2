﻿using System;
using System.Collections.Generic;
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
        public bool xeque { get; private set; }
        public Peca vulneravelEnPassant { get; private set; }
        //Coleção (Collection) de dados que obedece as regras de conjunto
        private HashSet<Peca> pecas; //declaração da coleção para as minhas peças
        private HashSet<Peca> capturadas; //declaração da coleção para as peças capturadas

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca; //quem inicia a partida no xadrez é a peça branca
            terminada = false;
            xeque = false;
            vulneravelEnPassant = null;
            //é preciso instanciar antes de colocar as peças
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();

            colocarPecas();
        }

        //
        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            //Dado uma coluna e linha do xadrez e uma peça, vou no tabuleiro do xadrez e coloco a peça
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca); //e coloco a peça no conjunto, uma vez que a peça faz parte da partida.
        }

        private void colocarPecas()
        {
            //Adiciona as peças nas posições

            //BRANCAS
            colocarNovaPeca('a', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('b', 1, new Cavalo(tab, Cor.Branca));
            colocarNovaPeca('c', 1, new Bispo(tab, Cor.Branca)); 
            colocarNovaPeca('d', 1, new Dama(tab, Cor.Branca));
            colocarNovaPeca('e', 1, new Rei(tab, Cor.Branca, this)); //autoreferencia
            colocarNovaPeca('f', 1, new Bispo(tab, Cor.Branca));
            colocarNovaPeca('g', 1, new Cavalo(tab, Cor.Branca));
            colocarNovaPeca('h', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('a', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('b', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('c', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('d', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('e', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('f', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('g', 2, new Peao(tab, Cor.Branca, this));
            colocarNovaPeca('h', 2, new Peao(tab, Cor.Branca, this));
            //---------
            //PRETAS
            colocarNovaPeca('a', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('b', 8, new Cavalo(tab, Cor.Preta));
            colocarNovaPeca('c', 8, new Bispo(tab, Cor.Preta));
            colocarNovaPeca('d', 8, new Dama(tab, Cor.Preta));
            colocarNovaPeca('e', 8, new Rei(tab, Cor.Preta, this)); //autoreferencia
            colocarNovaPeca('f', 8, new Bispo(tab, Cor.Preta));
            colocarNovaPeca('g', 8, new Cavalo(tab, Cor.Preta));
            colocarNovaPeca('h', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('a', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('b', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('c', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('d', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('e', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('f', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('g', 7, new Peao(tab, Cor.Preta, this));
            colocarNovaPeca('h', 7, new Peao(tab, Cor.Preta, this));

        }

        //Este método executa o momento da peça através dos parâmetros
        //de origem e destino
        public Peca executaMovimento(Posicao origem, Posicao destino)
        {
            //retira a peça da origem
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimento(); //mexo a peça
            //Controlo a captura da peça
            Peca pecaCapturada = tab.retirarPeca(destino); //retiro a peça se existir na posição destino
            tab.colocarPeca(p, destino); //coloca peça na posição destino

            //se tinha uma peça no destino
            if(pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada); //se capturou uma peça, insere no conjunto das peças capturadas
            }

            //#jogadaespecial RoquePequeno
            if(p is Rei && destino.Coluna == origem.Coluna + 2) //se a peça é rei moveu duas casas para a direita, é roque
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3); //pega a origem da torre
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1); //pego o destino da torre baseado no rei
                Peca T = tab.retirarPeca(origemT); //movimento a torre
                T.incrementarQteMovimento(); //incrementando novo movimento da torre
                tab.colocarPeca(T, destinoT); //coloco a torre no destino
            }
            //#jogadaespecial RoqueGrande
            if (p is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca T = tab.retirarPeca(origemT);
                T.incrementarQteMovimento();
                tab.colocarPeca(T, destinoT);
            }

            //#jogadaespecial En Passant
            if(p is Peao )
            {
                if(origem.Coluna != destino.Coluna && pecaCapturada == null)
                {
                    Posicao posP;
                    if(p.cor == Cor.Branca)
                    {
                        posP = new Posicao(destino.Linha + 1, destino.Coluna);
                    }
                    else
                    {
                        posP = new Posicao(destino.Linha - 1, destino.Coluna);
                    }
                    pecaCapturada = tab.retirarPeca(posP);
                    capturadas.Add(pecaCapturada);
                }
            }

            return pecaCapturada;
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.retirarPeca(destino);
            p.decrementarQteMovimento();
            //se teve uma peça capturada
            if (pecaCapturada != null)
            {
                tab.colocarPeca(pecaCapturada, destino); //coloca a peça no destino
                capturadas.Remove(pecaCapturada); //remove a peça do conjunto das peças capturadas
            }
            tab.colocarPeca(p, origem); //coloco a peça "p" de volta na posição de origem

            //#jogadaespecial RoquePequeno
            if (p is Rei && destino.Coluna == origem.Coluna + 2) //se a peça é rei moveu duas casas para a direita, é roque
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3); //pega a origem da torre
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1); //pego o destino da torre baseado no rei
                Peca T = tab.retirarPeca(destinoT); //movimento a torre
                T.decrementarQteMovimento(); //decrementando movimento da torre
                tab.colocarPeca(T, origemT); //coloco a torre de volta na origem
            }
            //#jogadaespecial RoqueGrande
            if (p is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca T = tab.retirarPeca(destinoT);
                T.decrementarQteMovimento();
                tab.colocarPeca(T, origemT);
            }

            //jogadaespecial En Passant
            if(p is Peao)
            {
                if(origem.Coluna != destino.Coluna && pecaCapturada == vulneravelEnPassant)
                {
                    Peca peao = tab.retirarPeca(destino);
                    Posicao posP;
                    if(p.cor ==  Cor.Branca)
                    {
                        posP = new Posicao(3, destino.Coluna);
                    }
                    else
                    {
                        posP = new Posicao(4, destino.Coluna);
                    }
                    tab.colocarPeca(peao, posP);
                }
            }

        }


            //método que retorna as peças capturadas separadas por cor
            public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            //declaro um conjunto temporário dentro deste método
            HashSet<Peca> aux = new HashSet<Peca>();
            //Para cada peça "x" dentro do conjunto de peças capturadas
            foreach(Peca x in capturadas)
            {
                if(x.cor == cor) //se for igual a cor do parâmetro
                {
                    aux.Add(x);//insere no aux
                }
            }
            return aux;
        }

        //método das peças em jogo
        //Dentro deste método, ele percorre todas as peças e insere
        //todas dentro do conjunto aux, no entanto, ao final
        //é removido as pelas que foram capturadas conforme a chamada
        //do outro método pecasCapturadas
        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            //declaro um conjunto temporário dentro deste método
            HashSet<Peca> aux = new HashSet<Peca>();
            //Para cada peça "x" dentro do conjunto de pecas 
            foreach (Peca x in pecas)
            {
                if (x.cor == cor) //se for igual a cor do parâmetro
                {
                    aux.Add(x);//insere no aux
                }
            }
            //retiro todas as peças capturadas desta mesma cor
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = executaMovimento(origem, destino);

            if(estaEmXeque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque.");
            }
            Peca p = tab.peca(destino);

            //#jogadaespecial promocao
            if(p is Peao)
            {
                if((p.cor == Cor.Branca && destino.Linha == 0) || (p.cor == Cor.Preta && destino.Linha == 7))
                {
                    p = tab.retirarPeca(destino);
                    pecas.Remove(p); //remove do conjunto de peças
                    Peca dama = new Dama(tab, p.cor); //instancio a dama
                    tab.colocarPeca(dama, destino);
                    pecas.Add(dama);
                }

            }

            if (estaEmXeque(adversaria(jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }
            
            if(testeXequeMate(adversaria(jogadorAtual)))
            {
                terminada = true;
            }
            else
            {
                turno++;
                mudaJogador();
            }

            

            //#jogadaespecial EnPassant
            //se a peça é um peão e andou duas casas
            if(p is Peao && (destino.Linha == origem.Linha -2 || destino.Linha == origem.Linha + 2))
            {
                vulneravelEnPassant = p;
            }
            else
            {
                vulneravelEnPassant = null;
            }

            
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
            //Se a posição de origem NÃO pode mover para a posição de destino
            if (!tab.peca(origem).movimentoPossivel(destino))
            {
                throw new TabuleiroException("Posição de destino inválida.");
            }
        }
        //Método private pois somente será usada nesta classe
        //Ela determina qual a cor é a adversária
        private Cor adversaria (Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        private Peca rei(Cor cor)
        {
            //percorre o conjunto pecasEmJogo para saber quem é o rei da cor
            foreach(Peca x in pecasEmJogo(cor))
            {
                //palavra "is"
                //Peca é uma superclasse e Rei, Torre, Bispo, etc, são subclasses
                //Para testar se a variável "x" do tipo da superclasse Peca
                //é uma instancia de uma subclasse (neste caso: Rei), então usa-se a palavra "is"
                if(x is Rei)
                {
                    return x;
                }
            }
            return null;
        }
        
        //método que retorna todos os movimentos possiveis
        public bool estaEmXeque(Cor cor)
        {
            Peca R = rei(cor); //variável R recebe o rei da cor informada

            //se R for nulo, não existe Rei
            if(R == null) 
            {
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro.");
            }

            //Para cada peça adversária
            foreach (Peca x in pecasEmJogo(adversaria(cor))) 
            {
                bool[,] mat = x.movimentosPossiveis(); //pego todos os movimentos possíveis da peça adversária

                //Se a matrix na posição da peça adversária
                //estiver dentro da posição do rei
                //significa que o rei está em xeque
                if(mat[R.posicao.Linha, R.posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public bool testeXequeMate(Cor cor)
        {
            if(!estaEmXeque(cor))
            {
                return false;
            }
            foreach(Peca x in pecasEmJogo(cor)) //varro toda peça x no conjunto de peças em jogo da cor
            {
                bool[,] mat = x.movimentosPossiveis();
                for(int i = 0; i < tab.linhas; i++)
                {
                    for(int j = 0; i < tab.colunas; i++)
                    {
                        if (mat[i,j]) //entro se for verdadeiro
                        {
                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = executaMovimento(origem, destino); //faço movimento da posição da peça para o destino
                            bool testeXeque = estaEmXeque(cor); //checo se ainda está em xeque
                            desfazMovimento(origem, destino, pecaCapturada); //desfaço o movimento
                            if(!testeXeque)
                            {
                                return false; //se entrar aqui é porque não está mais em xeque
                            }
                        }
                    }
                }
            }
            return true; //se todos os testes derem errado, é porque não há mais alternativas.

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
