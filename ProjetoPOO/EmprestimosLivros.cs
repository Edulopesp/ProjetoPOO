using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPOO
{
    internal class EmprestimosLivros
    {
        public Utilizadores Cliente;
        public RegistarLivro Livro;
        public int Duracao;
        public bool Devolvido = false;
        public DateOnly Data; //{ get; set; }



        public EmprestimosLivros(Utilizadores utilizadorLogado, RegistarLivro livro, int duracao, bool devolvido, DateOnly data) // int quantidadeLivroAlugado, int quantidadeExemplaresExistente,
        {
            Cliente = utilizadorLogado;
            Livro = livro;
            Duracao = duracao;
            Devolvido = devolvido;
            Data = data;
        }
        public EmprestimosLivros()
        {
        }
        public static RegistarLivro LerPedidoAluguer(List<RegistarLivro> Livros, Utilizadores utilizadorLogado, List<EmprestimosLivros> emprestimoLivros, List<Utilizadores> listaUtilizadores)
        {

            var dataHoje = DateOnly.FromDateTime(DateTime.Now);
            var dataPenalizacao = utilizadorLogado.Penalizado + 3;
            RegistarLivro livroVazio = new RegistarLivro("", "", 0, 0, "", "");

            Console.WriteLine("Para retroceder digite 'sair'.");

            if (dataPenalizacao > dataHoje.DayNumber)
            {
                Console.WriteLine($"Você está em processo de penalização, faltam {dataPenalizacao - dataHoje.DayNumber} dias.");

                return livroVazio;
            }
            else if (dataPenalizacao < dataHoje.DayNumber)
            {
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
                        emprestimoLivros.Add(new EmprestimosLivros(utilizadorLogado, livroEscolhido, duracaoLivroAluguer, false, dataLivroAluguer));

                        livroEscolhido.NumExemp--;

                        livroEscolhido.NumVezesAlugado++;

                        return livroEscolhido;
                    }
                    else
                    {
                        Console.Clear();
                        RegistarLivro.ExibirListaLivros(Livros);
                        Console.WriteLine();
                        Console.WriteLine("Livro não encontrado, tente novamente.");
                    }
            } while (true);
              return livroVazio;
        }

        public static void DevolucaoLivroAluguer(Utilizadores utilizadorLogado,List<EmprestimosLivros>emprestimoLivros,List<RegistarLivro>Livros, List<Utilizadores> listaUtilizadores)
        {   
            int contadorLivrosEmprestados = 0;
            Console.WriteLine("============================================= Os seus Livros =============================================");

            foreach (EmprestimosLivros livro in emprestimoLivros)
            {
                if ((livro.NomeCliente == utilizadorLogado.NomeUtilizador) && (livro.Devolvido == false))
                {
                    livro.ConsultaEmprestimoIndividual();
                    contadorLivrosEmprestados++;
                }
            }
            if (contadorLivrosEmprestados == 0)
              {
                Console.WriteLine("Não há livros alugados na sua conta.");
                MenuPrincipal.MenuAcoesPrincipal(listaUtilizadores, utilizadorLogado, Livros, emprestimoLivros);
              }

            Console.WriteLine("_________________________________________________________________________________________________________|");
            consultaAlugueresCliente(utilizadorLogado, emprestimoLivros, Livros, listaUtilizadores);

            Console.WriteLine();
            Console.WriteLine("Qual o livro que deseja devolver? ");
            string livroAremover = Console.ReadLine();

            var dataHoje = DateOnly.FromDateTime(DateTime.Now);

            //lemos o nome do objeto novo atraves de uma variavel e vamos a procura de onde na lista um objeto tem esse nome
            EmprestimosLivros DevolverLivro = emprestimoLivros.Find(x => x.Livro.NomeLivro == livroAremover);
            Console.WriteLine();
            if (DevolverLivro != null)
            {//atribuimos o estado verdadeiro ao atributo da nossa classe emprestimosLivros
                //adicionamos novamente a quantidade ao registo do livro devolvido
                DevolverLivro.Devolvido = true;
                DevolverLivro.Livro.NumExemp++;
                Console.Clear();

                int diasCalculo = DevolverLivro.DataEntregaLivroAlugado().DayNumber - dataHoje.DayNumber;

                if (diasCalculo > 0)
                {
                    Console.WriteLine("Livro devolvido com sucesso");
                }
                else
                {
                    DevolverLivro.Cliente.Penalizado = dataHoje.DayNumber;
                    Console.WriteLine("Livro entregue com atraso, penalizado por 3 dias sem possibilidade de aluguer.");
                }
            }
            else
            {
                Console.WriteLine("Livro nao encontrado");
            }
        }
        public void ConsultaListaEmpr()
        {
            //objetivo do nr vezes alugado seria para fazer um best of livros mais requisitados
            Console.WriteLine("|------------------------------------------------------------------------------------------------------------------|");
            Console.WriteLine($"| Titulo: {Livro.NomeLivro,-10} | Nome Cliente: {Cliente.NomeUtilizador,-10} | Duracao: {Duracao}  | Data Pedido: {Data,-10} | Status: {statusEmprestimo(),-12} |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------------------------|");
        }
        public void ConsultaEmprestimoIndividual()
        {
            var dataHoje = DateOnly.FromDateTime(DateTime.Now);

            Console.WriteLine("|----------------------------------------------------------------------------------|");
            Console.WriteLine($"| Título: {Livro.NomeLivro,-9} | Duração: {Duracao,-2} | Data Pedido: {Data,-9} | {calculoDiasParaEntrega()} |");
            Console.WriteLine("|----------------------------------------------------------------------------------|");
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

            Console.WriteLine("======================================== Os seus Livros =============================================");

            foreach (EmprestimosLivros livro in emprestimoLivros)
            {
                if ((livro.Cliente.NomeUtilizador == utilizadorLogado.NomeUtilizador) && (livro.Devolvido == false))
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
            Console.WriteLine("|___________________________________________________________________________________________________|");
        }
        public string statusEmprestimo()
        {
            var dataHoje = DateOnly.FromDateTime(DateTime.Now);
            string Status;

            if (Devolvido == true)
            {
                Status = "Finalizado";
                return Status;
            }
            else
            {
                if (DataEntregaLivroAlugado().DayNumber - dataHoje.DayNumber < 0)
                {
                    Status = "Atrasado";
                    return Status;
                }
                else
                {
                    Status = "Em Andamento";
                    return Status;
                }
            }
        }
        public string calculoDiasParaEntrega()
        {
            var dataHoje = DateOnly.FromDateTime(DateTime.Now);
            string respostaCalculo;

            int diasCalculo = DataEntregaLivroAlugado().DayNumber - dataHoje.DayNumber;
            if (diasCalculo > 0) 
            {
                respostaCalculo = $"Entregar em: {diasCalculo} dias";
                return respostaCalculo;
            } else
            {
                respostaCalculo = "Status: Atrasado";
                return respostaCalculo;
            }
        }
    }
}
