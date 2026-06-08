using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroSpace.Api.Models
{
    [Table("Locais")] // Nome exato da tabela no Oracle
    public class Local
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_local")]
        public int IdLocal { get; set; }

        [Required(ErrorMessage = "O nome do local é obrigatório.")]
        [MaxLength(50)]
        [Column("nome")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("cidade")]
        public string Cidade { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O estado deve ter exatamente 2 caracteres.")]
        [Column("estado")]
        public string Estado { get; set; }

        [Required]
        [Column("id_bioma")]
        public int IdBioma { get; set; }

        // Propriedade de Navegação
        public ICollection<Sensor> Sensores { get; set; } = new List<Sensor>();
    }
}