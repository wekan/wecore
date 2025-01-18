using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WeCore.Data;
using WeCore.Models;

namespace WeCore.Controllers
{
    [Authorize]
    public class BoardController : Controller
    {
        private readonly KanbanContext _context;

        public BoardController(KanbanContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var boards = await _context.Boards
                .Include(b => b.Columns)
                .ThenInclude(c => c.Cards)
                .ToListAsync();
            return View(boards);
        }

        public async Task<IActionResult> Details(int id)
        {
            var board = await _context.Boards
                .Include(b => b.Columns)
                .ThenInclude(c => c.Cards)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (board == null)
                return NotFound();

            return View(board);
        }
    }
}
