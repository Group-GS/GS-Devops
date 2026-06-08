using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AgroSpace.Api.Models
{
    [Table("Sensor")]
    public class Sensor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_sensor")]
        public int IdSensor { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("tipo_sensor")]
        public string TipoSensor { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("status")]
        public string Status { get; set; }

        [Required]
        [Column("id_local")]
        public int IdLocal { get; set; }

        // Propriedade de Navegação
        [JsonIgnore]
        [ForeignKey("IdLocal")]
        public Local Local { get; set; }
    }
}