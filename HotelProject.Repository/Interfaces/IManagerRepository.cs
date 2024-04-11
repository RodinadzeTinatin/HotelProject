using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.Exceptions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Repository.Interfaces
{
    public interface IManagerRepository
    {
        public Task<List<Manager>> GetManagers();
        public Task<Manager> GetSingleManager(int id);
        public  Task AddManager(Manager manager);
        public  Task UpdateManager(Manager manager);
        public Task DeleteManager(int id);
    }
}
