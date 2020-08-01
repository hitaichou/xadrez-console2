using System;
using tabuleiro;

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
                    //Console.Write('a' - j + " ");//insiro a letra nas colunas do tabuleiro

                    if (tab.peca(i,j) == null) //valido se a posição está nula
                    {
                        Console.Write("- ");                        
                    }
                    else
                    {
                        //chamo o método para imprimir peça na cor desejada
                        imprimiPeca(tab.peca(i, j));
                        Console.Write(" ");
                    }
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");           
        }

        //Método para mudar a cor da peça
        public static void imprimiPeca(Peca peca)
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

        }

    }
}

