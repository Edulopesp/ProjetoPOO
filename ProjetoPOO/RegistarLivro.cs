using System.Runtime;

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

        public RegistarLivro()
        {
        }


        // Métodos
        public void AtualizarQuantidadeDisponivel()
        {
            Console.WriteLine("Nova Quantidade: ");
            NumExemp = int.Parse(Console.ReadLine());
        }
        public void ConsultaLivros()
        {
            Console.WriteLine("|----------------------------------------------------------------------------------------------------------------------|");
            Console.WriteLine($"| Título: {NomeLivro,-9} | Autor: {Autor,-9} | Ano de Publicação: {AnoPublic} | Qtd Disp: {NumExemp,-2} |  Gênero: {GeneroLivro,-7} | Idioma: {IdiomaLivro,-9} |");
            // Console.WriteLine("|----------------------------------------------------------------------------------------------------------------------|");
        }
        public static void RegLivros(List<RegistarLivro> Livros, Utilizadores utilizadorLogado, List<EmprestimosLivros> emprestimoLivros, List<Utilizadores> listaUtilizadores)
        {
            int opcao;

            do
            {
                
                
                Console.WriteLine("=============== Gestão de Livros ================");              
                Console.WriteLine("|-----------------------------------------------|");
                Console.WriteLine("| 1. Adicionar Novo Livro                       |");
                Console.WriteLine("| 2. Remover Livro Existente                    |");
                Console.WriteLine("| 3. Atualizar Número de Exemplares Disponíveis |");
                Console.WriteLine("| 4. Exibir Lista Atual de Livros               |");
                Console.WriteLine("| 5. Voltar                                     |");
                Console.WriteLine("|_______________________________________________|");

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
                        ExibirListaLivros(Livros);
                        RemoverLivroExistente(Livros);
                        break;
                    case 3:
                        Console.Clear();
                        ExibirListaLivros(Livros);
                        AtualizarNumeroExemplares(Livros);
                        break;
                    case 4:
                        Console.Clear();
                        ExibirListaLivros(Livros);
                        ConsultaFiltrada(listaUtilizadores, utilizadorLogado, Livros, emprestimoLivros);
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

            Console.WriteLine("============================ Registo de Livros ============================");
            Console.WriteLine("|-------------------------------------------------------------------------|");
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
            Console.Write("Nome do livro a ser removido: ");
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
        public static void ExibirListaLivros(List<RegistarLivro> Livros)
        {
            Console.WriteLine("============================================== Consulta de Livros ======================================================");

            foreach (var livro in Livros)
            {
                if (livro.NumExemp > 0)
                {
                    livro.ConsultaLivros();
                }
            }

            Console.WriteLine("|______________________________________________________________________________________________________________________|");
            Console.WriteLine();
            Console.WriteLine();
        }
        public static string ExibirListaIdiomas()
        {
            int opcaoEscolhida;

            Console.WriteLine();
            Console.WriteLine("====== Idiomas ======");
            Console.WriteLine("|-------------------|");
            Console.WriteLine("| 1. Português      |");
            Console.WriteLine("| 2. Inglês         |");
            Console.WriteLine("| 3. Frances        |");
            Console.WriteLine("| 4. Espanhol       |");
            Console.WriteLine("| 5. Alemão         |");
            Console.WriteLine("| 0. voltar         |");
            Console.WriteLine("|___________________|");
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
                    
                case 2:
                    return "Inglês";
                    
                case 3:
                    return "Frances";
                   
                case 4:
                    return "Espanhol";
                   
                case 5:
                    return "Alemão";
                   
                case 0:
                    return "sair";

                 
                default:
                    return "Opção Inválida";
            }

        }
        public static string ExibirListaGeneros()
        {
            int opcaoEscolhida;

            Console.WriteLine();
            Console.WriteLine("====== Géneros =======");
            Console.WriteLine("|--------------------|");
            Console.WriteLine("| 1. Romance         |");
            Console.WriteLine("| 2. Drama           |");
            Console.WriteLine("| 3. Ação            |");
            Console.WriteLine("| 4. Thriller        |");
            Console.WriteLine("| 5. Terror          |");
            Console.WriteLine("| 0. Voltar          |");
            Console.WriteLine("|____________________|");
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
                case 2:
                    return "Drama";
                case 3:
                    return "Ação";
                case 4:
                    return "Thriller";
                case 5:
                    return "Terror";
                case 0:
                    return "sair";
                default:
                    return "Opção Inválida";

            }
        }
        public static void ConsultaFiltrada(List<Utilizadores> listaUtilizadores, Utilizadores utilizadorLogado, List<RegistarLivro> Livros, List<EmprestimosLivros> emprestimoLivros)

        {
            Console.WriteLine("Para retroceder escreva 'sair', para pesquisa filtrada prima ENTER");

            string valor = Console.ReadLine();

            Console.Clear();

            while (valor.ToLower() != "sair")
            {
                int option;
                
                Console.WriteLine();
                Console.WriteLine("==== Pesquisa Filtrada ====");
                Console.WriteLine("|-------------------------|");
                Console.WriteLine("| 1. Pesquisa por Genero  |");
                Console.WriteLine("| 2. Pesquisa por Idioma  |");
                Console.WriteLine("| 3. Voltar               |");
                Console.WriteLine("|_________________________|");

                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    
                    case 1:
                        Console.Clear();
                        Console.WriteLine("============================ Pesquisa por Genero ===============================");
                        Console.WriteLine();
                        string genero = ExibirListaGeneros();
                            int contador = 0;
                        Console.Clear();
                        
                            Console.WriteLine($"============================================== Lista do Genero {genero,-7} ================================================");
                            foreach (var livro in Livros)
                            {
                                if ((genero.ToLower() == livro.GeneroLivro.ToLower()) && (livro.NumExemp > 0))
                                {
                                   
                                    livro.ConsultaLivros();
                                    contador++;
                                }
                            }
                            if ((contador == 0) && (genero != "sair"))
                            {
                                Console.WriteLine("| Livros não encontrados                                                                                               |");
                            }
                                Console.WriteLine("|______________________________________________________________________________________________________________________|");

                        
                        break;
                    case 2:
                            Console.Clear();
                            Console.WriteLine("============================ Pesquisa por Idioma ===============================");
                            Console.WriteLine();

                            string idioma = ExibirListaIdiomas();
                            contador = 0;
                        Console.Clear();

                       
                            Console.WriteLine($"============================================== Lista do Genero {idioma,-7} ===============================================");

                            foreach (var livro in Livros)
                                {
                                    if ((idioma.ToLower() == livro.IdiomaLivro.ToLower()) && (livro.NumExemp > 0))
                                    {
                                        livro.ConsultaLivros();
                                        contador++;
                                    }
                                }
                                if ((contador == 0) && (idioma != "sair"))
                                {
                                    Console.WriteLine("| Idiomas não encontrados                                                                                              |");
                                }
                                    Console.WriteLine("|______________________________________________________________________________________________________________________|");

                        break;
                    case 3:
                        Console.Clear();
                        valor = "sair";
                        MenuPrincipal.MenuAcoesPrincipal(listaUtilizadores, utilizadorLogado, Livros, emprestimoLivros);
                        break;
                }
            }
        }
    }
}








































