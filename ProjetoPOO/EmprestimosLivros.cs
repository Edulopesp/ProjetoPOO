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
        //public int QuantidadeLivroAlugado;
        //public int NrVezesAlugado;
        public bool Devolvido = false;
        public DateOnly Data; //{ get; set; }



        public EmprestimosLivros(string nomeCliente, string titulo, int duracao, bool devolvido, DateOnly data) // int quantidadeLivroAlugado, int quantidadeExemplaresExistente,
        {
            NomeCliente = nomeCliente;
            Titulo = titulo;
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

        /*
        public void ConsultaListaEmpr()
        {

            //objetivo do nr vezes alugado seria para fazer um best of livros mais requisitados
            Console.WriteLine("| Titulo: " + Titulo + " Nome Cliente: " + NomeCliente + " Duracao: " + Duracao + " Data Pedido: " + Data + "|"); //  + "Nr vezes Alugado: " + QuantidadeLivroAlugado

        }

       public void AtualizarQuantidadeLista(RegistarLivro livro)
         {

              QuantidadeLivroAlugado -= livro.NumExemp;
         }

         */

    }
}
