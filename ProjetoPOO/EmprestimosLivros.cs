using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPOO
{
    internal class EmprestimosLivros
    {
        public string NomeCliente;
        public RegistarLivro Livro;
        public int Duracao;
        public bool Devolvido = false;
        public DateOnly Data; //{ get; set; }



        public EmprestimosLivros(string nomeCliente, RegistarLivro livro, int duracao, bool devolvido, DateOnly data) // int quantidadeLivroAlugado, int quantidadeExemplaresExistente,
        {
            NomeCliente = nomeCliente;
            Livro = livro;
            Duracao = duracao;
           
            Devolvido = devolvido;
            Data = data;
        }
        public EmprestimosLivros() 
        {
        }
        public static void LerPedidoAluguer(List<RegistarLivro>Livros,Utilizadores utilizadorLogado, List<EmprestimosLivros> emprestimoLivros)
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

                    //livroEscolhido.NumVezesEscolhido++

                    //retornamos o livro escolhido como registar livro para ? sair da funcao ?

                    //return livroEscolhido;
                   break; //inverter os ifs talvez o break salte fora do while 
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Livro não encontrado, tente novamente.");
                    Console.WriteLine("");
                }
            } while (true);
        }

        public static void DevolucaoLivroAluguer(Utilizadores utilizadorLogado,List<EmprestimosLivros>emprestimoLivros,List<RegistarLivro>Livros, RegistarLivro livro)
        {
            Console.WriteLine("--------------------------------------------- Os seus Livros ---------------------------------------------");
            foreach (EmprestimosLivros book in emprestimoLivros)
            {
                if ((book.NomeCliente == utilizadorLogado.NomeUtilizador) && (book.Devolvido == false))
                {
                    book.ConsultaEmprestimoIndividual();
                }
                else
                {
                    Console.WriteLine("Não há livros alugados na sua conta.");
                    MenuPrincipal.MenuAcoesPrincipal(utilizadorLogado,Livros,emprestimoLivros,livro);
                }

            }
            Console.WriteLine("==========================================================================================================");

            Console.WriteLine("Qual o livro que deseja devolver? ");
            string livroAremover = Console.ReadLine();

            //lemos o nome do objeto novo atraves de uma variavel e vamos a procura de onde na lista um objeto tem esse nome
            EmprestimosLivros DevolverLivro = emprestimoLivros.Find(x => x.Livro.NomeLivro == livroAremover);
            Console.WriteLine();
            if (livroAremover != null)
            {//atribuimos o estado verdadeiro ao atributo da nossa classe emprestimosLivros
                //adicionamos novamente a quantidade ao registo do livro devolvido
                DevolverLivro.Devolvido = true;
                DevolverLivro.Livro.NumExemp++;
                Console.WriteLine("Livro devolvido com sucesso");
            }
            else
            {
                Console.WriteLine("Livro nao encontrado");
            }
        }
        public void ConsultaListaEmpr()
        {
            //objetivo do nr vezes alugado seria para fazer um best of livros mais requisitados
            

            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine($"| Titulo: {Livro.NomeLivro, -10} | Nome Cliente: {NomeCliente,-10} | Duracao: {Duracao} | Data Pedido: {Data,-10} |");
           

        }
        public void ConsultaEmprestimoIndividual()
        {
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine($"| Título: {Livro.NomeLivro,-9} | Duração: {Duracao,-9} | Data Pedido: {Data,-9} |");
        }
        // no relatorio poderia vir a informacao  se o livro foi devolvido a tempo etc
        public static void RelatorioEmprestimos(List<EmprestimosLivros>emprestimoLivros)
        {
            Console.WriteLine("-------------------------------------- Lista de Emprestimos ---------------------------------");
            foreach (var livroAlugado in emprestimoLivros)
            {
                livroAlugado.ConsultaListaEmpr();
            }
            Console.WriteLine("============================================================================================="); // ajustar tamanho dps
        }
    }
}
