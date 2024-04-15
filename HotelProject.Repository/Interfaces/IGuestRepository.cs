using HotelProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Repository.Interfaces
{
    public interface IGuestRepository
    {
        public Task<List<Guest>> GetGuests();
        public Task<Guest> GetSingleGuest(int id);
        public Task AddGuest(Guest guest);
        public Task UpdateGuest(Guest guest);
        public Task DeleteGuest(int id);
    }
}
