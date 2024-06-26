﻿using HotelProject.Models;
using HotelProject.Repository.SQLClient;
using Microsoft.Data.SqlClient;
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
        public async void Return_Hotels_Without_Managers()
        {
            var result = await _hotelRepository.GetHotelsWithoutManager();
        }

        [Fact]
        public async void Not_Add_New_Hotel_In_Database()
        {
            Hotel newHotel = new()
            {
                Name = "Radisson",
                Rating = 10.0,
                Country = "საქართველო",
                City = "თბილისი",
                PhyisicalAddress = "ვარდების მოედანი"
            };

            await Assert.ThrowsAsync<SqlException>(async () => await _hotelRepository.AddHotel(newHotel));
        }


        [Fact]
        public async void Add_New_Hotel_In_Database()
        {
            Hotel newHotel = new()
            {
                Name = "Radisson",
                Rating = 9.5,
                Country = "საქართველო",
                City = "თბილისი",
                PhyisicalAddress = "ვარდების მოედანი"
            };

            await _hotelRepository.AddHotel(newHotel);
        }

        [Fact]
        public async void Update_Hotel_In_Database()
        {
            Hotel newHotel = new()
            {
                Id = 1,
                Name = "პირველი სასტუმრო",
                Rating = 9.5,
                Country = "საქართველო",
                City = "თბილისი",
                PhyisicalAddress = "ვარდების მოედანი"
            };

            await _hotelRepository.UpdateHotel(newHotel);
        }


        [Fact]
        public async void Delete_Hotel_From_Database()
        {
            await _hotelRepository.DeleteHotel(4);
        }

        [Fact]
        public async void Get_Single_Hotel_From_Database()
        {
            await _hotelRepository.GetSingleHotel(1);
        }
    }
}
