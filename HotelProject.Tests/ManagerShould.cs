using HotelProject.Models;
using HotelProject.Repository;
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
        public async void Add_New_Manager_In_Database()
        {
            Manager newManager = new()
            {
                FirstName = "ჯეინ",
                LastName = "ოსტინი"
            };

            await _managerRepository.AddManager(newManager);
        }

        [Fact]
        public async void Update_Manager_In_Database()
        {
            Manager newManager = new()
            {
                Id = 5,
                FirstName = "ჩარლზ",
                LastName = "დიკენსი"
            };

            await _managerRepository.UpdateManager(newManager);
        }

        [Fact]
        public async void Delete_Manager_From_Database()
        {

            await _managerRepository.DeleteManager(7);
        }
    }
}
