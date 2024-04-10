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
            Console.WriteLine("----------------------------------------------- Lista de Emprestimos ------------------------------------------------");
            foreach (var livroAlugado in emprestimoLivros)
            {
                livroAlugado.ConsultaListaEmpr();
            }
            Console.WriteLine("====================================================================================================================="); // ajustar tamanho dps
        }

        public void RelatorioLivrosClientes(List<RegistarLivro> Livros)
        {
            var dataHoje = DateOnly.FromDateTime(DateTime.Now);
            int livroMaisAlugado = 0;

            foreach (var livro in Livros)
            {
                if (livro.NumVezesAlugado > livroMaisAlugado)
                {
                    LivroMaisAlugado = livro;
                }
            }
            Console.WriteLine("============================== A Não Perder ============================== ");
            
            Console.WriteLine($"| --------------------------------- Livro mais alugado do mês ---------------------------------|");
            Console.WriteLine($"| Titulo: {LivroMaisAlugado.NomeLivro} | Autor: {LivroMaisAlugado.Autor} | Publicado: {LivroMaisAlugado.AnoPublic}  |");
            Console.WriteLine("| ----------------------------------------------------------------------");
            Console.WriteLine($"| --------------------------------- Proximos Lançamentos ---------------------------------|");
            Console.WriteLine($"| Titulo: O Rapaz | Autor: Claudio Ramos | Gênero: Romance | Idioma: Português |");
            Console.WriteLine($"| Titulo: A Corrente | Autor: Filipa Amorim | Gênero: Thriller | Idioma: Português |");
            Console.WriteLine($"| Titulo: Too Late | Autor: Collen Hoover | Gênero: Drama | Idioma: Inglês |");
            Console.WriteLine($"| Titulo: King of Sloth | Autor: Ana Huang | Gênero: Romance | Idioma: Inglês |");
            Console.WriteLine(" |--------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"| --------------------------------- Ultimas Oportunidades ---------------------------------|");


            foreach (var livro in Livros)
            {
                if (livro.NumExemp == 1) 
                {
                    Console.WriteLine($"| Titulo: {livro.NomeLivro} | Autor: {livro.Autor} | Gênero: Romance | Idioma: Inglês |");

                }
            }
            Console.WriteLine(" |--------------------------------------------------------------------------------------------------------");



            Console.WriteLine("============================================================================================="); // ajustar tamanho dps
        }
    }
}
