using HotelProject.Models;
using HotelProject.Repository;
using HotelProject.Repository.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Tests
{
    public class ManagerShould
    {
        private readonly ManagerRepository _managerRepository;
        public ManagerShould()
        {
            _managerRepository = new();
        }

        [Fact]
        public async void Return_All_Managers_From_Database()
        {
            var result = await _managerRepository.GetManagers();
        }

        [Fact]
        public async void Return_Hotels_Without_Managers()
        {
            var result = await _managerRepository.GetHotelsWithoutManagers();
        }

        [Fact]
        public async void Return_Single_Manager_From_Database()
        {
            var result = await _managerRepository.GetSingleManager(4);
        }


        [Fact]
        public async void Add_New_Manager_In_Database()
        {
            Manager newManager = new()
            {
                FirstName = "ლევანი",
                LastName = "სვანიძე",
                HotelId = 4,
            };

            await _managerRepository.AddManager(newManager);
        }

        [Fact]
        public async void Update_Manager_In_Database()
        {
            Manager manager = new()
            {
                Id = 5,
                FirstName = "ლუკა",
                LastName = "ცაგარიშვილი",
                HotelId = 4
            };

            await _managerRepository.UpdateManager(manager);
        }

        [Fact]
        public async void Delete_Manager_In_Database()
        {
            await _managerRepository.DeleteManager(4);
        }
    }
}
