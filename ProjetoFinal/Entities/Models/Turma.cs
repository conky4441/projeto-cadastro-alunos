using ProjetoFinal.Entities.models;
using ProjetoFinal.Entities.models.enums;

namespace ProjetoFinal.Entities.Models;
public class Turma
{
    public string Codigo { get; set; }
    public AnoTurmaEnum EtapaEnsino { get; set; }
    public int Ano { get; set; }
    public int TotalDeVagas { get; set; }
    public int LimiteVagas { get; set; }
    public List<Aluno> Alunos { get; set; } = new List<Aluno>();

    public Turma(string codigo, Enum etapaEnsino, int ano, int totalDeVagas)
    {
        Codigo = codigo;
        EtapaEnsino = (AnoTurmaEnum)etapaEnsino;
        Ano = ano;
        TotalDeVagas = totalDeVagas;
        LimiteVagas = TotalDeVagas;
    }

    public void AdicionarAlunoATurma(Aluno aluno)
    {
        Alunos.Add(aluno);
    }
    public override string ToString()
    {
        return $"Turma de código: {Codigo} - Etapa de ensino: {EtapaEnsino} - Ano: {Ano} - Limite de vagas: {TotalDeVagas}";
    }
    public override bool Equals(object? obj)
    {
        return obj is Turma turma &&
               Codigo == turma.Codigo;
    }
}