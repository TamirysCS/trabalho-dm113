using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ProdutoEstoquesClient.ProdutoEstoquesService;

namespace ProdutoEstoquesClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a proxy object and connect to the service
            ProdutoEstoquesServiceClient proxy = new ProdutoEstoquesServiceClient();


            // Test the operations in the service
            //  Listar produtos
            Console.WriteLine("Test 1: List all products");
            List<string> products = proxy.ListarProdutos().ToList();
            foreach (string p in products)
            {
                Console.WriteLine("Name: {0}", p);
                Console.WriteLine();
            }
            Console.WriteLine();


            // Incluir produto
            Console.WriteLine("Test 2: Add a new product");
            Produto produto = new Produto();
            produto.NumeroProduto = "12000";
            produto.NomeProduto = "Produto teste Tamirys";
            produto.DescricaoProduto = "Teste Tamirys Descricao";
            produto.EstoqueProduto = 234;

            bool added = proxy.IncluirProduto(produto);

            Console.WriteLine("Produto 12000 adicionado: {0}", added);
            Console.WriteLine();


            // Incluir produto
            Console.WriteLine("Test 2.1: Add a new product 2");
            Produto produto2 = new Produto();
            produto2.NumeroProduto = "13000";
            produto2.NomeProduto = "Produto 2 teste Tamirys";
            produto2.DescricaoProduto = "Teste 2 Tamirys Descricao";
            produto2.EstoqueProduto = 777;

            bool added2 = proxy.IncluirProduto(produto2);

            Console.WriteLine("Produto 13000 adicionado: {0}", added2);
            Console.WriteLine();


            // Remover produto
            Console.WriteLine("Test 3: Remove a product");

            bool removed = proxy.RemoverProduto("12000");

            Console.WriteLine("Produto 12000 removido: {0}", removed);
            Console.WriteLine();


            // Consultar estoque
            Console.WriteLine("Test 4: Get stock");

            int estoque = proxy.ConsultarEstoque("1000");

            Console.WriteLine("Quantidade em estoque do produto 1000: {0}", estoque);
            Console.WriteLine();


            // Adicionar estoque
            Console.WriteLine("Test 5: Add stock");

            bool estoqueAdicionado = proxy.AdicionarEstoque("2000", 25);

            Console.WriteLine("25 itens adicionados ao estoque do produto 2000: {0}", estoqueAdicionado);
            Console.WriteLine();


            // Remover estoque
            Console.WriteLine("Test 6: Remove stock");

            bool estoqueRemovido = proxy.RemoverEstoque("3000", 10);

            Console.WriteLine("10 itens removidos do estoque do produto 3000: {0}", estoqueRemovido);
            Console.WriteLine();


            // Ver produto
            Console.WriteLine("Test 7: Get product");

            Produto prod = proxy.VerProduto("3000");

            Console.WriteLine("Informações do produto 3000:");
            Console.WriteLine("Número: {0}", prod.NumeroProduto);
            Console.WriteLine("Nome: {0}", prod.NomeProduto);
            Console.WriteLine("Descrição: {0}", prod.DescricaoProduto);
            Console.WriteLine("Estoque: {0}", prod.EstoqueProduto);
            Console.WriteLine();


            //  Listar produtos
            Console.WriteLine("Final Test: List all products again");
            List<string> productsFinal = proxy.ListarProdutos().ToList();
            foreach (string p in productsFinal)
            {
                Console.WriteLine("Name: {0}", p);
                Console.WriteLine();
            }
            Console.WriteLine();


            // Disconnect from the service
            proxy.Close();
            Console.WriteLine("Press ENTER to finish");
            Console.ReadLine();
          
        }
    }
}
