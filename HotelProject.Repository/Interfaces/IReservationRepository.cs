using HotelProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Repository.Interfaces
{
    public interface IReservationRepository
    {
        public Task<List<Reservation>> GetReservations();
        public Task<Reservation> GetSingleReservation(int id);
        public Task AddReservation(Reservation reservation);
        public Task UpdateReservation(Reservation reservation);
        public Task DeleteReservation(int id);
    }
}
