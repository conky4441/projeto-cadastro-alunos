namespace ProjetoFinal.Entities.Models;
using System;
public class Aluno
{
    public string Nome { get; set; }
    public int Cpf { get; set; }
    public string Endereco { get; set; }
    public DateTime DataNascimento { get; set; }

    public Aluno(string nome, int cpf, string endereco, DateTime dataNascimento)
    {
        Nome = nome ?? throw new ArgumentNullException(nameof(nome));
        Cpf = cpf;
        Endereco = endereco ?? throw new ArgumentNullException(nameof(endereco));
        DataNascimento = dataNascimento;
    }
}

