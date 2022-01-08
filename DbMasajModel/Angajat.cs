namespace DbMasajModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Angajat")]
    public partial class Angajat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Angajat()
        {
            Programares = new HashSet<Programare>();
            Salas = new HashSet<Sala>();
        }

        public int AngajatId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nume { get; set; }

        [Required]
        [StringLength(50)]
        public string Prenume { get; set; }

        [Required]
        [StringLength(50)]
        public string NrTelefon { get; set; }

        public int Salariu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Programare> Programares { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sala> Salas { get; set; }
    }
}
