using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez_console2
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            //crio matriz para criar o tabuleiro na tela
            for(int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " "); //insiro o número da linha do tabuleiro

                for(int j = 0; j < tab.colunas; j++)
                {
                    //chamo o método para imprimir peça na cor desejada
                    imprimiPeca(tab.peca(i, j));                        
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");           
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] possicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor; //armazeno a cor de fundo
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray; //quando a posição estiver marcado, uso a cor alterado
            
            //crio matriz para criar o tabuleiro na tela
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " "); //insiro o número da linha do tabuleiro

                for (int j = 0; j < tab.colunas; j++)
                {
                    //Se a posição estiver marcado para possível movimento
                    //mudo a cor do fundo
                    if(possicoesPossiveis[i,j]) //Por ser bool, se for verdadeiro, entra no if
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    //chamo o método para imprimir peça na cor desejada
                    imprimiPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;

        }

        //Método para mudar a cor da peça
        public static void imprimiPeca(Peca peca)
        {
            if(peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                //se a peça for branca, mantém a sua cor
                if(peca.cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor; //salvo a cor padrão de fundo na variável
                    Console.ForegroundColor = ConsoleColor.Yellow; //mudo o fundo para uma outra cor
                    Console.Write(peca); //imprimo a peça
                    Console.ForegroundColor = aux; //volto a cor de fundo original
                }

                Console.Write(" ");
            }

        }

        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            Console.WriteLine("Aguardando jogada " + partida.jogadorAtual);
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Preta : ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void imprimirConjunto (HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach(Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine(); //leio a jogada do usuário 
            char coluna   = s[0]; //pego a letra na primeira posicao
            int linha = int.Parse(s[1] + ""); //forço a ser string
            return new PosicaoXadrez(coluna, linha); 

        }

    }
}

