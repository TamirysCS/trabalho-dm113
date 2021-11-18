using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProdutoEstoques
{

    // Use um contrato de dados como ilustrado no exemplo abaixo para adicionar tipos compostos a operações de serviço.
    [DataContract]
    public class Produto
    {
        [DataMember]
        public string NumeroProduto;

        [DataMember]
        public string NomeProduto;

        [DataMember]
        public string DescricaoProduto;

        [DataMember]
        public int EstoqueProduto;
    }

    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "IService1" no arquivo de código e configuração ao mesmo tempo.
    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/01", Name = "IProdutoEstoquesService")]
    public interface IProdutoEstoquesService
    {

        [OperationContract]
        List<string> ListarProdutos();//retorna lista de String contendo nomes dos produtos no banco

        [OperationContract]
        bool IncluirProduto(Produto Produto);//Produto a ser incluído com seus parâmetros preenchidos.

        [OperationContract]
        bool RemoverProduto(string NumeroProduto);//String contendo o número do produto a ser removido.

        [OperationContract]
        int ConsultarEstoque(string NumeroProduto);

        [OperationContract]
        bool AdicionarEstoque(string NumeroProduto, int Quantidade);

        [OperationContract]
        bool RemoverEstoque(string NumeroProduto, int Quantidade);

        [OperationContract]
        Produto VerProduto(string NumeroProduto);// retorna Produto contendo os parâmetros recuperados do banco.

    }

    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "IService1" no arquivo de código e configuração ao mesmo tempo.
    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/02", Name = "IProdutoEstoquesServiceV2")]
    public interface IProdutoEstoquesServiceV2
    {

        [OperationContract]
        bool AdicionarEstoque(string NumeroProduto, int Quantidade);

        [OperationContract]
        bool RemoverEstoque(string NumeroProduto, int Quantidade);

        [OperationContract]
        int ConsultarEstoque(string NumeroProduto);

    }


}
