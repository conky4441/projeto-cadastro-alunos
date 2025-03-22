using ProjetoFinal.Entities.listas;
using ProjetoFinal.Entities.models;
using ProjetoFinal.Entities.models.enums;

namespace ProjetoFinal.Entities.Models;
public class Turma
{
    public string Codigo { get; set; }
    public AnoTurmaEnum EtapaEnsino { get; set; }
    public int Ano { get; set; }
    public int LimiteVagas { get; set; }
    public List<Aluno> Alunos { get; set; } = new List<Aluno>();

    public Turma(string codigo, Enum etapaEnsino, int ano, int limiteVagas)
    {
        Codigo = codigo ?? throw new ArgumentNullException(nameof(codigo));
        EtapaEnsino = (AnoTurmaEnum)etapaEnsino;
        Ano = ano;
        LimiteVagas = limiteVagas;
    }

    public void AdicionarAlunoATurma(Aluno aluno)
    {
        Alunos.Add(aluno);
    }
  
}