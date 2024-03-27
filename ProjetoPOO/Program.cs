using ProjetoPOO;

class Program
{
    static void MenuLogRes()
    {
        double opcaoMenuLogRes;

        Console.WriteLine("----------Menu----------");
        Console.WriteLine("| Login (1)             |");
        Console.WriteLine("| Registrar (2)         |");
        Console.WriteLine("=========================");

        opcaoMenuLogRes = double.Parse(Console.ReadLine());

        while ((opcaoMenuLogRes != 1) && (opcaoMenuLogRes != 2))
        {
            Console.WriteLine("Opção inválida, escolha novamente: ");
            opcaoMenuLogRes = double.Parse(Console.ReadLine());
        }

        if (opcaoMenuLogRes == 1)
        {
            efetuarLogin();
        }
        else if (opcaoMenuLogRes == 2)
        {
            efetuarRegistro();
        }
    }

    static void efetuarRegistro()
    {

        // criando um usuario para teste
        listaUtilizadores.Add(new Utilizadores("Eduardo Lopes", "Rua Braga", "987654321", "12345"));
        listaUtilizadores.Add(new Utilizadores("Sara", "Rua Braga", "987654321", "12345"));
        listaUtilizadores.Add(new Utilizadores("Bruno", "Rua Braga", "987654321", "12345"));
        // --------------------------------------------------------------------------------

        Console.WriteLine("----------Registrar----------");
        Console.Write("| Nome: ");
        string nomeUtilizador = Console.ReadLine();
        Console.Write("| Endereço: ");
        string enderecoUtilizador = Console.ReadLine();
        Console.Write("| Telefone: ");
        string telefoneUtilizador = Console.ReadLine();
        Console.Write("| Palavra-Chave: ");
        string palavraChaveUtilizador = Console.ReadLine();
        Console.WriteLine("==============================");
        Console.WriteLine();


        /* nao ta funcionando pq o foreach itinera mas como altera o valor enquanto itinera ele trava

        foreach (Utilizadores usuario in listaUtilizadores)
        {
            string nomeProcura = usuario.NomeUtilizador;

            if (nomeProcura.Contains(nomeUtilizador))
            {
                Console.WriteLine("Usuário já registrado!");
            }
            else
            {
                Utilizadores novoUsuario = new Utilizadores(nomeUtilizador, enderecoUtilizador, telefoneUtilizador, palavraChaveUtilizador);
                listaUtilizadores.Add(novoUsuario);

                Console.WriteLine("Usuário registrado com sucesso!");
            }
        }


       ------------------------------------------------------------------------------------------------ */


        bool usuarioEncontrado = false;

        
        for (int i = 0; i < listaUtilizadores.Count; i++)
        {
            Utilizadores usuario = listaUtilizadores[i];
            string nomeProcura = usuario.NomeUtilizador;

            if (nomeProcura.Contains(nomeUtilizador))
            {
                Console.WriteLine("Usuário já registrado!");
                usuarioEncontrado = true; 
                break; 
            }
        }

        
        if (!usuarioEncontrado)
        {
            Utilizadores novoUsuario = new Utilizadores(nomeUtilizador, enderecoUtilizador, telefoneUtilizador, palavraChaveUtilizador);
            listaUtilizadores.Add(novoUsuario);
            Console.WriteLine("Usuário registrado com sucesso!");
        }


        /* tem que fazer assim pq assim

        Console.WriteLine("---------- Lista de Utilizadores ----------");
        for (int i = 0; i < listaUtilizadores.Count; i++)
        {
            Utilizadores usuario = listaUtilizadores[i];
            Console.WriteLine($"Nome: {usuario.NomeUtilizador}");
            Console.WriteLine($"Endereço: {usuario.EnderecoUtilizador}");
            Console.WriteLine($"Telefone: {usuario.TelefoneUtilizador}");
            Console.WriteLine($"Palavra-Chave: {usuario.PalavraChave}");
            Console.WriteLine("--------------------------------------------");
        }

        */

        // itinerar a lista de utilizadores para ver

        foreach (Utilizadores usuario in listaUtilizadores)
        {
            Console.WriteLine("---------- Lista de Utilizadores ----------");
            Console.WriteLine($"Nome: {usuario.NomeUtilizador}");
            Console.WriteLine($"Endereço: {usuario.EnderecoUtilizador}");
            Console.WriteLine($"Telefone: {usuario.TelefoneUtilizador}");
            Console.WriteLine($"Palavra-Chave: {usuario.PalavraChave}");
            Console.WriteLine("--------------------------------------------");
        }

        //
    }

    public static void efetuarLogin()
    {

        Console.WriteLine("----------Login----------");
        Console.Write("| Nome: ");
        string nomeUtilizador = Console.ReadLine();
        Console.Write("| Palavra-Chave: ");
        string palavraChaveUtilizador = Console.ReadLine();
        Console.WriteLine("==========================");
        Console.WriteLine();


        // string nomeLogin = NomeUtilizador.Utilizadores();

        foreach (Utilizadores usuario in listaUtilizadores)
        {
            string nomeValidacao = usuario.NomeUtilizador;
            string senhaValidacao = usuario.PalavraChave;

            if ((nomeValidacao.Contains(nomeUtilizador)) && (senhaValidacao.Contains(palavraChaveUtilizador)))
            {
                Console.WriteLine($"Bem vindo {usuario.NomeUtilizador}!");
            }
            else
            {
                Console.WriteLine("Nome ou Palavra-Chave Incorretos.");

            }
        }

    }


    static List<Utilizadores> listaUtilizadores = new List<Utilizadores>(); // Lista para armazenar os usuários registrados
    static void Main(string[] args)
    {

        Console.WriteLine("Bem vindo!");
        MenuLogRes();


    }
    
}