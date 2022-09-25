using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmployeeContext _context;

        public HomeController(ILogger<HomeController> logger, EmployeeContext context)
        {
            _logger = logger;
            _context = context;    
        }

        public IActionResult Index()
        {
            var Dept = _context.Depts.ToList();
            return View(Dept);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            //ViewBag.Dept = _context.Depts.ToList();
            var Dept = _context.Depts.ToList();
            return View(Dept);
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();

                return RedirectToAction("index");
            }
            else
            {
                var Dept = _context.Depts.ToList();
                return View(Dept);
            }
        }
        public IActionResult Details(int deptid)
        {
            var DeptId = _context.Depts.Where(m => m.DeptId == deptid).FirstOrDefault().DeptId;
            var Member = _context.Employees.Where(m => m.DeptId == DeptId).ToList();
            return View(Member);
        }

        public IActionResult Edit(int id)
        {
            var Member = _context.Employees.Where(m=>m.Id == id).FirstOrDefault();
            var DeptList = _context.Depts.ToList();
            EditViewModel editViewModel = new EditViewModel
            {
                Id = Member.Id,
                Name = Member.Name,
                Sex = Member.Sex,
                Year = Member.Year,
                DeptId = Member.DeptId,
                FileData = Member.FileData,
                FileName = Member.FileName,
                DeptList = DeptList
            };
            return View(editViewModel);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            var Member = _context.Employees.SingleOrDefault(m => m.Id == employee.Id);
            if (Member != null)
            {
                _context.Entry(employee).State = EntityState.Modified;
                //_context.Employees.Attach(employee);
                _context.SaveChanges();
            }
            var Dept = _context.Depts.ToList();
            return View("index", Dept);
        }

       
        public IActionResult Delete(int id)
        {
            var Member = _context.Employees.SingleOrDefault(m=>m.Id == id);
            if(Member != null)
            {
                _context.Employees.Remove(Member);
                _context.SaveChanges();
            }
            var Dept = _context.Depts.ToList();
            return View("index", Dept);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}