﻿using ProjetoPOO;
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

    */

    // Fim da parte Main Sara

/*
    // Parte dudu
    static Utilizadores MenuLogRes()
    {
        double opcaoMenuLogRes;
        Utilizadores utilizadorLogado = null;
        
        Console.Clear();
        Console.WriteLine("        Bem vindo!");
        Console.WriteLine("");

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
                utilizadorLogado = Utilizadores.efetuarLogin(listaUtilizadores);
                break;
            case 2:
                Console.Clear();
                utilizadorLogado = Utilizadores.efetuarRegistro(listaUtilizadores);
                break;
        }
        return utilizadorLogado;
    }*/

    /*
    public static Utilizadores efetuarRegistro()
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

        if (identificadorUtilizador == "BTCB")
        {
            funcionarioIdentificado = true;
        }
        else
        {
            funcionarioIdentificado = false;
        }

        Utilizadores utilizadorLogado = listaUtilizadores.Find(a => a.NomeUtilizador == nomeUtilizador);

        if (utilizadorLogado != null)
        {
            Console.Clear();
            Console.WriteLine("Usuário já registrado! Faça o login!");
            Console.WriteLine("");
            return utilizadorLogado; // adicionar a volta para o login
        }
        else
        {
            utilizadorLogado = new Utilizadores(nomeUtilizador, enderecoUtilizador, telefoneUtilizador, palavraChaveUtilizador, funcionarioIdentificado);
            listaUtilizadores.Add(utilizadorLogado);
            Console.WriteLine("Usuário registrado com sucesso!");
            Console.WriteLine("");

            if (funcionarioIdentificado == true)
            {
                Console.Clear();
                Console.WriteLine($"Bem vindo funcionário {utilizadorLogado.NomeUtilizador}!");
                Console.WriteLine("");
                return utilizadorLogado;
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Bem vindo {utilizadorLogado.NomeUtilizador}!");
                Console.WriteLine("");
                return utilizadorLogado;
            }
        }
    }
    public static Utilizadores efetuarLogin()
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

            Utilizadores utilizadorLogado = listaUtilizadores.Find(a => a.NomeUtilizador == nomeUtilizador);

            Utilizadores procurarPalavraChave = listaUtilizadores.Find(a => a.PalavraChave == palavraChaveUtilizador);

            if ((utilizadorLogado != null) && (procurarPalavraChave != null))
            {
                if (utilizadorLogado.Funcionario == true)
                {
                    Console.Clear();
                    Console.WriteLine($"Bem vindo funcionário {utilizadorLogado.NomeUtilizador}!");
                    Console.WriteLine("");
                    return utilizadorLogado;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Bem vindo {utilizadorLogado.NomeUtilizador}!");
                    Console.WriteLine("");
                    return utilizadorLogado;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Nome ou Palavra-Chave Incorretos, tente novamente.");
                Console.WriteLine("");
            }
        } while (true);

    }
    static void MenuAcoesPrincipal(Utilizadores utilizadorLogado)
    {
        bool permissaoFuncionario = utilizadorLogado.Funcionario;
        int opcaoMenuPrincipal = 0;


        if (permissaoFuncionario == true)
        {
            do
            {
                Console.WriteLine(" ------------ Menu ------------");
                Console.WriteLine("| 1. Exibir lista de livros   |");
                Console.WriteLine("| 2. Alugar livro             |");
                Console.WriteLine("| 3. Devolver livro           |");
                Console.WriteLine("| 4. Relatório de Empréstimos |");
                Console.WriteLine("| 5. Gestão de livros         |");
                Console.WriteLine("| 6. Lista de Utilizadores    |");
                Console.WriteLine("| 7. Sair                     |");
                Console.WriteLine("===============================");
                Console.WriteLine();

                Console.WriteLine("Escolha uma opção: ");
                opcaoMenuPrincipal = int.Parse(Console.ReadLine());

                while ((opcaoMenuPrincipal != 1) && (opcaoMenuPrincipal != 2) && (opcaoMenuPrincipal != 3) && (opcaoMenuPrincipal != 4) && (opcaoMenuPrincipal != 5) && (opcaoMenuPrincipal != 6) && (opcaoMenuPrincipal != 7))
                {
                    Console.WriteLine("Opção inválida, escolha novamente: ");
                    opcaoMenuPrincipal = int.Parse(Console.ReadLine());
                    Console.WriteLine("");
                }

                switch (opcaoMenuPrincipal)
                {
                    case 1:
                        Console.Clear();
                        ExibirListaLivros();
                        break;
                    case 2:
                        Console.Clear();
                        ExibirListaLivros();
                        Console.WriteLine();
                        LerPedidoAluguer(utilizadorLogado);
                        break;
                    case 3:
                        Console.Clear();
                        DevolucaoLivroAluguer(utilizadorLogado);
                        break;
                    case 4:
                        Console.Clear();
                        RelatorioEmprestimos();
                        break;
                    case 5:
                        Console.Clear();
                        RegLivros();
                        break;
                    case 6:
                        Console.Clear();
                        mostrarListaUtilizadores();
                        break;
                    case 7:
                        Console.WriteLine("Obrigado, até a próxima!");
                        break;

                }


                if (opcaoMenuPrincipal != 7)
                {
                    Console.WriteLine("Deseja ver o menu novamente? (S/N)");
                    string verMenu = Console.ReadLine();

                    if (verMenu.ToLower() == "n")
                    {
                        opcaoMenuPrincipal = 7;
                        Console.WriteLine("Obrigado, até a próxima!");
                    } else if (verMenu.ToLower() == "s")
                    {
                        Console.Clear();
                    }
                }
            } while (opcaoMenuPrincipal != 7);
        }
        else
        {
            do
            {
                Console.WriteLine(" ------------ Menu ------------");
                Console.WriteLine("| 1. Exibir lista de livros   |");
                Console.WriteLine("| 2. Alugar livro             |");
                Console.WriteLine("| 3. Devolver livro           |");
                Console.WriteLine("| 4. Sair                     |");
                Console.WriteLine("===============================");
                Console.WriteLine();

                Console.WriteLine("Escolha uma opção: ");
                opcaoMenuPrincipal = int.Parse(Console.ReadLine());

                while ((opcaoMenuPrincipal != 1) && (opcaoMenuPrincipal != 2) && (opcaoMenuPrincipal != 3) && (opcaoMenuPrincipal != 4))
                {
                    Console.WriteLine("Opção inválida, escolha novamente: ");
                    opcaoMenuPrincipal = int.Parse(Console.ReadLine());
                    Console.WriteLine("");
                }

                switch (opcaoMenuPrincipal)
                {
                    case 1:
                        ExibirListaLivros();
                        break;
                    case 2:
                        LerPedidoAluguer(utilizadorLogado);
                        break;
                    case 3:
                        DevolucaoLivroAluguer(utilizadorLogado);
                        break;
                    case 4:
                        Console.WriteLine("Obrigado, até a próxima!");
                        break;
                }

                if (opcaoMenuPrincipal != 4)
                {
                    Console.WriteLine("Deseja ver o menu novamente? (S/N)");
                    string verMenu = Console.ReadLine();

                    if (verMenu.ToLower() == "n")
                    {
                        opcaoMenuPrincipal = 4;
                        Console.WriteLine("Obrigado, até a próxima!");
                    } else if (verMenu.ToLower() == "s")
                    {
                        Console.Clear();
                    }
                }
            } while (opcaoMenuPrincipal != 4); 
        }
        MenuLogRes();
    }
    static void mostrarListaUtilizadores()
    {
        Console.WriteLine("");
        Console.WriteLine("-------------------- Lista de Utilizadores --------------------");

        foreach (Utilizadores usuario in listaUtilizadores)
        {
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine($"| Nome: {usuario.NomeUtilizador,-20} | Telefone: {usuario.TelefoneUtilizador,-20} |");

        }
        Console.WriteLine("===============================================================");
    }*/

    // Fim parte dudu

    // Parte Bruno

    /*public static void EscolhaAluguer(Utilizadores utilizadorLogado)
    {
        EmprestimosLivros LivroAluguerGeral = new EmprestimosLivros();

        LivroAluguerGeral.LerPedidoAluguer(utilizadorLogado);
        emprestimoLivros.Add(LivroAluguerGeral);
    }

    public static RegistarLivro LerPedidoAluguer(Utilizadores utilizadorLogado)
    {
        do
        {
            Console.WriteLine("Qual o livro que deseja alugar? ");
            string tituloLivroAluguer = Console.ReadLine();

            RegistarLivro livroEscolhido = Livros.Find(a => a.NomeLivro == tituloLivroAluguer);

            if (livroEscolhido != null)
            {
                Console.WriteLine("Quantos dias de aluguer deseja? ");
                int duracaoLivroAluguer = int.Parse(Console.ReadLine());

                DateOnly dataLivroAluguer = DateOnly.FromDateTime(DateTime.Now);

                //Console.WriteLine("Quantos exemplares pretende alugar?"); 
                //int qntLivroAluguer = int.Parse(Console.ReadLine());

                string nomeClienteAluguer = utilizadorLogado.NomeUtilizador;

                emprestimoLivros.Add(new EmprestimosLivros(utilizadorLogado.NomeUtilizador, livroEscolhido, duracaoLivroAluguer, false, dataLivroAluguer));

                livroEscolhido.NumExemp--;

                return livroEscolhido;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Livro não encontrado, tente novamente.");
                Console.WriteLine("");
            }
        } while (true);
    }

    /*public static void EscolhaAluguer(List<EmprestimosLivros> emprestimoLivros, ref Utilizadores listaUtilizadores, ref RegistarLivro Livros)
    {
        string opcao = "";
        do
        {
            EmprestimosLivros LivroAluguerGeral = new EmprestimosLivros();

            LivroAluguerGeral.LerPedidoAluguer();
            emprestimoLivros.Add(LivroAluguerGeral);

            Console.WriteLine("Deseja efetuar mais algum pedido ?(S/N)");
            opcao = Console.ReadLine();
        } while (opcao.ToLower() == "s");
    }
    public static void AtualizarLista(ref List<RegistarLivro> registarLivros, ref RegistarLivro Livros, EmprestimosLivros Emprestimos)
    {

        // ler o nome do objeto 
        //se for igual a um objeto da lista pedir nova quantidade
        string itemAatualizar = Emprestimos.Titulo;
        RegistarLivro livroMudarQuantidade = registarLivros.Find(x => x.NomeLivro == itemAatualizar);
        if (livroMudarQuantidade != null)
        {
            AtualizarQuantidadeLista(ref Livros, ref Emprestimos);
            Console.WriteLine("Item atualizado com sucesso");

        }
        else { Console.WriteLine("Item nao encontrado"); }
    }
     // AtualizarLista == atualizar quantidade sem ser por aluguer, opcao ja feita pela sara na gestao de livros
     
     
    public static void DevolucaoLivroAluguer(Utilizadores utilizadorLogado)
    {
        Console.WriteLine("--------------------------------------------- Os seus Livros ---------------------------------------------");
        foreach (EmprestimosLivros livro in emprestimoLivros)
        {
            if ((livro.NomeCliente == utilizadorLogado.NomeUtilizador) && (livro.Devolvido == false))
            {
                livro.ConsultaEmprestimoIndividual();
            } else
            {
                Console.WriteLine("Não há livros alugados na sua conta.");
                MenuPrincipal.MenuAcoesPrincipal(utilizadorLogado, listaUtilizadores);
            }

        }
        Console.WriteLine("==========================================================================================================");

        Console.WriteLine("Qual o livro que deseja devolver? ");
        string livroAremover = Console.ReadLine();

        //lemos o nome do objeto novo atraves de uma variavel e vamos a procura de onde na lista um objeto tem esse nome
        EmprestimosLivros DevolverLivro = emprestimoLivros.Find(x => x.Livro.NomeLivro == livroAremover);
        Console.WriteLine();
        if (livroAremover != null)
        {//removemos da lista  existente o objeto presente na lista com o mesmo nome do nosso objeto pedido pelo cliente
            DevolverLivro.Devolvido = true;
            DevolverLivro.Livro.NumExemp++;
            Console.WriteLine("Livro devolvido com sucesso");
        }
        else
        {
            Console.WriteLine("Livro nao encontrado");
        }
    }
    
    */
    static List<EmprestimosLivros> emprestimoLivros = new List<EmprestimosLivros>();

    static List<RegistarLivro> Livros = new List<RegistarLivro>();

    static List<Utilizadores> listaUtilizadores = new List<Utilizadores>();


    // Fim parte Bruno
    static void Main(string[] args)
    {
        DateOnly dataAtual = DateOnly.FromDateTime(DateTime.Now);

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
        Utilizadores utilizadorLogado = Utilizadores.MenuLogRes(listaUtilizadores);

        MenuPrincipal.MenuAcoesPrincipal(utilizadorLogado, listaUtilizadores);


        // Ajustar as tabelas, adicionar o livro da semana, organizar os consoleClear da gestao de livros, maior leitor do mes, penalizacao para qm nao devolver a tempo

        // Arrumar tabela Consulta Livros (opcao 1)
        // 
    }
}