using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FrontToBack.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CardController : Controller
    {
        private readonly AppDbContext _context;

        public CardController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Card> cards = _context.Cards.ToList();

            return View(cards);
        }

        public IActionResult Create(Card card)
        {
            if (!ModelState.IsValid)
                return View();

            _context.Cards.Add(card);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Read(int id)
        {
            Card? card = _context.Cards.FirstOrDefault(c => c.Id == id);
            if (card is null)
                return NotFound();

            return View(card);
        }

        public IActionResult Delete(int id)
        {
            Card? card = _context.Cards.FirstOrDefault(c => c.Id == id);
            
            if (card is null)
                return NotFound();

            return View(card);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteCard(int id)
        {
            Card? card = _context.Cards.FirstOrDefault(c => c.Id == id);

            if (card is null)
                return NotFound();
            _context.Cards.Remove(card);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            Card? card = _context.Cards.FirstOrDefault(c => c.Id == id);

            if (card is null)
                return NotFound();

            return View(card);
        }

        [HttpPost]
        public IActionResult Update(Card card, int id)
        {
            Card? upCard = _context.Cards.AsNoTracking().FirstOrDefault(c => c.Id == id);

            if (card is null)
                return NotFound();

            _context.Cards.Update(card);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
