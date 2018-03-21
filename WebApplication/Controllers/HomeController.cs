using PusherServer;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {

        private string app_id = "495978";
        private string key = "a5935c2b82279378ad4d";
        private string secret = "865ca4c795048d3d321c";
        private PusherOptions options = new PusherOptions
        {
            Cluster = "us2",
            Encrypted = true
        };

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(User user)
        {
            var pusher = new Pusher(
              app_id,
              key,
              secret,
              options);

            var result = await pusher.TriggerAsync(
              "chat",
              "conversation",
              new { User = user });

            return RedirectToAction("Index", "Home");
        }
    }
}
