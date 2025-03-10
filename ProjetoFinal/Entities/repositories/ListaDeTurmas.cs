
using ProjetoFinal.Entities.Models;


namespace ProjetoFinal.Entities.repositories;

class ListaDeTurmas
{
    public List<Turma> Turmas = new List<Turma>();

    //Métodos das Turmas

    public void AddTurma(Turma turma)
    {
        Turmas.Add(turma);
    }
    public bool ExisteCodigoTurma(string codigo)
    {
        return !string.IsNullOrEmpty(codigo) && Turmas.Exists(t => t.Codigo == codigo);
    }


    public bool EstaCheia()
    {
        var a = Turmas.FirstOrDefault(a => a.LimiteVagas == 0);
        return a != null;
    }

    public void AdicionarPorCodigo(int cpf, string codigo)
    {
        var listaDeAlunos = new ListaDeAlunos();
        var aluno = listaDeAlunos.RetornarAluno(cpf);

        if (aluno is not null)
        {
            var turma = Turmas.FirstOrDefault(t => t.Codigo == codigo);
            if (turma is not null)
            {
                turma.AdicionarAlunoATurma(aluno);
                turma.LimiteVagas--;
            }
        }

    }
    public void ExibirTurmas()
    {
        foreach (var turma in Turmas)
        {
            Console.WriteLine($"Código: {turma.Codigo}, Etapa: {turma.EtapaEnsino}," +
                $" Ano: {turma.Ano}, Alunos matriculados:{Turmas.Count} Quantidade de vagas restantes: {turma.LimiteVagas}");
        }
    }
}


