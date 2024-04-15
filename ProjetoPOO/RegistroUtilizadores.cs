namespace ProjetoPOO
{
    class Utilizadores
    {
        public string NomeUtilizador { get; set; }
        public string EnderecoUtilizador { get; set; }
        public string TelefoneUtilizador { get; set; }
        public string PalavraChave{ get; private set; }
        public bool Funcionario{ get; private set; }
        public int Penalizado { get; set; }

        public Utilizadores(string nome, string endereco, string telefone, string palavraChave, bool funcionario)
        {
            NomeUtilizador = nome;
            EnderecoUtilizador = endereco;
            TelefoneUtilizador = telefone;
            PalavraChave = palavraChave;
            Funcionario = funcionario;
            Penalizado = 0;

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


            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write("            Bem vindo à Biblioteca ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("BES<T>");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("!");
            Console.Write("   Onde temos à sua disposição mais de ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(totalLivrosBiblioteca - 1);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" Livros");
            Console.Write("           entre ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{Livros.Count()} Títulos");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" diferentes!");

            Console.WriteLine();
            Console.WriteLine();

            Console.ResetColor();
            /*
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("========== ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Menu");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" ==========");
            Console.WriteLine("|------------------------|");
            Console.Write("| 1. ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Login");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("               |");
            Console.Write("| 2. ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Registrar");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("           |");
            Console.WriteLine("|________________________|");

            Console.ResetColor();
            */


            Console.WriteLine("========== Menu ==========");
            Console.WriteLine("|------------------------|");
            Console.WriteLine("| 1. Login               |");
            Console.WriteLine("| 2. Registrar           |");
            Console.WriteLine("|________________________|");

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
            do
            {
                Console.WriteLine("============ Login ============");
                Console.WriteLine("|-----------------------------|");
                Console.Write("| Nome: ");
                string nomeUtilizador = Console.ReadLine();
                Console.Write("| Palavra-Chave: ");
                string palavraChaveUtilizador = palavraChaveSegura();
                Console.WriteLine("|_____________________________|");
                Console.WriteLine();

                Utilizadores utilizadorLogado = listaUtilizadores.Find(a => a.NomeUtilizador == nomeUtilizador);

                Utilizadores procurarPalavraChave = listaUtilizadores.Find(a => a.PalavraChave == palavraChaveUtilizador);

                if ((utilizadorLogado != null) && (procurarPalavraChave != null))
                {
                    if (utilizadorLogado.Funcionario == true)
                    {
                        Console.Clear();
                        Console.WriteLine($"Bem vindo funcionário(a) {utilizadorLogado.NomeUtilizador}!");
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
                    Console.Clear();
                    Console.WriteLine("Nome ou Palavra-Chave Incorretos, tente novamente.");
                    Console.WriteLine("");
                    Console.WriteLine("Para retroceder digite 'sair', caso contrario prima ENTER.");
                    string saida = Console.ReadLine();

                    if (saida == "sair")
                    {
                        Console.Clear();
                        return MenuLogRes(listaUtilizadores, Livros);

                    }
                }
            } while (true);
        }
        public static Utilizadores efetuarRegistro(List<Utilizadores> listaUtilizadores, List<RegistarLivro> Livros)
        {
            string nomeUtilizador;
            string enderecoUtilizador;
            string telefoneUtilizador;
            string palavraChaveUtilizador;
            string identificadorUtilizador;
            string saida = "";
            do
            {
                Console.WriteLine("");
                Console.WriteLine("======== Registrar =======");
                Console.WriteLine("|------------------------|");


                Console.Write("| Nome: ");
                nomeUtilizador = Console.ReadLine();
                saida = "sair";

                if (nomeUtilizador == "")
                {
                    Console.WriteLine("Nome introduzido nao admitido.");
                    Console.WriteLine();
                   Console.WriteLine("Para retroceder digite 'sair', caso contrario prima ENTER.");
                    saida = Console.ReadLine();
                    Console.Clear();
                    if (saida.ToLower() == "sair")
                    {
                        Console.Clear();
                         return MenuLogRes(listaUtilizadores, Livros);
                       
                    }
                }
            }
            while (saida == "" );
            do
            {
                Console.Write("| Endereço: ");
                enderecoUtilizador = Console.ReadLine();
            } while (enderecoUtilizador == "");

            do
            {
                Console.Write("| Telefone: ");
                telefoneUtilizador = Console.ReadLine();

            } while (telefoneUtilizador == "");

            do
            {
                Console.Write("| Palavra-Chave: ");
                palavraChaveUtilizador = Console.ReadLine();
            } while (palavraChaveUtilizador == "");

            do
            {
                Console.Write("| Funcionário: ");
                identificadorUtilizador = Console.ReadLine().ToUpper();
            } while ((identificadorUtilizador != "") && (identificadorUtilizador != "BTCB"));

            Console.WriteLine("|________________________|");
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

            if ((utilizadorLogado != null) && (utilizadorLogado.NomeUtilizador !="sair"))
            {
                Console.Clear();
                Console.WriteLine("Usuário já registrado! Faça o login!");
                Console.WriteLine("");
                efetuarLogin(listaUtilizadores, Livros);
                utilizadorLogado = MenuLogRes(listaUtilizadores, Livros);
                return utilizadorLogado;
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

       public static void mostrarListaUtilizadores(List<Utilizadores> listaUtilizadores)
        {
            Console.WriteLine("");
            Console.WriteLine("===================== Lista de Utilizadores ===================");
            Console.WriteLine("|-------------------------------------------------------------|");
            foreach (Utilizadores usuario in listaUtilizadores)
            {
                Console.WriteLine("|-------------------------------------------------------------|");
                Console.WriteLine($"| Nome: {usuario.NomeUtilizador,-20} | Telefone: {usuario.TelefoneUtilizador,-20} |");
                // Console.WriteLine("|-------------------------------------------------------------|");
            }
            Console.WriteLine("|_____________________________________________________________|");
        }
        static string palavraChaveSegura()
        {
            string palavrachave = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    palavrachave += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && palavrachave.Length > 0)
                {
                    palavrachave = palavrachave.Substring(0, (palavrachave.Length - 1));
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return palavrachave;
        }
    }
}
