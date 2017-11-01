namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("traininglog")]
    public partial class traininglog
    {
        public int id { get; set; }

        public int schoolid { get; set; }

        public int classid { get; set; }

        public int studentid { get; set; }

        public int student2id { get; set; }

        public int teacherid { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] version { get; set; }

        public DateTimeOffset createdAt { get; set; }

        public DateTimeOffset updatedAt { get; set; }

        public bool deleted { get; set; }
    }
}
