using HotelProject.Data;
using HotelProject.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Repository.Interfaces
{
    public interface IRoomRepository
    {
        public  Task<List<Room>> GetRooms();
        public Task<Room> GetSingleRoom(int id);
        public Task AddRoom(Room room);
        public Task UpdateRoom(Room room);
        public Task DeleteRoom(int id);
    }
}
