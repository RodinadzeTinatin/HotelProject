using HotelProject.Models;
using HotelProject.Repository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Tests
{
    public class RoomShould
    {
        private readonly RoomRepository _roomRepository;
        public RoomShould()
        {
            _roomRepository = new();
        }

        [Fact]
        public async void Return_All_Rooms_From_Database()
        {
            var result = await _roomRepository.GetRooms();
        }
        [Fact]
        public async void Return_Single_Room_From_Database()
        {
            var result = await _roomRepository.GetSingleRoom(1);
        }
        [Fact]
        public async void Add_New_Room_In_Database()
        {
            Room newRoom = new()
            {
                Name = "მეხუთე ოთახი",
                IsFree = true,
                HotelId = 2,
                DailyPrice = 10
            };

            await _roomRepository.AddRoom(newRoom);
        }



        [Fact]
        public async void Update_Room_In_Database()
        {
            Room newRoom = new()
            {
                Id = 6,
                Name = "first room",
                IsFree = false,
                HotelId = 2,
                DailyPrice = 10
                
            };

            await _roomRepository.UpdateRoom(newRoom);
        }


        [Fact]
        public async void Delete_Room_From_Database()
        {
            await _roomRepository.DeleteRoom(6);
        }
    }
}
