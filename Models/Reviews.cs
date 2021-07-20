using System;
using System.ComponentModel.DataAnnotations;

namespace MvcFirst.Models
{
    public class Review
    {
        // [Key]
        // [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CamaOriginKey { get; set; }
        public string CamaOriginParcelNo { get; set; }

        [DataType(DataType.Date)]
        public DateTime AssignedAt { get; set; }

        [DataType(DataType.Date)]
        public DateTime CompletedAt { get; set; }
        public string State { get; set; }
        public string County { get; set; }

        //Foreign Key
        public int CamaSystemId { get; set; }
        public CamaSystem CamaSystem { get; set; }
    }
}