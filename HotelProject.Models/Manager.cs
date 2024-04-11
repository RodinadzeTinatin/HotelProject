using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models
{
    public class Manager
    {
        //[Key]
        //[Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Required]
        //[MaxLength(50)]
        public string FirstName { get; set; }

        //[Required]
        //[MaxLength(50)]
        public string LastName { get; set; }

        //[Required]
        //[ForeignKey(nameof(Hotel))]
        public int HotelId { get; set; }
        //Navigation Property 
        public Hotel Hotel { get; set; }

    }
}
