using System;
using tabuleiro;
using xadrez;

namespace xadrez_console2
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8,8);

            /*Criado subclasse da Torre e Rei
             * Dentro da namespace xadrez
             * Com o toString T e R respectivamente
             * Atualizado classe Peca, agora toda peça começa na posição nula
             * Quem atribui a posição a peça é o método Tabuleiro.colocarPeca
             * E o método é chamado aqui no programa principal
             */
            tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
            tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
            tab.colocarPeca(new Rei(tab,Cor.Preta) , new Posicao(2, 4));

            Tela.imprimirTabuleiro(tab);

        }
    }
}
