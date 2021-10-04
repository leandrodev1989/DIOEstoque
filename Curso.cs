using System;
using System.Collections.Generic;
using System.Text;

namespace DIOEstoque
{
    [System.Serializable]
    class Curso : Produto, IRepositorio
    {
        //Atributos
        public string autor;
        private int vagas;

        public Curso(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
            
        }

        //Metodos: Entrada
        public void AdicionarEntrada()
        {

            Console.WriteLine($"Adicionar entrada no estoque  {nome}");
            Console.WriteLine("Digite a quantidade de Vagas que voçê quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            //estoque = estoque + entrada;
            vagas += entrada;
            Console.WriteLine("Entrada Registrada!!");
            Console.ReadLine();
        }

        //Metodo: Saida
        public void AdicionarSaida()
        {
            Console.WriteLine($"Consumir vagas no curso {nome}");
            Console.WriteLine("Digite a quantidade de vagas que voçê quer dar Baixa: ");
            int saida = int.Parse(Console.ReadLine());
            //estoque = estoque + entrada;
            vagas -= saida;
            Console.WriteLine("Saída Registrada!!");
            Console.ReadLine();
        }

        //Metodo: Exibir
        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Vagas restantes: {vagas}");
            Console.WriteLine("====================");

        }
    }
}
