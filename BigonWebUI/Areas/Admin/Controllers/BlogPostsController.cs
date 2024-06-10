using Bigon.Business.Modules.BlogPostModule.Commands.BlogPostAddCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace BigonWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogPostsController:Controller
    {
        private readonly IMediator mediator;

        public BlogPostsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(BlogPostAddRequest model)
        {
            await mediator.Send(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
