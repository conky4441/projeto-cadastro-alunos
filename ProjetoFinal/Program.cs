namespace ProjetoIntegrador
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int opcao;

            do
            {
                Console.WriteLine("\nSistema Escolar");
                Console.WriteLine("1. Cadastrar Aluno");
                Console.WriteLine("2. Cadastrar Turma");
                Console.WriteLine("3. Matricular Aluno em Turma");
                Console.WriteLine("4. Exibir Alunos");
                Console.WriteLine("5. Exibir Turmas");
                Console.WriteLine("6. Sair");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida.");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        CadastrarAluno();
                        break;
                    case 2:
                        CadastrarTurma();
                        break;
                    case 3:
                        MatricularAluno();
                        break;
                    case 4:
                        ExibirAlunos();
                        break;
                    case 5:
                        ExibirTurmas();
                        break;
                    case 6:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            } while (opcao != 6);
        }

        private static void CadastrarAluno()
        {
            string nome, cpf, endereco;
            DateTime dataNascimento;
            while (true)
            {
                Console.Write("Digite o nome do aluno: ");
                nome = Console.ReadLine() ?? "";
                Console.Write("Digite o CPF do aluno: ");
                cpf = Console.ReadLine() ?? ""; // Evita valor nulo
                Console.Write("Digite o endereço do aluno: ");
                endereco = Console.ReadLine() ?? ""; // Evita valor nulo
                Console.Write("Digite a data de nascimento (dd/mm/aaaa): ");

                while (true)
                {
                    if (DateTime.TryParse(Console.ReadLine(), out dataNascimento))
                    {
                        break;
                    }
                    Console.WriteLine("Data inválida, digite novamente.");
                    Console.ReadKey();
                }

                if (nome != "" && cpf != "" && endereco != "")
                {
                    break;
                }
                Console.WriteLine("O valor de nenhum dado pode ser vazio. Por favor digite novamente.");
            }

            if (ListaDeAlunos.ExisteCPF(cpf))
            {
                Console.WriteLine("Erro: CPF já cadastrado!");
                return;
            }

            if (ListaDeAlunos.ExisteNome(nome))
            {
                Console.WriteLine("Erro: Nome já cadastrado!");
                return;
            }

            Aluno aluno = new Aluno(nome, cpf, endereco, dataNascimento);
            ListaDeAlunos.IncluirNoFim(aluno);
            Console.WriteLine("Aluno cadastrado com sucesso.");
        }

        private static void CadastrarTurma()
        {
            Console.Write("Digite o código da turma: ");
            string codigo = Console.ReadLine() ?? ""; // Evita valor nulo
            Console.Write("Digite a etapa de ensino: ");
            string etapaEnsino = Console.ReadLine() ?? ""; // Evita valor nulo
            Console.Write("Digite o ano da turma: ");

            if (!int.TryParse(Console.ReadLine(), out int ano))
            {
                Console.WriteLine("Ano inválido.");
                return;
            }

            Console.Write("Digite o limite de vagas: ");
            if (!int.TryParse(Console.ReadLine(), out int limiteVagas))
            {
                Console.WriteLine("Limite de vagas inválido.");
                return;
            }

            if (ListaDeTurmas.ExisteCodigo(codigo))
            {
                Console.WriteLine("Erro: Código da turma já cadastrado!");
                return;
            }

            Turma turma = new Turma(codigo, etapaEnsino, ano, limiteVagas);
            ListaDeTurmas.Add(turma);
            Console.WriteLine("Turma cadastrada com sucesso.");
        }

        private static void MatricularAluno()
        {
            Console.Write("Digite o nome do aluno: ");
            string nome = Console.ReadLine() ?? "";

            Console.Write("Digite o código da turma: ");
            string codigo = Console.ReadLine() ?? "";

            if (!ListaDeAlunos.ExisteNome(nome))
            {
                Console.WriteLine("Erro: Aluno não encontrado.");
                return;
            }

            if (!ListaDeTurmas.ExisteCodigo(codigo))
            {
                Console.WriteLine("Erro: Turma não encontrada.");
                return;
            }

            Console.WriteLine($"Aluno {nome} matriculado na turma {codigo}.");
        }

        private static void ExibirAlunos()
        {
            Console.WriteLine("\nLista de Alunos:");
            ListaDeAlunos.Exibir();
        }

        private static void ExibirTurmas()
        {
            Console.WriteLine("\nLista de Turmas:");
            ListaDeTurmas.Exibir();
        }
    }

    public class Aluno
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }

        public Aluno(string nome, string cpf, string endereco, DateTime dataNascimento)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Cpf = cpf ?? throw new ArgumentNullException(nameof(cpf));
            Endereco = endereco ?? throw new ArgumentNullException(nameof(endereco));
            DataNascimento = dataNascimento;
        }
    }

    public class Turma
    {
        public string Codigo { get; set; }
        public string EtapaEnsino { get; set; }
        public int Ano { get; set; }
        public int LimiteVagas { get; set; }

        public Turma(string codigo, string etapaEnsino, int ano, int limiteVagas)
        {
            Codigo = codigo ?? throw new ArgumentNullException(nameof(codigo));
            EtapaEnsino = etapaEnsino ?? throw new ArgumentNullException(nameof(etapaEnsino));
            Ano = ano;
            LimiteVagas = limiteVagas;
        }
    }

    public static class ListaDeAlunos
    {
        private static List<Aluno> alunos = new List<Aluno>();

        public static void IncluirNoFim(Aluno aluno)
        {
            alunos.Add(aluno);
        }

        public static bool ExisteCPF(string cpf)
        {
            return !string.IsNullOrEmpty(cpf) && alunos.Exists(a => a.Cpf == cpf);
        }

        public static bool ExisteNome(string nome)
        {
            return !string.IsNullOrEmpty(nome) && alunos.Exists(a => a.Nome == nome);
        }

        public static void Exibir()
        {
            foreach (var aluno in alunos)
            {
                Console.WriteLine($"Nome: {aluno.Nome}, CPF: {aluno.Cpf}");
            }
        }
    }

    public static class ListaDeTurmas
    {
        private static List<Turma> turmas = new List<Turma>();

        public static void Add(Turma turma)
        {
            turmas.Add(turma);
        }

        public static bool ExisteCodigo(string codigo)
        {
            return !string.IsNullOrEmpty(codigo) && turmas.Exists(t => t.Codigo == codigo);
        }

        public static void Exibir()
        {
            foreach (var turma in turmas)
            {
                Console.WriteLine($"Código: {turma.Codigo}, Etapa: {turma.EtapaEnsino}, Ano: {turma.Ano}");
            }
        }
    }
}
