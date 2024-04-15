using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPOO
{
    internal class EmprestimosLivros
    { // class com dois atributos objetos de outras classes
        public Utilizadores Utilizador;
        public RegistarLivro Livro;
        public int Duracao;
        public bool Devolvido = false;
        public DateOnly Data; //{ get; set; }
        


        public EmprestimosLivros(Utilizadores utilizador, RegistarLivro livro, int duracao, bool devolvido, DateOnly data) 
        {
            Utilizador = utilizador;
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
            //atribuimos uma data pena 
            //int diaCalculo= CalculoDifData
            var dataPenalizacao = utilizadorLogado.Penalizado + 3;//(diacalculo)
            RegistarLivro livroVazio = new RegistarLivro("", "", 0, 0, "", "");
            Console.Clear();
            Console.WriteLine("Para retroceder digite 'sair'");

            // se estiver com atraso nao deixa alugar penalizacao padrao 3 dias
            if (dataPenalizacao > dataHoje.DayNumber)
            {                                                                               
                Console.WriteLine($"Interdito o aluguer. Dias de penalização restantes: {dataPenalizacao - dataHoje.DayNumber} .");
                return livroVazio;
            }
            else
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

                    RegistarLivro livroEscolhido = Livros.Find(a => a.NomeLivro.ToLower() == tituloLivroAluguer.ToLower());
                    //se houver correspondencia
                    if (livroEscolhido != null)
                    {
                        Console.WriteLine("Quantos dias de aluguer deseja? ");
                        int duracaoLivroAluguer = int.Parse(Console.ReadLine());

                        var dataLivroAluguer = DateOnly.FromDateTime(DateTime.Now);

                        emprestimoLivros.Add(new EmprestimosLivros(utilizadorLogado, livroEscolhido, duracaoLivroAluguer, false, dataLivroAluguer));

                        livroEscolhido.NumExemp--;

                        livroEscolhido.NumVezesAlugado++;
                        Console.WriteLine("Livro alugado com sucesso.");
                        // retorna o nosso objeto livro para aluguer atravez da lista de livros ja existentes e guarda na nossa lista de emprestimos
                        return livroEscolhido;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Livro não encontrado, tente novamente.");
                        Console.WriteLine("");
                        RegistarLivro.ExibirListaLivros(Livros);
                    }
                    // loop infinito saimos dele atravez de retorno 
                } while (true);
            }
        }
        public static void DevolucaoLivroAluguer(Utilizadores utilizadorLogado, List<EmprestimosLivros> emprestimoLivros, List<RegistarLivro> Livros, List<Utilizadores> listaUtilizadores)
        {
            Console.Clear();
            consultaAlugueresCliente(utilizadorLogado, emprestimoLivros, Livros, listaUtilizadores);

            StringWriter sw = new StringWriter(); // cria uma string que pode escrever chars
            TextWriter originalConsoleOut = Console.Out; // salva o output oritinal para usar dps
            Console.SetOut(sw); // redireciona o output para o objeto sw
            
            int result = consultaAlugueresCliente(utilizadorLogado, emprestimoLivros, Livros, listaUtilizadores); // vai guardar o resultado do metodo

            Console.SetOut(originalConsoleOut); // volta o output ao normal, onde foi salvo antes
         
            if (result  > 0)
            {

                Console.WriteLine("Qual o livro que deseja devolver? ");
                string livroAremover = Console.ReadLine();

                var dataHoje = DateOnly.FromDateTime(DateTime.Now);

                //lemos o nome do objeto novo atraves de uma variavel e vamos a procura de onde na lista um objeto tem esse nome
                EmprestimosLivros DevolverLivro = emprestimoLivros.Find(x => x.Livro.NomeLivro.ToLower() == livroAremover.ToLower()); ;
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
                        DevolverLivro.Utilizador.Penalizado = dataHoje.DayNumber;
                        Console.WriteLine("Livro entregue com atraso, penalizado por 3 dias sem possibilidade de aluguer.");
                    }

                }
                else
                {
                    Console.WriteLine("Livro nao encontrado");
                }
            }
        }
        public void ConsultaListaEmpr()
        {
            //objetivo do nr vezes alugado seria para fazer um best of livros mais requisitados
            Console.WriteLine("|-------------------------------------------------------------------------------------------------------------------|");
            Console.WriteLine($"| Titulo: {Livro.NomeLivro,-10} | Nome Cliente: {Utilizador.NomeUtilizador,-15} | Duracao: {Duracao}  | Data Pedido: {Data,-10} | Status: {statusEmprestimo(),-12} |");
            // Console.WriteLine("|--------------------------------------------------------------------------------------------------------------------|");
        }
        public void ConsultaEmprestimoIndividual()
        {
            var dataHoje = DateOnly.FromDateTime(DateTime.Now);

            Console.WriteLine("|----------------------------------------------------------------------------------------------------------|");
            Console.WriteLine($"| Título: {Livro.NomeLivro,-9} | Autor: {Livro.Autor, -9} | Duração: {Duracao,-2} | Data Pedido: {Data,-9} | {calculoDiasParaEntrega(), -20} |");
            // Console.WriteLine("|-------------------------------------------------------------------------------------------|");
        }
        public DateOnly DataEntregaLivroAlugado()
        {
            var dataLimite = Data.AddDays(Duracao);
            return dataLimite;
        }
        public static int consultaAlugueresCliente(Utilizadores utilizadorLogado, List<EmprestimosLivros> emprestimoLivros, List<RegistarLivro> Livros, List<Utilizadores> listaUtilizadores)
        {
            int contadorLivrosDoUtilizador = 0;

            Console.WriteLine("============================================ Os seus Livros ================================================");
            
            foreach (EmprestimosLivros livro in emprestimoLivros)
            {// se existir  um emprestimo com o user que esta logado onde ele tenha itens na lista de aluguers
                //apresenta lista
                if ((livro.Utilizador.NomeUtilizador == utilizadorLogado.NomeUtilizador) && (livro.Devolvido == false))
                {
                    livro.ConsultaEmprestimoIndividual();
                    contadorLivrosDoUtilizador++;
                }
            }
            // se nao tiver 
            if (contadorLivrosDoUtilizador == 0)
            {
                Console.WriteLine("|----------------------------------------------------------------------------------------------------------|");
                Console.WriteLine("| Não há livros alugados na sua conta                                                                      |");
            }

            Console.WriteLine("|__________________________________________________________________________________________________________|");
            Console.WriteLine();

            return contadorLivrosDoUtilizador;
        }
        public string statusEmprestimo()
        {
            var dataHoje = DateOnly.FromDateTime(DateTime.Now);
            string Status;
            //comparamos a diferenca entre a data de consulta com a data de entrega
            int difDatas= dataHoje.CompareTo(DataEntregaLivroAlugado());
            
            //se devolvido for verdadeiro pedido finalizado
            if (Devolvido == true)
            {
                Status = "Finalizado";
                return Status;
            }
            else
            {
                //se a diferenca entre a data consulta e data entrega for positiva (1) 
                if (difDatas == 1)
                {
                    int diasCalculo = CalculoDifDatas();
                    Status = "Atrasado "+diasCalculo+ "dias";
                    return Status;
                }
                else
                {
                    Status = "Em Andamento";
                    return Status;
                }
            }
        }

        
        public  string calculoDiasParaEntrega()
        {// da return do estado do status
            string respostaCalculo;
            int diasCalculo=CalculoDifDatas();

            if (diasCalculo > 0)
            {
                respostaCalculo = $"Entregar em: {diasCalculo} dias";
                return respostaCalculo;
            }
            else
            {
                //acrescentei apenas o nr dias de atraso
               // Math abs para ter o dia sem negativo
                respostaCalculo = "Status: Atrasado "+ Math.Abs(diasCalculo)+" dias";
                return respostaCalculo;
            }
        }

        public int CalculoDifDatas()
        { // faz a diferenca entre datas contemplando meses tambem
            var dataHoje = DateOnly.FromDateTime(DateTime.Now);           
            //criado uma variavel timeonly que vamos usar como argumento a converter as datas para datetime
            var time = TimeOnly.FromDateTime(DateTime.Now);
            var dataEntrega = DataEntregaLivroAlugado().ToDateTime(time);
            var dataAtual = dataHoje.ToDateTime(time);
            //Assim podemos subtrair as datas e obter um valor
            //obtemos um tipo timespan que dei o nome de dataFinal
            var dataFinal = dataEntrega.Subtract(dataAtual);
            //como so precisamos do numero do dia retiramos ao dataFinal o dia e obtemos o nosso resultado
            var diasCalculo = dataFinal.Days;
            return diasCalculo;
        }
    }
}
