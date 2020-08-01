using System;
using tabuleiro;
using xadrez;

namespace xadrez_console2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Tabuleiro tab = new Tabuleiro(8, 8);

                /*Criado subclasse da Torre e Rei
                 * Dentro da namespace xadrez
                 * Com o toString T e R respectivamente
                 * Atualizado classe Peca, agora toda peça começa na posição nula
                 * Quem atribui a posição a peça é o método Tabuleiro.colocarPeca
                 * E o método é chamado aqui no programa principal
                 */
                //tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));                
                //tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 2));

                PartidaDeXadrez partida = new PartidaDeXadrez();

                while(!partida.terminada)
                {
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);

                    Console.WriteLine();
                    //Peço a origem e destino
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao(); //leio a posição e transformo em posição de matriz
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                    partida.executaMovimento(origem, destino);

                }

                


            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            

        }
    }
}
