
using ProjetoFinal.Entities.Models;



namespace ProjetoFinal.Entities.repositories;

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
            Console.Write($"Código: {turma.Codigo}, Etapa: {turma.EtapaEnsino}" +
                $" Ano: {turma.Ano}, Alunos matriculados: {turma.Alunos.Count}, Quantidade de vagas restantes: {turma.LimiteVagas}\n");

            var v = Turmas.Select(a => a.Alunos).First();
            if (v.Count == 0)
            {
                return;
            }
        
            //Console.WriteLine($"Alunos fora da idade esperada: {AlunosForaIdade()}");
            Console.Write("Alunos: ");
            foreach (var a in v)
            {
                Console.WriteLine(a);

            }
            Console.WriteLine("-------------------------------------");
        }

    }
    //public int AlunosForaIdade()
    //{
    //    var
    //}
}



