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
        public int QuantidadeExemplaresExistente;
        //public int QuantidadeLivroAlugado;
        //public int NrVezesAlugado;
        public bool Devolvido = false;
        public DateOnly Data; //{ get; set; }



        public EmprestimosLivros(string nomeCliente, RegistarLivro livro, int duracao, bool devolvido, DateOnly data) // int quantidadeLivroAlugado, int quantidadeExemplaresExistente,
        {
            NomeCliente = nomeCliente;
            Livro = livro;
            Duracao = duracao;
            //QuantidadeExemplaresExistente = quantidadeExemplaresExistente;
            //QuantidadeLivroAlugado = quantidadeLivroAlugado;
            Devolvido = devolvido;
            Data = data;

            // NrVezesAlugado = nrVezesAlugado;
        }
        public EmprestimosLivros() 
        {
        }
        public void LerPedidoAluguer()
        {
        }
        public void ConsultaListaEmpr()
        {
            //objetivo do nr vezes alugado seria para fazer um best of livros mais requisitados
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine($"| Titulo: {Livro.NomeLivro, -10} | Nome Cliente: {NomeCliente,-10} | Duracao: {Duracao} | Data Pedido: {Data,-10} |");
            //  + "Nr vezes Alugado: " + QuantidadeLivroAlugado

        }
        public void ConsultaEmprestimoIndividual()
        {
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine($"| Título: {Livro.NomeLivro,-9} | Duração: {Duracao,-9} | Data Pedido: {Data,-9} |");
        }

        /*
       public void AtualizarQuantidadeLista(RegistarLivro livro)
         {

              QuantidadeLivroAlugado -= livro.NumExemp;
         }

         */

    }
}
