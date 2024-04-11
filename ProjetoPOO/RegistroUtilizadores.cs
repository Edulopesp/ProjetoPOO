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

        public static Utilizadores MenuLogRes(List<Utilizadores> listaUtilizadores, List<RegistarLivro> Livros)
        {
            double opcaoMenuLogRes;
            Utilizadores utilizadorLogado = null;
            int totalLivrosBiblioteca = 0;

            foreach (var livro in Livros)
            {
                totalLivrosBiblioteca += livro.NumExemp;
            }

            Console.Clear();
            Console.WriteLine("            Bem vindo à Biblioteca BES<T>!");
            Console.WriteLine($"   Onde temos à sua disposição mais de {totalLivrosBiblioteca - 1} Livros");
            Console.WriteLine($"           entre {Livros.Count()} Títulos diferentes!");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(" ----------Menu----------");
            Console.WriteLine("| 1 - Login              |");
            Console.WriteLine("| 2 - Registrar          |");
            Console.WriteLine("==========================");

            opcaoMenuLogRes = double.Parse(Console.ReadLine());
            Console.WriteLine("");

            while ((opcaoMenuLogRes != 1) && (opcaoMenuLogRes != 2))
            {
                Console.WriteLine("Opção inválida, escolha novamente: ");
                opcaoMenuLogRes = double.Parse(Console.ReadLine());
                Console.WriteLine("");
            }

            switch (opcaoMenuLogRes)
            {
                case 1:
                    Console.Clear();
                    utilizadorLogado = Utilizadores.efetuarLogin(listaUtilizadores, Livros);
                    break;
                case 2:
                    Console.Clear();
                    utilizadorLogado = Utilizadores.efetuarRegistro(listaUtilizadores, Livros);
                    break;
            }
            return utilizadorLogado;
        }


        public static Utilizadores efetuarLogin(List<Utilizadores> listaUtilizadores, List<RegistarLivro> Livros)
        {
            Console.WriteLine("-----------------------------------Login-------------------------------");
            Console.WriteLine();


            Console.WriteLine("  Para retroceder escreva 'sair', caso contrario primar ENTER");
            string saida = Console.ReadLine();

            if (saida == "sair")
            {
                Console.Clear();
                return MenuLogRes(listaUtilizadores, Livros);

            }
            else
            {

                do
                {
                    {

                        Console.Write("(1) Nome: ");
                        string nomeUtilizador = Console.ReadLine();




                        Console.Write("(2) Palavra-Chave: ");
                        string palavraChaveUtilizador = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine();

                        Utilizadores utilizadorLogado = listaUtilizadores.Find(a => a.NomeUtilizador == nomeUtilizador);

                        Utilizadores procurarPalavraChave = listaUtilizadores.Find(a => a.PalavraChave == palavraChaveUtilizador);



                        if ((utilizadorLogado != null) && (procurarPalavraChave != null))
                        {
                            if (utilizadorLogado.Funcionario == true)
                            {
                                Console.Clear();
                                Console.WriteLine($"Bem vindo funcionário {utilizadorLogado.NomeUtilizador}!");
                                Console.WriteLine("");
                                return utilizadorLogado;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine($"Bem vindo {utilizadorLogado.NomeUtilizador}!");
                                Console.WriteLine("");
                                return utilizadorLogado;
                            }
                        }
                        else
                        {

                            Console.WriteLine("  Para retroceder escreva 'sair', caso contrario primar ENTER");
                            string saida2 = Console.ReadLine();

                            if (saida2 == "sair")
                            {
                                Console.Clear();
                                return MenuLogRes(listaUtilizadores, Livros);

                            }

                            Console.Clear();
                            Console.WriteLine("Nome ou Palavra-Chave Incorretos, tente novamente.");
                            Console.WriteLine("");

                        }

                    }
                } while (true);

            }
        }

        public static Utilizadores efetuarRegistro(List<Utilizadores> listaUtilizadores, List<RegistarLivro> Livros)
        {

            Console.WriteLine("");
            Console.WriteLine("----------------------------Registrar-----------------------------");
            Console.WriteLine();
            Console.WriteLine(" ==> Para retroceder escreva 'sair', para continuar prima ENTER");
            string saida = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
            if (saida == "sair")
            {
                Console.Clear();
                return MenuLogRes(listaUtilizadores, Livros);

            }
            else
            {

                Console.Write("(1) Nome: ");
                string nomeUtilizador = Console.ReadLine();
                Console.Write("(2) Endereço: ");
                string enderecoUtilizador = Console.ReadLine();
                Console.Write("(3) Telefone: ");
                string telefoneUtilizador = Console.ReadLine();
                Console.Write("(4) Palavra-Chave: ");
                string palavraChaveUtilizador = Console.ReadLine();
                Console.Write("(5) Funcionário: ");
                string identificadorUtilizador = Console.ReadLine().ToUpper();
                Console.WriteLine();
                Console.WriteLine();


                // identificador do funcionario e usuário

                bool funcionarioIdentificado;

                if (identificadorUtilizador == "BTCB")
                {
                    funcionarioIdentificado = true;
                }
                else
                {
                    funcionarioIdentificado = false;
                }

                Utilizadores utilizadorLogado = listaUtilizadores.Find(a => a.NomeUtilizador == nomeUtilizador);

                if (utilizadorLogado != null)
                {
                    Console.Clear();
                    Console.WriteLine("Usuário já registrado! Faça o login!");
                    Console.WriteLine("");
                    return utilizadorLogado; // adicionar a volta para o login
                }
                else
                {
                    utilizadorLogado = new Utilizadores(nomeUtilizador, enderecoUtilizador, telefoneUtilizador, palavraChaveUtilizador, funcionarioIdentificado);
                    listaUtilizadores.Add(utilizadorLogado);
                    Console.WriteLine("Usuário registrado com sucesso!");
                    Console.WriteLine("");

                    if (funcionarioIdentificado == true)
                    {
                        Console.Clear();
                        Console.WriteLine($"Bem vindo funcionário {utilizadorLogado.NomeUtilizador}!");
                        Console.WriteLine("");
                        return utilizadorLogado;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Bem vindo {utilizadorLogado.NomeUtilizador}!");
                        Console.WriteLine("");
                        return utilizadorLogado;
                    }
                }
            }
        }

        public static void mostrarListaUtilizadores(List<Utilizadores> listaUtilizadores)
        {
            Console.WriteLine("");
            Console.WriteLine("-------------------- Lista de Utilizadores --------------------");

            foreach (Utilizadores usuario in listaUtilizadores)
            {
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine($"| Nome: {usuario.NomeUtilizador,-20} | Telefone: {usuario.TelefoneUtilizador,-20} |");

            }
            Console.WriteLine("===============================================================");
        }
    }
}
