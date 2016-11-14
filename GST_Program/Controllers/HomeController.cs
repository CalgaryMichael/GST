using System.Web.Mvc;
using GST_Program.Domain.Services;
using GST_Program.Models;

namespace GST_Program.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var service = new GstService(SystemContext.GstConnectionString);

            service.CreateDatabase(SystemContext.MasterConnectionString);
            service.CreateTables();
            service.InsertDummyData();

            return RedirectToAction("Index", "Admin");
        }
    }
}