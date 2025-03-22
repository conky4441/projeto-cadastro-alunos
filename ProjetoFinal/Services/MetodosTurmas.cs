using ProjetoFinal.Entities.listas;
using ProjetoFinal.Entities.models.enums;
using ProjetoFinal.Entities.Models;

namespace ProjetoFinal.Services;

public static class MetodosTurmas
{
    public static void CriarTurma(ListaDeTurmas turma)
    {
        string codigo;
        int ano, etapaEnsino, limiteVagas;

        Console.WriteLine("-----------------------------------------");
        while (true)
        {
            Console.Write("Digite o código da turma: ");
            while (true)
            {
                codigo = Console.ReadLine() ?? ""; // Evita valor nulo
                if (!turma.ExisteCodigoTurma(codigo) && codigo != "")
                {
                    break;
                }
                else if (turma.ExisteCodigoTurma(codigo))
                {
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("Erro: Código da turma já cadastrado!");
                    Console.WriteLine("-----------------------------------------");
                    Console.Write("Digite novamente: ");
                }
                else
                {
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("O valor de código não pode ser vazio");
                    Console.WriteLine("-----------------------------------------");
                    Console.Write("Digite novamente: ");
                }
            }

            while (true)
            {
                Console.Write("Digite o ano da turma: ");
                if (int.TryParse(Console.ReadLine(), out ano) && ano != 0)
                {
                    break;
                }
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Ano inválido.");
                Console.WriteLine("-----------------------------------------");
            }
            while (true)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Etapa de ensino");
                Console.WriteLine("[1] - Infantil\n[2] - Fundamental-Inicial\n[3] - Fundamental-Final\n[4] - Médio");
                Console.WriteLine("-----------------------------------------");
                Console.Write("Opção: ");
                if (int.TryParse(Console.ReadLine(), out etapaEnsino) && etapaEnsino >= 1 && etapaEnsino < 5)
                {
                    break;
                }
                Console.WriteLine("Etapa inválida, digite novamente.");

            }
            Console.WriteLine("-----------------------------------------");
            while (true)
            {
                Console.Write("Digite o limite de vagas: ");
                if (int.TryParse(Console.ReadLine(), out limiteVagas) && limiteVagas > 0 && limiteVagas != 0)
                {
                    break;
                }
                Console.WriteLine("Limite de vagas inválido.");
                Console.WriteLine("-----------------------------------------");
            }
            break;
        }

        Console.WriteLine("-----------------------------------------");
        turma.AddTurma(new Turma(codigo, (AnoTurmaEnum)etapaEnsino, ano, limiteVagas));
        Console.WriteLine("Turma cadastrada com sucesso.");
        Console.ReadKey();
    }
    public static void MatricularAluno(ListaDeTurmas turmaMatricula)
    {
        int cpf;
        string codigo;
        var turma = turmaMatricula;

        Console.WriteLine("-----------------------------------------");
        Console.Write("Digite o CPF do aluno: ");
        while (!int.TryParse(Console.ReadLine(), out cpf) || !ListaDeAlunos.ExisteCPF(cpf))
        {
            while (true)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Houve um problema com o número digitado.\n[1] - Digitar outro\n[2] - Cancelar a Ação");
                Console.WriteLine("-----------------------------------------");
                Console.Write("Opção: ");
                int.TryParse(Console.ReadLine() ?? "3", out int sair);

                if (sair == 1)
                {
                    break;
                }
                if (sair == 2)
                {
                    return;
                }
            }
            Console.Write("Digite o CPF novamente: ");
        }
        while (true)
        {
            Console.WriteLine("-----------------------------------------");
            Console.Write("Digite o código da turma: ");
            codigo = Console.ReadLine() ?? "";
            if (turma.ExisteCodigoTurma(codigo))
            {
                var vagas = turma.Turmas.Where(a => a.Codigo == codigo).Select(a => a.LimiteVagas).FirstOrDefault();
                if (vagas != 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("A turma já está cheia.");
                    Console.WriteLine("-----------------------------------------");
                    Console.ReadKey();
                    return;
                }
            }
            while (true)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Houve um problema com o número digitado\n[1] - Digitar novamente\n[2] - Cancelar a Ação");
                Console.WriteLine("-----------------------------------------");
                Console.Write("Opção: ");
                if (int.TryParse(Console.ReadLine(), out int sair))
                {
                    if (sair == 1)
                    {
                        break;
                    }
                    if (sair == 2)
                    {
                        return;
                    }

                }
            }
        }
        turma.AdicionarPorCodigo(cpf, codigo);
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("Aluno matriculado na turma com sucesso.");
        Console.ReadKey();

    }

    public static void ExibirTurmas(ListaDeTurmas turmaDeAlunos)
    {
        if (turmaDeAlunos.Turmas.Count == 0)
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Não há nenhuma turma cadastrada.");
            Console.WriteLine("-----------------------------------------");
            Console.ReadKey();
            return;
        }
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Lista de Turmas:");
        turmaDeAlunos.ExibirTurmas();
        Console.ReadKey();
    }


}
