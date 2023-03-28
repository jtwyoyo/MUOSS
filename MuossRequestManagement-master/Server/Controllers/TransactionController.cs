using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestManagement.Shared;

namespace RequestManagement.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : Controller
    {
        // GET: TransactionController
        [HttpGet]
        public async Task<IEnumerable<Transaction>> Get()
        {

            return await Task.Run(() => new List<Transaction> {
        new Transaction { TransactionID = 1, StudentID = 12345, FullName = "John Doe", RequestDate = new DateTime(2023, 3, 6), Amount = 100.00, Status = "Pending"},
        new Transaction { TransactionID = 2, StudentID = 67890, FullName = "Jane Smith", RequestDate = new DateTime(2023, 3, 5), Amount = 50.00, Status = "Approved"},
        new Transaction { TransactionID = 3, StudentID = 24680, FullName = "Bob Johnson", RequestDate = new DateTime(2023, 3, 4), Amount = 75.00, Status = "Pending"},
        new Transaction { TransactionID = 4, StudentID = 13579, FullName = "Mary Lee", RequestDate = new DateTime(2023, 3, 3), Amount = 125.00, Status = "Approved"},
        new Transaction { TransactionID = 5, StudentID = 86420, FullName = "Alice Thompson", RequestDate = new DateTime(2023, 3, 2), Amount = 200.00, Status = "Pending"},
        new Transaction { TransactionID = 6, StudentID = 97531, FullName = "Tom Williams", RequestDate = new DateTime(2023, 3, 1), Amount = 150.00, Status = "Approved"},
        new Transaction { TransactionID = 7, StudentID = 23456, FullName = "Samantha Taylor", RequestDate = new DateTime(2023, 2, 28), Amount = 75.00, Status = "Pending"},
        new Transaction { TransactionID = 8, StudentID = 78901, FullName = "David Brown", RequestDate = new DateTime(2023, 2, 27), Amount = 125.00, Status = "Approved"},
        new Transaction { TransactionID = 9, StudentID = 13579, FullName = "Maria Rodriguez", RequestDate = new DateTime(2023, 2, 26), Amount = 100.00, Status = "Pending"},
        new Transaction { TransactionID = 10, StudentID = 24680, FullName = "Javier Gomez", RequestDate = new DateTime(2023, 2, 25), Amount = 50.00, Status = "Approved"},
        new Transaction { TransactionID = 11, StudentID = 67890, FullName = "Sophie Lee", RequestDate = new DateTime(2023, 2, 24), Amount = 75.00, Status = "Pending"},
        new Transaction { TransactionID = 12, StudentID = 12345, FullName = "William Johnson", RequestDate = new DateTime(2023, 2, 23), Amount = 125.00, Status = "Approved"},
        new Transaction { TransactionID = 13, StudentID = 97531, FullName = "Olivia Smith", RequestDate = new DateTime(2023, 2, 22), Amount = 200.00, Status = "Pending"},
        new Transaction { TransactionID = 14, StudentID = 86420, FullName = "Daniel White", RequestDate = new DateTime(2023, 2, 21), Amount = 150.00, Status = "Approved"},
        new Transaction { TransactionID = 15, StudentID = 23456, FullName = "Emily Brown", RequestDate = new DateTime(2023, 2, 20), Amount = 75.00, Status = "Pending"},
        new Transaction { TransactionID = 16, StudentID = 78901, FullName = "Jacob Davis", RequestDate = new DateTime(2023, 2, 19), Amount = 125.00, Status = "Approved"},
        new Transaction { TransactionID = 17, StudentID = 12345, FullName = "Isabella Garcia", RequestDate = new DateTime(2023, 2, 18), Amount = 100.00, Status = "Pending"},
        new Transaction { TransactionID = 18, StudentID = 13579, FullName = "Anthony Perez", RequestDate = new DateTime(2023, 2, 17), Amount = 50.00, Status = "Approved"},
        new Transaction { TransactionID = 19, StudentID = 67890, FullName = "Ava Hernandez", RequestDate = new DateTime(2023, 2, 16), Amount = 75.00, Status = "Pending"},
        new Transaction { TransactionID = 20, StudentID = 24680, FullName = "Ethan Kim", RequestDate = new DateTime(2023, 2, 15), Amount = 125.00, Status = "Approved"}
    });

        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
