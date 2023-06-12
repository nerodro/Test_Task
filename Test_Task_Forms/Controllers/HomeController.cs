using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Test_Task_Forms.Models;

namespace Test_Task_Forms.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext _context;
        public HomeController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet]
        public void FindId(int? Id)
        {
            if (Id == null)
            {
                HttpNotFound();
            }
        }
        public IActionResult Index(string TrackNumber)
        {
            IQueryable<Form> forms = _context.Forms;
            if (!String.IsNullOrEmpty(TrackNumber))
            {
                forms = forms.Where(p => p.TrackNumber.Contains(TrackNumber));
            }
            FormListViewModel formListViewModel = new FormListViewModel
            {
                Form = forms.ToList(),
                TrackNumber = TrackNumber
            };
            return View(formListViewModel);
        }
        [HttpGet]
        public IActionResult Add_Form()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add_Form(Form form)
        {
            Random rnd = new Random();
            int a = rnd.Next(100, 999);
            int b = rnd.Next(10000, 99999);
            string c =  Convert.ToString(a) + " - " + Convert.ToString(b);
            Form forms = new Form
            {
                AddressFrom = form.AddressFrom,
                AddressTo = form.AddressTo,
                CityFrom = form.CityFrom,
                CityTo = form.CityTo,
                DateOfGet = form.DateOfGet,
                Weight = form.Weight,
                TrackNumber = form.TrackNumber = c,
            };
            _context.Forms.Add(form);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Details(int? Id)
        {
            Form form = _context.Forms.Find(Id);
            FindId(Id: Id);
            return View(form);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private void HttpNotFound()
        {
            throw new NotImplementedException();
        }
    }
}