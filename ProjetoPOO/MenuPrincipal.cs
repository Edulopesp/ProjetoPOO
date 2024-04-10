using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPOO
{
    class MenuPrincipal
    {
        public static void MenuAcoesPrincipal(List<Utilizadores> listaUtilizadores, Utilizadores utilizadorLogado,List<RegistarLivro> Livros,List  <EmprestimosLivros> emprestimoLivros)

        {
            bool permissaoFuncionario = utilizadorLogado.Funcionario;
            int opcaoMenuPrincipal = 0;


            if (permissaoFuncionario == true)
            {

                do
                {
                    Console.WriteLine(" ------------ Menu ------------");
                    Console.WriteLine("| 1. Exibir lista de livros   |");
                    Console.WriteLine("| 2. Alugar livro             |");
                    Console.WriteLine("| 3. Devolver livro           |");
                    Console.WriteLine("| 4. Relatório de Empréstimos |");
                    Console.WriteLine("| 5. Gestão de livros         |");
                    Console.WriteLine("| 6. Lista de Utilizadores    |");
                    Console.WriteLine("| 7. Sair                     |");
                    Console.WriteLine("===============================");
                    Console.WriteLine();

                    Console.WriteLine("Escolha uma opção: ");
                    opcaoMenuPrincipal = int.Parse(Console.ReadLine());

                    while ((opcaoMenuPrincipal != 1) && (opcaoMenuPrincipal != 2) && (opcaoMenuPrincipal != 3) && (opcaoMenuPrincipal != 4) && (opcaoMenuPrincipal != 5) && (opcaoMenuPrincipal != 6) && (opcaoMenuPrincipal != 7))
                    {
                        Console.WriteLine("Opção inválida, escolha novamente: ");
                        opcaoMenuPrincipal = int.Parse(Console.ReadLine());
                        Console.WriteLine("");
                    }

                    switch (opcaoMenuPrincipal)
                    {
                        case 1:
                            Console.Clear();
                            RegistarLivro.ExibirListaLivros(Livros);
                            break;
                        case 2:
                            Console.Clear();
                            RegistarLivro.ExibirListaLivros(Livros);
                            Console.WriteLine();
                            EmprestimosLivros.LerPedidoAluguer(Livros,utilizadorLogado,emprestimoLivros);
                            break;
                        case 3:
                            Console.Clear();
                            EmprestimosLivros.DevolucaoLivroAluguer(utilizadorLogado,emprestimoLivros,Livros);
                            break;
                        case 4:
                            Console.Clear();
                            EmprestimosLivros.RelatorioEmprestimos(emprestimoLivros);
                            break;
                        case 5:
                            Console.Clear();
                            RegistarLivro.RegLivros(Livros);
                            break;
                        case 6:
                            Console.Clear();
                            Utilizadores.mostrarListaUtilizadores(listaUtilizadores);
                            break;
                        case 7:
                            Console.WriteLine("Obrigado, até a próxima!");
                            break;

                    }


                    if (opcaoMenuPrincipal != 7)
                    {
                        Console.WriteLine("Deseja ver o menu novamente? (S/N)");
                        string verMenu = Console.ReadLine();

                        if (verMenu.ToLower() == "n")
                        {
                            opcaoMenuPrincipal = 7;
                            Console.WriteLine("Obrigado, até a próxima!");
                        }
                        else if (verMenu.ToLower() == "s")
                        {
                            Console.Clear();
                        }
                    }
                } while (opcaoMenuPrincipal != 7);
            }
            else
            {
                do
                {
                    Console.WriteLine(" ------------ Menu ------------");
                    Console.WriteLine("| 1. Exibir lista de livros   |");
                    Console.WriteLine("| 2. Alugar livro             |");
                    Console.WriteLine("| 3. Devolver livro           |");
                    Console.WriteLine("| 4. Sair                     |");
                    Console.WriteLine("===============================");
                    Console.WriteLine();

                    Console.WriteLine("Escolha uma opção: ");
                    opcaoMenuPrincipal = int.Parse(Console.ReadLine());

                    while ((opcaoMenuPrincipal != 1) && (opcaoMenuPrincipal != 2) && (opcaoMenuPrincipal != 3) && (opcaoMenuPrincipal != 4))
                    {
                        Console.WriteLine("Opção inválida, escolha novamente: ");
                        opcaoMenuPrincipal = int.Parse(Console.ReadLine());
                        Console.WriteLine("");
                    }

                    switch (opcaoMenuPrincipal)
                    {
                        case 1:
                            RegistarLivro.ExibirListaLivros(Livros);
                            break;
                        case 2:
                            EmprestimosLivros.LerPedidoAluguer(Livros, utilizadorLogado, emprestimoLivros);
                           
                            break;
                        case 3:
                            EmprestimosLivros.DevolucaoLivroAluguer(utilizadorLogado, emprestimoLivros, Livros, listaUtilizadores);
                            break;
                        case 4:
                            Console.WriteLine("Obrigado, até a próxima!");
                            break;
                    }

                    if (opcaoMenuPrincipal != 4)
                    {
                        Console.WriteLine("Deseja ver o menu novamente? (S/N)");
                        string verMenu = Console.ReadLine();

                        if (verMenu.ToLower() == "n")
                        {
                            opcaoMenuPrincipal = 4;
                            Console.WriteLine("Obrigado, até a próxima!");
                        }
                        else if (verMenu.ToLower() == "s")
                        {
                            Console.Clear();
                        }
                    }
                } while (opcaoMenuPrincipal != 4);
            }
            Utilizadores.MenuLogRes(listaUtilizadores);
        }
    }
}
