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

            RegistarLivro livroGrey = new RegistarLivro("grey", "bruno", 1720, 12, "Inglês", "Drama");
            RegistarLivro livroFox = new RegistarLivro("foxhound", "joaqui,", 1790, 2, "Inglês", "Ação");
            listaUtilizadores.Add(new Utilizadores("Eduardo Lopes", "Rua Braga", "987654321", "12345", true));
            listaUtilizadores.Add(new Utilizadores("Sara", "Rua Braga", "987654321", "12345", true));
            listaUtilizadores.Add(new Utilizadores("Bruno", "Rua Braga", "987654321", "12345", true));
            emprestimoLivros.Add(new EmprestimosLivros("paula", livroGrey, 5, false, dataAtual));
            emprestimoLivros.Add(new EmprestimosLivros("Sara", livroFox, 2, false, dataAtual));
            Livros.Add(livroGrey);
            Livros.Add(livroFox);
            Livros.Add(new RegistarLivro("uno", "jonh", 1989, 5, "Português", "Romance"));
            Livros.Add(new RegistarLivro("duo", "jonh2", 1986, 0, "Português", "Drama"));
            Livros.Add(new RegistarLivro("trio", "jonh3", 1980, 2, "Português", "Terror"));
        }
    }
}
