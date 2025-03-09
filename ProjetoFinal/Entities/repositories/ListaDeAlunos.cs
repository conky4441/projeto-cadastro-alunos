﻿using ProjetoFinal.Entities.models;



namespace ProjetoFinal.Entities.repositories;
public class ListaDeAlunos //É uma lista encadeada
{
    private Aluno? Inicio;
    private int Tamanho;
    public ListaDeAlunos()
    {
        Inicio = null;
    }
    public ListaDeAlunos(Aluno aluno)
    {
        Inicio = aluno;
        Tamanho++;
    }

    //Métodos pedidos pelo projeto
    public void IncluirNoFim(Aluno aluno)
    {
        Aluno novoAluno = aluno;

        if (Inicio == null)
        {
            Inicio = novoAluno;
            Tamanho++;
            Console.WriteLine("Aluno adicionado ao final da lista.");
            return;
        }

        Aluno alunoAtual = Inicio;
        while (alunoAtual.Proximo != null)
        {
            alunoAtual = alunoAtual.Proximo;
        }
        alunoAtual.Proximo = novoAluno;
        Tamanho++;
        Console.WriteLine("Aluno adicionado ao final da lista.");

    }
    public void IncluirNoInicio(Aluno aluno)
    {
        Aluno novoAluno = aluno;

        if (Inicio == null)
        {
            Inicio = novoAluno;
            Tamanho++;
            Console.WriteLine("Aluno adicionado ao inicio da lista.");
            return;
        }
        Aluno alunoInicial = Inicio;
        Inicio = novoAluno;
        Inicio.Proximo = alunoInicial;
        Tamanho++;
        Console.WriteLine("Aluno adicionado ao inicio da lista.");
    }
    public void RemoverDoFim()
    {

        if (Inicio == null)
        {
            Console.WriteLine("Não há nenhum aluno cadastrado.");
            return;
        }
        else if (Inicio.Proximo == null)
        {
            Inicio = null;
            Tamanho--;
            return;
        }

        var alunoAtual = Inicio;
        while (alunoAtual.Proximo != null && alunoAtual.Proximo.Proximo != null)
        //Precisei verificar se o segundo valor é null novamente pq o compilador é burro e ficou reclamando
        //Mas a primeira verificação do while é desnecessária, pois teria caído no else if
        {
            alunoAtual = alunoAtual.Proximo;
        }
        alunoAtual.Proximo = null; //Torno a referencia do penultimo nula, excluindo assim o ultimo objeto
        Tamanho--;

    }
    public void QuantidadeAlunos()
    {
        Console.WriteLine($"Quantidade de alunos: {Tamanho}");
        Console.ReadKey();
    }
    public void ExibirAlunos()
    {
        var aluno = Inicio;
        if (aluno == null)
        {
            Console.WriteLine("Não há nenhum aluno cadastrado.");
            Console.ReadKey();
            return;
        }
        
        while (aluno != null)
        {
            Console.WriteLine(aluno);
            aluno = aluno.Proximo;
        }

    }

    public Aluno? RetornarAluno(int cpf)
    {
        var aluno = Inicio;
        while (aluno.Proximo != null)
        {
            if(aluno.Cpf == cpf)
            {
                return aluno;
            }
            aluno = aluno.Proximo;
        }
        return null;
    }

    //Métodos para verificação de cadastro
    public bool ExisteCPF(int cpf)
    {
        if (Inicio == null)
        {
            return false;
        }
        if (Inicio.Cpf == cpf)
        {
            return true;
        }

        Aluno alunoAtual = Inicio;
        while (alunoAtual.Proximo != null)
        {
            if (alunoAtual.Cpf == cpf)
            {
                return true;
            }
            alunoAtual = alunoAtual.Proximo;
        }
        return false;


    }
    public bool ExisteNome(string nome)
    {
        if (Inicio == null)
        {
            return false;
        }
        if (Inicio.Nome == nome)
        {
            return true;
        }

        Aluno alunoAtual = Inicio;
        while (alunoAtual.Proximo != null)
        {
            if (alunoAtual.Nome == nome)
            {
                return true;
            }
            alunoAtual = alunoAtual.Proximo;
        }
        return false;
    }
}


