﻿using Microsoft.AspNetCore.Mvc;
using System;

namespace ExpenseAndBorrowTracker.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
            //string todaysDate = DateTime.Now.ToShortDateString();
            //return Ok(todaysDate);
        }
        public IActionResult Details(int id)
        {
            return Ok("You have entered Id= " + id);
        }
    }
}
