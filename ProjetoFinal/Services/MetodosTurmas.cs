using Models;
using ProjetoFinal.Services.Listas;
namespace ProjetoFinal.Services;

class MetodosTurmas
{
    public static void CadastrarTurma()
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

        ListaDeTurmas.Add(new Turma(codigo, etapaEnsino, ano, limiteVagas));
        Console.WriteLine("Turma cadastrada com sucesso.");
    }
    public static void MatricularAluno()
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
    public static void ExibirTurmas()
    {
        Console.WriteLine("\nLista de Turmas:");
        ListaDeTurmas.Exibir();
    }
}
