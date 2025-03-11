using ProjetoFinal.Services;
using ProjetoFinal.Entities.repositories;

namespace ProjetoFinal;
public class Program
{
    public static void Main()
    {
        int opcao, menu;
        var turmas = new ListaDeTurmas();

        do
        {
            Console.WriteLine("\nSistema Escolar");
            Console.WriteLine("1. Opções Referentes a Alunos");
            Console.WriteLine("2. Opções Referentes a Turmas");
            Console.WriteLine("3. Sair do Programa");
            Console.WriteLine("----------------------------");
            Console.Write("Escolha uma opção: ");
            if (!int.TryParse(Console.ReadLine(), out menu) || menu < 1 || menu > 3)
            {
                Console.WriteLine("Opção inválida.");
                Console.ReadKey();
                continue;
            }
            if (menu == 1)
            {
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("1. Cadastrar Aluno");
                    Console.WriteLine("2. Encontrar aluno por CPF");
                    Console.WriteLine("3. Encontrar aluno em posição da lista [A lista inicia na posição: 0] ");
                    Console.WriteLine("4. Quantidade de alunos");
                    Console.WriteLine("5. Exibir alunos");
                    Console.WriteLine("6. Ordernar a lista de alunos por ordem alfabetica");
                    Console.WriteLine("7. Remover o último aluno da lista");
                    Console.WriteLine("8. Voltar ao Menu Anterior");
                    Console.WriteLine("----------------------------");
                    Console.Write("Escolha uma opção: ");

                    if (!int.TryParse(Console.ReadLine(), out opcao))
                    {
                        Console.WriteLine("Opção inválida.");
                        Console.ReadKey();
                        continue;
                    }

                    switch (opcao)
                    {
                        case 1:
                            MetodosAlunos.CadastrarAluno();
                            break;
                        case 2:
                            MetodosAlunos.ProcurarCpf();
                            break;
                        case 3:
                            MetodosAlunos.IndiceLista();
                            break;
                        case 4:
                            ListaDeAlunos.QuantidadeAlunos();
                            break;
                        case 5:
                            ListaDeAlunos.ExibirAlunos();
                            break;

                        case 6: //Ordernar os alunos por ordem alfabetica
                            ListaDeAlunos.OrdernarAlunos();
                            ListaDeAlunos.ExibirAlunos();
                            break;
                        case 7:
                            ListaDeAlunos.RemoverDoFim();
                            break;
                        case 8:
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            Console.ReadKey();
                            break;
                    }
                } while (opcao != 8);
            }
            else if (menu == 2)
            {
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("1. Cadastrar Turma");
                    Console.WriteLine("2. Matricular Aluno em Turma");
                    Console.WriteLine("3. Exibir Turmas");
                    Console.WriteLine("4. Voltar ao Menu Anterior");
                    Console.WriteLine("----------------------------");
                    Console.Write("Escolha uma opção: ");

                    if (!int.TryParse(Console.ReadLine(), out opcao))
                    {
                        Console.WriteLine("Opção inválida.");
                        Console.ReadKey();
                        continue;
                    }

                    switch (opcao)
                    {
                        case 1:
                            MetodosTurmas.CriarTurma(turmas);
                            break;
                        case 2:
                            MetodosTurmas.MatricularAluno(turmas);
                            break;
                        case 3:
                            MetodosTurmas.ExibirTurmas(turmas);
                            break;
                        case 4:
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            Console.ReadKey();
                            break;
                    }
                } while (opcao != 4);
            }

        } while (menu != 3);
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("Muito obrigado por utilizar nosso serviço!");
    }
}




