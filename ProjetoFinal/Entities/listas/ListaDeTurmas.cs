using ProjetoFinal.Entities.models.enums;
using ProjetoFinal.Entities.Models;

namespace ProjetoFinal.Entities.listas;

public class ListaDeTurmas
{
    public List<Turma> Turmas { get; set; } = new List<Turma>();
    public ListaDeTurmas()
    {

    }

    //Métodos das Turmas
    public void AddTurma(Turma turma)
    {
        Turmas.Add(turma);
    }
    public bool ExisteCodigoTurma(string codigo)
    {
        return !string.IsNullOrEmpty(codigo) && Turmas.Exists(t => t.Codigo == codigo);
    }
    public void AdicionarPorCodigo(int cpf, string codigo)
    {
        var aluno = ListaDeAlunos.RetornarAluno(cpf);
        var turma = Turmas.FirstOrDefault(t => t.Codigo == codigo);
        if (aluno != null)
        {
            if (turma is not null)
            {
                turma.AdicionarAlunoATurma(aluno);
                turma.LimiteVagas--;
                return;
            }
            Console.WriteLine("Turma não encontrada.");
        }
        Console.WriteLine("Houve um problema com os dados fornecidos.");

    }
    public void ExibirTurmas()
    {
        foreach (var turma in Turmas)
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.Write($"{turma} - Alunos matriculados: {turma.Alunos.Count}\nQuantidade de vagas restantes: {turma.LimiteVagas}\n");

            if (turma.Alunos.Count == 0)
            {
                continue;
            }

            var alunos = string.Join(", ", turma.Alunos.Select(a => a.Nome));
            Console.WriteLine($"Alunos: {alunos}");           
        }       
    }
    public void AlunosForaIdade(AnoTurmaEnum etapaEnsino)
    {
        int totalForaFaixa = 0;

        foreach (var turma in Turmas)
        {
            if (turma.EtapaEnsino == etapaEnsino)
            {
                foreach (var aluno in turma.Alunos)
                {
                    if (!IdadeEstaDentroDaFaixa(aluno.Idade, etapaEnsino))
                    {
                        totalForaFaixa++;
                    }
                }
            }
        }

        if(totalForaFaixa == 0)
        {
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("Não há nenhum aluno nessa etapa de ensino que está fora da idade adequada.");
            Console.ReadKey();
            return;
        }
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine($"Número de alunos fora da idade adequada para essa etapa de ensino: {totalForaFaixa}");
        Console.ReadKey();

    }
    private bool IdadeEstaDentroDaFaixa(int idade, AnoTurmaEnum etapa)
    {
        return etapa switch
        {
            AnoTurmaEnum.infantil => idade > 0 && idade < 6,
            AnoTurmaEnum.fundamentalInicial => idade >= 6 && idade < 11,
            AnoTurmaEnum.fundamentalFinal => idade >= 11 && idade <= 14,
            AnoTurmaEnum.médio => idade >= 15 && idade <= 17,
            _ => false
        };
    }
}




