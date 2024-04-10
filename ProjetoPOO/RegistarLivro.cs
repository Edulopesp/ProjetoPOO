using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
       

        // adicionar o genero
        // adicionar idioma 
        // adicionar sinopse individual 

        // Construtor padrão
        public RegistarLivro(string nomeLivro, string autor, int anoPublic,int numExemp)
        {
            NomeLivro = nomeLivro;
            Autor = autor;
            AnoPublic = anoPublic;
            NumExemp = numExemp;
            NumVezesAlugado = 0;
        }

        // Métodos

        public void ArmazenarLivro()
        {
            Console.WriteLine("-------- Registo de Livros --------");
            Console.WriteLine("");

            Console.WriteLine("| Título: ");
            NomeLivro = Console.ReadLine();

            Console.WriteLine("| Autor: ");
            Autor = Console.ReadLine();

            Console.WriteLine("| Ano de publicação: ");
            AnoPublic = int.Parse(Console.ReadLine());

            Console.WriteLine("| Número de exemplares disponíveis: ");
            NumExemp = int.Parse(Console.ReadLine());

        }

        public void AtualizarQuantidadeDisponivel()
        {
            Console.WriteLine("Nova Quantidade: ");
            NumExemp = int.Parse(Console.ReadLine());
        }

        public void ConsultaLivros()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"| Título: {NomeLivro, -12} | Autor: {Autor, -12} | Ano de Publicação: {AnoPublic, -6} | Exemplares Disponíveis:{NumExemp, -3} |");
        }

        public static void RegLivros(List<RegistarLivro> Livros)
        {
            int opcao;
            
            do
            {
                Console.WriteLine("--------------- Gestão de Livros ---------------");
                Console.WriteLine("| 1. Adicionar Novo Livro                       |");
                Console.WriteLine("| 2. Remover Livro Existente                    |");
                Console.WriteLine("| 3. Atualizar Número de Exemplares Disponíveis |");
                Console.WriteLine("| 4. Exibir Lista Atual de Livros               |");
                Console.WriteLine("| 5. Sair                                       |");
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
                        Console.Clear();
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
        public static void ExibirListaLivros(List<RegistarLivro> Livros)
        {
            Console.WriteLine("------------------------------------------ Consulta de Livros -----------------------------------------");
            foreach (var livro in Livros)
            {
                if (livro.NumExemp > 0)
                {
                    livro.ConsultaLivros();
                }
                // talvez passar a lista para ca para ter organizacao, ja que nao eh uma metodo grande
            }
            Console.WriteLine("=======================================================================================================");
        }

    }
}


