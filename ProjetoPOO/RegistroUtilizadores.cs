using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPOO
{
    class Utilizadores
    {
        public string NomeUtilizador;
        public string EnderecoUtilizador;
        public string TelefoneUtilizador;
        public string PalavraChave;

        public Utilizadores(string nome, string endereco, string telefone, string palavraChave)
        {
            NomeUtilizador = nome;
            EnderecoUtilizador = endereco;
            TelefoneUtilizador = telefone;
            PalavraChave = palavraChave;
        }

        class Utilizador
        {
            public string NomeUtilizador { get; set; }

            public Utilizador(string nome)
            {
                NomeUtilizador = nome;
            }
        }




    }
}
