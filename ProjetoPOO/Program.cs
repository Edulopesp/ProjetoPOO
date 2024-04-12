using ProjetoPOO;
using System.Collections.Generic;
using System.Linq.Expressions;

class Program
{
    static void Main(string[] args)
    {
        
        List<Utilizadores> listaUtilizadores = new List<Utilizadores>();
        List<EmprestimosLivros> emprestimoLivros = new List<EmprestimosLivros>();
        List<RegistarLivro> Livros = new List<RegistarLivro>();

        // Gerar dados falsos para simulacoes
        GerarBaseDeDados.GerarDados(listaUtilizadores, emprestimoLivros, Livros);

        // loop para nao sair do programa, facilitar testes e simular cenarios
        do
        {
            // criar uma variável para armazenar o usuário logado
            Utilizadores utilizadorLogado = Utilizadores.MenuLogRes(listaUtilizadores, Livros);

            MenuPrincipal.MenuAcoesPrincipal(listaUtilizadores, utilizadorLogado, Livros, emprestimoLivros);
        } while(true);
    }
}   