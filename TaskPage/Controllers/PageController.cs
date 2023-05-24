using System.Web.Mvc;
using TaskPage.Models;

namespace TaskPage.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult Index()
        {
            CRUD model = new CRUD();
            ModelState.Clear();
            return View(model.GetOrders());
        }
        public ActionResult Main()
        {
            return View();
        }
        // GET: Page/Details/5
        public ActionResult Details(int id)
        {
            CRUD obj = new CRUD();
            return View(obj.GetOrders().Find(model => model.Id == id));
        }

        // GET: Page/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(HomePage model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CRUD obj = new CRUD();
                    if (obj.InsertData(model))
                    {
                        ViewBag.Message = " Details Added Successfully";
                        ModelState.Clear();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // POST: Page/Create
        [HttpPost]
        public ActionResult Main(HomePage model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CRUD obj = new CRUD();
                    if (obj.InsertData(model))
                    {
                        ViewBag.Message = " Details Added Successfully";
                        ModelState.Clear();
                    }
                }

                if (model.EMail == null)
                {
                    return View();
                }

                return RedirectToAction("Thanks");
            }
            catch
            {
                return View();
            }
        }


        // GET: Page/Edit/5
        public ActionResult Edit(int id)
        {
            CRUD obj = new CRUD();
            return View(obj.GetOrders().Find(model => model.Id == id));
        }

        // POST: Page/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HomePage model)
        {
            try
            {
                CRUD obj = new CRUD();
                obj.UpdateData(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Page/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                CRUD obj = new CRUD();
                if (obj.DeleteData(id))
                {
                    ViewBag.AlertMsg = "Student Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Thanks()
        {
            return View();
        }

    }
}
