using Bigon.Data;
using Bigon.Data.Repositories;
using Bigon.Infrastructure.Entites;
using Bigon.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BigonWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagController : Controller
    {
        private readonly ITagRepository _tagRepository;

        public TagController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public IActionResult Index()
        {

            var tags = _tagRepository.GetAll(c => c.DeletedBy == null);
            return View(tags);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Tag tag)
        {

            _tagRepository.Add(tag);
            _tagRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var dbTag = _tagRepository.Get(x => x.Id == id);

            if (dbTag == null) return NotFound();

            return View(dbTag);
        }

        [HttpPost]
        public IActionResult Edit(Tag tag)
        {
            _tagRepository.Add(tag);
            _tagRepository.Save();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var dbTag = _tagRepository.Get(x => x.Id == id);

            if (dbTag == null) return NotFound();

            return View(dbTag);
        }

        public IActionResult Remove(int id)
        {
            var dbTag = _tagRepository.Get(x => x.Id == id);
            _tagRepository.Remove(dbTag);
            _tagRepository.Save();

            var tags = _tagRepository.GetAll(c => c.DeletedBy == null);

            return PartialView("_Body", tags);
        }
    }
}
