using ProjetoFinal.Entities.repositories;
using ProjetoFinal.Entities.models.enums;
using ProjetoFinal.Entities.Models;

namespace ProjetoFinal.Services;

public static class MetodosTurmas
{
    public static void CriarTurma(ListaDeTurmas turma)
    {
        string codigo;
        int ano, etapaEnsino, limiteVagas;


        while (true)
        {
            while (true)
            {
                Console.Write("Digite o código da turma: ");
                codigo = Console.ReadLine() ?? ""; // Evita valor nulo
                if (!turma.ExisteCodigoTurma(codigo) && codigo != "")
                {
                    break;
                }
                else if (turma.ExisteCodigoTurma(codigo))
                {
                    Console.WriteLine("Erro: Código da turma já cadastrado!");
                }
                Console.WriteLine("O valor de código não pode ser vazio, digite novamente.");
            }

            while (true)
            {
                Console.Write("Digite o ano da turma: ");
                if (int.TryParse(Console.ReadLine(), out ano) && ano != 0)
                {
                    break;
                }

                Console.WriteLine("Ano inválido. Digite novamente.");
            }
            while (true)
            {
                Console.WriteLine("Digite a etapa de ensino: ");
                Console.WriteLine("[1] - Infantil // [2] - Fundamental-Inicial // [3] - Fundamental-Final // [4] - Médio");

                if (int.TryParse(Console.ReadLine(), out etapaEnsino) && etapaEnsino >= 1 && etapaEnsino < 4)
                {
                    break;
                }
                Console.WriteLine("Etapa inválida, digite novamente.");

            }
            while (true)
            {
                Console.Write("Digite o limite de vagas: ");
                if (int.TryParse(Console.ReadLine(), out limiteVagas) && limiteVagas > 0 && limiteVagas != 0)
                {
                    break;
                }
                Console.WriteLine("Limite de vagas inválido.");
            }
            break;
        }

        Console.WriteLine("--------------------------------------------------------------------------------------");
        turma.AddTurma(new Turma(codigo, (AnoTurmaEnum)etapaEnsino, ano, limiteVagas));
        Console.WriteLine("Turma cadastrada com sucesso.");
    }
    public static void MatricularAluno(ListaDeTurmas turmaMatricula)
    {
        int cpf;
        string codigo;
        var turma = turmaMatricula;

        while (true)
        {
            while (true)
            {
                Console.Write("Digite o CPF do aluno: ");
                if (int.TryParse(Console.ReadLine(), out cpf)) //Verificando se é um número
                {
                    if (ListaDeAlunos.ExisteCPF(cpf))
                    {
                        break;
                    }
                }
                while (true)
                {
                    Console.WriteLine("Houve um problema com o número digitado.\nDseja digitar outro? [1] ou Cancelar a Ação? [2]");
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

            while (true)
            {
                Console.Write("Digite o código da turma: ");
                codigo = Console.ReadLine() ?? "";
                if (turma.ExisteCodigoTurma(codigo))
                {
                    var vagas = turma.Turmas.Where(a => a.Codigo == codigo).Select(a => a.LimiteVagas).FirstOrDefault();
                    if (vagas != 0)
                    {
                        break;
                    }
                }
                while (true)
                {
                    Console.WriteLine("Houve um problema com o número digitado.\nDseja digitar outro? [1] ou Cancelar a Ação? [2]");
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
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Aluno matriculado na turma com sucesso.");
            Console.ReadKey();
            break;
        }
    }
    public static void ExibirTurmas(ListaDeTurmas turmaDeAlunos)
    {
        if (turmaDeAlunos.Turmas.Count == 0)
        {
            Console.WriteLine("Não há nenhuma turma cadastrada.");
            Console.ReadKey();
            return;
        }
        Console.WriteLine("\nLista de Turmas:");
        turmaDeAlunos.ExibirTurmas();
        Console.ReadKey();
    }


}
