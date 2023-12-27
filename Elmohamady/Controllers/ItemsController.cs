using Microsoft.AspNetCore.Mvc;
using Elmohamady.Data;
using Elmohamady.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.AspNetCore.Authorization;

namespace Elmohamady.Controllers
{
    [Authorize]

    public class ItemsController : Controller
        
    {
        public ItemsController(AppDbContext db ,IHostingEnvironment host)
        {
            _db = db;
            _host = host;

        }
        private readonly IHostingEnvironment _host;

        private readonly AppDbContext _db;
        public IActionResult Index()
        {
            IEnumerable<Item> itemlist = _db.items.Include(n => n.Category).ToList();
            return View(itemlist);
        }
        //get
        public IActionResult New()
        {
            createSelectList();
            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Item item)
        {
            if (ModelState.IsValid)
            {
                /* image*/
                string fileName = Guid.NewGuid().ToString();
                if (item.clientFile != null)
                {
                    string myUpload = Path.Combine(_host.WebRootPath, "images");
                    // fileName = item.clientFile.FileName;
                    fileName += Path.GetExtension(item.clientFile.FileName);
                    string fullPath = Path.Combine(myUpload, fileName);
                    item.clientFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                    item.imagePath = fileName;

                    
                }
                /* endimage*/

                _db.items.Add(item);
                _db.SaveChanges();
                TempData["successData"] = "Item has been added successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }
        }

        public void createSelectList(int selectId = 1)
        {
            //List<Category> categories = new List<Category> {
            //  new Category() {Id = 1, Name = "Select Category"},
            //  new Category() {Id = 2, Name = "Computers"},
            //  new Category() {Id = 3, Name = "Mobiles"},
            //  new Category() {Id = 4, Name = "Electric machines"},
            //};
            List<Category> categories = _db.Categories.ToList();
            SelectList listItems = new SelectList(categories, "Id", "Name", selectId);
            ViewBag.CategoryList = listItems;
        }
        //get
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var item = _db.items.Find(Id);
            if (item == null)
            {
                return NotFound();
            }
            
            createSelectList(item.CategoryId);
            return View(item);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item item)
        {
            if (item.Name == "100")
            {
                ModelState.AddModelError("Name", "Name can't equal 100");
            }
            if (ModelState.IsValid)
            {


                /* image*/
                string fileName = Guid.NewGuid().ToString();
                if (item.clientFile != null)
                {
                    string myUpload = Path.Combine(_host.WebRootPath, "images");
                    //fileName = item.clientFile.FileName;
                    fileName += Path.GetExtension(item.clientFile.FileName);
                    string fullPath = Path.Combine(myUpload, fileName);
                    item.clientFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                    item.imagePath = fileName;

                }
                /* endimage*/

                _db.items.Update(item);
                _db.SaveChanges();
                TempData["successData"] = "Item has been updated successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deleteitem(int?id)
        {
            var item = _db.items.Find(id);
            if (item == null)
            {
                return NotFound();
                
            }

                _db.items.Remove(item);
                _db.SaveChanges();
                return RedirectToAction("Index");    

        }

        //GET
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var item = _db.items.Find(Id);
            if (item == null)
            {
                return NotFound();
            }
            createSelectList(item.CategoryId);
            return View(item);
        }


    }
}
