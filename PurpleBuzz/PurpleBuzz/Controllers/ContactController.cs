﻿using FrontToBack.Data;
using FrontToBack.Models;
using FrontToBack.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            Contact contacts = await _context.Contacts.FirstOrDefaultAsync();

            ContactVM model = new()
            {
                Contact = contacts,
            };

            return View(model);
        }
    }
}
