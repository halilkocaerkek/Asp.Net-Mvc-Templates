namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("teacher")]
    public partial class teacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public teacher()
        {
            classteacher = new HashSet<classteacher>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string surname { get; set; }

        [Required]
        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(50)]
        public string mobilePhone { get; set; }

        public DateTime? birthDate { get; set; }

        [StringLength(50)]
        public string birthPlace { get; set; }

        public DateTime? workBegin { get; set; }

        public DateTime? workEnd { get; set; }

        public string image { get; set; }

        [StringLength(250)]
        public string imageUrl { get; set; }

        [StringLength(250)]
        public string thumbnailUrl { get; set; }

        [StringLength(250)]
        public string address { get; set; }

        [StringLength(50)]
        public string town { get; set; }
        [StringLength(50)]
        public string city { get; set; }
        [StringLength(50)]
        public string state { get; set; }
       
        public string postcode { get; set; }

 
        [DataType(DataType.EmailAddress, ErrorMessage = "EPosta adresi hatalý.")]
        public string email { get; set; }

        [StringLength(10)]
        public string gender { get; set; }

        public bool? schooladmin { get; set; }

        public bool? classadmin { get; set; }

        public bool? isSchoolAdmin { get; set; }

        public bool? isAcceptPayment { get; set; }

        public bool? isViewer { get; set; }

        [StringLength(20)]
        public string tckn { get; set; }

        [StringLength(20)]
        public string sgk { get; set; }

        [StringLength(20)]
        public string licence { get; set; }

        public DateTime? vizeBaslangic { get; set; }
        public DateTime? vizeBitis { get; set; }

        public int schoolid { get; set; }

        public int montlySalary { get; set; }
        public int hourlySalary { get; set; }
        public int percentSalary { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] version { get; set; }

        public DateTimeOffset createdAt { get; set; }

        public DateTimeOffset updatedAt { get; set; }

        public bool deleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<classteacher> classteacher { get; set; }

        public virtual school school { get; set; }
    }
}
