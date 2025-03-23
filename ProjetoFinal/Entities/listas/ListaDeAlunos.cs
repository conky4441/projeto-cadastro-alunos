using ProjetoFinal.Entities.models;



namespace ProjetoFinal.Entities.listas;
public static class ListaDeAlunos //É uma lista encadeada
{
    private static Aluno? Inicio = null;
    private static int Tamanho;


    //Métodos pedidos pelo projeto
    public static void IncluirNoFim(Aluno aluno)
    {
        Aluno novoAluno = aluno;

        if (Inicio == null)
        {
            Inicio = novoAluno;
            Tamanho++;
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine($"Aluno {aluno.Nome} adicionado ao final da lista.");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.ReadKey();
            return;
        }

        Aluno alunoAtual = Inicio;
        while (alunoAtual.Proximo != null)
        {
            alunoAtual = alunoAtual.Proximo;
        }
        alunoAtual.Proximo = novoAluno;
        Tamanho++;
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine($"Aluno {aluno.Nome} adicionado ao final da lista.");
        Console.WriteLine("----------------------------------------------------------------------");
        Console.ReadKey();

    }
    public static void IncluirNoInicio(Aluno aluno)
    {
        Aluno novoAluno = aluno;

        if (Inicio == null)
        {
            Inicio = novoAluno;
            Tamanho++;
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine($"Aluno {aluno.Nome} adicionado ao início da lista.");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.ReadKey();
            return;
        }
        Aluno alunoInicial = Inicio;
        Inicio = novoAluno;
        Inicio.Proximo = alunoInicial;
        Tamanho++;
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine($"Aluno {aluno.Nome} adicionado ao início da lista.");
        Console.WriteLine("----------------------------------------------------------------------");
        Console.ReadKey();
    }
    public static void RemoverDoFim()
    {
        if (Inicio == null)
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Não há nenhum aluno cadastrado.");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.ReadKey();
            return;
        }
        else if (Inicio.Proximo == null)
        {
            Inicio = null;
            Tamanho--;
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Último aluno da lista removido com sucesso.");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.ReadKey();
            return;
        }

        var alunoAtual = Inicio;
        while (alunoAtual.Proximo != null && alunoAtual.Proximo.Proximo != null)
        {
            alunoAtual = alunoAtual.Proximo;
        }
        alunoAtual.Proximo = null; //Torno a referencia do penultimo nula, excluindo assim o ultimo objeto
        Tamanho--;
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Último aluno da lista removido com sucesso.");
        Console.WriteLine("----------------------------------------------------------------------");
        Console.ReadKey();

    }
    public static void QuantidadeAlunos()
    {
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine($"Quantidade de alunos: {Tamanho}");
        Console.WriteLine("----------------------------------------------------------------------");
        Console.ReadKey();
    }
    public static void OrdernarAlunos()
    {
        if (Inicio == null || Inicio.Proximo == null) return;

        bool trocou;
        do
        {
            trocou = false;
            Aluno? anterior = null;
            Aluno? atual = Inicio;
            Aluno? proximo = Inicio?.Proximo;

            while (proximo != null)
            {
                if (string.Compare(atual!.Nome, proximo.Nome, StringComparison.OrdinalIgnoreCase) > 0)
                {
                    // Troca os nós ajustando os ponteiros
                    if (anterior == null)
                    {
                        // Mudando o início da lista
                        Inicio = proximo;
                    }
                    else
                    {
                        anterior.Proximo = proximo;
                    }

                    atual.Proximo = proximo.Proximo;
                    proximo.Proximo = atual;

                    // Atualiza os ponteiros para continuar o loop corretamente
                    trocou = true;
                    anterior = proximo;
                    proximo = atual.Proximo;
                }
                else
                {

                    anterior = atual;
                    atual = proximo;
                    proximo = proximo.Proximo;
                }
            }
        } while (trocou);
    }
    public static void ExibirAlunos()
    {

        var aluno = Inicio;
        if (aluno == null)
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Não há nenhum aluno cadastrado.");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.ReadKey();
            return;
        }
        Console.WriteLine("----------------------------------------------------------------------");
        while (aluno != null)
        {
            Console.WriteLine(aluno);
            aluno = aluno.Proximo;
        }
        Console.WriteLine("----------------------------------------------------------------------");
        Console.ReadKey();

    }
    public static void Get(int index)
    {
        var atual = Inicio;
        int contador = 0;

        while (atual != null)
        {
            if (contador == index)
            {
                Console.WriteLine(atual);
                Console.ReadKey();
                return;
            }
            atual = atual.Proximo;
            contador++;
        }
        Console.WriteLine("Não há nenhum aluno nessa posição da lista");
        Console.WriteLine("----------------------------------------------------------------------");
        Console.ReadKey();
        return;

    }
    public static Aluno? RetornarAluno(int cpf)
    {
        var aluno = Inicio;
        while (aluno != null)
        {
            if (aluno.Cpf == cpf)
            {
                var copiaAluno = aluno;
                return copiaAluno;
            }
            aluno = aluno.Proximo;

        }
        return null;
    }

    //Métodos para verificação de cadastro
    public static bool ExisteCPF(int cpf)
    {

        Aluno alunoAtual = Inicio;
        while (alunoAtual != null)
        {
            if (alunoAtual.Cpf == cpf)
            {
                return true;
            }
            alunoAtual = alunoAtual.Proximo;
        }
        return false;


    }
}


