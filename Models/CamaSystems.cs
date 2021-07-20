using System;
using System.ComponentModel.DataAnnotations;

namespace MvcFirst.Models
{
    public class CamaSystem
    {
        // [Key]
        // [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOpt ion.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string PropertyKeyName { get; set; }

        public string OwnerKeyName { get; set; }

        public virtual Review Review {get;set;}
    }
}