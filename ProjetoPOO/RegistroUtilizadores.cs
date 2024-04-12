namespace ProjetoPOO
{
    class Utilizadores
    {
        public string NomeUtilizador;
        public string EnderecoUtilizador;
        public string TelefoneUtilizador;
        public string PalavraChave;
        public bool Funcionario;
        public int Penalizado;

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
            Console.WriteLine("            Bem vindo à Biblioteca BES<T>!");
            Console.WriteLine($"   Onde temos à sua disposição mais de {totalLivrosBiblioteca - 1} Livros");
            Console.WriteLine($"           entre {Livros.Count()} Títulos diferentes!");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("========== Menu ==========");
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
            Console.WriteLine("============ Login ============");
            Console.WriteLine("|-----------------------------|");

            do
            {
                Console.Write("| Nome: ");
                string nomeUtilizador = Console.ReadLine();
                Console.Write("| Palavra-Chave: ");
                string palavraChaveUtilizador = Console.ReadLine() ;
                Console.WriteLine("|_____________________________|");
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
            Console.WriteLine("");
            Console.WriteLine("======== Registrar =======");
            Console.WriteLine("|------------------------|");
            string nomeUtilizador;
            string enderecoUtilizador;
            string telefoneUtilizador;
            string palavraChaveUtilizador;
            string identificadorUtilizador;

            do
            {
                Console.Write("| Nome: ");
                nomeUtilizador = Console.ReadLine();
                Console.WriteLine("|------------------------|");
            } while (nomeUtilizador == null);

            do {
                Console.Write("| Endereço: ");
                enderecoUtilizador = Console.ReadLine();
                Console.WriteLine("|------------------------|");
            } while(enderecoUtilizador == null);


            do {
                Console.Write("| Telefone: ");
                telefoneUtilizador = Console.ReadLine();
                Console.WriteLine("|------------------------|");

            } while (telefoneUtilizador == null);

            do
            {
                Console.Write("| Palavra-Chave: ");
                palavraChaveUtilizador = Console.ReadLine();
                Console.WriteLine("|------------------------|");
            } while (palavraChaveUtilizador == null);

            do {
                Console.Write("| Funcionário: ");
                identificadorUtilizador = Console.ReadLine().ToUpper();
                Console.WriteLine("|------------------------|");
            } while(identificadorUtilizador == null);

            Console.WriteLine("|------------------------|");
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
                efetuarLogin(listaUtilizadores, Livros);
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
        public static void mostrarListaUtilizadores(List<Utilizadores> listaUtilizadores)
        {
            Console.WriteLine("");
            Console.WriteLine("===================== Lista de Utilizadores ===================");
            Console.WriteLine("|-------------------------------------------------------------|");
            foreach (Utilizadores usuario in listaUtilizadores)
            {
                Console.WriteLine("|-------------------------------------------------------------|");
                Console.WriteLine($"| Nome: {usuario.NomeUtilizador,-20} | Telefone: {usuario.TelefoneUtilizador,-20} |");
                Console.WriteLine("|-------------------------------------------------------------|");
            }
            Console.WriteLine("|______________________________________________________________|");
        }
    }
}
