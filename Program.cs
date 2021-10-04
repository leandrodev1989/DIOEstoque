using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DIOEstoque
{
    class Program
    {

        static List<IRepositorio> produtos = new List<IRepositorio>();
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair }
        static void Main(string[] args)
        {
            //carrega tudo projeto
            Carregar();
            bool escolheuSair = false;
            while ( escolheuSair == false)
            {
                //Criação da Exibição do Menu
                Console.WriteLine("Sistema de Estoque DIO");
                Console.WriteLine("1-Listar\n2-Adicionar\n3-Remover\n4-Adicionar entrada\n5-Adicionar Saida\n6-Sair");
                string opStr = Console.ReadLine();
                int opInt = int.Parse(opStr);

                //Condição criada caso o usuario digite um numero diferente da opção do Menu
                if(opInt > 0 && opInt < 7)
                {
                    Menu escolha = (Menu)opInt;

                    switch (escolha)
                    {
                        case Menu.Listar:
                            Listagem();
                            break;
                        case Menu.Adicionar:
                            Cadastro();
                            break;
                        case Menu.Remover:
                            Remover();
                            break;
                        case Menu.Entrada:
                            Entrada();
                            break;
                        case Menu.Saida:
                            Saida();
                            break;
                        case Menu.Sair:
                            escolheuSair = true;
                            break;
                    }

                }
                else
                {
                    escolheuSair = true;
                }
                Console.Clear();
            }

        }

        //Metodo de Listagem dos Produtos
        static void Listagem()
        {
            Console.WriteLine("Lista de Produtos");
            int i = 0;
            foreach (IRepositorio produto in produtos)
            {
                Console.WriteLine("ID: " + i);
                produto.Exibir();
                i++;
            }
            Console.ReadLine();
        }

        //Metodo Remover produtos
        static void Remover()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que voçê quer remover:");
            int id = int.Parse(Console.ReadLine());
            if(id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }

        }

        //Metodo para dar entrada no estoque
        static void Entrada()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que voçê quer dar entrada:");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Salvar();
            }
        }

        //Metodo Saida
        static void Saida()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que voçê quer dar Baixa:");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();
            }
        }

        //Metodo Opção Cadastro Para adicionar
        static void Cadastro()
        {
            Console.WriteLine("Cadastro de Produtos");
            Console.WriteLine("1-Produto Fisico\n2-Ebook\n3-Curso");
            string opStr = Console.ReadLine();
            int escolhaInt = int.Parse(opStr);
            switch (escolhaInt)
            {
                case 1:
                    CadastrarPFisico();
                    break;
                case 2:
                    CadastrarEbook();
                    break;
                case 3:
                    CadastrarCurso();
                    break;
            }
                
        }

        //Metodo Cadastrar Produto Fisico
        static void CadastrarPFisico()
        {
            Console.WriteLine("Cadastrando produto fisico");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());

            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf);
            Salvar();
        }

        //Metodo Cadastrar Ebook
        static void CadastrarEbook()
        {
            Console.WriteLine("Cadastrando Ebook");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Ebook eb = new Ebook(nome, preco, autor);
            produtos.Add(eb);
            Salvar();

            
        }

        //Metodo para cadastrar cursos
        static void CadastrarCurso()
        {
            Console.WriteLine("Cadastrando Curso");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Curso cs = new Curso(nome, preco, autor);
            produtos.Add(cs);
            Salvar();


        }

        //Metodo: Salvar
        static void Salvar()
        {
            FileStream stream = new FileStream("produtos.dat",FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtos);

            stream.Close();
        }

        //Metodo para carregar
        static void Carregar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                produtos = (List<IRepositorio>)encoder.Deserialize(stream);

                if(produtos == null)
                {
                    produtos = new List<IRepositorio>();
                }
            }
            catch(Exception e)
            {
                produtos = new List<IRepositorio>();
            }

            stream.Close();

            
        }
    }
}
