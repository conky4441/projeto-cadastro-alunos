using ProjetoFinal.Entities.Models;

namespace ProjetoFinal.Entities;
public static class Escola
{
    public static List<Aluno> Alunos = new List<Aluno>();
    private static List<Turma> Turmas = new List<Turma>();

    public static void IncluirNoFim(Aluno aluno)
    {
        Alunos.Add(aluno);
    }

    public static bool ExisteCPF(int cpf)
    {
        return cpf != 0 && Alunos.Exists(a => a.Cpf == cpf);
    }

    public static bool ExisteNome(string nome)
    {
        return !string.IsNullOrEmpty(nome) && Alunos.Exists(a => a.Nome == nome);
    }

    public static void ExibirAlunos()
    {
        foreach (var aluno in Alunos)
        {
            Console.WriteLine($"Nome: {aluno.Nome}, CPF: {aluno.Cpf}");
        }
    }

    //Métodos das Turmas

    public static void AddTurma(Turma turma)
    {
        Turmas.Add(turma);
    }

    public static bool ExisteCodigoTurma(string codigo)
    {
        return !string.IsNullOrEmpty(codigo) && Turmas.Exists(t => t.Codigo == codigo);
    }

    public static void ExibirTurmas()
    {
        foreach (var turma in Turmas)
        {
            Console.WriteLine($"Código: {turma.Codigo}, Etapa: {turma.EtapaEnsino}, Ano: {turma.Ano}");
        }
    }
}
