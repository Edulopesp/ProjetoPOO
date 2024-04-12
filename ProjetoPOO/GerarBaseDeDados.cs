using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPOO
{
    internal class GerarBaseDeDados
    {
        public static void GerarDados(List<Utilizadores> listaUtilizadores, List<EmprestimosLivros> emprestimoLivros, List<RegistarLivro> Livros) 
        {
            var dataAtual = DateOnly.FromDateTime(DateTime.Now);

            var dataAntiga = new DateOnly(2024, 3, 17);

            RegistarLivro livroGrey = new RegistarLivro("grey", "bruno", 1720, 12, "Inglês", "Drama");
            RegistarLivro livroFox = new RegistarLivro("foxhound", "joaquim", 1790, 2, "Inglês", "Ação");

            Utilizadores eduardo = new Utilizadores("Eduardo Lopes", "Rua Braga", "987654321", "12345", true);
            Utilizadores bruno = new Utilizadores("Bruno", "Rua Braga", "987654321", "12345", true);
            Utilizadores sara = new Utilizadores("Sara", "Rua Braga", "987654321", "12345", true);
            listaUtilizadores.Add(eduardo);
            listaUtilizadores.Add(bruno);
            listaUtilizadores.Add(sara);
            emprestimoLivros.Add(new EmprestimosLivros(eduardo, livroGrey, 5, false, dataAtual));
            emprestimoLivros.Add(new EmprestimosLivros(sara, livroFox, 2, false, dataAntiga));
            Livros.Add(livroGrey);
            Livros.Add(livroFox);
            Livros.Add(new RegistarLivro("uno", "jonh", 1989, 5, "Português", "Romance"));
            Livros.Add(new RegistarLivro("duo", "jonh2", 1986, 0, "Português", "Drama"));
            Livros.Add(new RegistarLivro("trio", "jonh3", 1980, 2, "Português", "Terror"));
        }
    }
}
