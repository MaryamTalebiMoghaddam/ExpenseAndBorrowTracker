﻿using ExpenseAndBorrowTracker.Models;
using InAndOut.Data;
using InAndOut.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseAndBorrowTracker.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _db.Expenses;
            foreach (var obj in objList)
            {
                obj.ExpenseType = _db.ExpenseTypes.FirstOrDefault(u => u.Id == obj.ExpenseTypeId);
            }
            return View(objList);
            // return view();
        }
        //GET-Create
        public IActionResult Create()
        {
            //IEnumerable<SelectListItem> TypeDropDown=_db.ExpenseTypes.Select(i=> new SelectListItem { 
            //    Text=i.Name,
            //    Value=i.Id.ToString()
            //});
            //ViewBag.TypeDropDown=TypeDropDown;
            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expense(),
                TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            return View(expenseVM);
        }
        //Post-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseVM obj)
        {
            if (ModelState.IsValid)
            {
                //obj.ExpenseTypeId = 1;
                _db.Expenses.Add(obj.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get-Delete      
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        //Post-Delete
        [HttpDelete]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Expenses.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            _db.Expenses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        //Get-Update
        [HttpGet]
        public IActionResult Update(int? id)
        {
            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expense(),
                TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            if (id == null || id == 0)
            {
                return NotFound();
            }
            expenseVM.Expense = _db.Expenses.Find(id);

            if (expenseVM.Expense == null)
            {
                return NotFound();
            }
            return View(expenseVM);
        }


        // Post-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
