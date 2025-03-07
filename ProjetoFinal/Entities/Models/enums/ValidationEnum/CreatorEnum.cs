

namespace ProjetoFinal.Entities.Models.enums.ValidationEnum;

static class CreatorEnum
{
    static Enum Create(int idade)
    {

        if (idade > 0 && idade < 6)
        {
            return AnoTurmaEnum.infantil;
        }
        else if (idade >= 6 && idade < 11)
        {
            return AnoTurmaEnum.fundamentalInicial;
        }
        else if (idade >= 11 && idade < 15)
        {
            return AnoTurmaEnum.fundamentalFinal;
        }
        else if (idade >= 15 && idade < 19)
        {
            return AnoTurmaEnum.médio;
        }


    }


}

