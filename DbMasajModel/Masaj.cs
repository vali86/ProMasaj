namespace DbMasajModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Masaj")]
    public partial class Masaj
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Masaj()
        {
            Programares = new HashSet<Programare>();
        }

        public int MasajId { get; set; }

        [Required]
        [StringLength(50)]
        public string Denumire { get; set; }

        [Required]
        [StringLength(50)]
        public string Pret { get; set; }

        public int Durata { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Programare> Programares { get; set; }
    }
}
