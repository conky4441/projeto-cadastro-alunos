
namespace ProjetoFinal.Models;
using System;
public class Aluno
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Endereco { get; set; }
    public DateTime DataNascimento { get; set; }

    public Aluno(string nome, string cpf, string endereco, DateTime dataNascimento)
    {
        Nome = nome ?? throw new ArgumentNullException(nameof(nome));
        Cpf = cpf ?? throw new ArgumentNullException(nameof(cpf));
        Endereco = endereco ?? throw new ArgumentNullException(nameof(endereco));
        DataNascimento = dataNascimento;
    }
}

