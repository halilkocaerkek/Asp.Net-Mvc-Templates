namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("event")]
    public partial class _event
    {
        public int id { get; set; }

        public int classid { get; set; }

        public string eventname { get; set; }

        public string starthour { get; set; }

        public string endhour { get; set; }

        public string eventtype { get; set; }

        public int roomid { get; set; }

        public string left { get; set; }

        public string top { get; set; }

        public string height { get; set; }

        public string color { get; set; }

        public string dateformat { get; set; }

        public string date { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] version { get; set; }

        public DateTimeOffset createdAt { get; set; }

        public DateTimeOffset updatedAt { get; set; }

        public bool deleted { get; set; }

        public int sinif_id { get; set; }

        public virtual room room { get; set; }

        public virtual sinif sinif { get; set; }
    }
}
