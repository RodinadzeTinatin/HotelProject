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
        Task<List<Reservation>> GetAll();
        Task<Reservation> GetById(int id);
        Task<Reservation> GetByCheckInCheckOutDate(DateTime checkInDate, DateTime checkOutDate);
        Task Add(Reservation reservation);
        Task Update(Reservation reservation);
        Task Delete(int id);
    }
}
