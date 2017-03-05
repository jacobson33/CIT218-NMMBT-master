using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NMMBTrails.Models
{
    public class Trail
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Trail Name")]
        public string Name { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public string County { get; set; }
        public string URL { get; set; }
    }
}