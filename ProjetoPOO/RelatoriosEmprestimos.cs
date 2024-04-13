using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjetoPOO
{
    internal class RelatoriosEmprestimos
    {
        public RegistarLivro LivroMaisAlugado;

        public RelatoriosEmprestimos(RegistarLivro livroMaisAlugado)
        {
            LivroMaisAlugado = livroMaisAlugado;
        }

        public static void RelatorioEmprestimos(List<EmprestimosLivros> emprestimoLivros)
        {
            Console.WriteLine("=============================================== Lista de Emprestimos ================================================");
            foreach (var livroAlugado in emprestimoLivros)
            {
                livroAlugado.ConsultaListaEmpr();
            }
            Console.WriteLine("|___________________________________________________________________________________________________________________|"); // ajustar tamanho dps
        }

        public static void RelatorioLivrosEmpresas(List<EmprestimosLivros> emprestimoLivros, List<RegistarLivro> Livros)
        {
            int totalLivrosBiblioteca = 0;

            foreach (var livro in Livros)
            {
                totalLivrosBiblioteca += livro.NumExemp;
            }


            Console.WriteLine("======================================= Relatórios ========================================== ");
            Console.WriteLine("---------------------------------------------------------------------------------------------"); // ajustar tamanho dps
        }
        public static void RelatorioLivrosClientes(List<RegistarLivro> Livros)

        {
            //var dataHoje = DateOnly.FromDateTime(DateTime.Now);

            int livroTeste = 0;
            RegistarLivro LivroMaisAlugado=new RegistarLivro() ;


            foreach (RegistarLivro livro in Livros)
            {
                if (livro.NumVezesAlugado > livroTeste)
                {
                    livroTeste = livro.NumVezesAlugado;
                   LivroMaisAlugado = livro;
                    
                }
            }
            Console.WriteLine("======================================== A Não Perder ========================================");
            Console.WriteLine("|--------------------------------------------------------------------------------------------|");
            Console.WriteLine("|________________________________ Livro mais alugado do mês _________________________________|");
            Console.WriteLine($"| Titulo: {LivroMaisAlugado.NomeLivro,-12} | Autor: {LivroMaisAlugado.Autor,-12} | Publicado: {LivroMaisAlugado.AnoPublic,-4} | Numero de vezes Alugado:{LivroMaisAlugado.NumVezesAlugado,-2}  |");
            Console.WriteLine("|--------------------------------------------------------------------------------------------|");
            Console.WriteLine("|___________________________________ Proximos Lançamentos ___________________________________|");
            Console.WriteLine("| Titulo: O Rapaz | Autor: Claudio Ramos | Gênero: Romance | Idioma: Português               |");
            Console.WriteLine("| Titulo: A Corrente | Autor: Filipa Amorim | Gênero: Thriller | Idioma: Português           |");
            Console.WriteLine("| Titulo: Too Late | Autor: Collen Hoover | Gênero: Drama | Idioma: Inglês                   |");
            Console.WriteLine("| Titulo: King of Sloth | Autor: Ana Huang | Gênero: Romance | Idioma: Inglês                |");
            Console.WriteLine("|--------------------------------------------------------------------------------------------|");
            Console.WriteLine("|___________________________________ Ultimas Oportunidades __________________________________|");


            foreach (var livro in Livros)
            {
                if (livro.NumExemp == 1) 
                {
                    Console.WriteLine($"| Titulo: {livro.NomeLivro,-16} | Autor: {livro.Autor,16} | Gênero:{livro.GeneroLivro,-10} | Idioma:{livro.IdiomaLivro,-10} |");

                }
            }
            Console.WriteLine("|--------------------------------------------------------------------------------------------|");


            Console.WriteLine("|____________________________________________________________________________________________|"); // ajustar tamanho dps
        }
    }
}
