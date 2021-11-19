using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ProdutoEstoquesClient.ProdutoEstoquesServiceV2;

namespace ProdutoVendasClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vendas Cliente");
            Console.WriteLine("Press ENTER when the service has started");
            Console.ReadLine();

            // Create a proxy object and connect to the service
            ProdutoEstoquesServiceV2Client proxy =
                new ProdutoEstoquesServiceV2Client("WS2007HttpBinding_IProdutoEstoquesService");

            // 1) Verificar o estoque atual do Produto 1000
            Console.WriteLine("Test 1: Get stock");

            int estoque1000 = proxy.ConsultarEstoque("1000");

            Console.WriteLine("Quantidade em estoque do produto 1000: {0}", estoque1000);
            Console.WriteLine();


            // 2) Adicionar 20 unidades para este produto
            Console.WriteLine("Test 2: Add stock");

            bool estoqueAdicionado = proxy.AdicionarEstoque("1000", 20);

            Console.WriteLine("20 itens adicionados ao estoque do produto 1000: {0}", estoqueAdicionado);
            Console.WriteLine();

            // 3) Verificar o estoque do Produto 1 novamente
            Console.WriteLine("Test 3: Get stock");

            int estoque1000Atualizado = proxy.ConsultarEstoque("1000");

            Console.WriteLine("Quantidade em estoque atualizada do produto 1000: {0}", estoque1000Atualizado);
            Console.WriteLine();

            // 4) Verificar o estoque atual do Produto 2000
            Console.WriteLine("Test 4: Get stock");

            int estoque2000 = proxy.ConsultarEstoque("2000");

            Console.WriteLine("Quantidade em estoque do produto 2000: {0}", estoque2000);
            Console.WriteLine();

            // 5) Remover 10 unidades para este produto
            Console.WriteLine("Test 5: Remove stock");

            bool estoqueRemovido = proxy.RemoverEstoque("2000", 10);

            Console.WriteLine("10 itens removidos do estoque do produto 2000: {0}", estoqueRemovido);
            Console.WriteLine();

            // 6) Verificar o estoque do Produto 2000 novamente
            Console.WriteLine("Test 6: Get stock");

            int estoque2000Atualizado = proxy.ConsultarEstoque("2000");

            Console.WriteLine("Quantidade em estoque do produto 2000: {0}", estoque2000Atualizado);
            Console.WriteLine();

        }
    }
}
