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
        public string Titulo;
        public int Duracao;
        public int QuantidadeExemplaresExistente;
        public int QuantidadeLivroAlugado;
        //public int NrVezesAlugado;
        public DateOnly Data; //{ get; set; }



        public EmprestimosLivros(string nomeCliente, string titulo, int duracao, int quantidadeExemplaresExistente, int quantidadeLivroAlugado, DateOnly data)
        {
            NomeCliente = nomeCliente;
            Titulo = titulo;
            Duracao = duracao;
            QuantidadeExemplaresExistente = quantidadeExemplaresExistente;
            QuantidadeLivroAlugado = quantidadeLivroAlugado;
            Data = data;
            // NrVezesAlugado = nrVezesAlugado;

        }
        public EmprestimosLivros() { }



        public void LerPedidoAluguer(ref Utilizadores listaUtilizadores, ref RegistarLivro Livros)
        {
            Console.WriteLine("Qual o livro que deseja alugar? ");
            Titulo = Console.ReadLine();

            Console.WriteLine("Quantos dias de aluguer deseja? ");
            Duracao = int.Parse(Console.ReadLine());

            Data = DateOnly.FromDateTime(DateTime.Now);

            Console.WriteLine("Quantos exemplares pretende alugar?");
            QuantidadeLivroAlugado = int.Parse(Console.ReadLine());

            NomeCliente = listaUtilizadores.NomeUtilizador;

            QuantidadeExemplaresExistente = Livros.NumExemp;
        }
        public void ConsultaListaEmpr()
        {

            //objetivo do nr vezes alugado seria para fazer um best of livros mais requisitados
            Console.WriteLine("Titulo: " + Titulo + " Nome Cliente: " + NomeCliente + " Duracao: " + Duracao + " Data Pedido: " + Data + "Nr vezes Alugado: " + QuantidadeLivroAlugado);

        }

        /* public void AtualizarQuantidadeLista(RegistarLivro livro)
         {

              QuantidadeLivroAlugado -= livro.NumExemp;
         }

         */

    }
}
