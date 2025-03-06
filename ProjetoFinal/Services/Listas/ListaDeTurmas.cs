using Models;

namespace ProjetoFinal.Services.Listas;

    public static class ListaDeTurmas
    {
        private static List<Turma> turmas = new List<Turma>();

        public static void Add(Turma turma)
        {
            turmas.Add(turma);
        }

        public static bool ExisteCodigo(string codigo)
        {
            return !string.IsNullOrEmpty(codigo) && turmas.Exists(t => t.Codigo == codigo);
        }

        public static void Exibir()
        {
            foreach (var turma in turmas)
            {
                Console.WriteLine($"Código: {turma.Codigo}, Etapa: {turma.EtapaEnsino}, Ano: {turma.Ano}");
            }
        }
    }

