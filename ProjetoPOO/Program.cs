using ProjetoPOO;

class Program
{

    // Parte Main Sara

    // Criar lista para armazenar os livros


    static void RegLivros()
    {
        List<RegistarLivro> Livros = new List<RegistarLivro>();

        int opcao;

        do
        {
            Console.WriteLine(" --------------- Gestão de Livros ---------------");
            Console.WriteLine(" | 1. Adicionar Novo Livro                      |");
            Console.WriteLine(" | 2. Remover Livro Existente                   |");
            Console.WriteLine(" | 3. Atualizar Número de Exemplares Disponíveis|");
            Console.WriteLine(" | 4. Exibir Lista Atual de Livros              |");
            Console.WriteLine(" | 5. Sair                                      |");
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
                    ExibirListaLivros(Livros);
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

    static void AdicionarNovoLivro(List<RegistarLivro> Livros)
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

    static void ExibirListaLivros(List<RegistarLivro> Livros)
    {
        Console.WriteLine("Consulta de Livros");
        foreach (var livro in Livros)
        {
            livro.ConsultaLivros();
            Console.WriteLine("");
        }
    }

    // Fim da parte Main Sara



    // Parte Main dudu
    static void MenuLogRes()

    {
        double opcaoMenuLogRes;

        Console.WriteLine(" ----------Menu----------");
        Console.WriteLine("| 1 - Login              |");
        Console.WriteLine("| 2 - Registrar          |");
        Console.WriteLine("==========================");

        opcaoMenuLogRes = double.Parse(Console.ReadLine());
        Console.WriteLine("");

        while ((opcaoMenuLogRes != 1) && (opcaoMenuLogRes != 2))
        {
            Console.WriteLine("Opção inválida, escolha novamente: ");
            opcaoMenuLogRes = double.Parse(Console.ReadLine());
            Console.WriteLine("");
        }

        switch (opcaoMenuLogRes)
        {
            case 1:
                Console.Clear();
                efetuarLogin();
                break;
            case 2:
                Console.Clear();
                efetuarRegistro();
                break;
        }
    }


    public static void efetuarRegistro()
    {

        Console.WriteLine("");
        Console.WriteLine("----------Registrar----------");
        Console.Write("| Nome: ");
        string nomeUtilizador = Console.ReadLine();
        Console.Write("| Endereço: ");
        string enderecoUtilizador = Console.ReadLine();
        Console.Write("| Telefone: ");
        string telefoneUtilizador = Console.ReadLine();
        Console.Write("| Palavra-Chave: ");
        string palavraChaveUtilizador = Console.ReadLine();
        Console.Write("| Funcionário: ");
        string identificadorUtilizador = Console.ReadLine().ToUpper();
        Console.WriteLine("==============================");
        Console.WriteLine();


        // identificador do funcionario e usuário

        bool funcionarioIdentificado;
        bool usuarioEncontrado = false;


        if (identificadorUtilizador == "BTCB")
        {
            funcionarioIdentificado = true;
        }
        else
        {
            funcionarioIdentificado = false;
        }

        for (int i = 0; i < listaUtilizadores.Count; i++)
        {
            Utilizadores usuario = listaUtilizadores[i];
            string nomeProcura = usuario.NomeUtilizador;

            if (nomeProcura.Contains(nomeUtilizador))
            {
                Console.WriteLine("Usuário já registrado! Faça o login!");
                usuarioEncontrado = true;
                Console.WriteLine("");
                efetuarLogin();
                break;
            }
        }

        if (!usuarioEncontrado)
        {
            Utilizadores novoUsuario = new Utilizadores(nomeUtilizador, enderecoUtilizador, telefoneUtilizador, palavraChaveUtilizador, funcionarioIdentificado);
            listaUtilizadores.Add(novoUsuario);
            Console.WriteLine("Usuário registrado com sucesso!");
            Console.WriteLine("");

            if (funcionarioIdentificado == true)
            {
                Console.Clear();
                Console.WriteLine($"Bem vindo funcionário {novoUsuario.NomeUtilizador}!");
                Console.WriteLine("");
            }
            else if (funcionarioIdentificado == false)
            {
                Console.Clear();
                Console.WriteLine($"Bem vindo {novoUsuario.NomeUtilizador}!");
                Console.WriteLine("");
            }
        }

    }
    public static void efetuarLogin()
    {
        do
        {
            Console.WriteLine("----------Login----------");
            Console.Write("| Nome: ");
            string nomeUtilizador = Console.ReadLine();
            Console.Write("| Palavra-Chave: ");
            string palavraChaveUtilizador = Console.ReadLine();
            Console.WriteLine("==========================");
            Console.WriteLine();

            Utilizadores procurarUtilizador = listaUtilizadores.Find(a => a.NomeUtilizador == nomeUtilizador);

            Utilizadores procurarPalavraChave = listaUtilizadores.Find(a => a.PalavraChave == palavraChaveUtilizador);

            if ((procurarUtilizador != null) && (procurarPalavraChave != null))
            {
                Console.Clear();
                Console.WriteLine($"Bem vindo {procurarUtilizador.NomeUtilizador}!");
                Console.WriteLine("");
                MenuAcoesPrincipal(procurarUtilizador);
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Nome ou Palavra-Chave Incorretos, tente novamente.");
                Console.WriteLine("");
            }
        } while (true);

    }

    static void MenuAcoesPrincipal(Utilizadores procurarUtilizador)
    {
        bool permissaoFuncionario = procurarUtilizador.Funcionario;

        Console.WriteLine(" ----------Menu----------");

    }

    static List<Utilizadores> listaUtilizadores = new List<Utilizadores>();

    // Fim parte Main dudu
    static void Main(string[] args)
    {
        // criando um usuario para teste
        listaUtilizadores.Add(new Utilizadores("Eduardo Lopes", "Rua Braga", "987654321", "12345", true));
        listaUtilizadores.Add(new Utilizadores("Sara", "Rua Braga", "987654321", "12345", true));
        listaUtilizadores.Add(new Utilizadores("Bruno", "Rua Braga", "987654321", "12345", true));
        // --------------------------------------------------------------------------------


        Console.WriteLine("Bem vindo!");
        Console.WriteLine("");
        MenuLogRes();
        RegLivros();

        // itinerar a lista de utilizadores para ver
        Console.WriteLine("");
        Console.WriteLine("---------- Lista de Utilizadores ----------");

        foreach (Utilizadores usuario in listaUtilizadores)
        {
            Console.WriteLine($"| Nome: {usuario.NomeUtilizador,-33} |");
            Console.WriteLine($"| Endereço: {usuario.EnderecoUtilizador,-29} |");
            Console.WriteLine($"| Telefone: {usuario.TelefoneUtilizador,-29} |");
            Console.WriteLine($"| Palavra-Chave: {usuario.PalavraChave,-24} |");
            Console.WriteLine("===========================================");
        }

        // Menu para mostrar opcoes do que pode fazer

    }

}