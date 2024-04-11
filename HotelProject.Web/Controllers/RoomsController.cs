﻿using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomRepository _roomRepository;
       
        public RoomsController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _roomRepository.GetRooms();
            return View(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Room model)
        {
            await _roomRepository.AddRoom(model);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _roomRepository.GetSingleRoom(id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> DeletePOST(int id)
        {
            await _roomRepository.DeleteRoom(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await _roomRepository.GetSingleRoom(id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> UpdatePOST(Room model)
        {
            await _roomRepository.UpdateRoom(model);
            return RedirectToAction("Index");
        }
    }
}
