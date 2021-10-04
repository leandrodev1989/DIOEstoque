using System;
using System.Collections.Generic;
using System.Text;

namespace DIOEstoque
{
    [System.Serializable]
    class ProdutoFisico : Produto, IRepositorio
    {
        //Atributos
        public float frete;
        private int estoque;

        public ProdutoFisico(string nome, float preco, float frete)
        {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;
            


        }


        //Metodos: Entrada
        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar Entrada no estoque do produto {nome}");
            Console.WriteLine("Digite a quantidade que voçê quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            //estoque = estoque + entrada;
            estoque += entrada;
            Console.WriteLine("Entrada Registrada!!");
            Console.ReadLine();
            
        }
        //Metodo: Saida
        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar Saída no estoque do produto {nome}");
            Console.WriteLine("Digite a quantidade que voçê quer dar Baixa: ");
            int saida = int.Parse(Console.ReadLine());
            //estoque = estoque + entrada;
            estoque -= saida;
            Console.WriteLine("Saída Registrada!!");
            Console.ReadLine();

        }

        //Metodo: Exibir
        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Frete: {frete}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Estoque: {estoque}");
            Console.WriteLine("====================");

        }
    }
}
