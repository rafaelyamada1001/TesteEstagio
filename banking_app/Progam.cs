using banking_app;
using System;

namespace BankingAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SistemaBancario sistema = new SistemaBancario();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== BankingApp ===");
                Console.WriteLine("1. Cadastrar Usuário");
                Console.WriteLine("2. Realizar Transferência");
                Console.WriteLine("3. Mostrar Saldo");
                Console.WriteLine("4. Adicionar Saldo");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarUsuario(sistema);
                        break;
                    case "2":
                        RealizarTransferencia(sistema);
                        break;
                    case "3":
                        MostrarSaldo(sistema);
                        break;
                    case "4":
                        AdicionarSaldo(sistema);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void CadastrarUsuario(SistemaBancario sistema)
        {
            Console.Clear();
            Console.WriteLine("=== Cadastrar Usuário ===");
            Console.Write("Nome completo: ");
            string nome = Console.ReadLine();
            Console.Write("CPF (ou CNPJ para lojistas): ");
            string cpf = Console.ReadLine();
            Console.Write("E-mail: ");
            string email = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();
            Console.Write("Tipo de usuário (1- Comum, 2- Lojista): ");
            string tipo = Console.ReadLine();

            try
            {
                if (tipo == "1")
                {
                    UsuarioComum usuario = new UsuarioComum(nome, cpf, email, senha);
                    sistema.CadastrarUsuario(usuario);
                }
                else if (tipo == "2")
                {
                    Lojista lojista = new Lojista(nome, cpf, email, senha);
                    sistema.CadastrarUsuario(lojista);
                }
                else
                {
                    Console.WriteLine("Tipo de usuário inválido!");
                    return;
                }

                Console.WriteLine("Usuário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        static void RealizarTransferencia(SistemaBancario sistema)
        {
            Console.Clear();
            Console.WriteLine("=== Realizar Transferência ===");
            Console.Write("E-mail do remetente: ");
            string emailRemetente = Console.ReadLine();
            Console.Write("Senha do remetente: ");
            string senhaRemetente = Console.ReadLine();

            Usuario remetente;
            try
            {
                remetente = sistema.Login(emailRemetente, senhaRemetente);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                return;
            }

            if (remetente is Lojista)
            {
                Console.WriteLine("Lojistas não podem realizar transferências!");
                return;
            }

            Console.Write("E-mail do destinatário: ");
            string emailDestinatario = Console.ReadLine();
            Usuario destinatario = sistema.BuscarUsuarioPorEmail(emailDestinatario);
            if (destinatario == null)
            {
                Console.WriteLine("Destinatário não encontrado!");
                return;
            }

            Console.Write("Valor da transferência: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal valor))
            {
                Console.WriteLine("Valor inválido!");
                return;
            }

            try
            {
                ((UsuarioComum)remetente).EnviarTransferencia(destinatario, valor);
                Console.WriteLine("Transferência realizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        static void MostrarSaldo(SistemaBancario sistema)
        {
            Console.Clear();
            Console.WriteLine("=== Mostrar Saldo ===");
            Console.Write("E-mail do usuário: ");
            string email = Console.ReadLine();
            Console.Write("Senha do usuário: ");
            string senha = Console.ReadLine();

            try
            {
                Usuario usuario = sistema.Login(email, senha);
                sistema.MostrarSaldo(usuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        static void AdicionarSaldo(SistemaBancario sistema)
        {
            Console.Clear();
            Console.WriteLine("=== Adicionar Saldo ===");
            Console.Write("E-mail do usuário: ");
            string email = Console.ReadLine();
            Console.Write("Senha do usuário: ");
            string senha = Console.ReadLine();

            try
            {
                Usuario usuario = sistema.Login(email, senha);

                Console.Write("Valor a ser adicionado: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal valor))
                {
                    Console.WriteLine("Valor inválido!");
                    return;
                }

                sistema.AdicionarSaldo(usuario, valor);
                Console.WriteLine("Saldo adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
