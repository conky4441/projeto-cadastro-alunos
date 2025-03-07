using ProjetoFinal.Entities;
using ProjetoFinal.Entities.Models;

namespace Services;
public static class MetodosAlunos
{
    public static void CadastrarAluno()
    {
        string nome, endereco;
        int cpf;
        DateTime dataNascimento;
        while (true)
        {
            while (true)
            {
                Console.Write("Digite o nome do aluno: ");
                nome = Console.ReadLine() ?? "";
                if (nome != "")
                {
                    break;
                }
                Console.WriteLine("O nome não pode ser vazio");
            }

            while (true)
            {
                Console.Write("Digite o CPF do aluno: ");
                // Evita valor nulo
                bool resp = int.TryParse(Console.ReadLine(), out cpf);
                if (!Escola.ExisteCPF(cpf) && cpf != 0 && resp)
                {
                    break;
                }

                else if (Escola.ExisteCPF(cpf))
                {
                    Console.WriteLine("Erro: CPF já cadastrado! Digite novamente: ");
                }      

                Console.WriteLine("Campo inválido, verifique os dados fornecidos e digite novamente.");
            }

            while (true)
            {
                Console.Write("Digite o endereço do aluno: ");
                endereco = Console.ReadLine() ?? ""; // Evita valor nulo
                if (endereco != "")
                {
                    break;
                }
                Console.WriteLine("O endereço não pode ser vazio, digite novamente.");
            }
            Console.Write("Digite a data de nascimento (dd/mm/aaaa): ");
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out dataNascimento))
                {
                    break;
                }
                Console.Write("Data inválida, digite novamente: ");
            }
            break;
        }

        Escola.IncluirNoFim(new Aluno(nome, cpf, endereco, dataNascimento));
        Console.WriteLine("Aluno cadastrado com sucesso.");
    }
    public static void ExibirAlunos()
    {
        Console.WriteLine("\nLista de Alunos:");
        Escola.ExibirAlunos();
        Console.ReadKey();
    }
}