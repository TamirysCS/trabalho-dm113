using EstoqueEntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace ProdutoEstoques
{
    // WCF service that implements the service contract 
    // This implementation performs minimal error checking and exception handling
    [AspNetCompatibilityRequirements(
        RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ProductoEstoquesService : IProdutoEstoquesService
    {
        public bool AdicionarEstoque(string NumeroProduto, int Quantidade)
        {
            throw new NotImplementedException();
        }

        public int ConsultarEstoque(string NumeroProduto)
        {
            throw new NotImplementedException();
        }

        public bool IncluirProduto(Produto Produto)
        {
            throw new NotImplementedException();
        }

        public List<string> ListarProdutos()
        {
            // Create a list of products
            List<string> productsListNames = new List<string>();
            try
            {
                // Connect to the EstoqueEntityModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Fetch the products in the database
                    List<ProdutoEstoque> produtoEstoques = (from produtoEstoque in database.ProdutoEstoques select produtoEstoque).ToList();
                    foreach (ProdutoEstoque produtoEstoque in produtoEstoques)
                    {
                        productsListNames.Add(produtoEstoque.NomeProduto);
                    }
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            // Return the list of products names
            return productsListNames;
        }

        public bool RemoverEstoque(string NumeroProduto, int Quantidade)
        {
            throw new NotImplementedException();
        }

        public bool RemoverProduto(string NumeroProduto)
        {
            throw new NotImplementedException();
        }

        public Produto VerProduto(string NumeroProduto)
        {
            throw new NotImplementedException();
        }
    }
}
