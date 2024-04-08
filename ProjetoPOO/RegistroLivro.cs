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

        // Construtor padrão
        public RegistarLivro(string nomeLivro, string autor, int anoPublic,int numExemp)
        {
            NomeLivro = nomeLivro;
            Autor = autor;
            AnoPublic = anoPublic;
            NumExemp = numExemp;
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
            Console.WriteLine("Consulta de Livros");
            Console.WriteLine($"| Título: {NomeLivro} | Autor: {Autor} | Ano de publicação: {AnoPublic} | Número de exemplares disponíveis:{NumExemp} |");
        }

    }
}


