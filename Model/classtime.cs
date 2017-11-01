namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("classtime")]
    public partial class classtime
    {
        public int id { get; set; }

        [StringLength(10)]
        public string day { get; set; }

        [StringLength(50)]
        public string room { get; set; }

        [StringLength(50)]
        public string start { get; set; }

        public int classid { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] version { get; set; }

        public DateTimeOffset createdAt { get; set; }

        public DateTimeOffset updatedAt { get; set; }

        public bool deleted { get; set; }

        public int sinif_id { get; set; }

        public virtual sinif sinif { get; set; }
    }
}
