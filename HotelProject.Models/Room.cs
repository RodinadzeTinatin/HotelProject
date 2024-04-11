using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Models
{
    public class Room
    {
        //[Key]
        //[Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Required]
        //[MaxLength(50)]
        public string Name { get; set; }

        //[Required]
        public bool IsFree { get; set; }

        //[Required]
        //[ForeignKey(nameof(Hotel))]
        public int HotelId { get; set; }

        //[Required]
        public double DailyPrice { get; set; }

        public Hotel Hotel { get; set; }
    }
}
