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
            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Find the ProductID for the specified product
                    int productID = (from p in database.ProdutoEstoques
                                     where String.Compare(p.NumeroProduto, NumeroProduto) == 0
                                     select p.Id).First();
                    // Find the Stock object that matches the parameters passed
                    // in to the operation
                    ProdutoEstoque ProdutoEstoque = database.ProdutoEstoques.First(pi => pi.Id == productID);
                    ProdutoEstoque.EstoqueProduto = Quantidade;
                    database.ProdutoEstoques.Add(ProdutoEstoque);
                    // Save the change back to the database
                    database.SaveChanges();
                }
            }
            catch
            {
                // If an exception occurs, return false to indicate failure
                return false;
            }
            // Return true to indicate success
            return true;
        }

        public int ConsultarEstoque(string NumeroProduto)
        {
            int quantityTotal = 0;
            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Calculate the sum of all quantities for the specified product
                    quantityTotal = (from p in database.ProdutoEstoques
                                     where String.Compare(p.NumeroProduto, NumeroProduto) == 0
                                     select (int)p.EstoqueProduto).Sum();
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            // Return the stock level
            return quantityTotal;
        }

        public bool IncluirProduto(Produto Produto)
        {
            try
            {
                // Connect to the EstoqueEntityModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque p = new ProdutoEstoque()
                    {
                        NumeroProduto = Produto.NumeroProduto,
                        NomeProduto = Produto.NomeProduto,
                        DescricaoProduto = Produto.DescricaoProduto,
                        EstoqueProduto = Produto.EstoqueProduto
                    };

                    database.ProdutoEstoques.Add(p);
                    // Save the change back to the database
                    database.SaveChanges();

                    return true;
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            return false;
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
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Find the first product that matches the specified product code
                    ProdutoEstoque matchingProduct = database.ProdutoEstoques.First(
                        p => String.Compare(p.NumeroProduto, NumeroProduto) == 0);

                    if (Quantidade >= matchingProduct.EstoqueProduto)
                    {
                        matchingProduct.EstoqueProduto = 0;
                    }
                    else
                    {
                        matchingProduct.EstoqueProduto = matchingProduct.EstoqueProduto - Quantidade;
                    }

                    //database.ProdutoEstoques.Remove(matchingProduct);
                    database.ProdutoEstoques.Add(matchingProduct);
                    database.SaveChanges();//?????
                        //PAGINA 28 APOSTILA E 7 TRABALHO

                    return true;
                }

            }
            catch (Exception)
            {

                //throw;
                // Ignore exceptions in this implementation
            }

            return false;
        }

        public bool RemoverProduto(string NumeroProduto)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Find the first product that matches the specified product code
                    ProdutoEstoque matchingProduct = database.ProdutoEstoques.First(
                        p => String.Compare(p.NumeroProduto, NumeroProduto) == 0);

                    database.ProdutoEstoques.Remove(matchingProduct);
                    database.SaveChanges();

                    return true;
                }

            }
            catch (Exception)
            {

                //throw;
                // Ignore exceptions in this implementation
            }

            return false;
        }

        public Produto VerProduto(string NumeroProduto)
        {
            Produto Produto = null;

            try
            {
                // Connect to the EstoqueEntityModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Find the first product that matches the specified product code
                    ProdutoEstoque matchingProduct = database.ProdutoEstoques.First(
                        p => String.Compare(p.NumeroProduto, NumeroProduto) == 0);
                    Produto = new Produto()
                    {
                        NumeroProduto = matchingProduct.NumeroProduto,
                        NomeProduto = matchingProduct.NomeProduto,
                        DescricaoProduto = matchingProduct.DescricaoProduto,
                        EstoqueProduto = matchingProduct.EstoqueProduto
                    };
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            // Return the product
            return Produto;
            
        }
    }
}
