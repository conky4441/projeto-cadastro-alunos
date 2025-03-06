using ProjetoFinal.Models;
using ProjetoFinal.Services.Listas;

namespace Services;
public static class MetodosAlunos
{
    public static void CadastrarAluno()
    {
        string nome, cpf, endereco;
        DateTime dataNascimento;
        while (true)
        {

            Console.Write("Digite o nome do aluno: ");
            nome = Console.ReadLine() ?? "";
            //if (!ListaDeAlunos.ExisteNome(nome))
            //{
            //    break;
            //}
            //Console.WriteLine("Erro: Nome já cadastrado!");  
            // Não exclui o método, porém pessoas podem ter o mesmo nome, então nao acho que faça sentido

            while (true)
            {
                Console.Write("Digite o CPF do aluno: ");
                cpf = Console.ReadLine() ?? ""; // Evita valor nulo
                if (!ListaDeAlunos.ExisteCPF(cpf))
                {
                    break;
                }
                Console.WriteLine("Erro: CPF já cadastrado! Digite novamente: ");
            }
            Console.Write("Digite o endereço do aluno: ");
            endereco = Console.ReadLine() ?? ""; // Evita valor nulo
            Console.Write("Digite a data de nascimento (dd/mm/aaaa): ");
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out dataNascimento))
                {
                    break;
                }
                Console.WriteLine("Data inválida, digite novamente.");
            }

            if (nome != "" && cpf != "" && endereco != "")
            {
                break;
            }
            Console.WriteLine("O valor de nenhum dado pode ser vazio. Por favor revise os dados e digite novamente.");
        }

        ListaDeAlunos.IncluirNoFim(new Aluno(nome, cpf, endereco, dataNascimento));
        Console.WriteLine("Aluno cadastrado com sucesso.");
    }
    public static void ExibirAlunos()
    {
        Console.WriteLine("\nLista de Alunos:");
        ListaDeAlunos.Exibir();
        Console.ReadKey();
    }
    public static void ExibirTurmas()
    {
        Console.WriteLine("\nLista de Turmas:");
        ListaDeTurmas.Exibir();
        Console.ReadKey();
    }
}