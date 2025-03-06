using Models;
using ProjetoFinal.Models;
namespace ProjetoFinal.Services.Listas;
public static class ListaDeAlunos
{
    public static List<Aluno> alunos = new List<Aluno>();

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
