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
        public static RegistarLivro LerPedidoAluguer(List<RegistarLivro>Livros,Utilizadores utilizadorLogado, List<EmprestimosLivros> emprestimoLivros, List<Utilizadores> listaUtilizadores)
        {
                Console.WriteLine("Para retroceder digite 'sair'.");

            do
            {
                Console.WriteLine("Qual o livro que deseja alugar?");
                string tituloLivroAluguer = Console.ReadLine();

                if (tituloLivroAluguer.ToLower() == "sair")
                {
                    Console.Clear();
                    MenuPrincipal.MenuAcoesPrincipal(listaUtilizadores, utilizadorLogado, Livros, emprestimoLivros);
                }
                
                

                    RegistarLivro livroEscolhido = Livros.Find(a => a.NomeLivro == tituloLivroAluguer);


                    if (livroEscolhido != null)
                    {
                        Console.WriteLine("Quantos dias de aluguer deseja? ");
                        int duracaoLivroAluguer = int.Parse(Console.ReadLine());

                        var dataLivroAluguer = DateOnly.FromDateTime(DateTime.Now);

                        //string nomeClienteAluguer = utilizadorLogado.NomeUtilizador;
                        emprestimoLivros.Add(new EmprestimosLivros(utilizadorLogado.NomeUtilizador, livroEscolhido, duracaoLivroAluguer, false, dataLivroAluguer));

                        livroEscolhido.NumExemp--;

                        livroEscolhido.NumVezesAlugado++;

                        return livroEscolhido;
                        //break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Livro não encontrado, tente novamente.");
                        Console.WriteLine("");
                        RegistarLivro.ExibirListaLivros(Livros);
                    }
            } while (true);
        }

        public static void DevolucaoLivroAluguer(Utilizadores utilizadorLogado,List<EmprestimosLivros>emprestimoLivros,List<RegistarLivro>Livros, List<Utilizadores> listaUtilizadores)
        {
            Console.WriteLine("--------------------------------------------- Os seus Livros ---------------------------------------------");

            foreach (EmprestimosLivros livro in emprestimoLivros)
            {
                if ((livro.NomeCliente == utilizadorLogado.NomeUtilizador) && (livro.Devolvido == false))
                {
                    livro.ConsultaEmprestimoIndividual();
                }
                else
                {
                    Console.WriteLine("Não há livros alugados na sua conta.");
                    MenuPrincipal.MenuAcoesPrincipal(listaUtilizadores, utilizadorLogado, Livros, emprestimoLivros);
                }

            }

            Console.WriteLine("==========================================================================================================");

            consultaAlugueresCliente(utilizadorLogado, emprestimoLivros, Livros, listaUtilizadores);

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
            Console.WriteLine($"| Titulo: {Livro.NomeLivro, -10} | Nome Cliente: {NomeCliente,-10} | Duracao: {Duracao}  | Data Pedido: {Data,-10} |");
        }
        public void ConsultaEmprestimoIndividual()
        {
            var dataHoje = DateOnly.FromDateTime(DateTime.Now);

            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine($"| Título: {Livro.NomeLivro,-9} | Duração: {Duracao,-9} | Data Pedido: {Data,-9} | | Entregar em: {DataEntregaLivroAlugado().DayNumber - dataHoje.DayNumber} |");
        }
        // no relatorio poderia vir a informacao  se o livro foi devolvido a tempo etc
        public DateOnly DataEntregaLivroAlugado()
        {
            var dataLimite = Data.AddDays(Duracao);
            return dataLimite;
        }
        public static void consultaAlugueresCliente(Utilizadores utilizadorLogado, List<EmprestimosLivros> emprestimoLivros, List<RegistarLivro> Livros, List<Utilizadores> listaUtilizadores) 
        {
            int contadorLivrosDoUtilizador = 0;

            Console.WriteLine("--------------------------------------------- Os seus Livros ---------------------------------------------");
            foreach (EmprestimosLivros livro in emprestimoLivros)
            {
                if ((livro.NomeCliente == utilizadorLogado.NomeUtilizador) && (livro.Devolvido == false))
                {
                    livro.ConsultaEmprestimoIndividual();
                    contadorLivrosDoUtilizador++;
                }
            }
            if (contadorLivrosDoUtilizador == 0)
            {
                Console.WriteLine("Não há livros alugados na sua conta.");
                MenuPrincipal.MenuAcoesPrincipal(listaUtilizadores, utilizadorLogado, Livros, emprestimoLivros);
            }

            Console.WriteLine("==========================================================================================================");

            }
    }
}
