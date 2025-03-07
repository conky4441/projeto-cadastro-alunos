using ProjetoFinal.Entities.Models.enums;
using System;

namespace ProjetoFinal.Entities.Models;
public class Turma
{
    public string Codigo { get; set; }
    public AnoTurmaEnum EtapaEnsino { get; set; }
    public int Ano { get; set; }
    public int LimiteVagas { get; set; }

    public Turma(string codigo, Enum etapaEnsino, int ano, int limiteVagas)
    {
        Codigo = codigo ?? throw new ArgumentNullException(nameof(codigo));
        EtapaEnsino = (AnoTurmaEnum)etapaEnsino;
        Ano = ano;
        LimiteVagas = limiteVagas;
    }
}