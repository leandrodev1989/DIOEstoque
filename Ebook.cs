using System;
using System.Collections.Generic;
using System.Text;

namespace DIOEstoque
{
    [System.Serializable]
    class Ebook : Produto, IRepositorio 
    {
        //Atributos
        public string autor;
        private int vendas;

        public Ebook(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
            
        }

        //Metodos: Entrada
        public void AdicionarEntrada()
        {
            Console.WriteLine("Não é possivel dar entrada no estoque de um E-book, pois é um produto digital!");
            Console.ReadLine();
        }

        //Metodo: Saida
        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar vendas no E-book {nome}");
            Console.WriteLine("Digite a quantidade de vendas voçê quer dar Entrada: ");
            int saida = int.Parse(Console.ReadLine());
            //estoque = estoque + entrada;
            vendas -= saida;
            Console.WriteLine("Saída Registrada!!");
            Console.ReadLine();
        }

        //Metodo: Exibir
        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Vendas: {vendas}");
            Console.WriteLine("====================");
        }
    }
}
