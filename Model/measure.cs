namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("measure")]
    public partial class measure
    {
        public int id { get; set; }

        public int studentId { get; set; }

        public int type { get; set; }

        public int value { get; set; }

        public int createdBy { get; set; }

        public DateTimeOffset createdAt { get; set; }

        public virtual student student { get; set; }

        public virtual measuretype measuretype { get; set; }
    }
}
