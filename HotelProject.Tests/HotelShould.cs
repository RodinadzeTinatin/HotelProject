using HotelProject.Models;
using HotelProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Tests
{
    public class HotelShould
    {
        private readonly HotelRepository _hotelRepository;

        public HotelShould()
        {
            _hotelRepository = new();
        }

        [Fact]
        public async void Return_All_Hotels_From_Database()
        {
            var result = await _hotelRepository.GetHotels();
        }


        [Fact]
        public async void Add_New_Hotel_In_Database()
        {
            Hotel newHotel = new()
            {
                Name = "new hotel",
                Rating = 9,
                Country = "Georgia",
                City ="Shekvetili",
                PhysicalAddress = "raghac adgili",
                ManagerId =8
            };

            await _hotelRepository.AddHotel(newHotel);
        }
        
        [Fact]
        public async void Update_Hotel_In_Database()
        {
            Hotel newHotel = new()
            {
                Id =8,
                Name = "New Hootel",
                Rating = 9,
                Country = "Georgia",
                City = "Shekvetili",
                PhysicalAddress = "raghac adgili",
                ManagerId = 8
            };

            await _hotelRepository.UpdateHotels(newHotel);
        }
        [Fact]
        public async void Delete_Hotel_From_Database()
        {

            await _hotelRepository.DeleteHotel(8);
        }
    }
}
