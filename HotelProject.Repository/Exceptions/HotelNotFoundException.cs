using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Repository.Exceptions
{
    public class HotelNotFoundException : Exception
    {
        public HotelNotFoundException() : base("Hotel not found")
        {
        }
    }
}
