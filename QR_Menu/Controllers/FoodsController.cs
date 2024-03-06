using System;
using Microsoft.AspNetCore.Mvc;
using QR_Menu.Data;
using QR_Menu.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QR_Menu.Controllers
{
	public class FoodsController : Controller
	{
		private readonly ApplicationContext _context;

		public FoodsController(ApplicationContext context)
		{
			_context = context;
		}

		public ViewResult Index(bool admin = true)
		{
            IQueryable<Food> foods =  _context.Foods!;
            if (admin == true)
            {
                foods = _context.Foods!.Where(f => f.StateId == 1);
            }
            ViewData["admin"] = admin;
			return View(foods.ToList());
		}

		public ActionResult Details(int id)
		{
			Food? food = _context.Foods!.Where(f => f.Id == id).Include(f => f.State).FirstOrDefault();
			if (food == null)
			{
				return NotFound();
			}
			return View(food);
		}

		//GET
        public ViewResult Create()
        {
			//ViewData["StateId"] = new SelectList(_context.Set<State>(), "Id", "Name");
            ViewData["StateId"] = new SelectList(_context.States, "Id", "Name");
            return View();
        }

        //POST
        [HttpPost]	
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,"+ nameof(Food.Name) +",Description,Price,StateId")] Food food)
        {
            if (ModelState.IsValid)
            {
                _context.Add(food);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StateId"] = new SelectList(_context.States, "Id", "Name", food.StateId);
            return View(food);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int id)
        {
            Food? food = _context.Foods!.Find(id);
            if (food == null)
            {
                return NotFound();
            }
            ViewData["StateId"] = new SelectList(_context.States, "Id", "Name", food.StateId);
            return View(food);
        }

        // POST: Companies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,Name,Description,Price,StateId")] Food food)
        {
            if (ModelState.IsValid)
            {
                _context.Update(food);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StateId"] = new SelectList(_context.States, "Id", "Name", food.StateId);
            return View(food);
        }

        //Get
        public ActionResult Delete(int id)
		{
            Food? food = _context.Foods!.Where(f => f.Id == id).Include(f => f.State).FirstOrDefault();
            if (food == null)
            {
                return NotFound();
            }
            return View(food);
        }

        //Action name kulanılmasının sebebi get ile posttaki metod imzası aynı yani ikiside integer paramatre aldığı için
        //post edilirken delete ile gelirse imzalar bu fonksiyona girmesini sağlar
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult  DeleteConfirmed(int id)
        {
            Food? food = _context.Foods!.Find(id);
            if (food != null)
            {
                food.StateId = 0;
                _context.Foods.Update(food);
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

