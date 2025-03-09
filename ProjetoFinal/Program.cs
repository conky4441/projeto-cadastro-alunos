using ProjetoFinal.Services;
using ProjetoFinal.Entities.repositories;

namespace ProjetoFinal;
public class Program
{
    public static void Main()
    {
        int opcao, menu;
        var lista = new ListaDeAlunos();

        do
        {
            Console.WriteLine("\nSistema Escolar");
            Console.WriteLine("1. Opções Referentes a Alunos");
            Console.WriteLine("2. Opções Referentes a Turmas");
            Console.WriteLine("3. Sair do Programa");
            if (!int.TryParse(Console.ReadLine(), out menu) || menu < 1 || menu > 3)
            {
                Console.WriteLine("Opção inválida.");
                continue;
            }
            if (menu == 1)
            {
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("1. Cadastrar Aluno");
                    Console.WriteLine("2. Matricular Aluno em Turma");
                    Console.WriteLine("3. Exibir Alunos");
                    Console.WriteLine("4. Quantidade de Alunos");
                    Console.WriteLine("5. Voltar ao Menu Anterior");
                    Console.Write("Escolha uma opção: ");

                    if (!int.TryParse(Console.ReadLine(), out opcao))
                    {
                        Console.WriteLine("Opção inválisda.");
                        continue;
                    }

                    switch (opcao)
                    {
                        case 1:
                            MetodosAlunos.CadastrarAluno();
                            break;
                        case 2:
                            MetodosTurmas.MatricularAluno();
                            break;
                        case 3:
                            lista.ExibirAlunos();
                            break;
                        case 4:
                            lista.QuantidadeAlunos();
                            break;
                        case 5:
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                } while (opcao != 5);
            }
            else if (menu == 2)
            {
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("1. Cadastrar Turma");
                    Console.WriteLine("2. Matricular Aluno em Turma");
                    Console.WriteLine("3. Exibir Turmas");
                    Console.WriteLine("4. Quantidade de Alunos");
                    Console.WriteLine("5. Voltar ao Menu Anterior");
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
                            MetodosTurmas.MatricularAluno();
                            break;
                        case 3:
                            lista.ExibirAlunos();
                            break;
                        case 4:
                            MetodosTurmas.ExibirTurmas();
                            break;
                        case 5:
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                } while (opcao != 5);
            }

        } while (menu != 3);

        Console.WriteLine("Muito obrigado por utilizar nosso serviço");
    }
}




