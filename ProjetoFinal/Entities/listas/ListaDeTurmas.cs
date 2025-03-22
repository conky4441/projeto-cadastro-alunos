
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
            Console.Write($"Código da turma: {turma.Codigo} - Etapa: {turma.EtapaEnsino} - " +
                $" Ano: {turma.Ano} - Alunos matriculados: {turma.Alunos.Count}\nQuantidade de vagas restantes: {turma.LimiteVagas}\n");

            var v = Turmas.Select(a => a.Alunos).First();
            if (v.Count == 0)
            {
                Console.WriteLine("----------------------------------------------------------------------");
                return;
            }
            Console.WriteLine("----------------------------------------------------------------------"); 
            Console.Write("Alunos: ");
            foreach (var a in v)
            {
                Console.WriteLine(a);

            }
            Console.WriteLine($"Alunos fora da idade esperada: {AlunosForaIdade()}");
            Console.WriteLine("----------------------------------------------------------------------");
        }

    }
    public int AlunosForaIdade()
    {
        int totalForaFaixa = 0;

        foreach (var turma in Turmas)
        {
            foreach (var aluno in turma.Alunos)
            {
                if (!IdadeEstaDentroDaFaixa(aluno.Idade, turma.EtapaEnsino))
                {
                    totalForaFaixa++;
                }
            }
        }

        return totalForaFaixa;
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




