using ProjetoFinal.Entities;
using ProjetoFinal.Entities.Models;
using ProjetoFinal.Entities.Models.enums.ValidationEnum;

namespace ProjetoFinal.Services;

class MetodosTurmas
{
    public static void CadastrarTurma()
    {
        string codigo, endereco;
        int ano, etapaEnsino, limiteVagas;

        while (true)
        {
            while (true)
            {
                Console.Write("Digite o código da turma: ");
                codigo = Console.ReadLine() ?? ""; // Evita valor nulo
                if (!Escola.ExisteCodigoTurma(codigo) && codigo != "")
                {
                    break;
                }
                else if (Escola.ExisteCodigoTurma(codigo))
                {
                    Console.WriteLine("Erro: Código da turma já cadastrado!");
                }
                Console.WriteLine("O valor de código não pode ser vazio, digite novamente.");
            }

            Console.Write("Digite o endereço do aluno: ");
            endereco = Console.ReadLine() ?? ""; // Evita valor nulo
            while (true)
            {
                Console.Write("Digite a idade do aluno: [Idade Máxima: 18] ");
                bool v = int.TryParse(Console.ReadLine(), out etapaEnsino); // Evita valor nulo
                if(v && etapaEnsino > 0 && etapaEnsino < 18)
                {
                    break;
                }
                Console.WriteLine("Idade inválida, verifique e digite novamente.");

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
                Console.Write("Digite o limite de vagas: ");
                if (int.TryParse(Console.ReadLine(), out limiteVagas) && limiteVagas != 0)
                {
                    break;
                }
                Console.WriteLine("Limite de vagas inválido.");
            }
            if (endereco != "")
            {
                break;
            }
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("O valor de nenhum dado pode ser vazio. Por favor verifique os dados e digite novamente.\n");
        }

        Escola.AddTurma(new Turma(codigo, CreatorEnum.Create(etapaEnsino), ano, limiteVagas));
        Console.WriteLine("Turma cadastrada com sucesso.");
    }
    public static void MatricularAluno()
    {
        Console.Write("Digite o nome do aluno: ");
        string nome = Console.ReadLine() ?? "";

        Console.Write("Digite o código da turma: ");
        string codigo = Console.ReadLine() ?? "";

        if (!Escola.ExisteNome(nome))
        {
            Console.WriteLine("Erro: Aluno não encontrado.");
            return;
        }

        if (!Escola.ExisteCodigoTurma(codigo))
        {
            Console.WriteLine("Erro: Turma não encontrada.");
            return;
        }

        Console.WriteLine($"Aluno {nome} matriculado na turma {codigo}.");
    }
    public static void ExibirTurmas()
    {
        Console.WriteLine("\nLista de Turmas:");
        Escola.ExibirTurmas();
        Console.ReadKey();
    }
}
