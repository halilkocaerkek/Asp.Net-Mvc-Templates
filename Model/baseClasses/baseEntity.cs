 

namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
 
    public partial class baseEntity
    {

        [ScaffoldColumn(false)]
  
        public int id { get; set; }


        [ScaffoldColumn (false)]
        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] version { get; set; }

        [ScaffoldColumn(false)]
        public DateTimeOffset createdAt { get; set; }

        [ScaffoldColumn(false)]
        public DateTimeOffset updatedAt { get; set; }

        [ScaffoldColumn(false)]
        public bool deleted { get; set; }
 
    }
}
