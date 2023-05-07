namespace FrontToBack.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Card> cards = _context.Cards.ToList();
            List<Slider> sliders = _context.Sliders.ToList();

            HomeViewModel homeViewModels = new()
            {
                Sliders = sliders,
                Cards = cards
            };
          return View(homeViewModels);
        }
    }
}
