namespace ProjetoFinal.Entities.models;
using System;

public class Aluno() : IComparable<Aluno>
{
    public string Nome { get; set; } = "";
    public int Cpf { get; set; }
    public string Endereco { get; set; } = "";
    public DateTime DataNascimento { get; set; }
    public int Idade { get; set; } = 0;

    public Aluno? Proximo;

    public Aluno(string nome, int cpf, string endereco, DateTime dataNascimento) : this()
    {
        Nome = nome;
        Cpf = cpf;
        Endereco = endereco;
        DataNascimento = dataNascimento;

        var hoje = DateTime.Now;
        int idade = hoje.Year - DataNascimento.Year;
        if (hoje < DataNascimento.AddYears(idade))
        {
            idade--;
        }
        Idade = idade;
        Proximo = null;
    }

    public override string ToString()
    {
        var hoje = DateTime.Now;
        Idade = hoje.Year - DataNascimento.Year;
        return $"Nome: {Nome}, CPF: {Cpf} Idade: {Idade} anos, Endereço: {Endereco}";
    }

    public int CompareTo(Aluno? obj)
    {
        if (obj is not null)
        {
            var resp = Nome.CompareTo(obj.Nome);
            return resp;
        }
        return 0;
    }
}

