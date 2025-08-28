using System.ComponentModel;

namespace ERP.API.Domain.Enums;

public enum Status
{
    [Description("Ativo")]
    Ativo = 1,
    [Description("Inativo")]
    Inativo = 2,
    [Description("Agendado")]
    Agendado = 3,
    [Description("Cancelado")]
    Cancelado = 4,
    [Description("Realizado")]
    Realizado = 5,
}
