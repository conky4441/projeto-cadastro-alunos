﻿using System;

namespace ProjetoFinal.Entities.Models;
public class Turma
{
    public string Codigo { get; set; }
    public string EtapaEnsino { get; set; }
    public enum Ano { get; set; }
    public int LimiteVagas { get; set; }

    public Turma(string codigo, string etapaEnsino, enum ano, int limiteVagas)
    {
        Codigo = codigo ?? throw new ArgumentNullException(nameof(codigo));
        EtapaEnsino = etapaEnsino ?? throw new ArgumentNullException(nameof(etapaEnsino));
        Ano = ano;
        LimiteVagas = limiteVagas;
    }
}