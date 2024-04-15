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

            var dataAntiga = new DateOnly(2024, 3, 22);

            RegistarLivro livroGrey = new RegistarLivro("Grey", "Bruno", 1720, 12, "Inglês", "Drama");
            RegistarLivro livroFox = new RegistarLivro("Foxhound", "Joaquim", 1790, 2, "Inglês", "Ação");
            RegistarLivro livroGame = new RegistarLivro("Shrek", "George", 1996, 22, "Inglês", "Ação");
            RegistarLivro livroMob = new RegistarLivro("Mob Dick", "Cleber", 1998, 12, "Português", "Drama");

            Livros.Add(livroGrey);
            Livros.Add(livroFox);
            Livros.Add(livroGame);
            Livros.Add(livroMob);

            Livros.Add(new RegistarLivro("Jester", "Jennifer", 1989, 5, "Inglês", "Romance"));
            Livros.Add(new RegistarLivro("Klarna", "Bruno", 1986, 0, "Alemão", "Drama"));
            Livros.Add(new RegistarLivro("Jupter", "Clark", 1980, 2, "Português", "Terror"));
            Livros.Add(new RegistarLivro("Coder", "Karla", 1989, 5, "Inglês", "Romance"));
            Livros.Add(new RegistarLivro("Geleia", "Julian J", 1986, 1, "Francês", "Thriller"));
            Livros.Add(new RegistarLivro("Hooster", "Charles" , 1990, 1, "Português", "Terror"));

            Utilizadores eduardo = new Utilizadores("Eduardo Lopes", "Rua Braga", "987654321", "12345", true);
            Utilizadores bruno = new Utilizadores("Bruno", "Rua Braga", "987654321", "12345", true);
            Utilizadores sara = new Utilizadores("Sara", "Rua Braga", "987654321", "12345", true);
            Utilizadores joao = new Utilizadores("Joao", "Rua do Porto", "923244856", "12345", false);
            Utilizadores claudio = new Utilizadores("Marta", "Rua Braga", "998764532", "12345", false);

            listaUtilizadores.Add(eduardo);
            listaUtilizadores.Add(bruno);
            listaUtilizadores.Add(sara);
            listaUtilizadores.Add(joao);
            listaUtilizadores.Add(claudio);

            emprestimoLivros.Add(new EmprestimosLivros(eduardo, livroGrey, 5, false, dataAtual));
            emprestimoLivros.Add(new EmprestimosLivros(sara, livroFox, 2, false, dataAntiga));
            emprestimoLivros.Add(new EmprestimosLivros(joao, livroMob, 3, false, dataAntiga));
            emprestimoLivros.Add(new EmprestimosLivros(claudio, livroGame, 6, true, dataAntiga));
            emprestimoLivros.Add(new EmprestimosLivros(eduardo, livroGame, 4, true, dataAntiga));
            emprestimoLivros.Add(new EmprestimosLivros(bruno, livroGame,8, false, dataAtual));

        }
    }
}
