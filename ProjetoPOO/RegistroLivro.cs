
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
        public int NumVezesAlugado=0;

        // Construtor padrão
        public RegistarLivro(string nomeLivro, string autor, int anoPublic,int numExemp, int numVezesAlugado)
        {
            NomeLivro = nomeLivro;
            Autor = autor;
            AnoPublic = anoPublic;
            NumExemp = numExemp;
            NumVezesAlugado = numVezesAlugado;
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
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"| Título: {NomeLivro, -9} | Autor: {Autor, -9} | Ano de Publicação: {AnoPublic, -9} | Exemplares Disponíveis:{NumExemp, -3} |");
        }

    }
}


