using System;
using System.Web.Mvc;
using WorldWideWat.IffyLink.Models;
using WorldWideWat.IffyLink.Service;

namespace WorldWideWat.IffyLink.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILinkRepository _linkRepository;

        public HomeController(ILinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Iffify(IffifyModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _linkRepository.CreateLink(model.Link, model.Alias, DateTimeOffset.UtcNow.AddMinutes(10));

            var viewModel = new ShareViewModel
            {
                IffyLink = model.Link
            };

            return View("Share", viewModel);
        }
    }
}