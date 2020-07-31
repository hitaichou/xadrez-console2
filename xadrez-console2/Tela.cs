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
                for(int j = 0; j < tab.colunas; j++)
                {
                    if (tab.peca(i,j) == null) //valido se a posição está nula
                    {
                        Console.Write("- ");                        
                    }
                    else
                    {
                        Console.Write(tab.peca(i, j) + " ");
                    }
                    
                }
                Console.WriteLine();
            }
           
        }

    }
}

