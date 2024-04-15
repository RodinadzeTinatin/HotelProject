using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Repository
{
    public class ReservationRepositoryEF : IReservationRepository
    {
        public readonly ApplicationDbContext _context;

        public ReservationRepositoryEF(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddReservation(Reservation reservation)
        {
            if (reservation == null) 
            {
                throw new ArgumentNullException("Invalid argument passed");
            }

            _context.AddAsync(reservation);
            _context.SaveChanges();
        }

        public async Task DeleteReservation(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }

            var entity = await _context.Reservations.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new NullReferenceException("Entity not found");
            }

            _context.Reservations.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Reservation>> GetReservations()
        {
            var entities = await _context.Reservations.ToListAsync();

            if (entities == null)
            {
                throw new NullReferenceException("Entities not found");
            }

            return entities;
        }

        public async Task<Reservation> GetSingleReservation(int id)
        {
            var entity = await _context.Reservations.FirstOrDefaultAsync(x=>x.Id == id);
            if (entity == null)
            {
                throw new NullReferenceException("Entities not found");
            }

            return entity;
        }

        public async Task UpdateReservation(Reservation reservation)
        {
            if (reservation == null || reservation.Id <= 0)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }

            var entity = await _context.Reservations.FirstOrDefaultAsync(x => x.Id == reservation.Id);

            if (entity == null)
            {
                throw new NullReferenceException("Entity not found");
            }

            entity.CheckInDate = reservation.CheckInDate;
            entity.CheckOutDate = reservation.CheckOutDate;

            _context.Reservations.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
