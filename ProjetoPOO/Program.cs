using ProjetoPOO;
using System.Collections.Generic;
using System.Linq.Expressions;

class Program
{

    // Parte Main Sara

    // Criar lista para armazenar os livros
    /*
    static void RegLivros()
    {
        int opcao;


        // mudar a validacao para while na resposta ou so tirar o menu de dentro, assim nao repete o menu
        do
        {
            Console.WriteLine("--------------- Gestão de Livros ---------------");
            Console.WriteLine("| 1. Adicionar Novo Livro                      |");
            Console.WriteLine("| 2. Remover Livro Existente                   |");
            Console.WriteLine("| 3. Atualizar Número de Exemplares Disponíveis|");
            Console.WriteLine("| 4. Exibir Lista Atual de Livros              |");
            Console.WriteLine("| 5. Sair                                      |");
            Console.WriteLine("================================================");
            opcao = int.Parse(Console.ReadLine());
            Console.WriteLine("");


            switch (opcao)
            {
                case 1:
                    AdicionarNovoLivro(Livros);
                    break;
                case 2:
                    RemoverLivroExistente(Livros);
                    break;
                case 3:
                    AtualizarNumeroExemplares(Livros);
                    break;
                case 4:
                    ExibirListaLivros();
                    break;
                case 5:
                    Console.WriteLine("Saiu do programa");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente!");
                    break;
            }
        }
        while (opcao != 5);
    }
    
    static void AdicionarNovoLivro(List<RegistarLivro> Livros) // conflitos
    {
        string nomeLivro;
        string autor;
        int anoPublic;
        int numExemp;

        Console.WriteLine("Título: ");
        nomeLivro = Console.ReadLine();

        Console.WriteLine("Autor: ");
        autor = Console.ReadLine();

        Console.WriteLine("Ano de publicação: ");
        anoPublic = int.Parse(Console.ReadLine());

        Console.WriteLine("Número de exemplares disponíveis: ");
        numExemp = int.Parse(Console.ReadLine());

        RegistarLivro novoLivro = new RegistarLivro(nomeLivro, autor, anoPublic, numExemp);

        Livros.Add(novoLivro);
        Console.WriteLine("Novo Livro adicionado com sucesso!");
    }
    static void RemoverLivroExistente(List<RegistarLivro> Livros)
    {
        Console.Write("Nome do item a ser removido: ");
        string nomeLivro = Console.ReadLine();
        RegistarLivro livroRemover = Livros.Find(i => i.NomeLivro == nomeLivro);
        if (livroRemover != null)
        {
            Livros.Remove(livroRemover);
            Console.WriteLine("Livro removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
        }
    }
    static void AtualizarNumeroExemplares(List<RegistarLivro> Livros)
    {
        Console.Write("Nome do Livro que deseja atualizar o número de exemplares disponíveis: ");
        string nomeLivro = Console.ReadLine();
        RegistarLivro livroAtualizar = Livros.Find(i => i.NomeLivro == nomeLivro);
        if (livroAtualizar != null)
        {
            livroAtualizar.AtualizarQuantidadeDisponivel(); // método para atualizar a quantidade de exemplares
            Console.WriteLine("Número de exemplares disponíveis atualizado com sucesso!");
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
        }
    }
    static void ExibirListaLivros()
    {
        Console.WriteLine("---------------------------------------- Consulta de Livros ----------------------------------------");
        foreach (var livro in Livros)
        {
            if (livro.NumExemp > 0)
            {
                livro.ConsultaLivros();
            }
            // talvez passar a lista para ca para ter organizacao, ja que nao eh uma metodo grande
        }
        Console.WriteLine("====================================================================================================");
    }
    // Fim da parte Main Sara
    /*
    static List<EmprestimosLivros> emprestimoLivros = new List<EmprestimosLivros>();

    static List<RegistarLivro> Livros = new List<RegistarLivro>();

    static List<Utilizadores> listaUtilizadores = new List<Utilizadores>();
    */

    // Fim parte Bruno
    static void Main(string[] args)
    {
        
        List<Utilizadores> listaUtilizadores = new List<Utilizadores>();
        List<EmprestimosLivros> emprestimoLivros = new List<EmprestimosLivros>();
        List<RegistarLivro> Livros = new List<RegistarLivro>();

        var dataAtual = DateOnly.FromDateTime(DateTime.Now);

        // criando um usuario para teste
        RegistarLivro livroGrey = new RegistarLivro("grey", "bruno", 1720, 12);
        RegistarLivro livroFox = new RegistarLivro("foxhound", "joaqui,", 1790, 2);
        listaUtilizadores.Add(new Utilizadores("Eduardo Lopes", "Rua Braga", "987654321", "12345", true));
        listaUtilizadores.Add(new Utilizadores("Sara", "Rua Braga", "987654321", "12345", true));
        listaUtilizadores.Add(new Utilizadores("Bruno", "Rua Braga", "987654321", "12345", true));
        emprestimoLivros.Add(new EmprestimosLivros("paula", livroGrey, 5, false, dataAtual));
        emprestimoLivros.Add(new EmprestimosLivros("Sara", livroFox, 2, false, dataAtual));
        Livros.Add(livroGrey);
        Livros.Add(livroFox);
        Livros.Add(new RegistarLivro("uno", "jonh", 1989, 5));
        Livros.Add(new RegistarLivro("duo", "jonh2", 1986, 0));
        Livros.Add(new RegistarLivro("trio", "jonh3", 1980, 2));
        // --------------------------------------------------------------------------------

        

        // criar uma variável para armazenar o usuário logado
        Utilizadores utilizadorLogado = Utilizadores.MenuLogRes(listaUtilizadores, Livros);

        MenuPrincipal.MenuAcoesPrincipal(listaUtilizadores, utilizadorLogado, Livros, emprestimoLivros);


        // Ajustar as tabelas, adicionar o livro da semana, organizar os consoleClear da gestao de livros, maior leitor do mes, penalizacao para qm nao devolver a tempo

        // Arrumar tabela Consulta Livros (opcao 1)
        // 
        

        Console.WriteLine(dataAtual);
    }
}