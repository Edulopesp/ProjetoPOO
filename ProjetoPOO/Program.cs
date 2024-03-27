using ProjetoPOO;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;

class Program
{
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

    static List<Utilizadores> listaUtilizadores = new List<Utilizadores>();

    static void MenuAcoesPrincipal(Utilizadores procurarUtilizador)
    {
        bool permissaoFuncionario = procurarUtilizador.Funcionario;

        Console.WriteLine(" ----------Menu----------");

        if (permissaoFuncionario == true)
        {
            // Lista de coisas para o funcionario fazer
        } else
        {
            // lista de coisas para o usuario fazer
        }
    }

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