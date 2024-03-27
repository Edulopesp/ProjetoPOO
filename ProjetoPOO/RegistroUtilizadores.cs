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
        public bool Funcionario;

        public Utilizadores(string nome, string endereco, string telefone, string palavraChave, bool funcionario)
        {
            NomeUtilizador = nome;
            EnderecoUtilizador = endereco;
            TelefoneUtilizador = telefone;
            PalavraChave = palavraChave;
            Funcionario = funcionario;
        }
    }
}
