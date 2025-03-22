using ProjetoFinal.Entities.listas;
using ProjetoFinal.Entities.models;


namespace ProjetoFinal.Services;
public static class MetodosAlunos 
{
    public static void CadastrarAluno()
    {
        string nome, endereco;
        int cpf;
        DateTime dataNascimento;
        Console.WriteLine("----------------------------------------------------------------------");
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
                if (!ListaDeAlunos.ExisteCPF(cpf) && cpf != 0 && resp)
                {
                    break;
                }

                else if (ListaDeAlunos.ExisteCPF(cpf))
                {
                    Console.WriteLine("Erro: CPF já cadastrado! Digite novamente: ");
                }

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
            Console.Write("Digite a data de nascimento (dd/mm/aaaa) [Máximo de 18 anos]: ");
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out dataNascimento))
                {
                    if (DateTime.Now.Year - dataNascimento.Year < 19 && dataNascimento < DateTime.Now)
                    {
                        break;
                    }
                }
                Console.WriteLine("----------------------------------------------------------------------");
                Console.Write("Houve um erro, verifique se digitou a data corretamente.");
                Console.ReadKey();
                Console.WriteLine();
                Console.Write("Digite novamente (dd/mm/aaaa): ");
            }
            var aluno = new Aluno(nome, cpf, endereco, dataNascimento);
            Console.WriteLine("----------------------------------------------------------------------");
            while (true)
            {
                Console.WriteLine("Como deseja incluir o aluno na lista de alunos?");
                Console.WriteLine("1 - [Incluir no inicio da lista]\n2 - [Incluir no final da lista]");
                Console.WriteLine("----------------------------------------------------------------------");
                Console.Write("Opção: ");
                if (int.TryParse(Console.ReadLine(), out int opcao))
                {
                    if (opcao == 1)
                    {
                        ListaDeAlunos.IncluirNoInicio(aluno);
                        break;
                    }
                    else if (opcao == 2)
                    {
                        ListaDeAlunos.IncluirNoFim(aluno);
                        break;
                    }

                }
                Console.WriteLine("Opção inválida\n. Digite novamente: ");
            }

            break;
        }


    }
    public static void ProcurarCpf()
    {
        Console.WriteLine("----------------------------------------------------------------------");
        while (true)
        {
            Console.Write("Digite o CPF do aluno: ");
            if (int.TryParse(Console.ReadLine(), out int cpf))
            {
                if (ListaDeAlunos.ExisteCPF(cpf))
                {
                    Console.WriteLine("----------------------------------------------------------------------");
                    Console.WriteLine(ListaDeAlunos.RetornarAluno(cpf));
                    Console.WriteLine("----------------------------------------------------------------------");
                    Console.ReadKey();
                    return;
                }
            }
            while (true)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Houve um problema com o CPF digitado.\n");
                Console.WriteLine("Deseja digitar outro número ou retornar ao Menu?");
                Console.WriteLine("[1] - Digitar outro número\n[2] - Retornar ao Menu");
                Console.WriteLine("-----------------------------------------------");
                Console.Write("Opção: ");
                if (int.TryParse(Console.ReadLine(), out int menu))
                {
                    if (menu == 1)
                    {
                        break;
                    }
                    if (menu == 2)
                    {
                        return;
                    }
                }
            }
        }
    }

    public static void IndiceLista()
    {
        while (true)
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.Write("Índice da lista: ");
            if (int.TryParse(Console.ReadLine(), out int indice))
            {
                Console.WriteLine("----------------------------------------------------------------------");
                ListaDeAlunos.Get(indice);
                Console.WriteLine("----------------------------------------------------------------------");
                return;

            }
            while (true)
            {
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("Houve um problema com o Indice fornecido.");
                Console.WriteLine("Deseja digitar outro número ou voltar ao Menu?");
                Console.WriteLine("[1] - Digitar outro número\n[2] - Retornar ao Menu");
                Console.WriteLine("----------------------------------------------------------------------");
                Console.Write("Opção: ");
                if (int.TryParse(Console.ReadLine(), out int menu))
                {
                    if (menu == 1)
                    {
                        break;
                    }
                    if (menu == 2)
                    {
                        return;
                    }
                }
            }
        }
    }
}