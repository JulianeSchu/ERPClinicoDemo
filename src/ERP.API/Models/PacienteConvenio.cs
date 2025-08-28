using ERP.API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.API.Domain.Models;

public class PacienteConvenio
{
    public Guid PacienteId { get; set; }
    public Paciente Paciente { get; set; }

    public Guid ConvenioId { get; set; }
    public Convenio Convenio { get; set; }

    public DateTime DataVinculo { get; set; }
}
