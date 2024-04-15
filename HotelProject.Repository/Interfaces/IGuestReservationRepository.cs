using HotelProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Repository.Interfaces
{
    public interface IGuestReservationRepository
    {
        public Task<List<GuestReservation>> GetGuestReservations();
        public Task<GuestReservation> GetSingleGuestReservation(int id);
        public Task AddGuestReservation(GuestReservation guestReservation);
        public Task UpdateGuestReservation(GuestReservation guestReservation);
        public Task DeleteGuestReservation(int id);
    }
}
