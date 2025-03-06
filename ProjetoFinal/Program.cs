using Services;
using ProjetoFinal.Services;

namespace ProjetoFinal;
public class Program
{
    public static void Main()
    {
        int opcao;

        do
        {
            Console.WriteLine("\nSistema Escolar");
            Console.WriteLine("1. Cadastrar Aluno");
            Console.WriteLine("2. Cadastrar Turma");
            Console.WriteLine("3. Matricular Aluno em Turma");
            Console.WriteLine("4. Exibir Alunos");
            Console.WriteLine("5. Exibir Turmas");
            Console.WriteLine("6. Sair");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida.");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    MetodosAlunos.CadastrarAluno();
                    break;
                case 2:
                    MetodosTurmas.CadastrarTurma();
                    break;
                case 3:
                    MetodosTurmas.MatricularAluno();
                    break;
                case 4:
                    MetodosAlunos.ExibirAlunos();
                    break;
                case 5:
                    MetodosAlunos.ExibirTurmas();
                    break;
                case 6:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        } while (opcao != 6);
    }

}



