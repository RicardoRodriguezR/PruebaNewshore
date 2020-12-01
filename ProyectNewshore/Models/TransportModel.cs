using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectNewshore.Models
{
    public class TransportModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "FlightNumber")]
        public string FlightNumber { get; set; }

        public TransportModel()
        {

        }
    }
}