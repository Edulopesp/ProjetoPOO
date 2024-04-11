namespace ProjetoPOO
{
    internal class RegistarLivro
    {
        // Atributos da classe

        public string NomeLivro;
        public string Autor;
        public int AnoPublic;
        public int NumExemp;
        public int NumVezesAlugado;
        public string GeneroLivro;
        public string IdiomaLivro;

        // adicionar sinopse individual 

        // Construtor padrão
        public RegistarLivro(string nomeLivro, string autor, int anoPublic, int numExemp, string idioma, string genero)
        {
            NomeLivro = nomeLivro;
            Autor = autor;
            AnoPublic = anoPublic;
            NumExemp = numExemp;
            NumVezesAlugado = 0;
            GeneroLivro = genero;
            IdiomaLivro = idioma;
        }

        // Métodos
        public void AtualizarQuantidadeDisponivel()
        {
            Console.Write("Nova Quantidade: ");
            NumExemp = int.Parse(Console.ReadLine());
        }
        public void ConsultaLivros()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"| Título: {NomeLivro,-9} | Autor: {Autor,-9} | Ano de Publicação: {AnoPublic} | Qtd Disp: {NumExemp,-2} |  Gênero: {GeneroLivro,-7} | Idioma: {IdiomaLivro,-9} |");
        }
        public static void RegLivros(List<RegistarLivro> Livros, Utilizadores utilizadorLogado, List<EmprestimosLivros> emprestimoLivros, List<Utilizadores> listaUtilizadores)
        {
            int opcao;

            do
            {
                Console.WriteLine("--------------- Gestão de Livros ----------------");
                Console.WriteLine("| 1. Adicionar Novo Livro                       |");
                Console.WriteLine("| 2. Remover Livro Existente                    |");
                Console.WriteLine("| 3. Atualizar Número de Exemplares Disponíveis |");
                Console.WriteLine("| 4. Exibir Lista Atual de Livros               |");
                Console.WriteLine("| 5. Voltar                                     |");
                Console.WriteLine("=================================================");

                opcao = int.Parse(Console.ReadLine());
                Console.WriteLine("");


                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        AdicionarNovoLivro(Livros);
                        break;
                    case 2:
                        Console.Clear();
                        RemoverLivroExistente(Livros);
                        break;
                    case 3:
                        Console.Clear();
                        ExibirListaLivros(Livros);
                        AtualizarNumeroExemplares(Livros, utilizadorLogado, emprestimoLivros, listaUtilizadores);
                        break;
                    case 4:
                        Console.Clear();
                        ExibirListaLivros(Livros);
                        ConsultaFiltrada(Livros);
                        break;
                    case 5:
                        Console.Clear();
                        MenuPrincipal.MenuAcoesPrincipal(listaUtilizadores, utilizadorLogado, Livros, emprestimoLivros);
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
            string genero;
            string idioma;

            Console.WriteLine("-------- Registo de Livros --------");
            Console.WriteLine("");
            Console.Write("| Título: ");
            nomeLivro = Console.ReadLine();

            Console.Write("| Autor: ");
            autor = Console.ReadLine();

            Console.Write("| Ano de publicação: ");
            anoPublic = int.Parse(Console.ReadLine());

            Console.Write("| Número de exemplares disponíveis: ");
            numExemp = int.Parse(Console.ReadLine());

            genero = ExibirListaGeneros();

            idioma = ExibirListaIdiomas();

            RegistarLivro novoLivro = new RegistarLivro(nomeLivro, autor, anoPublic, numExemp, idioma, genero);

            Livros.Add(novoLivro);

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Novo Livro adicionado com sucesso!");
            Console.WriteLine();

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
        static void AtualizarNumeroExemplares(List<RegistarLivro> Livros, Utilizadores utilizadorLogado, List<EmprestimosLivros> emprestimoLivros, List<Utilizadores> listaUtilizadores)
        {
            Console.Write("Nome do Livro que deseja atualizar o número de exemplares disponíveis: ");
            string nomeLivro = Console.ReadLine();
            RegistarLivro livroAtualizar = Livros.Find(i => i.NomeLivro == nomeLivro);
            if (livroAtualizar != null)
            {
                livroAtualizar.AtualizarQuantidadeDisponivel(); // método para atualizar a quantidade de exemplares
                Console.WriteLine("Número de exemplares disponíveis atualizado com sucesso!");
                Console.WriteLine();
                Console.WriteLine("Deseja ver o menu novamente? (S/N)");
                string verMenu = Console.ReadLine();

                if (verMenu.ToLower() == "n")
                {
                    Console.Clear();
                    MenuPrincipal.MenuAcoesPrincipal(listaUtilizadores, utilizadorLogado, Livros, emprestimoLivros);
                }
                else if (verMenu.ToLower() == "s")
                {
                    Console.Clear();
                    RegLivros(Livros, utilizadorLogado, emprestimoLivros, listaUtilizadores);
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }
        public static void ExibirListaLivros(List<RegistarLivro> Livros)
        {
            Console.WriteLine("------------------------------------------------ Consulta de Livros ---------------------------------------------------");

            foreach (var livro in Livros)
            {
                if (livro.NumExemp > 0)
                {
                    livro.ConsultaLivros();
                }
            }

            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine();
        }
        public static string ExibirListaIdiomas()
        {
            int opcaoEscolhida;

            Console.WriteLine();
            Console.WriteLine("------ Idiomas ------");
            Console.WriteLine("| 1. Português      |");
            Console.WriteLine("| 2. Inglês         |");
            Console.WriteLine("| 3. Frances        |");
            Console.WriteLine("| 4. Espanhol       |");
            Console.WriteLine("| 5. Alemão         |");
            Console.WriteLine("| 0. voltar         |");
            Console.WriteLine("====================");
            Console.WriteLine();

            do
            {
                Console.Write("| Idioma do livro: ");
                opcaoEscolhida = int.Parse(Console.ReadLine());

            } while ((opcaoEscolhida != 0) && (opcaoEscolhida != 1) && (opcaoEscolhida != 2) && (opcaoEscolhida != 3) && (opcaoEscolhida != 4) && (opcaoEscolhida != 5));


            switch (opcaoEscolhida)
            {
                case 1:
                    return "Português";
                    break;
                case 2:
                    return "Inglês";
                    break;
                case 3:
                    return "Frances";
                    break;
                case 4:
                    return "Espanhol";
                    break;
                case 5:
                    return "Alemão";
                    break;
                case 0:
                    return "sair";

                    break;
                default:
                    return "Opção Inválida";
            }

        }
        public static string ExibirListaGeneros()
        {
            int opcaoEscolhida;

            Console.WriteLine();
            Console.WriteLine("------ Géneros ------");
            Console.WriteLine("| 1. Romance        |");
            Console.WriteLine("| 2. Drama          |");
            Console.WriteLine("| 3. Ação           |");
            Console.WriteLine("| 4. Thriller       |");
            Console.WriteLine("| 5. Terror         |");
            Console.WriteLine("| 0. voltar         |");
            Console.WriteLine("=====================");
            Console.WriteLine();

            do
            {
                Console.Write("| Género do livro: ");
                opcaoEscolhida = int.Parse(Console.ReadLine());


            } while ((opcaoEscolhida != 0) && (opcaoEscolhida != 1) && (opcaoEscolhida != 2) && (opcaoEscolhida != 3) && (opcaoEscolhida != 4) && (opcaoEscolhida != 5));


            switch (opcaoEscolhida)
            {
                case 1:
                    return "Romance";
                    break;
                case 2:
                    return "Drama";
                    break;
                case 3:
                    return "Ação";
                    break;
                case 4:
                    return "Thriller";
                    break;
                case 5:
                    return "Terror";
                    break;
                case 0:
                    return "sair";
                    break;
                default:
                    return "Opção Inválida";

            }


        }
        public static void ConsultaFiltrada(List<RegistarLivro> Livros)

        {
            Console.WriteLine("Para retroceder escreva 'sair', para pesquisa filtrada prima ENTER");

            string valor = Console.ReadLine();

            while (valor.ToLower() != "sair")
            {
                Console.WriteLine();
                Console.WriteLine("1. Pesquisa por Genero");
                Console.WriteLine("2. Pesquisa por Idioma");
                Console.WriteLine("3. Sair");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:

                        Console.Clear();
                        Console.WriteLine("----------- Pesquisa por Genero ------------");

                        Console.WriteLine();

                        string genero = ExibirListaGeneros();
                        Console.Clear();
                        Console.WriteLine($"---------------------------------------------- Lista do Genero {genero, -7} ------------------------------------------------");

                        foreach (var livro in Livros)
                        {

                            if (genero.ToLower() == livro.GeneroLivro.ToLower())
                            {
                                livro.ConsultaLivros();
                            }

                        }

                        if ((genero.ToLower() == "sair") || (genero == "Opção Inválida"))

                        {
                            Console.WriteLine("Obrigado");

                        
                        }

                        Console.WriteLine("=======================================================================================================================");
                        Console.WriteLine();


                        break;

                    case 2:
                        
                            Console.Clear();
                            Console.WriteLine("----------- Pesquisa por Idioma ------------");

                            Console.WriteLine();

                            string idioma = ExibirListaIdiomas();
                            Console.Clear();
                            Console.WriteLine($"--------------------------------------------- Lista do Idioma {idioma,-7} -----------------------------------------------");

                            foreach (var livro in Livros)
                            {
                                if (idioma.ToLower() == livro.IdiomaLivro.ToLower())
                                {
                                    livro.ConsultaLivros();
                                }
                            }
                            if ((idioma.ToLower() == "sair") || (idioma == "Opção Inválida"))
                            {
                                Console.WriteLine("Obrigado");
                            }

                            Console.WriteLine("=======================================================================================================================");
                            Console.WriteLine();

                        break;
                    case 3:
                        Console.Clear();
                        valor = "sair";
                        break;
                     
                }
            }
        }
    }
}


























