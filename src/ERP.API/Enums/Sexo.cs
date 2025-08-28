using System.ComponentModel;

namespace ERP.API.Domain.Enums;

public enum Sexo
{
    [Description("Prefere não informar")]
    NaoInformado = 0,
    [Description("Masculino")]
    Masculino = 1,
    [Description("Feminino")]
    Feminino = 2,
    [Description("Outros")]
    Outro = 3
}
