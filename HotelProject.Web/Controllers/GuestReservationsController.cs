using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using HotelProject.Repository.SQLClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelProject.Web.Controllers
{
    public class GuestReservationsController : Controller
    {
        private readonly IGuestReservationRepository _guestReservationRepository;
        private readonly IGuestRepository _guestRepository;


        public GuestReservationsController(IGuestReservationRepository guestReservationRepository, IGuestRepository guestRepository)
        {
            _guestReservationRepository = guestReservationRepository;
            _guestRepository = guestRepository;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _guestReservationRepository.GetGuestReservations();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var guests = await _guestRepository.GetGuests();
            ViewBag.GuestsForReservation = new SelectList(guests.Select(g => new { g.Id, FullName = $"{g.FirstName} {g.LastName}" }), "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GuestReservation model)
        {
            await _guestReservationRepository.AddGuestReservation(model);
            
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _guestReservationRepository.GetSingleGuestReservation(id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> DeletePOST(int id)
        {
            await _guestReservationRepository.DeleteGuestReservation(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var result = await _guestReservationRepository.GetSingleGuestReservation(id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> UpdatePOST(GuestReservation model)
        {
            await _guestReservationRepository.UpdateGuestReservation(model);
            return RedirectToAction("Index");
        }
    }
}
