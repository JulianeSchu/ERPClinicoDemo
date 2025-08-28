using System.ComponentModel;

namespace ERP.API.Enums;

public enum TipoConsulta
{
    [Description("Consulta Inicial")]
    ConsultaInicial = 1,
    [Description("Retorno")]
    Retorno = 2,
    [Description("Exame")]
    Exame = 3,
    [Description("Teleconsulta")]
    Teleconsulta = 4,
    [Description("Avaliação")]
    Avaliacao = 5,
    [Description("Procedimento")]
    Procedimento = 6
}
