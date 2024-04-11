using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models
{
    public class Hotel
    {
        //[Key]
        //[Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        //[Required]
        //[MaxLength(50)]
        public string Name { get; set; }
        //[Required]
        public double Rating { get; set; }

        //[Required]
        //[MaxLength(50)]
        public string Country { get; set; }

        //[Required]
        //[MaxLength(50)]
        public string City { get; set; }    

        //[Required]
        //[MaxLength(50)]
        public string PhyisicalAddress { get; set; }

        //Navigation Property for one-to-one connection
        public Manager Manager { get; set; }

        public ICollection<Room> Rooms { get; set; }

    }
}
