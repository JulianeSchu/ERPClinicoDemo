using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.API.Domain.Models
{
    [Table("convenios")]
    public class Convenio
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; } = string.Empty;
        public string? Cnpj { get; set; }
        public bool Ativo { get; set; } = true;

        // Relacionamento com pacientes
        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
        public ICollection<PacienteConvenio> PacienteConvenios { get; set; } = new List<PacienteConvenio>();

    }
}
