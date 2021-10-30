using System;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace EstoqueEntityModel
{
    public class ProvedorEstoque : DbContext
    {
        // Your context has been configured to use a 'ProvedorEstoque' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EstoqueEntityModel.ProvedorEstoque' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ProvedorEstoque' 
        // connection string in the application configuration file.
        public ProvedorEstoque()
            : base("name=ProvedorEstoque")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<ProdutoEstoque> ProdutoEstoques { get; set; }
    }

    public class ProdutoEstoque
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Número é obrigatório")]
        public string NumeroProduto { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string NomeProduto { get; set; }

        public string DescricaoProduto { get; set; }

        [Required(ErrorMessage = "O campo Estoque é obrigatório")]
        public int EstoqueProduto { get; set; }

    }
}