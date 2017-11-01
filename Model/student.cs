namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("student")]
    public partial class student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public student()
        {
            classstudent = new HashSet<classstudent>();
            measure = new HashSet<measure>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string surname { get; set; }

        public string phone { get; set; }

        [StringLength(250)]
        public string imageUrl { get; set; }
        [StringLength(250)]
        public string thumbnailUrl { get; set; }

        public DateTime? birthDate { get; set; }

        [StringLength(50)]
        public string birthPlace { get; set; }

        [StringLength(50)]
        public string street { get; set; }

        [StringLength(250)]
        public string address { get; set; }

        [StringLength(50)]
        public string town { get; set; }
        [StringLength(50)]
        public string city { get; set; }
        [StringLength(50)]
        public string state { get; set; }

        public string postcode { get; set; }

        public string email { get; set; }

        public string gender { get; set; }

        public int schoolid { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] version { get; set; }

        public DateTimeOffset createdAt { get; set; }

        public DateTimeOffset updatedAt { get; set; }

        public bool deleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<classstudent> classstudent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<measure> measure { get; set; }

        public virtual school school { get; set; }
    }
}
