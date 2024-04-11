using HotelProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Repository.Interfaces
{
    public interface IHotelRepository
    {
        public Task<List<Hotel>> GetHotels();
        public Task<List<Hotel>> GetHotelsWithoutManager();
        public  Task<Hotel> GetSingleHotel(int id);
        public Task AddHotel(Hotel hotel);
        public Task UpdateHotel(Hotel hotel);
        public Task DeleteHotel(int id);

    }
}
