using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


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
                    Console.WriteLine("============= Menu ============");
                    Console.WriteLine("|-----------------------------|");
                    Console.WriteLine("| 1. Exibir lista de livros   |");
                    Console.WriteLine("| 2. Alugar livro             |");
                    Console.WriteLine("| 3. Devolver livro           |");
                    Console.WriteLine("| 4. Relatório de Empréstimos |");
                    Console.WriteLine("| 5. Gestão de livros         |");
                    Console.WriteLine("| 6. Lista de Utilizadores    |");
                    Console.WriteLine("| 7. A não Perder             |");
                    Console.WriteLine("| 8. Sair                     |");
                    Console.WriteLine("|_____________________________|");
                    Console.WriteLine();
                    //acrescentar funcao relatorioclientes
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
                            RegistarLivro.ConsultaFiltrada(Livros);
                            break;
                        case 2:
                            Console.Clear();
                            RegistarLivro.ExibirListaLivros(Livros);
                            Console.WriteLine();
                            EmprestimosLivros.LerPedidoAluguer(Livros,utilizadorLogado,emprestimoLivros, listaUtilizadores);
                            break;
                        case 3:
                            Console.Clear();
                            EmprestimosLivros.DevolucaoLivroAluguer(utilizadorLogado,emprestimoLivros,Livros, listaUtilizadores);
                            break;
                        case 4:
                            Console.Clear();
                            RelatoriosEmprestimos.RelatorioEmprestimos(emprestimoLivros);
                            break;
                        case 5:
                            Console.Clear();
                            RegistarLivro.RegLivros(Livros, utilizadorLogado, emprestimoLivros, listaUtilizadores);
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
                    Console.WriteLine("============ Menu =============");
                    Console.WriteLine("|-----------------------------|");
                    Console.WriteLine("| 1. Exibir lista de livros   |");
                    Console.WriteLine("| 2. Alugar livro             |");
                    Console.WriteLine("| 3. Consultar Alugueres      |");
                    Console.WriteLine("| 4. Devolver livro           |");
                    Console.WriteLine("| 5. Sair                     |");
                    Console.WriteLine("|_____________________________|");
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
                            Console.Clear();
                            RegistarLivro.ExibirListaLivros(Livros);
                            
                            RegistarLivro.ConsultaFiltrada(Livros);
                            break;
                        case 2:
                            Console.Clear();
                            RegistarLivro.ExibirListaLivros(Livros);
                            EmprestimosLivros.LerPedidoAluguer(Livros, utilizadorLogado, emprestimoLivros, listaUtilizadores);
                            break;
                        case 3:
                            Console.Clear();
                            EmprestimosLivros.consultaAlugueresCliente(utilizadorLogado, emprestimoLivros, Livros, listaUtilizadores);
                            break;
                        case 4:
                            Console.Clear();
                            EmprestimosLivros.DevolucaoLivroAluguer(utilizadorLogado, emprestimoLivros, Livros, listaUtilizadores);
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Obrigado, até a próxima!");
                            break;

                    }

                    if (opcaoMenuPrincipal != 5)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Deseja ver o menu novamente? (S/N)");
                        string verMenu = Console.ReadLine();

                        if (verMenu.ToLower() == "n")
                        {
                            opcaoMenuPrincipal = 5;
                            Console.WriteLine("Obrigado, até a próxima!");
                        }
                        else if (verMenu.ToLower() == "s")
                        {
                            Console.Clear();
                        }
                    }
                } while (opcaoMenuPrincipal != 5);
            }
            Utilizadores.MenuLogRes(listaUtilizadores, Livros);
        }
    }
}
