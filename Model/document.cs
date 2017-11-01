namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("document")]
    public class document
    {

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public int? pageCount { get; set; }

         public string image { get; set; }

        [StringLength(50)]
        public string issuer { get; set; }

        public DateTime? issuedate { get; set; }

        public DateTime? validdate { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] version { get; set; }

        public DateTimeOffset createdAt { get; set; }

        public DateTimeOffset updatedAt { get; set; }

        public bool deleted { get; set; }

        public virtual documenttype documenttype { get; set; }

        public virtual teacher teacher { get; set; }

        public virtual student student { get; set; }
    }
}