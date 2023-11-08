using System.Diagnostics.CodeAnalysis;

namespace desaTec.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public double Precio { get; set; }
    }

    public class ContractItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ContractId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [Required]
        public bool Enabled { get; set; }
        [Required]
        public bool Deleted { get; set; }
        [Required]
        [MaxLength(255)]
        public string CreatedBy { get; set; }
        public virtual Item Item { get; set; }

    }

    public class Contract
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string CourseCode { get; set; }
        [Required]
        public DateTime FechaAlta { get; set; }
        [Required]
        public int Estado { get; set; }
        public int CantidadEgresados { get; set; }
        public DateTime FechaEntrega { get; set; }
        [AllowNull]
        [StringLength(255)]
        public string? MedioEntrega { get; set; }
        [AllowNull]
        [StringLength(255)]
        public string? Vendedor { get; set; }
        [StringLength(255)]
        public string ColegioNivel { get; set; }
        [StringLength(255)]
        public string ColegioNombre { get; set; }
        public int ColegioCurso { get; set; }
        [StringLength(255)]
        public string ColegioLocalidad { get; set; }
        public decimal Comision { get; set; }
        public decimal Total { get; set; }
        public virtual ICollection<ContractItem> ContractItems { get; set; }
    }
}