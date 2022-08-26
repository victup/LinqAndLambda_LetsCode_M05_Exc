using LinqAndLambda;
using static System.Console;

class Program
{
    private static List<Produto> listaProdutos = new()
    {
        new Produto { Id = 2, Nome = "Camiseta", Valor = 52, Ativo = true },
        new Produto { Id = 8, Nome = "Guarda-Chuva", Valor = 19, Ativo = true },
        new Produto { Id = 4, Nome = "Celular", Valor = 8500, Ativo = true },
        new Produto { Id = 3, Nome = "Arroz", Valor = 21, Ativo = false },
        new Produto { Id = 1, Nome = "Geladeira", Valor = 1900, Ativo = true },
        new Produto { Id = 9, Nome = "Panela", Valor = 41, Ativo = true },
        new Produto { Id = 5, Nome = "Chinelo", Valor = 11, Ativo = false },
        new Produto { Id = 7, Nome = "TV", Valor = 2350, Ativo = true },
        new Produto { Id = 6, Nome = "Patins", Valor = 66, Ativo = true },
    };

    public static void Main(string[] args)
    {

        var retorno = RetornaProdutosTerminadosEm('o');

        foreach (var item in retorno)
        {
            WriteLine(item);
        }

        WriteLine("Quantidade de Produtos menor que 50 " + RetornaQuantidadeDeProdutosComValorMenorQue(20));
        WriteLine("Média de Valor dos Produtos Inativos: " + RetornaMediaDosProdutosInativos());

        WriteLine("Primeiro produto com valor inferior à 10 reais: " + RetornaPrimeiroProdutoComValorInferiorA(10));


        WriteLine("Retorna o último elemento da lista em ordem Decrescente: " + RetornaUltimoElementoDaListaDeOrdemDescrescente());



        WriteLine("Produtos Antes");

        foreach (var item in listaProdutos)
        {
            WriteLine(item);
        }





        WriteLine("Produtos Depois");

        AtualizaValoresDoProduto(1, 2000);
        AtualizaValoresDoProduto(2, 200);
        AtualizaValoresDoProduto(40, 200);
        foreach (var item in listaProdutos)
        {
            WriteLine(item);
        }
    }

    //Utilizando a fonte de dados disponibilizada, crie um método que retorne uma lista de produtos cuja última letra do nome é a vogal "O".
    private static List<Produto> RetornaProdutosTerminadosEm(char letra)
    {
        return listaProdutos
            .Where(prod => prod.Nome.ToLower()
            .EndsWith(letra.ToString().ToLower()))
            .ToList();
    }

    //Utilizando a fonte de dados disponibilizada, crie um método que retorne a quantidade de produtos cujo valor é menor que 50 reais.
    private static int RetornaQuantidadeDeProdutosComValorMenorQue(decimal valor)
    {
        return listaProdutos.Count(prod => prod.Valor < valor);
    }

    //Utilizando a fonte de dados disponibilizada, crie um método que retorne a média de preço dos produtos inativos.

    private static decimal RetornaMediaDosProdutosInativos()
    {
        return listaProdutos
            .Where(prod => prod.Ativo == false)
            .Average(prod => prod.Valor);

    }

    //Utilizando a fonte de dados disponibilizada, crie um método que retorne o primeiro produto com valor inferior à 10 reais.
    //Retorne nulo se não existir.

    private static string RetornaPrimeiroProdutoComValorInferiorA(decimal valor)
    {
        return listaProdutos
            .Where(prod => prod.Valor < valor)
            .OrderBy(prod => prod.Valor)
            .Select(prod => prod.Nome)
            .FirstOrDefault();

    }

    //Utilizando a fonte de dados disponibilizada, crie um método que ordene os produtos por Nome, em ordem decrescente,
    //e retorne o último elemento da lista.

    private static string RetornaUltimoElementoDaListaDeOrdemDescrescente()
    {
        return listaProdutos
            .OrderByDescending(prod => prod.Nome)
            .Select(prod => prod.Nome)
            .LastOrDefault();
    }

    //Utilizando a fonte de dados disponibilizada, crie um método que permita a alteração dos valores dos produtos.
    //Esse método irá receber o Id e o novo valor e irá realizar a atualização.
    //Caso o Id não exista, exiba uma mensagem.



    private static void AtualizaValoresDoProduto(int id, decimal novoValor)
    {
        var produto = listaProdutos.Find(prod => prod.Id == id);

        if (produto != null)
            produto.Valor = novoValor;
        else
            WriteLine($"Não foi possível localizar o produto pelo ID {id} informado");

    }




}
